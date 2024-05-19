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
            if (type == typeof(bool))
            {
                primitive.Add.Bool((bool)blackbox);
            }
            else if (type == typeof(byte))
            {
                primitive.Add.Byte((byte)blackbox);
            }
            else if (type == typeof(sbyte))
            {
                primitive.Add.SByte((sbyte)blackbox);
            }
            // 2 bytes (3)
            else if (type == typeof(char))
            {
                primitive.Add.Char((char)blackbox);
            }
            else if (type == typeof(short))
            {
                primitive.Add.Short((short)blackbox);
            }
            else if (type == typeof(ushort))
            {
                primitive.Add.UShort((ushort)blackbox);
            }
            // 4 bytes (4)
            else if (type == typeof(int))
            {
                primitive.Add.Int((int)blackbox);
            }
            else if (type == typeof(uint))
            {
                primitive.Add.UInt((uint)blackbox);
            }
            else if (type == typeof(float))
            {
                primitive.Add.Float((float)blackbox);
            }
            else if (type.IsEnum)
            {
                primitive.Add.Enum(value);
            }
            // 8 bytes (3)
            else if (type == typeof(long))
            {
                primitive.Add.Long((long)blackbox);
            }
            else if (type == typeof(ulong))
            {
                primitive.Add.ULong((ulong)blackbox);
            }
            else if (type == typeof(double))
            {
                primitive.Add.Double((double)blackbox);
            }
            else if (type == typeof(DateTime))
            {
                primitive.Add.DateTime((DateTime)blackbox);
            }
            // 16 bytes (1)
            else if (type == typeof(decimal))
            {
                primitive.Add.Decimal((decimal)blackbox);
            }
            // dynamic (7)
            else if (type == typeof(string))
            {
                primitive.Add.String((string)blackbox);
            }
            else if (type == typeof(BigInteger))
            {
                primitive.Add.BigInteger((BigInteger)blackbox);
            }
            else if (type == typeof(byte[]))
            {
                primitive.Add.Bytes((byte[])blackbox);
            }
            else if (type == typeof(T[]))
            {
                // TODO: array
            }
            else if (type == typeof(List<T>))
            {
                // TODO: list
            }
            else if (type == typeof(object))
            {
                // TODO: class
            }
            else if (type == typeof(object))
            {
                // TODO: struct
            }

            return primitive.Data;
        }

        internal static (T Value, bool IsError) FromPrimitive<T>(Primitive primitive)
        {
            var type = typeof(T);

            object value = null;

            // 1 byte (3)
            if (type == typeof(bool))
            {
                value = primitive.Get.Bool();
            }
            else if (type == typeof(byte))
            {
                value = primitive.Get.Byte();
            }
            else if (type == typeof(sbyte))
            {
                value = primitive.Get.SByte();
            }
            // 2 bytes (3)
            else if (type == typeof(char))
            {
                value = primitive.Get.Char();
            }
            else if (type == typeof(short))
            {
                value = primitive.Get.Short();
            }
            else if (type == typeof(ushort))
            {
                value = primitive.Get.UShort();
            }
            // 4 bytes (4)
            else if (type == typeof(int))
            {
                value = primitive.Get.Int();
            }
            else if (type == typeof(uint))
            {
                value = primitive.Get.UInt();
            }
            else if (type == typeof(float))
            {
                value = primitive.Get.Float();
            }
            else if (type.IsEnum)
            {
                value = primitive.Get.Enum<T>();
            }
            // 8 bytes (3)
            else if (type == typeof(long))
            {
                value = primitive.Get.Long();
            }
            else if (type == typeof(ulong))
            {
                value = primitive.Get.ULong();
            }
            else if (type == typeof(double))
            {
                value = primitive.Get.Double();
            }
            else if (type == typeof(DateTime))
            {
                value = primitive.Get.DateTime();
            }
            // 16 bytes (1)
            else if (type == typeof(decimal))
            {
                value = primitive.Get.Decimal();
            }
            // dynamic (7)
            else if (type == typeof(string))
            {
                value = primitive.Get.String();
            }
            else if (type == typeof(BigInteger))
            {
                value = primitive.Get.BigInteger();
            }
            else if (type == typeof(byte[]))
            {
                value = primitive.Get.Bytes();
            }
            else if (type == typeof(T[]))
            {
                // TODO: array
            }
            else if (type == typeof(List<T>))
            {
                // TODO: list
            }
            else if (type == typeof(object))
            {
                // TODO: class
            }
            else if (type == typeof(object))
            {
                // TODO: struct
            }

            return ((T)value, value == null);
        }
    }
}