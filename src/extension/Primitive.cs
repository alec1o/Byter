using System;
using System.Collections.Generic;
using System.Numerics;

namespace Byter
{
    public static class PrimitiveExtension
    {
        internal static byte[] ToPrimitive<T>(this T value)
        {
            var primitive = new Primitive();
            var type = typeof(T);

            object blackbox = value;

            // 1 byte (3)
            if (type == typeof(bool)) primitive.Add.Bool((bool)blackbox);
            if (type == typeof(byte)) primitive.Add.Byte((byte)blackbox);
            if (type == typeof(sbyte)) primitive.Add.SByte((sbyte)blackbox);

            // 2 bytes (3)
            if (type == typeof(char)) primitive.Add.Char((char)blackbox);
            if (type == typeof(short)) primitive.Add.Short((short)blackbox);
            if (type == typeof(ushort)) primitive.Add.UShort((ushort)blackbox);

            // 4 bytes (4)
            if (type == typeof(int)) primitive.Add.Int((int)blackbox);
            if (type == typeof(uint)) primitive.Add.UInt((uint)blackbox);
            if (type == typeof(float)) primitive.Add.Float((float)blackbox);
            if (type.IsEnum) primitive.Add.Enum(value);

            // 8 bytes (3)
            else if (type == typeof(long)) primitive.Add.Long((long)blackbox);
            else if (type == typeof(ulong)) primitive.Add.ULong((ulong)blackbox);
            else if (type == typeof(double)) primitive.Add.Double((double)blackbox);
            else if (type == typeof(DateTime)) primitive.Add.DateTime((DateTime)blackbox);

            // 16 bytes (1)
            else if (type == typeof(decimal)) primitive.Add.Decimal((decimal)blackbox);

            // dynamic (7)
            else if (type == typeof(string)) primitive.Add.String((string)blackbox);
            else if (type == typeof(BigInteger)) primitive.Add.BigInteger((BigInteger)blackbox);
            else if (type == typeof(byte[])) primitive.Add.Bytes((byte[])blackbox);
            else if (type == typeof(T[])) ; // TODO: array
            else if (type == typeof(List<T>)) ; // TODO: list
            else if (type == typeof(object)) ; // TODO: class
            else if (type == typeof(object)) ; // TODO: struct

            return primitive.Data;
        }

        public static T ToPrimitive<T>(this T value, Primitive primitive)
        {
            return value;
        }

        public static T FromPrimitive<T>(this T value, Primitive primitive)
        {
            return value;
        }
    }
}