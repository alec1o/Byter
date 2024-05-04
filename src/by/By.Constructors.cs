using System;
using System.Collections.Generic;

namespace Byter
{
    public partial class By : IBy
    {
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
    }
}