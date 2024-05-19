using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Byter
{
    public partial class Primitive
    {
        private class PrimitiveGet : IPrimitiveGet
        {
            private readonly Primitive _primitive;

            private bool IsValid
            {
                get => _primitive.IsValid;
                set => _primitive.IsValid = value;
            }

            private List<byte> Vault => _primitive._bytes;
            private byte[] VaultArray => _primitive._bytes.ToArray();

            private int Position
            {
                get => _primitive.Position;
                set => _primitive.Position = value;
            }

            public PrimitiveGet(Primitive primitive)
            {
                _primitive = primitive;
            }

            private bool IsValidPrefix(byte prefix)
            {
                bool value = prefix == Vault[Position];
                if (value) Position += sizeof(byte);
                return value;
            }

            private T SetError<T>()
            {
                IsValid = false;
                return default;
            }

            public bool Bool()
            {
                try
                {
                    if (!IsValidPrefix(Prefix.Bool)) throw new InvalidDataException();

                    bool value = BitConverter.ToBoolean(VaultArray, Position);

                    Position += sizeof(bool);

                    return value;
                }
                catch
                {
                    return SetError<bool>();
                }
            }

            public byte Byte()
            {
                throw new NotImplementedException();
            }

            public sbyte SByte()
            {
                throw new NotImplementedException();
            }

            public char Char()
            {
                throw new NotImplementedException();
            }

            public short Short()
            {
                throw new NotImplementedException();
            }

            public ushort UShort()
            {
                throw new NotImplementedException();
            }

            public int Int()
            {
                throw new NotImplementedException();
            }

            public uint UInt()
            {
                throw new NotImplementedException();
            }

            public float Float()
            {
                throw new NotImplementedException();
            }

            public Enum Enum()
            {
                throw new NotImplementedException();
            }

            public long Long()
            {
                throw new NotImplementedException();
            }

            public ulong ULong()
            {
                throw new NotImplementedException();
            }

            public double Double()
            {
                throw new NotImplementedException();
            }

            public DateTime DateTime()
            {
                throw new NotImplementedException();
            }

            public decimal Decimal()
            {
                throw new NotImplementedException();
            }

            public string String()
            {
                throw new NotImplementedException();
            }

            public T Class<T>()
            {
                throw new NotImplementedException();
            }

            public T Struct<T>()
            {
                throw new NotImplementedException();
            }

            public IList<T> Array<T>()
            {
                throw new NotImplementedException();
            }

            public List<T> List<T>()
            {
                throw new NotImplementedException();
            }

            public BigInteger BigInteger()
            {
                throw new NotImplementedException();
            }
        }
    }
}