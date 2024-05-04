using System;
using System.Collections.Generic;

namespace Byter
{
    public partial class By : IBy
    {
        public static readonly Type[] Types;
        private readonly List<byte> _vault;
        public int Index { get; private set; }
        public bool IsValid { get; private set; }
        public byte[] Buffer => _vault.ToArray();
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