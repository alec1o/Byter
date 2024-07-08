using System.Collections.Generic;

namespace Byter
{
    public partial class Primitive : IPrimitive
    {
        private static readonly IPrimitivePrefix Prefix;
        private readonly List<byte> _bytes = new List<byte>();
        private readonly byte[] _nullPrefix = { 0, 9 }; // 0 mean begin - 9 mean end. (from begin to end)

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
            Reset(data);
        }

        public long Position { get; private set; }
        public bool IsValid { get; private set; }
        internal byte[] Data => _bytes.ToArray();
        public IPrimitiveAdd Add { get; }
        public IPrimitiveGet Get { get; }

        public void Reset(byte[] data = null)
        {
            Position = 0;
            _bytes.Clear();
            IsValid = true;
            if (data != null && data.Length > 0) _bytes.AddRange(data);
        }

        public byte[] GetBytes()
        {
            return Data;
        }

        public List<byte> GetList()
        {
            return _bytes;
        }
    }
}