using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Byter
{
    public static class PrimitiveExtension
    {
        internal static byte[] ToPrimitive<T>(this T value)
        {
            return ToPrimitive(value, typeof(T));
        }

        internal static byte[] ToPrimitive<T>(this T value, Type type)
        {
            var primitive = new Primitive();

            object blackbox = value;

            // 1 byte (3)
            if (value is bool)
            {
                primitive.Add.Bool((bool)blackbox);
            }
            else if (value is byte)
            {
                primitive.Add.Byte((byte)blackbox);
            }
            else if (value is sbyte)
            {
                primitive.Add.SByte((sbyte)blackbox);
            }
            // 2 bytes (3)
            else if (value is char)
            {
                primitive.Add.Char((char)blackbox);
            }
            else if (value is short)
            {
                primitive.Add.Short((short)blackbox);
            }
            else if (value is ushort)
            {
                primitive.Add.UShort((ushort)blackbox);
            }
            // 4 bytes (4)
            else if (value is int)
            {
                primitive.Add.Int((int)blackbox);
            }
            else if (value is uint)
            {
                primitive.Add.UInt((uint)blackbox);
            }
            else if (value is float)
            {
                primitive.Add.Float((float)blackbox);
            }
            else if (value is Enum || type.IsEnum)
            {
                primitive.Add.Enum(value);
            }
            // 8 bytes (3)
            else if (value is long)
            {
                primitive.Add.Long((long)blackbox);
            }
            else if (value is ulong)
            {
                primitive.Add.ULong((ulong)blackbox);
            }
            else if (value is double)
            {
                primitive.Add.Double((double)blackbox);
            }
            else if (value is DateTime)
            {
                primitive.Add.DateTime((DateTime)blackbox);
            }
            // 16 bytes (1)
            else if (value is decimal)
            {
                primitive.Add.Decimal((decimal)blackbox);
            }
            // dynamic (7)
            else if (value is string)
            {
                primitive.Add.String((string)blackbox);
            }
            else if (value is BigInteger)
            {
                primitive.Add.BigInteger((BigInteger)blackbox);
            }
            else if (value is byte[])
            {
                primitive.Add.Bytes((byte[])blackbox);
            }
            else if (type.IsArray || value is T[])
            {
                // TODO: array
                // primitive.Add.Array(value);
            }
            else if (value is ICollection)
            {
                primitive.Add.List(value);
            }
            else if (type.IsClass)
            {
                primitive.Add.Class(value);
            }
            else if (type.IsValueType && !type.IsEnum && !type.IsPrimitive)
            {
                primitive.Add.Struct(value);
            }

            return primitive.Data;
        }

        internal static (T Value, bool IsError) FromPrimitive<T>(Primitive primitive)
        {
            var result = FromPrimitive(typeof(T), primitive);
            return ((T)result.Value, result.IsError);
        }

        internal static (object Value, bool IsError) FromPrimitive(Type type, Primitive primitive)
        {
            if (type == null || primitive == null) return (default, true);

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
                value = primitive.Get.Enum(type);
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
            else if (type.IsGenericType)
            {
                value = primitive.Get.List(type);
            }
            else if (type.IsArray)
            {
                value = primitive.Get.Array(type);
            }
            else if (type.IsClass)
            {
                value = primitive.Get.Class(type);
            }
            else if (type.IsValueType && !type.IsEnum && !type.IsPrimitive)
            {
                // TODO: impl this...
                //value = primitive.Get.Struct(value);
            }

            if (primitive.IsValid)
                return (value, value == null);
            return (default, true);
        }
    }
}