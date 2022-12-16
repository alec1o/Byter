using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Byter.Core.Interface
{
    internal interface IWriter
    {
        int Length { get; }

        byte[] GetBytes();
        List<byte> GetList();

        void Write(byte a);
        void Write(byte[] a);
        void Write(short a);
        void Write(ushort a);
        void Write(int a);
        void Write(uint a);
        void Write(long a);
        void Write(ulong a);
        void Write(float a);
        void Write(double a);
        void Write(char a);
        void Write(string a);        
        void Write(string a, Encoding b);

        void Clear();
    }
}