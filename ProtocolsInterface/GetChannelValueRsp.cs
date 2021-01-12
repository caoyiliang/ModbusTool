using CommonDatatypes;
using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace ProtocolsInterface
{
    public class GetChannelValueRsp
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public List<ChannelRspValue> RecData { get; set; }

        public override string ToString()
        {
            return Message;
        }
    }
}
