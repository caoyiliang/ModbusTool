using System;

namespace ProtocolModbus
{
    public class WBlockInfo
    {
        public UInt16 RegisterAddress { get; set; }
        public byte[] Data { get; set; }
    }
}