using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using Byter;
using Xunit;

namespace ByterTest.by;

public class ByHash
{
    struct MyStruct
    {
        private const float A = -1;
        private const float B = -1;
    }

    class MyClass
    {
        private const float A = -1;
        private const float B = -1;
    }

    [Fact]
    public void Start()
    {
        object? @null = null;
        sbyte @sbyte = -32;
        byte @byte = 42;
        bool @bool = true;
        char @char = 'A';
        int @int = int.MaxValue;
        float @float = float.MinValue;
        uint @uint = uint.MaxValue;
        long @long = long.MaxValue;
        ulong @ulong = ulong.MaxValue;
        DateTime date = DateTime.Now;
        short @short = short.MaxValue;
        ushort @ushort = ushort.MaxValue;
        string @string = Guid.NewGuid().ToString();
        double @double = double.MaxValue;
        decimal @decimal = decimal.MaxValue;
        SocketType @enum = SocketType.Stream;
        byte[] bytes = Encoding.UTF8.GetBytes("By");
        MyStruct @struct = new MyStruct();
        List<int> list = [1, 2, 3];
        int[] array = [1, 2, 3];
        MyClass @class = new MyClass();
        BigInteger big = BigInteger.One;

        Assert.Equal(By.Types.Null, By.Hash(@null));
        Assert.Equal(By.Types.Sbyte, By.Hash(@sbyte));
        Assert.Equal(By.Types.Byte, By.Hash(@byte));
        Assert.Equal(By.Types.Bool, By.Hash(@bool));
        Assert.Equal(By.Types.Char, By.Hash(@char));
        Assert.Equal(By.Types.Short, By.Hash(@short));
        Assert.Equal(By.Types.Ushort, By.Hash(@ushort));
        Assert.Equal(By.Types.Uint, By.Hash(@uint));
        Assert.Equal(By.Types.Int, By.Hash(@int));
        Assert.Equal(By.Types.Float, By.Hash(@float));
        Assert.Equal(By.Types.Enum, By.Hash(@enum));
        Assert.Equal(By.Types.Long, By.Hash(@long));
        Assert.Equal(By.Types.Ulong, By.Hash(@ulong));
        Assert.Equal(By.Types.Double, By.Hash(@double));
        Assert.Equal(By.Types.Decimal, By.Hash(@decimal));
        Assert.Equal(By.Types.Bytes, By.Hash(bytes));
        Assert.Equal(By.Types.String, By.Hash(@string));
        Assert.Equal(By.Types.BigInteger, By.Hash(@big));
        Assert.Equal(By.Types.Class, By.Hash(@class));
        Assert.Equal(By.Types.Struct, By.Hash(@struct));
        Assert.Equal(By.Types.DateTime, By.Hash(date));
        Assert.Equal(By.Types.Array, By.Hash(@array));
        Assert.Equal(By.Types.List, By.Hash(list));
    }
}