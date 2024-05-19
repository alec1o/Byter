using System;
using System.Collections.Generic;
using System.Numerics;

namespace Byter
{
    public interface IPrimitiveGet
    {
        // 1 byte (3)
        bool Bool();
        byte Byte();
        sbyte SByte();

        // 2 bytes (3)
        char Char();
        short Short();
        ushort UShort();

        // 4 bytes (4)
        int Int();
        uint UInt();
        float Float();
        T Enum<T>();

        // 8 bytes (4)
        long Long();
        ulong ULong();
        double Double();
        DateTime DateTime();

        // 16 bytes (1)
        decimal Decimal();

        // dynamic (6)
        string String();
        T Class<T>();
        T Struct<T>();
        T[] Array<T>();
        List<T> List<T>();
        BigInteger BigInteger();
        byte[] Bytes();
    }
}