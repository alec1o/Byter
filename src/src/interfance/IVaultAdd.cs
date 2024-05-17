using System;
using System.Collections.Generic;
using System.Numerics;

namespace Byter
{
    public interface IVaultAdd
    {
        // 1 byte (3)
        void Bool(bool value);
        void Byte(byte value);
        void SByteInt(sbyte value);
        
        // 2 bytes (3)
        void Char(char value);
        void Short(short value);
        void UShort(ushort value);
        
        // 4 bytes (4)
        void Int(int value);
        void UInt(uint value);
        void Float(float value);
        void Enum(Enum value);

        // 8 bytes (3)
        void Long(long value);
        void ULong(ulong value);
        void Double(double value);
        void DateTime(DateTime value);
        
        // 16 bytes (1)
        void Decimal(decimal value);
        
        // dynamic (6)
        void String(string value);
        void Class(object value);
        void Struct(object value);
        void Array<T>(IList<T> value);
        void List<T>(List<T> value);
        void BigInteger(BigInteger value);
    }
}