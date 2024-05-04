using System;
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
            byte[] buffer;

            switch (type)
            {
                case Types.Bool:
                {
                    buffer = BitConverter.GetBytes((bool)data);
                    break;
                }
                case Types.Byte:
                {
                    buffer = BitConverter.GetBytes((byte)data);
                    break;
                }
                case Types.Char:
                {
                    buffer = BitConverter.GetBytes((char)data);
                    break;
                }
                case Types.Bytes:
                {
                    buffer = (byte[])data;
                    break;
                }
                case Types.Float:
                {
                    buffer = BitConverter.GetBytes((float)data);
                    break;
                }
                case Types.Int:
                {
                    buffer = BitConverter.GetBytes((int)data);
                    break;
                }
                case Types.Ulong:
                {
                    buffer = BitConverter.GetBytes((ulong)data);
                    break;
                }
                case Types.Ushort:
                {
                    buffer = BitConverter.GetBytes((ushort)data);
                    break;
                }
                case Types.Short:
                {
                    buffer = BitConverter.GetBytes((short)data);
                    break;
                }
                case Types.Sbyte:
                {
                    buffer = BitConverter.GetBytes((sbyte)data);
                    break;
                }
                case Types.BigInteger:
                {
                    buffer = ((BigInteger)data).ToByteArray();
                    break;
                }
                case Types.Long:
                {
                    buffer = BitConverter.GetBytes((long)data);
                    break;
                }
                case Types.String:
                {
                    buffer = Encoding.UTF8.GetBytes((string)data);
                    break;
                }
                case Types.Double:
                {
                    buffer = BitConverter.GetBytes((double)data);
                    break;
                }
                case Types.Null:
                {
                    buffer = BitConverter.GetBytes((sbyte)-1);
                    break;
                }
                default:
                {
                    throw new NotImplementedException();
                }
            }

        }
    }
}