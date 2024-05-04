using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Byter
{
    public partial class By : IBy
    {
        public void Add<T>(T value)
        {
            Types type = Hash(value);

            object data = value;
            byte prefix = (byte)type;
            List<byte> buffer = new List<byte>();

            switch (type)
            {
                case Types.Bool:
                {
                    buffer.AddRange(BitConverter.GetBytes((bool)data));
                    break;
                }
                case Types.Byte:
                {
                    buffer.AddRange(BitConverter.GetBytes((byte)data));
                    break;
                }
                case Types.Char:
                {
                    buffer.AddRange(BitConverter.GetBytes((char)data));
                    break;
                }
                case Types.Bytes:
                {
                    var bytes = (byte[])data;
                    var size = BitConverter.GetBytes(bytes.Length);
                    buffer.AddRange(size);
                    buffer.AddRange(bytes);
                    break;
                }
                case Types.Float:
                {
                    buffer.AddRange(BitConverter.GetBytes((float)data));
                    break;
                }
                case Types.Int:
                {
                    buffer.AddRange(BitConverter.GetBytes((int)data));
                    break;
                }
                case Types.Uint:
                {
                    buffer.AddRange(BitConverter.GetBytes((uint)data));
                    break;
                }
                case Types.Ulong:
                {
                    buffer.AddRange(BitConverter.GetBytes((ulong)data));
                    break;
                }
                case Types.Ushort:
                {
                    buffer.AddRange(BitConverter.GetBytes((ushort)data));
                    break;
                }
                case Types.Short:
                {
                    buffer.AddRange(BitConverter.GetBytes((short)data));
                    break;
                }
                case Types.Sbyte:
                {
                    buffer.AddRange(BitConverter.GetBytes((sbyte)data));
                    break;
                }
                case Types.BigInteger:
                {
                    var bytes = ((BigInteger)data).ToByteArray();
                    var size = BitConverter.GetBytes(bytes.Length);
                    buffer.AddRange(size);
                    buffer.AddRange(bytes);
                    break;
                }
                case Types.Long:
                {
                    buffer.AddRange(BitConverter.GetBytes((long)data));
                    break;
                }
                case Types.String:
                {
                    var bytes = ((string)data).GetBytes(Encoding.UTF8);
                    var size = BitConverter.GetBytes(bytes.Length);
                    buffer.AddRange(size);
                    buffer.AddRange(bytes);
                    break;
                }
                case Types.Double:
                {
                    buffer.AddRange(BitConverter.GetBytes((double)data));
                    break;
                }
                case Types.Null:
                {
                    buffer.AddRange(BitConverter.GetBytes((sbyte)-1));
                    break;
                }
                case Types.Decimal:
                {
                    // TODO: create own implementation to be 100% precise
                    buffer.AddRange(BitConverter.GetBytes(Decimal.ToOACurrency((decimal)data)));
                    break;
                }
                case Types.DateTime:
                {
                    buffer.AddRange(BitConverter.GetBytes(((DateTime)data).ToBinary()));
                    break;
                }
                default:
                {
                    throw new NotImplementedException();
                }
            }

            _vault.Add(prefix);
            _vault.AddRange(buffer);
        }
    }
}