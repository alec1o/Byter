using System;
using System.Collections.Generic;

namespace Byter
{
    public partial class Vault : IVault
    {
        private readonly List<byte> _bytes;
        public bool IsValid { get; }
        public byte[] Data => _bytes.ToArray();
        public IVaultAdd Add { get; }
        public IVaultGet Get { get; }

        public Vault() : this(null)
        {
        }

        public Vault(byte[] data)
        {
            Get = new VaultGet(this);
            Add = new VaultAdd(this);
            
            IsValid = false;
            
            _bytes = new List<byte>();

            if (data != null && data.Length > 0)
            {
                _bytes.AddRange(data);
            }
        }
    }
}