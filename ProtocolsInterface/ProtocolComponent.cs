using DataPairs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolsInterface
{
    public class ProtocolComponent : IProtocolComponent
    {
        [SavePirvateProperty]
        public string Name { get; private set; }

        [SavePirvateProperty]
        public ushort RegisterAddress { get; private set; }

        [SavePirvateProperty]
        public RegisterValueType ValueType { get; private set; }
    }
}
