using System;
using System.Collections.Generic;

namespace Byter
{
    internal interface IBy
    {
        int Index { get; }
        bool IsValid { get; }
        byte[] Buffer { get; }
        
        void Reset();
        void Add<T>(T value);
        T Get<T>();
    }
}