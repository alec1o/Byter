using System;
using System.Collections.Generic;

namespace Byter
{
    public class By : IBy
    {
        public int Index { get; private set; }
        public bool IsValid { get; private set; }
        public byte[] Buffer => _vault.ToArray();
        private readonly List<byte> _vault;

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