using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Byter
{
    public partial class By : IBy
    {
        public T Get<T>()
        {
            if (Buffer.Length <= 0 || Index >= Buffer.Length)
            {
                IsValid = false;
                return default;
            }

            Types type = Hash(typeof(T));

            T value;

            switch (type)
            {
                case Types.Int:
                {
                    if (!IsValidPrefix(type, sizeof(int))) return default;

                    value = (T)(object)BitConverter.ToInt32(Buffer, GetIndex());

                    AddIndex(sizeof(int));

                    return value;
                }

                case Types.Uint:
                {
                    if (!IsValidPrefix(type, sizeof(uint))) return default;

                    value = (T)(object)BitConverter.ToUInt32(Buffer, GetIndex());

                    AddIndex(sizeof(uint));

                    return value;
                }

                case Types.Float:
                {
                    if (!IsValidPrefix(type, sizeof(float))) return default;

                    value = (T)(object)BitConverter.ToSingle(Buffer, GetIndex());

                    AddIndex(sizeof(float));

                    return value;
                }

                case Types.Long:
                {
                    if (!IsValidPrefix(type, sizeof(long))) return default;

                    value = (T)(object)BitConverter.ToInt64(Buffer, GetIndex());

                    AddIndex(sizeof(long));

                    return value;
                }

                case Types.Ulong:
                {
                    if (!IsValidPrefix(type, sizeof(ulong))) return default;

                    value = (T)(object)BitConverter.ToUInt64(Buffer, GetIndex());

                    AddIndex(sizeof(ulong));

                    return value;
                }
                case Types.Bool:
                {
                    if (!IsValidPrefix(type, sizeof(bool))) return default;

                    value = (T)(object)BitConverter.ToBoolean(Buffer, GetIndex());

                    AddIndex(sizeof(bool));

                    return value;
                }

                case Types.Char:
                {
                    if (!IsValidPrefix(type, sizeof(char))) return default;

                    value = (T)(object)BitConverter.ToChar(Buffer, GetIndex());

                    AddIndex(sizeof(char));

                    return value;
                }

                case Types.Short:
                {
                    if (!IsValidPrefix(type, sizeof(short))) return default;

                    value = (T)(object)BitConverter.ToInt16(Buffer, GetIndex());

                    AddIndex(sizeof(short));

                    return value;
                }

                case Types.Ushort:
                {
                    if (!IsValidPrefix(type, sizeof(short))) return default;

                    value = (T)(object)BitConverter.ToUInt16(Buffer, GetIndex());

                    AddIndex(sizeof(short));

                    return value;
                }

                case Types.Double:
                {
                    if (!IsValidPrefix(type, sizeof(double))) return default;

                    value = (T)(object)BitConverter.ToDouble(Buffer, GetIndex());

                    AddIndex(sizeof(double));

                    return value;
                }

                case Types.DateTime:
                {
                    if (!IsValidPrefix(type, sizeof(long))) return default;

                    value = (T)(object)DateTime.FromBinary(BitConverter.ToInt64(Buffer, GetIndex()));

                    AddIndex(sizeof(long));

                    return value;
                }
                case Types.Byte:
                {
                    if (!IsValidPrefix(type, sizeof(byte))) return default;

                    value = (T)(object)(byte)_vault[GetIndex()];

                    AddIndex(sizeof(byte));

                    return value;
                }

                case Types.Sbyte:
                {
                    if (!IsValidPrefix(type, sizeof(sbyte))) return default;

                    value = (T)(object)(sbyte)_vault[GetIndex()];

                    AddIndex(sizeof(sbyte));

                    return value;
                }

                case Types.Null:
                {
                    if (!IsValidPrefix(type, sizeof(sbyte))) return default;

                    sbyte data = (sbyte)_vault[GetIndex()];

                    if (data != -1)
                    {
                        IsValid = false;
                        return default;
                    }

                    value = (T)(object)data;

                    AddIndex(sizeof(sbyte));

                    return value;
                }

                case Types.Bytes:
                {
                    if (!IsValidPrefix(type, sizeof(int))) return default;

                    int size = BitConverter.ToInt32(Buffer, GetIndex());

                    int index = Index + sizeof(sbyte) + sizeof(int);

                    value = (T)(object)(byte[])_vault.GetRange(index, size).ToArray();

                    AddIndex(sizeof(int) + size);

                    return value;
                }

                case Types.String:
                {
                    if (!IsValidPrefix(type, sizeof(int))) return default;

                    int size = BitConverter.ToInt32(Buffer, GetIndex());

                    int index = Index + sizeof(sbyte) + sizeof(int);

                    value = (T)(object)(string)_vault.GetRange(index, size).ToArray().GetString(Encoding.UTF8);

                    AddIndex(sizeof(int) + size);

                    return value;
                }

                case Types.BigInteger:
                {
                    if (!IsValidPrefix(type, sizeof(int))) return default;

                    int size = BitConverter.ToInt32(Buffer, GetIndex());

                    int index = Index + sizeof(sbyte) + sizeof(int);

                    value = (T)(object)(BigInteger)new BigInteger(_vault.GetRange(index, size).ToArray());

                    AddIndex(sizeof(int) + size);

                    return value;
                }

                default:
                    throw new NotImplementedException($"{type}");
            }
        }
    }
}