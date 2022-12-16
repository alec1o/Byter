using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Byter.Core.Interface
{
    internal interface IWriter
    {
        int Length { get; }
        int Position { get; }

        byte[] GetBytes();
        List<byte> GetList();
        void Write<T>(T value);
        void Write<T>(T value, Encoding encode);
        void Seek(int position);
    }
}