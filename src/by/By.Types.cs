using System.Numerics;

namespace Byter
{
    public partial class By : IBy
    {
        enum Types
        {
            // 1 byte
            Sbyte,
            Byte,
            Bool,

            // 2 bytes
            Char,
            Short,
            Ushort,

            // 4 bytes
            Uint,
            Int,
            Float,
            Enum,

            // 8 bytes
            Long,
            Ulong,
            Double,

            // 16 bytes
            Decimal,

            // dynamic
            Bytes,
            String,
            BigInteger,

            // Symbols
            Class,
            Struct,
            Array,
        };
    }
}