using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolModbus
{
    public class BlockInfo
    {
        public UInt16 StartRegisterAddress { get; set; }
        public UInt16 EndRegisterAddress { get; set; }
        public List<ChannelInfo> ChannelInfos { get; set; }
        public BlockInfo()
        {
            ChannelInfos = new List<ChannelInfo>();
        }
    }
}
