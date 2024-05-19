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
                try
                {
                    if (!IsValidPrefix(Prefix.Byte)) throw new InvalidDataException();

                    byte value = Vault[Position];

                    Position += sizeof(byte);

                    return value;
                }
                catch
                {
                    return SetError<byte>();
                }
            }

            public sbyte SByte()
            {
                try
                {
                    if (!IsValidPrefix(Prefix.SByte)) throw new InvalidDataException();

                    sbyte value = (sbyte)Vault[Position];

                    Position += sizeof(sbyte);

                    return value;
                }
                catch
                {
                    return SetError<sbyte>();
                }
            }

            public char Char()
            {
                try
                {
                    if (!IsValidPrefix(Prefix.Char)) throw new InvalidDataException();

                    char value = BitConverter.ToChar(VaultArray, Position);

                    Position += sizeof(char);

                    return value;
                }
                catch
                {
                    return SetError<char>();
                }
            }

            public short Short()
            {
                try
                {
                    if (!IsValidPrefix(Prefix.Short)) throw new InvalidDataException();

                    short value = BitConverter.ToInt16(VaultArray, Position);

                    Position += sizeof(short);

                    return value;
                }
                catch
                {
                    return SetError<short>();
                }
            }

            public ushort UShort()
            {
                try
                {
                    if (!IsValidPrefix(Prefix.UShort)) throw new InvalidDataException();

                    ushort value = BitConverter.ToUInt16(VaultArray, Position);

                    Position += sizeof(ushort);

                    return value;
                }
                catch
                {
                    return SetError<ushort>();
                }
            }

            public int Int()
            {
                try
                {
                    if (!IsValidPrefix(Prefix.Int)) throw new InvalidDataException();

                    int value = BitConverter.ToInt32(VaultArray, Position);

                    Position += sizeof(int);

                    return value;
                }
                catch
                {
                    return SetError<int>();
                }
            }

            public uint UInt()
            {
                try
                {
                    if (!IsValidPrefix(Prefix.UInt)) throw new InvalidDataException();

                    uint value = BitConverter.ToUInt32(VaultArray, Position);

                    Position += sizeof(uint);

                    return value;
                }
                catch
                {
                    return SetError<uint>();
                }
            }

            public float Float()
            {
                try
                {
                    if (!IsValidPrefix(Prefix.Float)) throw new InvalidDataException();

                    float value = BitConverter.ToSingle(VaultArray, Position);

                    Position += sizeof(float);

                    return value;
                }
                catch
                {
                    return SetError<float>();
                }
            }

            public T Enum<T>()
            {
                try
                {
                    if (!typeof(T).IsEnum) throw new InvalidOperationException();

                    if (!IsValidPrefix(Prefix.Enum)) throw new InvalidDataException();

                    int value = BitConverter.ToInt32(VaultArray, Position);

                    Position += sizeof(int);

                    return (T)(object)value;
                }
                catch
                {
                    return SetError<T>();
                }
            }

            public long Long()
            {
                try
                {
                    if (!IsValidPrefix(Prefix.Long)) throw new InvalidDataException();

                    long value = BitConverter.ToInt64(VaultArray, Position);

                    Position += sizeof(long);

                    return value;
                }
                catch
                {
                    return SetError<long>();
                }
            }

            public ulong ULong()
            {
                try
                {
                    if (!IsValidPrefix(Prefix.ULong)) throw new InvalidDataException();

                    ulong value = BitConverter.ToUInt64(VaultArray, Position);

                    Position += sizeof(ulong);

                    return value;
                }
                catch
                {
                    return SetError<uint>();
                }
            }

            public double Double()
            {
                try
                {
                    if (!IsValidPrefix(Prefix.Double)) throw new InvalidDataException();

                    double value = BitConverter.ToDouble(VaultArray, Position);

                    Position += sizeof(double);

                    return value;
                }
                catch
                {
                    return SetError<double>();
                }
            }

            public DateTime DateTime()
            {
                try
                {
                    if (!IsValidPrefix(Prefix.DateTime)) throw new InvalidDataException();

                    long value = BitConverter.ToInt64(VaultArray, Position);

                    Position += sizeof(long);

                    return System.DateTime.FromBinary(value);
                }
                catch
                {
                    return SetError<DateTime>();
                }
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