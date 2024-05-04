using System;
using System.Collections.Generic;
using System.Numerics;

namespace Byter
{
    public class By : IBy
    {
        public static readonly Type[] Types;
        public int Index { get; private set; }
        public bool IsValid { get; private set; }
        public byte[] Buffer => _vault.ToArray();
        private readonly List<byte> _vault;

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

        private By(int index, bool isValid, byte[] buffer)
        {
            _vault = new List<byte>();
            _vault.AddRange(buffer);
            Index = index;
            IsValid = isValid;
        }

        public By() : this(Array.Empty<byte>())
        {
        }

        public By(byte[] buffer) : this(0, true, buffer)
        {
        }

        public void Reset()
        {
            Index = 0;
            IsValid = true;
        }

        public void Add<T>(T value)
        {
            throw new System.NotImplementedException();
        }

        public T Get<T>()
        {
            throw new System.NotImplementedException();
        }
    }
}