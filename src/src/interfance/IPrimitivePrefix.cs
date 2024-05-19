namespace Byter
{
    internal interface IPrimitivePrefix
    {
        // 1 byte (3)
        byte Bool { get; }
        byte Byte { get; }
        byte SByte { get; }

        // 2 bytes (3)
        byte Char { get; }
        byte Short { get; }
        byte UShort { get; }

        // 4 bytes (4)
        byte Int { get; }
        byte UInt { get; }
        byte Float { get; }
        byte Enum { get; }

        // 8 bytes (4)
        byte Long { get; }
        byte ULong { get; }
        byte Double { get; }
        byte DateTime { get; }

        // 16 bytes (1)
        byte Decimal { get; }

        // dynamic (6)
        byte String { get; }
        byte Class { get; }
        byte Struct { get; }
        byte Array { get; }
        byte List { get; }
        byte BigInteger { get; }
        byte Bytes { get; }
    }
}