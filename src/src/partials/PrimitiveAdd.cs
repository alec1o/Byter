using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Byter
{
    public partial class Primitive
    {
        private class PrimitiveAdd : IPrimitiveAdd
        {
            private readonly Primitive _primitive;
            private List<byte> Vault => _primitive._bytes;

            public PrimitiveAdd(Primitive primitive)
            {
                _primitive = primitive;
            }

            public void Bool(bool value)
            {
                Vault.Add(Prefix.Bool);
                Vault.AddRange(BitConverter.GetBytes(value));
            }

            public void Byte(byte value)
            {
                Vault.Add(Prefix.Byte);
                Vault.Add(value);
            }

            public void SByte(sbyte value)
            {
                Vault.Add(Prefix.SByte);
                Vault.Add((byte)value);
            }

            public void Char(char value)
            {
                Vault.Add(Prefix.Char);
                Vault.AddRange(BitConverter.GetBytes(value));
            }

            public void Short(short value)
            {
                Vault.Add(Prefix.Short);
                Vault.AddRange(BitConverter.GetBytes(value));
            }

            public void UShort(ushort value)
            {
                Vault.Add(Prefix.UShort);
                Vault.AddRange(BitConverter.GetBytes(value));
            }

            public void Int(int value)
            {
                Vault.Add(Prefix.Int);
                Vault.AddRange(BitConverter.GetBytes(value));
            }

            public void UInt(uint value)
            {
                Vault.Add(Prefix.UInt);
                Vault.AddRange(BitConverter.GetBytes(value));
            }

            public void Float(float value)
            {
                Vault.Add(Prefix.Float);
                Vault.AddRange(BitConverter.GetBytes(value));
            }

            public void Enum<T>(T value)
            {
                if (!typeof(T).IsEnum) throw new InvalidOperationException();
                Vault.Add(Prefix.Enum);
                Vault.AddRange(BitConverter.GetBytes((int)(object)value));
            }

            public void Long(long value)
            {
                Vault.Add(Prefix.Long);
                Vault.AddRange(BitConverter.GetBytes(value));
            }

            public void ULong(ulong value)
            {
                Vault.Add(Prefix.ULong);
                Vault.AddRange(BitConverter.GetBytes(value));
            }

            public void Double(double value)
            {
                Vault.Add(Prefix.Double);
                Vault.AddRange(BitConverter.GetBytes(value));
            }

            public void DateTime(DateTime value)
            {
                Vault.Add(Prefix.DateTime);
                Vault.AddRange(BitConverter.GetBytes(value.ToBinary()));
            }

            public void Decimal(decimal value)
            {
                Vault.Add(Prefix.Decimal);

                List<int> list = decimal.GetBits(value).ToList();

                foreach (int x in list)
                {
                    Vault.AddRange(BitConverter.GetBytes(x));
                }
            }

            public void String(string value)
            {
                Vault.Add(Prefix.String);

                byte[] bytes = Encoding.UTF8.GetBytes(value ?? string.Empty);

                Vault.AddRange(BitConverter.GetBytes(bytes.Length));

                if (bytes.Length > 0)
                {
                    Vault.AddRange(bytes);
                }
            }

            public void Class(object value)
            {
                throw new NotImplementedException();
            }

            public void Struct(object value)
            {
                throw new NotImplementedException();
            }

            public void Array<T>(T[] value)
            {
                throw new NotImplementedException();
            }

            public void List<T>(List<T> value)
            {
                throw new NotImplementedException();
            }

            public void BigInteger(BigInteger value)
            {
                Vault.Add(Prefix.BigInteger);

                byte[] bytes = value.ToByteArray();

                Vault.AddRange(BitConverter.GetBytes(bytes.Length));

                Vault.AddRange(bytes);
            }

            public void Bytes(byte[] value)
            {
                byte[] bytes = value ?? System.Array.Empty<byte>();
                
                Vault.Add(Prefix.Bytes);

                Vault.AddRange(BitConverter.GetBytes(bytes.Length));

                if (bytes.Length > 0)
                {
                    Vault.AddRange(bytes);
                }
            }
        }
    }
}