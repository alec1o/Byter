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
                default:
                {
                    throw new NotImplementedException();
                }
            }

        }
    }
}