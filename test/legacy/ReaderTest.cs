using System;
using System.Text;
using Byter;
using Xunit;

namespace ByterTest;

public class ReaderTest
{
    private const float FLOAT_X = 1024 * 2;
    private const float FLOAT_Y = 1024 * 4;
    private const float FLOAT_Z = 1024 * 6;
    private const float FLOAT_W = 1024 * 8;

    [Fact]
    public void ReadByte()
    {
        Writer writer = new();
        writer.Write((byte)255);

        Reader reader = new(ref writer);

        var result = reader.Read<byte>();
        Assert.Equal((byte)255, result);
        Assert.True(reader.Success);
    }

    [Fact]
    public void ReadBool()
    {
        Writer writer = new();
        writer.Write(true); // value 1
        writer.Write(false); // value 2
        writer.Write(true); // value 3

        Reader reader = new(ref writer);

        var value1 = reader.Read<bool>();
        var value2 = reader.Read<bool>();
        var value3 = reader.Read<bool>();

        Assert.True(value1);
        Assert.False(value2);
        Assert.True(value3);

        Assert.True(reader.Success);
    }

    [Fact]
    public void ReadBytes()
    {
        var target = new byte[] { 8, 16, 32, 64 };

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);

        var result = reader.Read<byte[]>();
        Assert.Equal(target, result);
        Assert.True(reader.Success);
    }

    [Fact]
    public void ReadShort()
    {
        var target = (short)-255;

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);

        var result = reader.Read<short>();
        Assert.Equal(target, result);
        Assert.True(reader.Success);
    }

    [Fact]
    public void ReadUShort()
    {
        var target = (ushort)255;

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);

        var result = reader.Read<ushort>();
        Assert.Equal(target, result);
        Assert.True(reader.Success);
    }

    [Fact]
    public void ReadInt()
    {
        var target = -255;

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);

        var result = reader.Read<int>();
        Assert.Equal(target, result);
        Assert.True(reader.Success);
    }

    [Fact]
    public void ReadUInt()
    {
        var target = (uint)255;

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);

        var result = reader.Read<uint>();
        Assert.Equal(target, result);
        Assert.True(reader.Success);
    }

    [Fact]
    public void ReadLong()
    {
        var target = (long)-255;

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);

        var result = reader.Read<long>();
        Assert.Equal(target, result);
        Assert.True(reader.Success);
    }

    [Fact]
    public void ReadULong()
    {
        var target = (ulong)255;

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);

        var result = reader.Read<ulong>();
        Assert.Equal(target, result);
        Assert.True(reader.Success);
    }

    [Fact]
    public void ReadFloat()
    {
        var target = 255.255f;

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);

        var result = reader.Read<float>();
        Assert.Equal(target, result);
        Assert.True(reader.Success);
    }

    [Fact]
    public void ReadDouble()
    {
        var target = 255.255d;

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);

        var result = reader.Read<double>();
        Assert.Equal(target, result);
        Assert.True(reader.Success);
    }

    [Fact]
    public void ReadChar()
    {
        var target = 'A';

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);

        var result = reader.Read<char>();
        Assert.Equal(target, result);
        Assert.True(reader.Success);
    }

    [Fact]
    public void ReadString()
    {
        var target = (string)"1234.1234.1234.1234";

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);

        var result = reader.Read<string>();
        Assert.Equal(target, result);
        Assert.True(reader.Success);
    }

    [Fact]
    public void TryMakeError()
    {
        var target = 1;

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(writer.GetBytes());

        var result = reader.Read<int>();
        Assert.Equal(target, result);
        Assert.True(reader.Success);

        var result2 = reader.Read<long>();
        Assert.NotEqual(2, result2);
        Assert.Equal(default, result2);
        Assert.False(reader.Success);
    }

    [Fact]
    public void ReadFloat2()
    {
        var target = new Float2(1, 2);

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);

        var result = reader.Read<Float2>();
        Assert.Equal(target, result);
        Assert.True(reader.Success);
    }

    [Fact]
    public void ReadFloat3()
    {
        var target = new Float3(1, 2, 3);

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);

        var result = reader.Read<Float3>();
        Assert.Equal(target, result);
        Assert.True(reader.Success);
    }

    [Fact]
    public void ImplFloat2()
    {
        var result = new Float2(FLOAT_X, FLOAT_Y);

        Assert.Equal(FLOAT_X, result.X);
        Assert.Equal(FLOAT_Y, result.Y);
    }

    [Fact]
    public void ImplFloat3()
    {
        var result = new Float3(FLOAT_X, FLOAT_Y, FLOAT_Z);

        Assert.Equal(FLOAT_X, result.X);
        Assert.Equal(FLOAT_Y, result.Y);
        Assert.Equal(FLOAT_Z, result.Z);
    }

    [Fact]
    public void ImplFloat4()
    {
        var result = new Float4(FLOAT_X, FLOAT_Y, FLOAT_Z, FLOAT_W);

        Assert.Equal(FLOAT_X, result.X);
        Assert.Equal(FLOAT_Y, result.Y);
        Assert.Equal(FLOAT_Z, result.Z);
        Assert.Equal(FLOAT_W, result.W);
    }

    [Fact]
    public void ReadFromEmptyBuffer()
    {
        var r = new Reader(Array.Empty<byte>());

        Assert.True(r.Success);

        _ = r.Read<string>(Encoding.ASCII);

        Assert.False(r.Success);
    }

    [Fact]
    public void ReadFromNullBuffer()
    {
        var r = new Reader(null);

        Assert.True(r.Success);

        _ = r.Read<string>(Encoding.ASCII);

        Assert.False(r.Success);
    }

    [Fact]
    public void ReadFromOneByteBuffer()
    {
        var r = new Reader([0]);

        Assert.True(r.Success);

        _ = r.Read<string>(Encoding.ASCII);

        Assert.False(r.Success);
    }
}