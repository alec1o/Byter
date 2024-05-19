using System;
using System.Collections.Generic;
using System.Numerics;

namespace Byter
{
    public partial class Primitive
    {
        private class PrimitiveGet : IPrimitiveGet
        {
            private Primitive _primitive;
            public PrimitiveGet(Primitive primitive)
            {
                _primitive = primitive;
            }

            public bool Bool()
            {
                throw new NotImplementedException();
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