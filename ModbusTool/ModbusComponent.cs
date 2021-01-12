using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusTool
{
    public partial class ModbusComponent : UserControl
    {
        public event EventHandler ReadEvent;
        public event EventHandler WriteEvent;

        [Category("数据"), Description("变量值"), Browsable(true)]
        public string Value { get => tbValue.Text; set => tbValue.Text = value; }

        public ModbusComponent(string Name)
        {
            InitializeComponent();
            this.Name = Name;
            groupBox.Text = Name;
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            ReadEvent?.Invoke(this.Name, null);
        }

        private void btnW_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbValue.Text)) return;
            WriteEvent?.Invoke(this.Name, new WriteEventArgs() { Value = tbValue.Text });
        }

        internal void Read()
        {
            btnR.PerformClick();
        }

        internal void Write()
        {
            btnW.PerformClick();
        }
    }

    public class WriteEventArgs : EventArgs
    {
        public string Value { get; set; }
    }
}
