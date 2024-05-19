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

            public void Enum(Enum value)
            {
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
                throw new NotImplementedException();
            }

            public void String(string value)
            {
                throw new NotImplementedException();
            }

            public void Class(object value)
            {
                throw new NotImplementedException();
            }

            public void Struct(object value)
            {
                throw new NotImplementedException();
            }

            public void Array<T>(IList<T> value)
            {
                throw new NotImplementedException();
            }

            public void List<T>(List<T> value)
            {
                throw new NotImplementedException();
            }

            public void BigInteger(BigInteger value)
            {
                throw new NotImplementedException();
            }
        }
    }
}