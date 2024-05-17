using System;
using System.Net.Sockets;
using System.Numerics;
using Byter;
using Xunit;

namespace ByterTest.by;

public class ByWriteAndRead
{
    public ByWriteAndRead()
    {
        
    }
    
    [Fact]
    public void ByInt()
    {
        var b = new By();

        b.Add(int.MinValue);
        b.Add(int.MaxValue);

        Assert.Equal(int.MinValue, b.Get<int>());
        Assert.Equal(int.MaxValue, b.Get<int>());
        Assert.True(b.IsValid);
    }

    [Fact]
    public void ByUInt()
    {
        var b = new By();

        b.Add(uint.MinValue);
        b.Add(uint.MaxValue);

        Assert.Equal(uint.MinValue, b.Get<uint>());
        Assert.Equal(uint.MaxValue, b.Get<uint>());
        Assert.True(b.IsValid);
    }

    [Fact]
    public void ByLong()
    {
        var b = new By();

        b.Add(long.MinValue);
        b.Add(long.MaxValue);

        Assert.Equal(long.MinValue, b.Get<long>());
        Assert.Equal(long.MaxValue, b.Get<long>());
        Assert.True(b.IsValid);
    }

    [Fact]
    public void ByULong()
    {
        var b = new By();

        b.Add(ulong.MinValue);
        b.Add(ulong.MaxValue);

        Assert.Equal(ulong.MinValue, b.Get<ulong>());
        Assert.Equal(ulong.MaxValue, b.Get<ulong>());
        Assert.True(b.IsValid);
    }

    [Fact]
    public void ByFloat()
    {
        var b = new By();

        b.Add(float.MinValue);
        b.Add(float.MaxValue);

        Assert.Equal(float.MinValue, b.Get<float>());
        Assert.Equal(float.MaxValue, b.Get<float>());
        Assert.True(b.IsValid);
    }

    [Fact]
    public void ByShort()
    {
        var b = new By();

        b.Add(short.MinValue);
        b.Add(short.MaxValue);

        Assert.Equal(short.MinValue, b.Get<short>());
        Assert.Equal(short.MaxValue, b.Get<short>());
        Assert.True(b.IsValid);
    }

    [Fact]
    public void ByUShort()
    {
        var b = new By();

        b.Add(ushort.MinValue);
        b.Add(ushort.MaxValue);

        Assert.Equal(ushort.MinValue, b.Get<ushort>());
        Assert.Equal(ushort.MaxValue, b.Get<ushort>());
        Assert.True(b.IsValid);
    }

    [Fact]
    public void Byte()
    {
        var b = new By();

        b.Add(byte.MinValue);
        b.Add(byte.MaxValue);

        Assert.Equal(byte.MinValue, b.Get<byte>());
        Assert.Equal(byte.MaxValue, b.Get<byte>());
        Assert.True(b.IsValid);
    }

    [Fact]
    public void SByte()
    {
        var b = new By();

        b.Add(sbyte.MinValue);
        b.Add(sbyte.MaxValue);

        Assert.Equal(sbyte.MinValue, b.Get<sbyte>());
        Assert.Equal(sbyte.MaxValue, b.Get<sbyte>());
        Assert.True(b.IsValid);
    }

    [Fact]
    public void ByDouble()
    {
        var b = new By();

        b.Add(double.MinValue);
        b.Add(double.MaxValue);

        Assert.Equal(double.MinValue, b.Get<double>());
        Assert.Equal(double.MaxValue, b.Get<double>());
        Assert.True(b.IsValid);
    }

    [Fact]
    public void ByDecimal()
    {
        var b = new By();

        b.Add(decimal.MinValue);
        b.Add(decimal.MaxValue);

        Assert.Equal(decimal.MinValue, b.Get<decimal>());
        Assert.Equal(decimal.MaxValue, b.Get<decimal>());
        Assert.True(b.IsValid);
    }

    [Fact]
    public void ByNull()
    {
        var b = new By();

        b.Add(string.Empty);
        b.Add(Array.Empty<byte>());
        b.Add(BigInteger.Zero);

        Assert.Equal(string.Empty, b.Get<string>());
        Assert.Equal(Array.Empty<byte>(), b.Get<byte[]>());
        Assert.Equal(BigInteger.Zero, b.Get<BigInteger>());
        Assert.True(b.IsValid);
    }

    [Fact]
    public void ByDateTime()
    {
        var b = new By();

        var y1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0, 0);
        var y2038 = new DateTime(2038, 1, 1, 0, 0, 0, 0, 0);

        b.Add(y1970);
        b.Add(y2038);

        Assert.Equal(y1970, b.Get<DateTime>());
        Assert.Equal(y2038, b.Get<DateTime>());
        Assert.True(b.IsValid);
    }

    [Fact]
    public void ByBytes()
    {
        var b = new By();

        byte[] b1 = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        byte[] b2 = [9, 8, 7, 6, 5, 4, 3, 2, 1];

        b.Add(b1);
        b.Add(b2);

        Assert.Equal(b1, b.Get<byte[]>());
        Assert.Equal(b2, b.Get<byte[]>());
        Assert.True(b.IsValid);
    }

    [Fact]
    public void ByChar()
    {
        var b = new By();

        b.Add('A');
        b.Add('L');
        b.Add('E');
        b.Add('C');
        b.Add('1');
        b.Add('O');

        Assert.Equal('A', b.Get<char>());
        Assert.Equal('L', b.Get<char>());
        Assert.Equal('E', b.Get<char>());
        Assert.Equal('C', b.Get<char>());
        Assert.Equal('1', b.Get<char>());
        Assert.Equal('O', b.Get<char>());
        Assert.True(b.IsValid);
    }

    [Fact]
    public void ByBool()
    {
        var b = new By();

        b.Add(true);
        b.Add(true);
        b.Add(false);
        b.Add(true);
        b.Add(false);
        b.Add(false);

        Assert.True(b.Get<bool>());
        Assert.True(b.Get<bool>());
        Assert.False(b.Get<bool>());
        Assert.True(b.Get<bool>());
        Assert.False(b.Get<bool>());
        Assert.False(b.Get<bool>());
        Assert.True(b.IsValid);
    }

    [Fact]
    public void ByString()
    {
        var b = new By();

        var s1 = Guid.NewGuid().ToString();
        var s2 = Guid.NewGuid().ToString();
        var s3 = Guid.NewGuid().ToString();
        var s4 = Guid.NewGuid().ToString();

        b.Add(s1);
        b.Add(s2);
        b.Add(s3);
        b.Add(s4);

        Assert.Equal(s1, b.Get<string>());
        Assert.Equal(s2, b.Get<string>());
        Assert.Equal(s3, b.Get<string>());
        Assert.Equal(s4, b.Get<string>());
        Assert.True(b.IsValid);
    }

    [Fact]
    public void ByBigInteger()
    {
        var b = new By();

        const string data = "01234567891011121314151617181920212223242526272829303132";

        BigInteger b1 = BigInteger.Parse("1970" + data);
        BigInteger b2 = BigInteger.Parse("2038" + data);

        b.Add(b1);
        b.Add(b2);

        Assert.Equal(b1, b.Get<BigInteger>());
        Assert.Equal(b2, b.Get<BigInteger>());
        Assert.True(b.IsValid);
    }

    [Fact]
    public void ByEnum()
    {
        By b = new By();

        b.Add(SocketType.Unknown);
        b.Add(SocketType.Stream);
        b.Add(SocketType.Dgram);
        b.Add(SocketType.Raw);
        b.Add(SocketType.Rdm);
        b.Add(SocketType.Seqpacket);

        Assert.Equal(SocketType.Unknown, b.Get<SocketType>());
        Assert.Equal(SocketType.Stream, b.Get<SocketType>());
        Assert.Equal(SocketType.Dgram, b.Get<SocketType>());
        Assert.Equal(SocketType.Raw, b.Get<SocketType>());
        Assert.Equal(SocketType.Rdm, b.Get<SocketType>());
        Assert.Equal(SocketType.Seqpacket, b.Get<SocketType>());

        Assert.True(b.IsValid);
    }

    [Fact(Skip = "TODO")]
    public void ByArray()
    {
        int[] intArray =
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 0
        };

        char[] charArray =
        {
            'A', 'L', 'E', 'C', 'I', 'O', ' ', 'F', 'U', 'R', 'A', 'N', 'Z', 'E'
        };

        By b = new By();

        b.Add(intArray);
        b.Add(charArray);

        Assert.Equal(intArray, b.Get<int[]>());
        Assert.Equal(charArray, b.Get<char[]>());

        Assert.True(b.IsValid);
    }

    [Fact(Skip = "TODO")]
    public void ByList()
    {
    }

    [Fact(Skip = "TODO")]
    public void ByStruct()
    {
    }

    public class MyClass
    {
        public int MyInt { get; set; }
        public string MyString { get; set; }
        public byte MyByte { get; set; }
        public char MyChar { get; set; }
        public sbyte MySbyte { get; set; }
        public byte[] MyBytes { get; set; }
        public long MyLong { get; set; }
        public double MyDouble { get; set; }
        public bool MyBool { get; set; }
        public float MyFloat { get; set; }
        public DateTime DateTime { get; set; }
        public decimal MyDecimal { get; set; }
        public MyClass2 MyNewClass2 { get; set; }

        public class MyClass2
        {
            public string MyString { get; set; }
            public double MyDouble { get; set; }
        }
    }

    [Fact]
    public void ByClass()
    {
        MyClass myClass = new()
        {
            MyInt = int.MaxValue,
            MyString = "alecio",
            MyByte = byte.MaxValue,
            MyChar = 'A',
            MySbyte = sbyte.MinValue,
            MyBytes = [1, 2, 3, 4],
            MyLong = long.MaxValue,
            MyDouble = double.MaxValue,
            MyBool = true,
            MyFloat = float.MaxValue,
            DateTime = new DateTime(1970, 1, 1),
            MyDecimal = decimal.MaxValue,
            MyNewClass2 = new MyClass.MyClass2()
            {
                MyString = "Byter",
                MyDouble = double.MinValue,
            }
        };

        By b = new By();
        b.Add(myClass);

        Assert.Equal(myClass, b.Get<MyClass>());
    }
}