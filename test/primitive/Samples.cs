//#define IS_COMPLEX

using System;
using System.Collections.Generic;
using System.Numerics;
using Byter;

namespace ByterTest.primitive;

public static class Macro
{
    public static readonly Random Random = new();
}

public class MyFilmClass
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public string Director { get; set; }
}

public struct MyFilmStruct
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public string Director { get; set; }
}

public class ComplexClass
{
    public bool Bool { get; set; }
    public byte Byte { get; set; }
    public sbyte SByte { get; set; }
    public char Char { get; set; }
    public short Short { get; set; }
    public ushort UShort { get; set; }
    public int Int { get; set; }
    public uint UInt { get; set; }
    public float Float { get; set; }
    public long Long { get; set; }
    public ulong ULong { get; set; }
    public double Double { get; set; }
    public DateTime DateTime { get; set; }
    public decimal Decimal { get; set; }
    public string String { get; set; }
    public BigInteger BigInteger { get; set; }
    public byte[] Bytes { get; set; }
    public ComplexEnum Enum { get; set; }
#if IS_COMPLEX
    public ComplexSubClass Class { get; set; }
    public ComplexSubStruct Struct { get; set; }
    public ComplexArrayObject[] Array { get; set; }
    public List<ComplexListObject> List { get; set; }
#endif

    public static ComplexClass GetRandom()
    {
        return new ComplexClass
        {
            Bool = Macro.Random.Next(-100, 100) > 0,
            Byte = (byte)Macro.Random.Next(0, 255),
            SByte = (sbyte)Macro.Random.Next(-127, 127),
            Char = Macro.Random.Next(-100, 100) > 0 ? 'A' : 'B',
            Short = (short)Macro.Random.Next(short.MinValue, short.MaxValue),
            UShort = (ushort)Macro.Random.Next(ushort.MinValue, ushort.MaxValue),
            Int = Macro.Random.Next(int.MinValue, int.MaxValue),
            UInt = uint.MaxValue - (uint)Macro.Random.Next(byte.MaxValue, short.MaxValue),
            Float = float.MaxValue / Macro.Random.Next(short.MinValue, short.MaxValue),
            Long = Macro.Random.NextInt64(long.MinValue, long.MaxValue),
            ULong = ulong.MaxValue - (ulong)Macro.Random.Next(0, 255),
            Double = double.MaxValue - Macro.Random.Next(0, 255),
            DateTime = DateTime.Now.AddMilliseconds(Macro.Random.Next(int.MinValue, int.MaxValue)),
            Decimal = decimal.MaxValue / Macro.Random.Next(-255, 255),
            String = Guid.NewGuid().ToString(),
            BigInteger = BigInteger.Parse(long.MaxValue + int.MaxValue.ToString()),
            Bytes = Guid.NewGuid().ToString().GetBytes(),
            Enum = Macro.Random.Next(-100, 100) > 0 ? ComplexEnum.Value1 : ComplexEnum.Value3,
#if IS_COMPLEX
            Class = ComplexSubClass.GetRandom(),
            Struct = ComplexSubStruct.GetRandom(),
            Array = ComplexArrayObject.GetRandomArray(),
            List = ComplexListObject.GetRandomList(),
#endif
        };
    }
}

public struct ComplexStruct
{
    public bool Bool { get; set; }
    public byte Byte { get; set; }
    public sbyte SByte { get; set; }
    public char Char { get; set; }
    public short Short { get; set; }
    public ushort UShort { get; set; }
    public int Int { get; set; }
    public uint UInt { get; set; }
    public float Float { get; set; }
    public long Long { get; set; }
    public ulong ULong { get; set; }
    public double Double { get; set; }
    public DateTime DateTime { get; set; }
    public decimal Decimal { get; set; }
    public string String { get; set; }
    public BigInteger BigInteger { get; set; }
    public byte[] Bytes { get; set; }
    public ComplexEnum Enum { get; set; }
#if IS_COMPLEX
    public ComplexSubClass Class { get; set; }
    public ComplexSubStruct Struct { get; set; }
    public ComplexArrayObject[] Array { get; set; }
    public List<ComplexListObject> List { get; set; }
#endif

    public static ComplexStruct GetRandom()
    {
        return new ComplexStruct
        {
            Bool = Macro.Random.Next(-100, 100) > 0,
            Byte = (byte)Macro.Random.Next(0, 255),
            SByte = (sbyte)Macro.Random.Next(-127, 127),
            Char = Macro.Random.Next(-100, 100) > 0 ? 'A' : 'B',
            Short = (short)Macro.Random.Next(short.MinValue, short.MaxValue),
            UShort = (ushort)Macro.Random.Next(ushort.MinValue, ushort.MaxValue),
            Int = Macro.Random.Next(int.MinValue, int.MaxValue),
            UInt = uint.MaxValue - (uint)Macro.Random.Next(byte.MaxValue, short.MaxValue),
            Float = float.MaxValue / Macro.Random.Next(short.MinValue, short.MaxValue),
            Long = Macro.Random.NextInt64(long.MinValue, long.MaxValue),
            ULong = ulong.MaxValue - (ulong)Macro.Random.Next(0, 255),
            Double = double.MaxValue - Macro.Random.Next(0, 255),
            DateTime = DateTime.Now.AddMilliseconds(Macro.Random.Next(int.MinValue, int.MaxValue)),
            Decimal = decimal.MaxValue / Macro.Random.Next(-255, 255),
            String = Guid.NewGuid().ToString(),
            BigInteger = BigInteger.Parse(long.MaxValue + int.MaxValue.ToString()),
            Bytes = Guid.NewGuid().ToString().GetBytes(),
            Enum = Macro.Random.Next(-100, 100) > 0 ? ComplexEnum.Value1 : ComplexEnum.Value3,
#if IS_COMPLEX
            Class = ComplexSubClass.GetRandom(),
            Struct = ComplexSubStruct.GetRandom(),
            Array = ComplexArrayObject.GetRandomArray(),
            List = ComplexListObject.GetRandomList(),
#endif
        };
    }
}

public enum ComplexEnum
{
    Value1 = 8080,
    Value2 = -360,
    Value3 = 360,
    Value4 = -720,
    Value5 = 720
}

public class ComplexListObject
{
    public DateTime DateTime { get; set; }
    public decimal Decimal { get; set; }
    public string String { get; set; }

    public static ComplexListObject GetRandom()
    {
        return new ComplexListObject
        {
            DateTime = DateTime.UtcNow.AddMicroseconds(Macro.Random.Next(0, int.MaxValue)),
            Decimal = decimal.MaxValue / Macro.Random.Next(short.MinValue, short.MaxValue),
            String = Guid.NewGuid().ToString()
        };
    }

    public static List<ComplexListObject> GetRandomList()
    {
        var round = Macro.Random.Next(5, byte.MaxValue);
        List<ComplexListObject> list = new();

        for (var i = 0; i < round; i++) list.Add(GetRandom());

        return list;
    }
}

public struct ComplexArrayObject
{
    public DateTime DateTime { get; set; }
    public decimal Decimal { get; set; }
    public string String { get; set; }

    public static ComplexArrayObject GetRandom()
    {
        return new ComplexArrayObject
        {
            DateTime = DateTime.UtcNow.AddMicroseconds(Macro.Random.Next(0, int.MaxValue)),
            Decimal = decimal.MaxValue / Macro.Random.Next(short.MinValue, short.MaxValue),
            String = Guid.NewGuid().ToString()
        };
    }

    public static ComplexArrayObject[] GetRandomArray()
    {
        var round = Macro.Random.Next(5, byte.MaxValue);
        List<ComplexArrayObject> list = new();

        for (var i = 0; i < round; i++) list.Add(GetRandom());

        return list.ToArray();
    }
}

public class ComplexSubClass
{
    public float Float { get; set; }
    public ComplexEnum Enum { get; set; }
    public DateTime DateTime { get; set; }
    public decimal Decimal { get; set; }
    public string String { get; set; }
    public ComplexArrayObject[] Array { get; set; }
    public List<ComplexListObject> List { get; set; }
    public byte[] Bytes { get; set; }

    public static ComplexSubClass GetRandom()
    {
        return new ComplexSubClass
        {
            Float = float.MaxValue / Macro.Random.Next(short.MinValue, short.MaxValue),
            Enum = ComplexEnum.Value4,
            DateTime = DateTime.Now.AddMilliseconds(Macro.Random.Next(int.MinValue / 2, int.MaxValue / 2)),
            Decimal = decimal.MaxValue / Macro.Random.Next(short.MinValue, short.MaxValue),
            String = Guid.NewGuid().ToString(),
            Array = ComplexArrayObject.GetRandomArray(),
            List = ComplexListObject.GetRandomList(),
            Bytes = Guid.NewGuid().ToString().GetBytes()
        };
    }
}

public struct ComplexSubStruct
{
    public float Float { get; set; }
    public ComplexEnum Enum { get; set; }
    public DateTime DateTime { get; set; }
    public decimal Decimal { get; set; }
    public string String { get; set; }
    public ComplexArrayObject[] Array { get; set; }
    public List<ComplexListObject> List { get; set; }
    public byte[] Bytes { get; set; }

    public static ComplexSubStruct GetRandom()
    {
        return new ComplexSubStruct
        {
            Float = float.MaxValue / Macro.Random.Next(short.MinValue, short.MaxValue),
            Enum = ComplexEnum.Value4,
            DateTime = DateTime.Now.AddMilliseconds(Macro.Random.Next(int.MinValue / 2, int.MaxValue / 2)),
            Decimal = decimal.MaxValue / Macro.Random.Next(short.MinValue, short.MaxValue),
            String = Guid.NewGuid().ToString(),
            Array = ComplexArrayObject.GetRandomArray(),
            List = ComplexListObject.GetRandomList(),
            Bytes = Guid.NewGuid().ToString().GetBytes()
        };
    }
}