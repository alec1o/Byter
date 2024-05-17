using System;
using System.Collections.Generic;

namespace Byter
{
    public partial class Pot
    {
        private class PotAdd : IPotAdd
        {
            private Pot _pot;
            public PotAdd(Pot pot)
            {
                _pot = pot;
            }

            public void Bool(bool value)
            {
                throw new NotImplementedException();
            }

            public void Byte(byte value)
            {
                throw new NotImplementedException();
            }

            public void SByteInt(sbyte value)
            {
                throw new NotImplementedException();
            }

            public void Char(char value)
            {
                throw new NotImplementedException();
            }

            public void Short(short value)
            {
                throw new NotImplementedException();
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
        }
    }
}