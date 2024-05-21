using System.Text;
using System.Collections.Generic;

namespace Byter.Legacy
{
    internal interface IWriter
    {
        int Length { get; }

        byte[] GetBytes();
        List<byte> GetList();

        void Write(byte value);
        void Write(byte[] value);
        void Write(short value);
        void Write(ushort value);
        void Write(int value);
        void Write(uint value);
        void Write(long value);
        void Write(ulong value);
        void Write(float value);
        void Write(double value);
        void Write(char value);
        void Write(string value);        
        void Write(string value1, Encoding value2);
        void Write(ByFloat2 value);
        void Write(ByFloat3 value);

        void Clear();
    }
}
