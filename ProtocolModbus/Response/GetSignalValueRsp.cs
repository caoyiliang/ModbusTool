using CommonDatatypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolsInterface;

namespace ProtocolModbus
{
    internal class GetSignalValueRsp
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public List<ChannelRspValue> RecData { get; set; }

        public GetSignalValueRsp(UInt16 startAddress, byte[] rspBytes, List<ChannelInfo> channelInfos, bool isHighByteBefore = false)
        {
            if (rspBytes.Length < 3)
            {
                Success = false;
                Message = "长度不够";
                return;
            }
            var crc = Utils.CRC.Crc16(rspBytes, rspBytes.Length - 2);
            if (!(crc[0] == rspBytes[rspBytes.Length - 2] && crc[1] == rspBytes[rspBytes.Length - 1]))
            {
                Success = false;
                Message = "CRC校验失败";
                return;
            }
            Success = true;
            RecData = new List<ChannelRspValue>();
            foreach (var channelInfo in channelInfos)
            {
                var index = (channelInfo.RegisterAddress - startAddress) * 2 + 3;
                decimal value;
                switch (channelInfo.ValueType)
                {
                    case RegisterValueType.FloatType:
                        value = Convert.ToDecimal(Utils.StringByteUtils.ToSingle(rspBytes, index, isHighByteBefore));
                        break;
                    case RegisterValueType.UInt16Type:
                        value = Convert.ToDecimal(Utils.StringByteUtils.ToUInt16(rspBytes, index, isHighByteBefore));
                        break;
                    case RegisterValueType.UInt32Type:
                        value = Convert.ToDecimal(Utils.StringByteUtils.ToUInt32(rspBytes, index, isHighByteBefore));
                        break;
                    default:
                        throw new ArgumentException();
                }
                RecData.Add(new ChannelRspValue()
                {
                    ChannelId = channelInfo.ChannelId,
                    Value = value
                });
            }
        }
    }
}
