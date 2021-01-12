using System;

namespace ProtocolsInterface
{
    public interface IProtocolComponent
    {
        string Name { get; }
        UInt16 RegisterAddress { get; }
        RegisterValueType ValueType { get; }
    }

    public enum RegisterValueType
    {
        FloatType, UInt16Type, UInt32Type
    }
}