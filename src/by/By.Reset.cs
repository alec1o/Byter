using System;
using System.Collections.Generic;
using System.Linq;

namespace Byter
{
    public partial class By : IBy
    {
        public void Reset()
        {
            InternalReset(Array.Empty<byte>());
        }

        public void Reset(byte[] buffer)
        {
            InternalReset((buffer == null || buffer.Length <= 0) ? Array.Empty<byte>() : buffer.ToArray());
        }

        public void Reset(List<byte> buffer)
        {
            InternalReset((buffer == null || buffer.Count <= 0) ? Array.Empty<byte>() : buffer.ToArray());
        }

        private void InternalReset(byte[] buffer)
        {
            Index = 0;
            IsValid = true;
            _vault.Clear();

            if (buffer != null && buffer.Length >= 1)
            {
                _vault.AddRange(buffer);
            }
        }
    }
}