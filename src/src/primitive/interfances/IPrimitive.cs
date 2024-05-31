using System.Collections.Generic;

namespace Byter
{
    internal interface IPrimitive
    {
        long Position { get; }
        bool IsValid { get; }
        IPrimitiveAdd Add { get; }
        IPrimitiveGet Get { get; }
        void Reset(byte[] data = null);
        byte[] GetBytes();
        List<byte> GetList();
    }
}