using System;
using Xunit;
using Byter;

namespace ByterTest;

public class ReaderTest
{

    [Fact]
    public void ReadByte()
    {
        Writer writer = new();
        writer.Write((byte)255);

        Reader reader = new(ref writer);
        
        var result = reader.Read<byte>(); 
        Assert.Equal((byte)255, result);
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
    }

    [Fact]
    public void ReadShort()
    {
        var target = (short) -255;

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);
        
        var result = reader.Read<short>(); 
        Assert.Equal(target, result);
    }

    [Fact]
    public void ReadUShort()
    {
        var target = (ushort) 255;

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);
        
        var result = reader.Read<ushort>(); 
        Assert.Equal(target, result);
    }

    [Fact]
    public void ReadInt()
    {
        var target = (int) -255;

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);
        
        var result = reader.Read<int>(); 
        Assert.Equal(target, result);
    }

    [Fact]
    public void ReadUInt()
    {
        var target = (uint) 255;

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);
        
        var result = reader.Read<uint>(); 
        Assert.Equal(target, result);
    }

    [Fact]
    public void ReadLong()
    {
        var target = (long) -255;

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);
        
        var result = reader.Read<long>(); 
        Assert.Equal(target, result);
    }

    [Fact]
    public void ReadULong()
    {
        var target = (ulong) 255;

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);
        
        var result = reader.Read<ulong>(); 
        Assert.Equal(target, result);
    }

    [Fact]
    public void ReadFloat()
    {
        var target = (float) 255.255f;

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);
        
        var result = reader.Read<float>(); 
        Assert.Equal(target, result);
    }

    [Fact]
    public void ReadDouble()
    {
        var target = (double) 255.255d;

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);
        
        var result = reader.Read<double>(); 
        Assert.Equal(target, result);
    }

    [Fact]
    public void ReadChar()
    {
        var target = (char) 'A';

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);
        
        var result = reader.Read<char>(); 
        Assert.Equal(target, result);
    }

    [Fact]
    public void ReadString()
    {
        var target = (string) "1234.1234.1234.1234";

        Writer writer = new();
        writer.Write(target);

        Reader reader = new(ref writer);
        
        var result = reader.Read<string>(); 
        Assert.Equal(target, result);
    }
}