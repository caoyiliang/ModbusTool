using ProtocolModbus;
using ProtocolsInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopPortLib.Interfaces;

namespace ModbusTool.Protocol
{
    class DWProtocol
    {
        IProtocol _protocol;
        ICrowPort _crowPort;
        string _address;
        List<ProtocolComponent> _ADWProtocols = new List<ProtocolComponent>();
        Dictionary<string, BlockInfo> ADWProtocols = new Dictionary<string, BlockInfo>();
        public DWProtocol(string addr, ICrowPort crowPort, List<ProtocolComponent> protocols)
        {
            _ADWProtocols = protocols;
            _protocol = new ProtocolModbus.ProtocolModbus();
            _crowPort = crowPort;
            _address = addr;

            for (int i = 0; i < _ADWProtocols.Count; i++)
            {
                UInt16 END = _ADWProtocols[i].RegisterAddress;
                switch (_ADWProtocols[i].ValueType)
                {
                    case RegisterValueType.FloatType:
                    case RegisterValueType.UInt32Type:
                        END++;
                        break;
                    case RegisterValueType.UInt16Type:
                        break;
                    case RegisterValueType.ASCIIType:
                        END += 4;
                        break;
                    default:
                        break;
                }
                var block = new BlockInfo()
                {
                    StartRegisterAddress = _ADWProtocols[i].RegisterAddress,
                    EndRegisterAddress = END,
                    ChannelInfos = new List<ChannelInfo>()
                    {
                        new ChannelInfo()
                        {
                            ChannelId=i,
                            RegisterAddress=_ADWProtocols[i].RegisterAddress,
                            ValueType=_ADWProtocols[i].ValueType
                        }
                    }
                };
                ADWProtocols.Add(_ADWProtocols[i].Name, block);
                (_protocol as ProtocolModbus.ProtocolModbus).BlockInfos.Add(block);
            }
        }

        public async Task<string> GetValueAsync(string block)
        {
            try
            {
                var task = await (_protocol as ProtocolModbus.ProtocolModbus).GetSignalValueAsync(_crowPort, _address, ADWProtocols[block]);
                return task.RecData[0].Value;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SetValueAsync(Dictionary<string, string> block)
        {
            var ts = new List<WBlockInfo>();
            foreach (var item in block)
            {
                var temp = ADWProtocols[item.Key].ChannelInfos[0];
                byte[] data = new byte[0];
                switch (temp.ValueType)
                {
                    case RegisterValueType.FloatType:
                        {
                            if (float.TryParse(item.Value, out var number))
                            {
                                data = Utils.StringByteUtils.GetBytes(number);
                            }
                            else
                            {
                                throw new Exception($"{item.Key}数据类型错误");
                            }
                        }
                        break;
                    case RegisterValueType.UInt16Type:
                        {
                            if (UInt16.TryParse(item.Value, out var number))
                            {
                                data = Utils.StringByteUtils.GetBytes(number);
                            }
                            else
                            {
                                throw new Exception($"{item.Key}数据类型错误");
                            }
                        }
                        break;
                    case RegisterValueType.UInt32Type:
                        {
                            if (UInt32.TryParse(item.Value, out var number))
                            {
                                data = Utils.StringByteUtils.GetBytes(number);
                            }
                            else
                            {
                                throw new Exception($"{item.Key}数据类型错误");
                            }
                        }
                        break;
                    case RegisterValueType.ASCIIType:
                        {
                            data = Encoding.ASCII.GetBytes(item.Value);
                        }
                        break;
                    default:
                        throw new Exception("数据类型错误");
                }
                ts.Add(new WBlockInfo() { RegisterAddress = temp.RegisterAddress, Data = data });
            }
            try
            {
                await (_protocol as ProtocolModbus.ProtocolModbus).SetSignalValueAsync(_crowPort, _address, ts);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
