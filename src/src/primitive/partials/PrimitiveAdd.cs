using System;
using System.Collections;
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

            public PrimitiveAdd(Primitive primitive)
            {
                _primitive = primitive;
            }

            private List<byte> Vault => _primitive._bytes;

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
                var type = typeof(T);

                if (!(value is Enum || type.IsEnum))
                {
                    throw new InvalidOperationException($"Typeof {typeof(T)}, Is not enum type.");
                }

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

                var list = decimal.GetBits(value).ToList();

                foreach (var x in list) Vault.AddRange(BitConverter.GetBytes(x));
            }

            public void String(string value)
            {
                Vault.Add(Prefix.String);

                var bytes = Encoding.UTF8.GetBytes(value ?? string.Empty);

                Vault.AddRange(BitConverter.GetBytes(bytes.Length));

                if (bytes.Length > 0) Vault.AddRange(bytes);
            }

            public void Class<T>(T value)
            {
                const int defaultCount = 0;
                const int defaultBuffer = 0;

                var type = value.GetType();

                if (!type.IsClass) throw new InvalidOperationException($"Only class is accepted. {type} isn't allowed");
                // if (!type.IsSerializable) throw new InvalidOperationException("Only serialized class is accepted");

                Vault.Add(Prefix.Class);
                var cache = new List<byte>();

                if (value == null)
                {
                    Vault.AddRange(BitConverter.GetBytes(defaultCount));
                    Vault.AddRange(BitConverter.GetBytes(defaultBuffer));
                    return;
                }

                var props = type.GetProperties();

                if (props.Length <= 0)
                {
                    Vault.AddRange(BitConverter.GetBytes(defaultCount));
                    Vault.AddRange(BitConverter.GetBytes(defaultBuffer));
                    return;
                }

                var count = 0;

                foreach (var prop in props)
                    if (prop.CanRead && prop.CanWrite)
                    {
                        var propValue = prop.GetValue(value);
                        var propBuffer = propValue.ToPrimitive(prop.PropertyType);
                        if (propBuffer != null && propBuffer.Length > 0)
                        {
                            count++;
                            cache.AddRange(propBuffer);
                        }
                    }

                if (count <= 0 || cache.Count <= 0)
                {
                    Vault.AddRange(BitConverter.GetBytes(defaultCount));
                    Vault.AddRange(BitConverter.GetBytes(defaultBuffer));
                }
                else
                {
                    Vault.AddRange(BitConverter.GetBytes(count));
                    Vault.AddRange(BitConverter.GetBytes(cache.Count));
                    Vault.AddRange(cache);
                }
            }

            public void Struct<T>(T value)
            {
                const int defaultCount = 0;
                const int defaultBuffer = 0;

                var type = value.GetType();

                if (!(type.IsValueType && !type.IsEnum && !type.IsPrimitive))
                    throw new InvalidOperationException($"Only struct is accepted. {type} isn't allowed");
                // if (!type.IsSerializable) throw new InvalidOperationException("Only serialized class is accepted");

                Vault.Add(Prefix.Struct);
                var cache = new List<byte>();

                if (value == null)
                {
                    Vault.AddRange(BitConverter.GetBytes(defaultCount));
                    Vault.AddRange(BitConverter.GetBytes(defaultBuffer));
                    return;
                }

                var props = type.GetProperties();

                if (props.Length <= 0)
                {
                    Vault.AddRange(BitConverter.GetBytes(defaultCount));
                    Vault.AddRange(BitConverter.GetBytes(defaultBuffer));
                    return;
                }

                var count = 0;

                foreach (var prop in props)
                    if (prop.CanRead && prop.CanWrite)
                    {
                        var propValue = prop.GetValue(value);
                        var propBuffer = propValue.ToPrimitive(prop.PropertyType);
                        if (propBuffer != null && propBuffer.Length > 0)
                        {
                            count++;
                            cache.AddRange(propBuffer);
                        }
                    }

                if (count <= 0 || cache.Count <= 0)
                {
                    Vault.AddRange(BitConverter.GetBytes(defaultCount));
                    Vault.AddRange(BitConverter.GetBytes(defaultBuffer));
                }
                else
                {
                    Vault.AddRange(BitConverter.GetBytes(count));
                    Vault.AddRange(BitConverter.GetBytes(cache.Count));
                    Vault.AddRange(cache);
                }
            }
            
            public void Array<T>(T[] value)
            {
                Vault.Add(Prefix.Array);

                var size = value?.Length ?? 0;

                if (size > 0 && value != null)
                {
                    var collection = new List<byte>();

                    foreach (var x in value) collection.AddRange(x.ToPrimitive());

                    Vault.AddRange(BitConverter.GetBytes(size)); // objects count
                    Vault.AddRange(BitConverter.GetBytes(collection.Count)); // buffer size
                    Vault.AddRange(collection); // buffer
                }
                else
                {
                    Vault.AddRange(BitConverter.GetBytes(0)); // objects count
                    Vault.AddRange(BitConverter.GetBytes(0)); // buffer
                }
            }

            public void Array(object value)
            {
                if (value == null || !(value is IList list)) return;
                var type = value.GetType();
                if (!type.IsArray) return;
                var childrenType = type.GetElementType();

                Vault.Add(Prefix.Array);

                var size = list?.Count ?? 0;

                if (size > 0)
                {
                    var collection = new List<byte>();

                    foreach (var x in list) collection.AddRange(x.ToPrimitive());

                    Vault.AddRange(BitConverter.GetBytes(size)); // objects count
                    Vault.AddRange(BitConverter.GetBytes(collection.Count)); // buffer size
                    Vault.AddRange(collection); // buffer
                }
                else
                {
                    Vault.AddRange(BitConverter.GetBytes(0)); // objects count
                    Vault.AddRange(BitConverter.GetBytes(0)); // buffer
                }
            }

            public void List(object value)
            {
                if (value == null || !(value is ICollection list)) return;
                var type = value.GetType();
                if (!type.IsGenericType) return;
                var args = type.GetGenericArguments();
                if (args.Length != 1) return; // is empty or multi args e.g. Example<object, object?...>

                Vault.Add(Prefix.List);

                var size = list?.Count ?? 0;

                if (size > 0)
                {
                    var collection = new List<byte>();

                    foreach (var x in list) collection.AddRange(x.ToPrimitive());

                    Vault.AddRange(BitConverter.GetBytes(size)); // objects count
                    Vault.AddRange(BitConverter.GetBytes(collection.Count)); // buffer size
                    Vault.AddRange(collection); // buffer
                }
                else
                {
                    Vault.AddRange(BitConverter.GetBytes(0)); // objects count
                    Vault.AddRange(BitConverter.GetBytes(0)); // buffer
                }
            }

            public void List<T>(List<T> value)
            {
                Vault.Add(Prefix.List);

                var size = value?.Count ?? 0;

                if (size > 0 && value != null)
                {
                    var collection = new List<byte>();

                    foreach (var x in value) collection.AddRange(x.ToPrimitive());

                    Vault.AddRange(BitConverter.GetBytes(size)); // objects count
                    Vault.AddRange(BitConverter.GetBytes(collection.Count)); // buffer size
                    Vault.AddRange(collection); // buffer
                }
                else
                {
                    Vault.AddRange(BitConverter.GetBytes(0)); // objects count
                    Vault.AddRange(BitConverter.GetBytes(0)); // buffer
                }
            }

            public void BigInteger(BigInteger value)
            {
                Vault.Add(Prefix.BigInteger);

                var bytes = value.ToByteArray();

                Vault.AddRange(BitConverter.GetBytes(bytes.Length));

                Vault.AddRange(bytes);
            }

            public void Bytes(byte[] value)
            {
                var bytes = value ?? System.Array.Empty<byte>();

                Vault.Add(Prefix.Bytes);

                Vault.AddRange(BitConverter.GetBytes(bytes.Length));

                if (bytes.Length > 0) Vault.AddRange(bytes);
            }
        }
    }
}