using System.Collections.Generic;

namespace Byter
{
    public partial class Primitive : IPrimitive
    {
        private static readonly IPrimitivePrefix Prefix;
        private readonly List<byte> _bytes;

        static Primitive()
        {
            Prefix = new PrimitivePrefix();
        }

        public Primitive() : this(null)
        {
        }

        public Primitive(byte[] data)
        {
            Get = new PrimitiveGet(this);
            Add = new PrimitiveAdd(this);

            IsValid = true;

            _bytes = new List<byte>();

            if (data != null && data.Length > 0) _bytes.AddRange(data);
        }

        public int Position { get; private set; }
        public bool IsValid { get; private set; }
        public byte[] Data => _bytes.ToArray();
        public IPrimitiveAdd Add { get; }
        public IPrimitiveGet Get { get; }
    }
}