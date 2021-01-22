using Parser;
using ProtocolsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopPortLib.Interfaces;

namespace ProtocolModbus
{
    public class ProtocolModbus : IProtocol, IGetChannelValue
    {
        public string Name => "ModbusRTU";

        public ParerType ParerType => ParerType.Time;

        public ProtocolType ProtocolType => ProtocolType.Modbus485;

        public byte[] Head { get; set; }
        public byte[] Foot { get; set; }
        public GetDataLengthEventHandler GetDataLength { get; set; }

        public List<BlockInfo> BlockInfos { get; set; } = new List<BlockInfo>();

        public bool IsHighByteBefore { get; set; }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            var t = obj as ProtocolModbus;
            if (t is null) return false;
            return t.Name == this.Name;
        }
        public override string ToString()
        {
            return Name;
        }

        public async Task<GetChannelValueRsp> GetSignalValueAsync(ICrowPort crowPort, string address)
        {
            byte addressByte = Convert.ToByte(address);
            var result = new GetChannelValueRsp()
            {
                RecData = new List<ChannelRspValue>()
            };
            var list = new List<ChannelRspValue>();
            foreach (var block in BlockInfos)
            {
                UInt16 registerAddress = block.StartRegisterAddress;
                UInt16 registerCount = (UInt16)(block.EndRegisterAddress - block.StartRegisterAddress + 1);
                var req = new GetSignalValueReq(addressByte, registerAddress, registerCount);
                var rsp = await crowPort.RequestAsync(req, new Func<byte[], GetSignalValueRsp>(rspByte => new GetSignalValueRsp(block.StartRegisterAddress, rspByte, block.ChannelInfos, IsHighByteBefore)));
                if (!rsp.Success)
                {
                    return new GetChannelValueRsp()
                    {
                        Message = rsp.Message,
                        Success = false
                    };
                }
                list.AddRange(rsp.RecData);
            }
            return new GetChannelValueRsp()
            {
                Success = true,
                RecData = list,
            };
        }

        public async Task<GetChannelValueRsp> GetSignalValueAsync(ICrowPort crowPort, string address, BlockInfo block)
        {
            byte addressByte = Convert.ToByte(address);
            var result = new GetChannelValueRsp()
            {
                RecData = new List<ChannelRspValue>()
            };
            var list = new List<ChannelRspValue>();

            UInt16 registerAddress = block.StartRegisterAddress;
            UInt16 registerCount = (UInt16)(block.EndRegisterAddress - block.StartRegisterAddress + 1);
            var req = new GetSignalValueReq(addressByte, registerAddress, registerCount);
            var rsp = await crowPort.RequestAsync(req, new Func<byte[], GetSignalValueRsp>(rspByte => new GetSignalValueRsp(block.StartRegisterAddress, rspByte, block.ChannelInfos, IsHighByteBefore)));
            if (!rsp.Success)
            {
                return new GetChannelValueRsp()
                {
                    Message = rsp.Message,
                    Success = false
                };
            }
            list.AddRange(rsp.RecData);

            return new GetChannelValueRsp()
            {
                Success = true,
                RecData = list,
            };
        }

        public async Task SetSignalValueAsync(ICrowPort crowPort, string address, List<WBlockInfo> ts)
        {
            byte addressByte = Convert.ToByte(address);
            foreach (var item in ts)
            {
                var req = new SetSignalValueReq(addressByte, item.RegisterAddress, item.Data);
                try
                {
                    var rsp = await crowPort.RequestAsync(req, new Func<byte[], SetSignalValueRsp>(rspByte => new SetSignalValueRsp(rspByte)));
                    if (!rsp.Success) throw new Exception($"{item.RegisterAddress}返回：设置失败");
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
