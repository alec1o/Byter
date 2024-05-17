using System;
using System.Collections.Generic;

namespace Byter
{
    public partial class Pot : IPot
    {
        private readonly List<byte> _bytes;
        public bool IsValid { get; }
        public byte[] Data => _bytes.ToArray();
        public IPotAdd Add { get; }
        public IPotGet Get { get; }

        public Pot() : this(null)
        {
        }

        public Pot(byte[] data)
        {
            Get = new PotGet(this);
            Add = new PotAdd(this);
            
            IsValid = false;
            
            _bytes = new List<byte>();

            if (data != null && data.Length > 0)
            {
                _bytes.AddRange(data);
            }
        }
    }
}