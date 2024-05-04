using System.Numerics;

namespace Byter
{
    public partial class By : IBy
    {
        static By()
        {
            Types = new[]
            {
                // 1 byte
                typeof(sbyte),
                typeof(byte),
                typeof(bool),

                // 2 bytes
                typeof(char),
                typeof(short),
                typeof(ushort),

                // 4 bytes
                typeof(uint),
                typeof(int),
                typeof(float),

                // 8 bytes
                typeof(long),
                typeof(ulong),
                typeof(double),

                // 16 bytes
                typeof(decimal),

                // dynamic
                typeof(byte[]),
                typeof(string),
                typeof(BigInteger)
            };
        }
    }
}