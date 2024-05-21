using System;
using System.Collections.Generic;
using System.Numerics;
using Byter;

namespace ByterTest.primitive;

public static class Macro
{
    public static readonly Random Random = new Random();
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
    public ComplexEnum Enum { get; set; }
    public long Long { get; set; }
    public ulong ULong { get; set; }
    public double Double { get; set; }
    public DateTime DateTime { get; set; }
    public decimal Decimal { get; set; }
    public string String { get; set; }
    public ComplexSubClass Class { get; set; }
    public ComplexSubStruct Struct { get; set; }
    public ComplexArrayObject[] Array { get; set; }
    public List<ComplexListObject> List { get; set; }
    public BigInteger BigInteger { get; set; }
    public Byte[] Bytes { get; set; }
}

public enum ComplexEnum
{
    Value1 = 8080,
    Value2 = -360,
    Value3 = 360,
    Value4 = -720,
    Value5 = 720,
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
            Decimal = Decimal.MaxValue / Macro.Random.Next(short.MinValue, short.MaxValue),
            String = Guid.NewGuid().ToString()
        };
    }

    public static List<ComplexListObject> GetRandomList()
    {
        int round = Macro.Random.Next(5, byte.MaxValue);
        List<ComplexListObject> list = new();
        
        for (int i = 0; i < round; i++)
        {
            list.Add(GetRandom());
        }

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
            Decimal = Decimal.MaxValue / (decimal)Macro.Random.Next(short.MinValue, short.MaxValue),
            String = Guid.NewGuid().ToString()
        };
    }

    public static ComplexArrayObject[] GetRandomArray()
    {
        int round = Macro.Random.Next(5, byte.MaxValue);
        List<ComplexArrayObject> list = new();
        
        for (int i = 0; i < round; i++)
        {
            list.Add(GetRandom());
        }

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
    public Byte[] Bytes { get; set; }

    public static ComplexSubClass GetRandom()
    {
        return new ComplexSubClass
        {
            Float = float.MaxValue / Macro.Random.Next(short.MinValue, short.MaxValue),
            Enum = ComplexEnum.Value4,
            DateTime = DateTime.Now.AddMilliseconds(Macro.Random.Next(int.MinValue / 2, int.MaxValue / 2)),
            Decimal = Decimal.MaxValue / (decimal)Macro.Random.Next(short.MinValue, short.MaxValue),
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
    public Byte[] Bytes { get; set; }
    
    public static ComplexSubStruct GetRandom()
    {
        return new ComplexSubStruct
        {
            Float = float.MaxValue / Macro.Random.Next(short.MinValue, short.MaxValue),
            Enum = ComplexEnum.Value4,
            DateTime = DateTime.Now.AddMilliseconds(Macro.Random.Next(int.MinValue / 2, int.MaxValue / 2)),
            Decimal = Decimal.MaxValue / (decimal)Macro.Random.Next(short.MinValue, short.MaxValue),
            String = Guid.NewGuid().ToString(),
            Array = ComplexArrayObject.GetRandomArray(),
            List = ComplexListObject.GetRandomList(),
            Bytes = Guid.NewGuid().ToString().GetBytes()
        };
    }
}