using ProtocolsInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolModbus
{
    public class ChannelInfo
    {
        public int ChannelId { get; set; }
        public UInt16 RegisterAddress { get; set; }
        public RegisterValueType ValueType { get; set; }
    }
}
