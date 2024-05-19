using System;
using System.Collections.Generic;
using System.Numerics;
using Byter;
using Xunit;

namespace ByterTest.primitive;

public class ReadAndWrite : IPrimitiveGet
{
    [Fact]
    public bool Bool()
    {
        Primitive primitive = new();

        primitive.Add.Bool(true);
        primitive.Add.Bool(false);
        primitive.Add.Bool(false);
        primitive.Add.Bool(true);

        Assert.True(primitive.Get.Bool());
        Assert.False(primitive.Get.Bool());
        Assert.False(primitive.Get.Bool());
        Assert.True(primitive.Get.Bool());

        return default;
    }

    [Fact]
    public byte Byte()
    {
        Primitive primitive = new();

        primitive.Add.Byte(byte.MinValue);
        primitive.Add.Byte(byte.MaxValue);

        Assert.Equal(byte.MinValue, primitive.Get.Byte());
        Assert.Equal(byte.MaxValue, primitive.Get.Byte());

        return default;
    }

    [Fact]
    public sbyte SByte()
    {
        Primitive primitive = new();

        primitive.Add.SByte(sbyte.MinValue);
        primitive.Add.SByte(sbyte.MaxValue);

        Assert.Equal(sbyte.MinValue, primitive.Get.SByte());
        Assert.Equal(sbyte.MaxValue, primitive.Get.SByte());

        return default;
    }

    [Fact]
    public char Char()
    {
        return default;
    }

    [Fact]
    public short Short()
    {
        Primitive primitive = new();

        primitive.Add.Short(short.MinValue);
        primitive.Add.Short(short.MaxValue);

        Assert.Equal(short.MinValue, primitive.Get.Short());
        Assert.Equal(short.MaxValue, primitive.Get.Short());

        return default;
    }

    [Fact]
    public ushort UShort()
    {
        Primitive primitive = new();

        primitive.Add.UShort(ushort.MinValue);
        primitive.Add.UShort(ushort.MaxValue);

        Assert.Equal(ushort.MinValue, primitive.Get.UShort());
        Assert.Equal(ushort.MaxValue, primitive.Get.UShort());

        return default;
    }

    [Fact]
    public int Int()
    {
        Primitive primitive = new();

        primitive.Add.Int(int.MinValue);
        primitive.Add.Int(int.MaxValue);

        Assert.Equal(int.MinValue, primitive.Get.Int());
        Assert.Equal(int.MaxValue, primitive.Get.Int());

        return default;
    }

    [Fact]
    public uint UInt()
    {
        Primitive primitive = new();

        primitive.Add.UInt(uint.MinValue);
        primitive.Add.UInt(uint.MaxValue);

        Assert.Equal(uint.MinValue, primitive.Get.UInt());
        Assert.Equal(uint.MaxValue, primitive.Get.UInt());

        return default;
    }

    [Fact]
    public float Float()
    {
        Primitive primitive = new();

        primitive.Add.Float(float.MinValue);
        primitive.Add.Float(float.MaxValue);

        Assert.Equal(float.MinValue, primitive.Get.Float());
        Assert.Equal(float.MaxValue, primitive.Get.Float());

        return default;
    }

    public T? Enum<T>()
    {
        return default;
    }

    [Fact]
    public long Long()
    {
        Primitive primitive = new();

        primitive.Add.Long(long.MinValue);
        primitive.Add.Long(long.MaxValue);

        Assert.Equal(long.MinValue, primitive.Get.Long());
        Assert.Equal(long.MaxValue, primitive.Get.Long());

        return default;
    }

    [Fact]
    public ulong ULong()
    {
        Primitive primitive = new();

        primitive.Add.ULong(ulong.MinValue);
        primitive.Add.ULong(ulong.MaxValue);

        Assert.Equal(ulong.MinValue, primitive.Get.ULong());
        Assert.Equal(ulong.MaxValue, primitive.Get.ULong());

        return default;
    }

    [Fact]
    public double Double()
    {
        Primitive primitive = new();

        primitive.Add.Double(double.MinValue);
        primitive.Add.Double(double.MaxValue);

        Assert.Equal(double.MinValue, primitive.Get.Double());
        Assert.Equal(double.MaxValue, primitive.Get.Double());

        return default;
    }

    [Fact]
    public DateTime DateTime()
    {
        return default;
    }

    [Fact]
    public decimal Decimal()
    {
        Primitive primitive = new();

        primitive.Add.Decimal(decimal.MinValue);
        primitive.Add.Decimal(decimal.MaxValue);

        Assert.Equal(decimal.MinValue, primitive.Get.Decimal());
        Assert.Equal(decimal.MaxValue, primitive.Get.Decimal());

        return default;
    }

    #region Unused

    public string? String()
    {
        return default;
    }

    public T? Class<T>()
    {
        return default;
    }

    public T? Struct<T>()
    {
        return default;
    }

    public IList<T>? Array<T>()
    {
        return default;
    }

    public List<T>? List<T>()
    {
        return default;
    }

    #endregion

    [Fact]
    public BigInteger BigInteger()
    {
        return default;
    }

    [Fact]
    public byte[]? Bytes()
    {
        return default;
    }

    [Fact]
    public void _Enum()
    {
    }

    [Fact]
    public void _String()
    {
    }

    [Fact]
    public void _Class()
    {
    }

    [Fact]
    public void _Struct()
    {
    }

    [Fact]
    public void _Array()
    {
    }

    [Fact]
    public void _List()
    {
    }
}