using System;
using System.Collections.Generic;

namespace Byter
{
    public partial class By : IBy
    {
        private readonly List<byte> _vault;
        public int Index { get; private set; }
        public bool IsValid { get; private set; }
        public byte[] Buffer => _vault.ToArray();
    }
}