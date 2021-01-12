using Communication.Bus.PhysicalPort;
using ModbusTool.Protocol;
using LogInterface;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TopPortLib;
using TopPortLib.Interfaces;

namespace ModbusTool
{
    public partial class Main : Form
    {
        private static readonly ILogger _logger = Logs.LogFactory.GetLogger<Main>();
        ICrowPort _crowPort;
        DWProtocol _DWProtocol;
        private TaskCompletionSource<bool> _ok;
        public Main()
        {
            InitializeComponent();
            var portName = ConfigurationManager.AppSettings["portName"];
            var baudRate = ConfigurationManager.AppSettings["baudRate"];
            _crowPort = new CrowPort(new TopPort(new SerialPort(portName, int.Parse(baudRate)), new Parser.Parsers.TimeParser(50)));
            _crowPort.OnSentData += _crowPort_OnSentData;
            _crowPort.OnReceivedData += _crowPort_OnReceivedData;
        }

        private async Task _crowPort_OnReceivedData(byte[] data)
        {
            _logger.Trace($"Received: {Utils.StringByteUtils.BytesToString(data)}");
        }

        private async Task _crowPort_OnSentData(byte[] data)
        {
            _logger.Trace($"Sent: {Utils.StringByteUtils.BytesToString(data)}");
        }

        private async void Main_LoadAsync(object sender, EventArgs e)
        {
            try
            {
                await _crowPort.OpenAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("串口打开失败，请检查后重新打开软件");
                Environment.Exit(0);
            }

            var protocolConfig = await ProtocolConfig.GetValueAsync();

            foreach (var item in protocolConfig.Protocols)
            {
                var modbusComponent = new ModbusComponent(item.Name);
                modbusComponent.ReadEvent += ModbusComponent_ReadEventAsync;
                modbusComponent.WriteEvent += ModbusComponent_WriteEventAsync;
                flowLayoutPanel.Controls.Add(modbusComponent);
            }

            var addr = ConfigurationManager.AppSettings["addr"];
            _DWProtocol = new DWProtocol(addr, _crowPort, protocolConfig.Protocols);
        }

        private async void ModbusComponent_WriteEventAsync(object sender, EventArgs e)
        {
            var name = sender.ToString();
            Dictionary<string, string> pairs = new Dictionary<string, string>()
            {
                {name, (e as WriteEventArgs).Value}
            };
            try
            {
                await _DWProtocol.SetValueAsync(pairs);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"获取失败\n{ex}");
            }
            finally
            {
                _ok?.TrySetResult(true);
            }
        }

        private async void ModbusComponent_ReadEventAsync(object sender, EventArgs e)
        {
            try
            {
                var name = sender.ToString();
                var value = await _DWProtocol.GetValueAsync(name);
                ((ModbusComponent)Controls.Find($"{name}", true)[0]).Value = value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"获取失败\n{ex}");
            }
            finally
            {
                _ok?.TrySetResult(true);
            }
        }

        private async void btnOneR_Click(object sender, EventArgs e)
        {
            btnOneW.Enabled = false;
            foreach (var item in flowLayoutPanel.Controls)
            {
                if (item is ModbusComponent)
                {
                    var component = item as ModbusComponent;
                    _ok = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                    component.Read();
                    await _ok.Task;
                }
            }
            btnOneW.Enabled = true;
        }

        private async void btnOneW_Click(object sender, EventArgs e)
        {
            btnOneR.Enabled = false;
            foreach (var item in flowLayoutPanel.Controls)
            {
                if (item is ModbusComponent)
                {
                    var component = item as ModbusComponent;
                    _ok = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                    component.Write();
                    await _ok.Task;
                }
            }
            btnOneR.Enabled = true;
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            IWorkbook workbook = new XSSFWorkbook();

            ISheet sheet = workbook.CreateSheet("DWBook");

            for (int i = 0; i < flowLayoutPanel.Controls.Count; i++)
            {
                var component = flowLayoutPanel.Controls[i] as ModbusComponent;
                sheet.CreateRow(i).CreateCell(0).SetCellValue(component.Name);
                sheet.GetRow(i).CreateCell(1).SetCellValue(component.Value);
            }
            FileStream sw = File.Create("Protocol.xlsx");
            workbook.Write(sw);
            sw.Close();
            MessageBox.Show("秒导完成");
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            using (var fs = File.OpenRead("Protocol.xlsx"))
            {
                var workbook = new XSSFWorkbook(fs);
                if (workbook != null)
                {
                    var sheet = workbook.GetSheetAt(0);
                    if (sheet != null)
                    {
                        var rowCount = sheet.LastRowNum;
                        for (int i = 0; i < rowCount; i++)
                        {
                            (flowLayoutPanel.Controls.Find($"{sheet.GetRow(i).GetCell(0).StringCellValue}", false)[0] as ModbusComponent).Value = sheet.GetRow(i).GetCell(1).StringCellValue;
                        }
                        MessageBox.Show("秒导完成");
                    }
                }
            }
        }
    }
}
