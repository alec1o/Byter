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

        // 4 bytes (4) + (1) Overhead
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

        // dynamic (7)
        string String();
        T Class<T>();
        T Struct<T>();
        T[] Array<T>();
        List<T> List<T>();
        BigInteger BigInteger();
        byte[] Bytes();
        
        // overhead
        object Enum(Type type);
        object List(Type type);
        object Class(Type type);
        object Array(Type type);
        object Struct(Type type);
    }
}