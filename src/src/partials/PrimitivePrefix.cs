namespace Byter
{
    public partial class Primitive
    {
        private sealed class PrimitivePrefix : IPrimitivePrefix
        {
            public byte Bool { get; } = 247;
            public byte Byte { get; } = 237;
            public byte SByteInt { get; } = 227;
            public byte Char { get; } = 217;
            public byte Short { get; } = 207;
            public byte UShort { get; } = 197;
            public byte Int { get; } = 187;
            public byte UInt { get; } = 177;
            public byte Float { get; } = 167;
            public byte Enum { get; } = 157;
            public byte Long { get; } = 147;
            public byte ULong { get; } = 137;
            public byte Double { get; } = 127;
            public byte DateTime { get; } = 117;
            public byte Decimal { get; } = 107;
            public byte String { get; } = 97;
            public byte Class { get; } = 87;
            public byte Struct { get; } = 77;
            public byte Array { get; } = 67;
            public byte List { get; } = 57;
            public byte BigInteger { get; } = 47;
        }
    }
}