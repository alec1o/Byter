using System;
using System.Collections;
using System.Numerics;

namespace Byter
{
    public partial class By : IBy
    {
        public static Types Hash<T>(T value)
        {
            if (value == null) return Types.Null;

            Type type = value.GetType();

            if (type == typeof(sbyte)) return Types.Sbyte;
            if (type == typeof(byte)) return Types.Byte;
            if (type == typeof(bool)) return Types.Bool;
            if (type == typeof(char)) return Types.Char;
            if (type == typeof(short)) return Types.Short;
            if (type == typeof(ushort)) return Types.Ushort;
            if (type == typeof(uint)) return Types.Uint;
            if (type == typeof(int)) return Types.Int;
            if (type == typeof(float)) return Types.Float;
            if (type.IsEnum) return Types.Enum;
            if (type == typeof(long)) return Types.Long;
            if (type == typeof(ulong)) return Types.Ulong;
            if (type == typeof(double)) return Types.Double;
            if (type == typeof(decimal)) return Types.Decimal;
            if (type == typeof(byte[])) return Types.Bytes;
            if (type == typeof(string)) return Types.String;
            if (type == typeof(BigInteger)) return Types.BigInteger;
            if (type.IsClass) return Types.Class;
            if (type.IsValueType && !type.IsEnum && !type.IsPrimitive) return Types.Struct;
            if (type == typeof(ICollection)) return Types.List;
            if (type.IsArray) return Types.Array;
            if (type == typeof(DateTime)) return Types.DateTime;

            throw new NotImplementedException($"[{nameof(By)}.{nameof(Hash)}] Error: {type} Isn't implemented");
        }
    }
}