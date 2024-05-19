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
                throw new NotImplementedException();
            }

            public void Int(int value)
            {
                throw new NotImplementedException();
            }

            public void UInt(uint value)
            {
                throw new NotImplementedException();
            }

            public void Float(float value)
            {
                throw new NotImplementedException();
            }

            public void Enum(Enum value)
            {
                throw new NotImplementedException();
            }

            public void Long(long value)
            {
                throw new NotImplementedException();
            }

            public void ULong(ulong value)
            {
                throw new NotImplementedException();
            }

            public void Double(double value)
            {
                throw new NotImplementedException();
            }

            public void DateTime(DateTime value)
            {
                throw new NotImplementedException();
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