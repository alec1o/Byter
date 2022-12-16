using System;
using System.Collections;

namespace Byter.Core.Interface
{
    internal interface IReader
    {
        int Length { get; }
        int Position { get; }
        bool Success { get; }

        T Read<T>(T type);
        void Seek(int position);
    }
}