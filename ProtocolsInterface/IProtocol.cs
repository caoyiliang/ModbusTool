using Parser;
using System;

namespace ProtocolsInterface
{
    public interface IProtocol
    {
        string Name { get; }
        ParerType ParerType { get; }
        ProtocolType ProtocolType { get; }
        byte[] Head { get; set; }
        byte[] Foot { get; set; }
        GetDataLengthEventHandler GetDataLength { get; set; }
    }
}
