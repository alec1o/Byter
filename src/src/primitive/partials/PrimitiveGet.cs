using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Numerics;
using System.Text;

namespace Byter
{
    public partial class Primitive
    {
        private class PrimitiveGet : IPrimitiveGet
        {
            private readonly Primitive _primitive;

            public PrimitiveGet(Primitive primitive)
            {
                _primitive = primitive;
            }

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

            public bool Bool()
            {
                try
                {
                    if (!IsValidPrefix(Prefix.Bool)) throw new InvalidDataException();

                    var value = BitConverter.ToBoolean(VaultArray, Position);

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

                    var value = Vault[Position];

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

                    var value = (sbyte)Vault[Position];

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

                    var value = BitConverter.ToChar(VaultArray, Position);

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

                    var value = BitConverter.ToInt16(VaultArray, Position);

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

                    var value = BitConverter.ToUInt16(VaultArray, Position);

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

                    var value = BitConverter.ToInt32(VaultArray, Position);

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

                    var value = BitConverter.ToUInt32(VaultArray, Position);

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

                    var value = BitConverter.ToSingle(VaultArray, Position);

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
                return (T)Enum(typeof(T));
            }

            public object Enum(Type type)
            {
                try
                {
                    if (!type.IsEnum) throw new InvalidOperationException();

                    if (!IsValidPrefix(Prefix.Enum)) throw new InvalidDataException();

                    var value = BitConverter.ToInt32(VaultArray, Position);

                    Position += sizeof(int);

                    return value;
                }
                catch
                {
                    return SetError<object>();
                }
            }

            public long Long()
            {
                try
                {
                    if (!IsValidPrefix(Prefix.Long)) throw new InvalidDataException();

                    var value = BitConverter.ToInt64(VaultArray, Position);

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

                    var value = BitConverter.ToUInt64(VaultArray, Position);

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

                    var value = BitConverter.ToDouble(VaultArray, Position);

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

                    var value = BitConverter.ToInt64(VaultArray, Position);

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
                try
                {
                    if (!IsValidPrefix(Prefix.Decimal)) throw new InvalidDataException();

                    var value = Vault.GetRange(Position, sizeof(decimal)).ToArray();

                    Position += sizeof(decimal);

                    int[] bits =
                    {
                        BitConverter.ToInt32(value, sizeof(int) * 0),
                        BitConverter.ToInt32(value, sizeof(int) * 1),
                        BitConverter.ToInt32(value, sizeof(int) * 2),
                        BitConverter.ToInt32(value, sizeof(int) * 3)
                    };

                    return new decimal(bits);
                }
                catch
                {
                    return SetError<decimal>();
                }
            }

            public string String()
            {
                try
                {
                    if (!IsValidPrefix(Prefix.String)) throw new InvalidDataException();

                    var valueSize = BitConverter.ToInt32(VaultArray, Position);

                    Position += sizeof(int);

                    if (valueSize <= 0 || valueSize > Vault.Count - Position) throw new InvalidDataException();

                    var value = Vault.GetRange(Position, valueSize).ToArray();

                    Position += valueSize;

                    return Encoding.UTF8.GetString(value);
                }
                catch
                {
                    return SetError<string>();
                }
            }


            public object Class(Type type)
            {
                try
                {
                    if (!type.IsClass) throw new InvalidOperationException("Only class is accepted");

                    if (!IsValidPrefix(Prefix.Class)) throw new InvalidDataException();

                    var objectCount = BitConverter.ToInt32(VaultArray, Position);
                    Position += sizeof(int);

                    var collectionBuffer = BitConverter.ToInt32(VaultArray, Position);
                    Position += sizeof(int);

                    if
                    (
                        // objects count lower than zero
                        objectCount < 0 ||
                        // buffer size lower than zero
                        collectionBuffer < 0 ||
                        // if zero objects count is zero, buffer size must be zero too
                        (objectCount == 0 && collectionBuffer != 0) ||
                        // if have object(s), the buffer size must not be zero
                        (objectCount != 0 && collectionBuffer == 0)
                    )
                        throw new InvalidConstraintException();

                    var instance = Activator.CreateInstance(type);

                    if (objectCount > 0 && collectionBuffer > 0)
                    {
                        var primitive = new Primitive(Vault.GetRange(Position, collectionBuffer).ToArray());

                        Position += collectionBuffer;

                        var props = type.GetProperties();

                        if (props.Length <= 0) return default;

                        foreach (var prop in props)
                            if (prop.CanRead && prop.CanWrite)
                            {
                                var result = PrimitiveExtension.FromPrimitive(prop.PropertyType, primitive);

                                if (result.IsError) throw new InvalidDataException();

                                prop.SetValue(instance, result.Value);
                            }

                        return instance;
                    }

                    return instance;
                }
                catch
                {
                    return SetError<object>();
                }
            }


            public T Class<T>()
            {
                try
                {
                    if (!typeof(T).IsClass) throw new InvalidOperationException("Only class is accepted");

                    if (!IsValidPrefix(Prefix.Class)) throw new InvalidDataException();

                    var objectCount = BitConverter.ToInt32(VaultArray, Position);
                    Position += sizeof(int);

                    var collectionBuffer = BitConverter.ToInt32(VaultArray, Position);
                    Position += sizeof(int);

                    if
                    (
                        // objects count lower than zero
                        objectCount < 0 ||
                        // buffer size lower than zero
                        collectionBuffer < 0 ||
                        // if zero objects count is zero, buffer size must be zero too
                        (objectCount == 0 && collectionBuffer != 0) ||
                        // if have object(s), the buffer size must not be zero
                        (objectCount != 0 && collectionBuffer == 0)
                    )
                        throw new InvalidConstraintException();

                    var instance = (T)Activator.CreateInstance(typeof(T));

                    if (objectCount > 0 && collectionBuffer > 0)
                    {
                        var primitive = new Primitive(Vault.GetRange(Position, collectionBuffer).ToArray());

                        Position += collectionBuffer;

                        var props = typeof(T).GetProperties();

                        if (props.Length <= 0) return default;

                        foreach (var prop in props)
                            if (prop.CanRead && prop.CanWrite)
                            {
                                var result = PrimitiveExtension.FromPrimitive(prop.PropertyType, primitive);

                                if (result.IsError) throw new InvalidDataException();

                                prop.SetValue(instance, result.Value);
                            }

                        return instance;
                    }

                    return instance;
                }
                catch
                {
                    return SetError<T>();
                }
            }

            public T Struct<T>()
            {
                return (T)Struct(typeof(T));
            }
            
            public object Struct(Type type)
            {
                if (type == null) return null;

                try
                {
                    if (!(type.IsValueType && !type.IsEnum && !type.IsPrimitive))
                        throw new InvalidOperationException("Only struct is accepted");

                    if (!IsValidPrefix(Prefix.Struct)) throw new InvalidDataException();

                    var objectCount = BitConverter.ToInt32(VaultArray, Position);
                    Position += sizeof(int);

                    var collectionBuffer = BitConverter.ToInt32(VaultArray, Position);
                    Position += sizeof(int);

                    if
                    (
                        // objects count lower than zero
                        objectCount < 0 ||
                        // buffer size lower than zero
                        collectionBuffer < 0 ||
                        // if zero objects count is zero, buffer size must be zero too
                        (objectCount == 0 && collectionBuffer != 0) ||
                        // if have object(s), the buffer size must not be zero
                        (objectCount != 0 && collectionBuffer == 0)
                    )
                        throw new InvalidConstraintException();

                    var instance = Activator.CreateInstance(type);

                    if (objectCount > 0 && collectionBuffer > 0)
                    {
                        var primitive = new Primitive(Vault.GetRange(Position, collectionBuffer).ToArray());

                        Position += collectionBuffer;

                        var props = type.GetProperties();

                        foreach (var prop in props)
                            if (prop.CanRead && prop.CanWrite)
                            {
                                var result = PrimitiveExtension.FromPrimitive(prop.PropertyType, primitive);

                                if (result.IsError) throw new InvalidDataException();

                                /*
 * WARNING: dotnet standard bug. but this code working if running in dotnet 8+
 * NOTICE 1*: https://stackoverflow.com/questions/9694404/propertyinfo-setvalue-not-working-but-no-errors
 * NOTICE 1 (original): https://bytes.com/topic/visual-basic-net/372981-cannot-get-propertyinfo-setvalue-work-structure

 -> prop.SetValue(instance, result.Value);

 * NOTICE 1*: https://stackoverflow.com/questions/9694404/propertyinfo-setvalue-not-working-but-no-errors
 * NOTICE 1 (Original): https://stackoverflow.com/questions/6280506/is-there-a-way-to-set-properties-on-struct-instances-using-reflection

 -> typeof(T).GetField(prop.Name).SetValue(instance, result.Value);
 */
                                /*
https://stackoverflow.com/questions/9694404/propertyinfo-setvalue-not-working-but-no-errors
|-----------------------------------------------------------------------------------|
|   PropertyInfo.SetValue/GetValue worked with struct with accurate using           |
|-----------------------------------------------------------------------------------|
|  struct Z                                                                         |
|  {                                                                                |
|      public int X { get; set; }                                                   |
|  }                                                                                |
|                                                                                   |
|  Z z1 = new Z();                                                                  |
|  z1.GetType().GetProperty("X").SetValue(z1, 100, null);                           |
|  Console.WriteLine(z1.X); //z1.X dont changed                                     |
|                                                                                   |
|  object z2 = new Z();                                                             |
|  z2.GetType().GetProperty("X").SetValue(z2, 100, null);                           |
|  Console.WriteLine(((Z)z2).X); //z2.x changed to 100                              |
|                                                                                   |
|  Z z3 = new Z();                                                                  |
|  object _z3 = z3;                                                                 |
|  _z3.GetType().GetProperty("X").SetValue(_z3, 100, null);                         |
|  z3 = (Z)_z3;                                                                     |
|  Console.WriteLine(z3.X); //z3.x changed to 100                                   |
|-----------------------------------------------------------------------------------|
|  Correct way to change struct:                                                    |
|                                                                                   |
|     - box struct                                                                  |
|     - change property of boxed struct                                             |
|     - assign boxed struct to source                                               |
|-----------------------------------------------------------------------------------|
*/
                                object dto = instance;

                                prop.SetValue(dto, result.Value);

                                instance = dto;
                            }

                        return instance;
                    }

                    return instance;
                }
                catch
                {
                    return SetError<object>();
                }
            }

            public object Array(Type type)
            {
                if (type == null) return null;
                if (!type.IsArray) return null;
                Type childrenType = type.GetElementType();
                Type listType = typeof(List<>).MakeGenericType(childrenType);

                try
                {
                    if (!IsValidPrefix(Prefix.Array)) throw new InvalidDataException();

                    var list = (List<dynamic>)Activator.CreateInstance(listType);

                    var objectCount = BitConverter.ToInt32(VaultArray, Position);
                    Position += sizeof(int);

                    var collectionBuffer = BitConverter.ToInt32(VaultArray, Position);
                    Position += sizeof(int);

                    if
                    (
                        // objects count lower than zero
                        objectCount < 0 ||
                        // buffer size lower than zero
                        collectionBuffer < 0 ||
                        // if zero objects count is zero, buffer size must be zero too
                        (objectCount == 0 && collectionBuffer != 0) ||
                        // if have object(s), the buffer size must not be zero
                        (objectCount != 0 && collectionBuffer == 0)
                    ) throw new InvalidConstraintException();

                    if (objectCount > 0 && collectionBuffer > 0)
                    {
                        var primitive = new Primitive(Vault.GetRange(Position, collectionBuffer).ToArray());

                        Position += collectionBuffer;

                        for (var i = 0; i < objectCount; i++)
                        {
                            var result = PrimitiveExtension.FromPrimitive(childrenType, primitive);

                            if (result.IsError) throw new InvalidDataException();

                            list.Add(result.Value);
                        }
                    }

                    return list.ToArray();
                }
                catch
                {
                    return SetError<object>();
                }
            }

            public T[] Array<T>()
            {
                try
                {
                    if (!IsValidPrefix(Prefix.Array)) throw new InvalidDataException();

                    var list = new List<T>();

                    var objectCount = BitConverter.ToInt32(VaultArray, Position);
                    Position += sizeof(int);

                    var collectionBuffer = BitConverter.ToInt32(VaultArray, Position);
                    Position += sizeof(int);

                    if
                    (
                        // objects count lower than zero
                        objectCount < 0 ||
                        // buffer size lower than zero
                        collectionBuffer < 0 ||
                        // if zero objects count is zero, buffer size must be zero too
                        (objectCount == 0 && collectionBuffer != 0) ||
                        // if have object(s), the buffer size must not be zero
                        (objectCount != 0 && collectionBuffer == 0)
                    )
                        throw new InvalidConstraintException();

                    if (objectCount > 0 && collectionBuffer > 0)
                    {
                        var primitive = new Primitive(Vault.GetRange(Position, collectionBuffer).ToArray());

                        Position += collectionBuffer;

                        for (var i = 0; i < objectCount; i++)
                        {
                            var result = PrimitiveExtension.FromPrimitive<T>(primitive);

                            if (result.IsError) throw new InvalidDataException();

                            list.Add(result.Value);
                        }
                    }

                    return list.ToArray();
                }
                catch
                {
                    return SetError<T[]>();
                }
            }

            public object List(Type type)
            {
                if (type == null) return null;
                if (!type.IsGenericType) return null;
                var args = type.GetGenericArguments();
                if (args.Length != 1) return null; // is empty or multi args e.g. Example<object, object?...>
                Type childrenType = args[0];

                try
                {
                    if (!IsValidPrefix(Prefix.List)) throw new InvalidDataException();

                    var list = (IList)Activator.CreateInstance(type);

                    var objectCount = BitConverter.ToInt32(VaultArray, Position);
                    Position += sizeof(int);

                    var collectionBuffer = BitConverter.ToInt32(VaultArray, Position);
                    Position += sizeof(int);

                    if
                    (
                        // objects count lower than zero
                        objectCount < 0 ||
                        // buffer size lower than zero
                        collectionBuffer < 0 ||
                        // if zero objects count is zero, buffer size must be zero too
                        (objectCount == 0 && collectionBuffer != 0) ||
                        // if have object(s), the buffer size must not be zero
                        (objectCount != 0 && collectionBuffer == 0)
                    )
                        throw new InvalidConstraintException();

                    if (objectCount > 0 && collectionBuffer > 0)
                    {
                        var primitive = new Primitive(Vault.GetRange(Position, collectionBuffer).ToArray());

                        Position += collectionBuffer;

                        for (var i = 0; i < objectCount; i++)
                        {
                            var result = PrimitiveExtension.FromPrimitive(childrenType, primitive);

                            if (result.IsError) throw new InvalidDataException();

                            list.Add(result.Value);
                        }
                    }

                    return list;
                }
                catch
                {
                    return SetError<object>();
                }
            }

            public List<T> List<T>()
            {
                try
                {
                    if (!IsValidPrefix(Prefix.List)) throw new InvalidDataException();

                    var list = new List<T>();

                    var objectCount = BitConverter.ToInt32(VaultArray, Position);
                    Position += sizeof(int);

                    var collectionBuffer = BitConverter.ToInt32(VaultArray, Position);
                    Position += sizeof(int);

                    if
                    (
                        // objects count lower than zero
                        objectCount < 0 ||
                        // buffer size lower than zero
                        collectionBuffer < 0 ||
                        // if zero objects count is zero, buffer size must be zero too
                        (objectCount == 0 && collectionBuffer != 0) ||
                        // if have object(s), the buffer size must not be zero
                        (objectCount != 0 && collectionBuffer == 0)
                    )
                        throw new InvalidConstraintException();

                    if (objectCount > 0 && collectionBuffer > 0)
                    {
                        var primitive = new Primitive(Vault.GetRange(Position, collectionBuffer).ToArray());

                        Position += collectionBuffer;

                        for (var i = 0; i < objectCount; i++)
                        {
                            var result = PrimitiveExtension.FromPrimitive<T>(primitive);

                            if (result.IsError) throw new InvalidDataException();

                            list.Add(result.Value);
                        }
                    }

                    return list;
                }
                catch
                {
                    return SetError<List<T>>();
                }
            }

            public BigInteger BigInteger()
            {
                try
                {
                    if (!IsValidPrefix(Prefix.BigInteger)) throw new InvalidDataException();

                    var valueSize = BitConverter.ToInt32(VaultArray, Position);

                    Position += sizeof(int);

                    if (valueSize <= 0 || valueSize > Vault.Count - Position) throw new InvalidDataException();

                    var value = Vault.GetRange(Position, valueSize).ToArray();

                    Position += valueSize;

                    return new BigInteger(value);
                }
                catch
                {
                    return SetError<BigInteger>();
                }
            }

            public byte[] Bytes()
            {
                try
                {
                    if (!IsValidPrefix(Prefix.Bytes)) throw new InvalidDataException();

                    var valueSize = BitConverter.ToInt32(VaultArray, Position);

                    Position += sizeof(int);

                    if (valueSize <= 0 || valueSize > Vault.Count - Position) throw new InvalidDataException();

                    var value = Vault.GetRange(Position, valueSize).ToArray();

                    Position += valueSize;

                    return value;
                }
                catch
                {
                    return SetError<byte[]>();
                }
            }

            private bool IsValidPrefix(byte prefix)
            {
                var value = prefix == Vault[Position];
                if (value) Position += sizeof(byte);
                return value;
            }

            private T SetError<T>()
            {
                IsValid = false;
                return default;
            }
        }
    }
}