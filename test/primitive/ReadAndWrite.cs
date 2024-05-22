using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Byter;
using Xunit;

namespace ByterTest.primitive;

public class ReadAndWrite: IPrimitiveGet
{
    [Fact] // DONE
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

        return Terminate<bool>(ref primitive);
    }

    [Fact] // DONE
    public byte Byte()
    {
        Primitive primitive = new();

        primitive.Add.Byte(byte.MinValue);
        primitive.Add.Byte(byte.MaxValue);

        Assert.Equal(byte.MinValue, primitive.Get.Byte());
        Assert.Equal(byte.MaxValue, primitive.Get.Byte());

        return Terminate<byte>(ref primitive);
    }

    [Fact] // DONE
    public sbyte SByte()
    {
        Primitive primitive = new();

        primitive.Add.SByte(sbyte.MinValue);
        primitive.Add.SByte(sbyte.MaxValue);

        Assert.Equal(sbyte.MinValue, primitive.Get.SByte());
        Assert.Equal(sbyte.MaxValue, primitive.Get.SByte());

        return Terminate<sbyte>(ref primitive);
    }

    [Fact] // DONE
    public char Char()
    {
        Primitive primitive = new();

        primitive.Add.Char('A');
        primitive.Add.Char('L');
        primitive.Add.Char('E');
        primitive.Add.Char('C');
        primitive.Add.Char('I');
        primitive.Add.Char('O');

        Assert.Equal('A', primitive.Get.Char());
        Assert.Equal('L', primitive.Get.Char());
        Assert.Equal('E', primitive.Get.Char());
        Assert.Equal('C', primitive.Get.Char());
        Assert.Equal('I', primitive.Get.Char());
        Assert.Equal('O', primitive.Get.Char());

        return Terminate<char>(ref primitive);
    }

    [Fact] // DONE
    public short Short()
    {
        Primitive primitive = new();

        primitive.Add.Short(short.MinValue);
        primitive.Add.Short(short.MaxValue);

        Assert.Equal(short.MinValue, primitive.Get.Short());
        Assert.Equal(short.MaxValue, primitive.Get.Short());

        return Terminate<short>(ref primitive);
    }

    [Fact] // DONE
    public ushort UShort()
    {
        Primitive primitive = new();

        primitive.Add.UShort(ushort.MinValue);
        primitive.Add.UShort(ushort.MaxValue);

        Assert.Equal(ushort.MinValue, primitive.Get.UShort());
        Assert.Equal(ushort.MaxValue, primitive.Get.UShort());

        return Terminate<ushort>(ref primitive);
    }

    [Fact] // DONE
    public int Int()
    {
        Primitive primitive = new();

        primitive.Add.Int(int.MinValue);
        primitive.Add.Int(int.MaxValue);

        Assert.Equal(int.MinValue, primitive.Get.Int());
        Assert.Equal(int.MaxValue, primitive.Get.Int());

        return Terminate<int>(ref primitive);
    }

    [Fact] // DONE
    public uint UInt()
    {
        Primitive primitive = new();

        primitive.Add.UInt(uint.MinValue);
        primitive.Add.UInt(uint.MaxValue);

        Assert.Equal(uint.MinValue, primitive.Get.UInt());
        Assert.Equal(uint.MaxValue, primitive.Get.UInt());

        return Terminate<uint>(ref primitive);
    }

    [Fact] // DONE
    public float Float()
    {
        Primitive primitive = new();

        primitive.Add.Float(float.MinValue);
        primitive.Add.Float(float.MaxValue);

        Assert.Equal(float.MinValue, primitive.Get.Float());
        Assert.Equal(float.MaxValue, primitive.Get.Float());

        return Terminate<float>(ref primitive);
    }

    public object Enum(Type type)
    {
        throw new NotImplementedException();
    }

    [Fact] // DONE
    public long Long()
    {
        Primitive primitive = new();

        primitive.Add.Long(long.MinValue);
        primitive.Add.Long(long.MaxValue);

        Assert.Equal(long.MinValue, primitive.Get.Long());
        Assert.Equal(long.MaxValue, primitive.Get.Long());

        return Terminate<long>(ref primitive);
    }

    [Fact] // DONE
    public ulong ULong()
    {
        Primitive primitive = new();

        primitive.Add.ULong(ulong.MinValue);
        primitive.Add.ULong(ulong.MaxValue);

        Assert.Equal(ulong.MinValue, primitive.Get.ULong());
        Assert.Equal(ulong.MaxValue, primitive.Get.ULong());

        return Terminate<ulong>(ref primitive);
    }

    [Fact] // DONE
    public double Double()
    {
        Primitive primitive = new();

        primitive.Add.Double(double.MinValue);
        primitive.Add.Double(double.MaxValue);

        Assert.Equal(double.MinValue, primitive.Get.Double());
        Assert.Equal(double.MaxValue, primitive.Get.Double());

        return Terminate<double>(ref primitive);
    }

    [Fact] // DONE
    public DateTime DateTime()
    {
        Primitive primitive = new();

        DateTime time1 = new(1970, 1, 1);
        DateTime time2 = new(2038, 1, 19);
        DateTime time3 = new(2038, 1, 20); // 2038 Bug Fixed.

        primitive.Add.DateTime(time1);
        primitive.Add.DateTime(time2);
        primitive.Add.DateTime(time3);

        Assert.Equal(time1, primitive.Get.DateTime());
        Assert.Equal(time2, primitive.Get.DateTime());
        Assert.Equal(time3, primitive.Get.DateTime());

        return Terminate<DateTime>(ref primitive);
    }

    [Fact] // DONE
    public decimal Decimal()
    {
        Primitive primitive = new();

        primitive.Add.Decimal(decimal.MinValue);
        primitive.Add.Decimal(decimal.MaxValue);

        Assert.Equal(decimal.MinValue, primitive.Get.Decimal());
        Assert.Equal(decimal.MaxValue, primitive.Get.Decimal());

        return Terminate<decimal>(ref primitive);
    }

    [Fact] // DONE
    public BigInteger BigInteger()
    {
        const string n1 = "1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111";
        const string n2 = "2222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222";
        const string n3 = "3333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333";
        const string n9 = "9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999";

        var number1 = System.Numerics.BigInteger.Parse(n1);
        var number2 = System.Numerics.BigInteger.Parse(n2);
        var number3 = System.Numerics.BigInteger.Parse(n3);
        var number9 = System.Numerics.BigInteger.Parse(n9);

        Assert.Equal(n1, number1.ToString());
        Assert.Equal(n2, number2.ToString());
        Assert.Equal(n3, number3.ToString());
        Assert.Equal(n9, number9.ToString());

        Primitive primitive = new();

        primitive.Add.BigInteger(number1);
        primitive.Add.BigInteger(number2);
        primitive.Add.BigInteger(number3);
        primitive.Add.BigInteger(number9);

        Assert.Equal(number1, primitive.Get.BigInteger());
        Assert.Equal(number2, primitive.Get.BigInteger());
        Assert.Equal(number3, primitive.Get.BigInteger());
        Assert.Equal(number9, primitive.Get.BigInteger());

        return Terminate<BigInteger>(ref primitive);
    }

    [Fact] // DONE
    public byte[]? Bytes()
    {
        byte[] data1 = [1, 2, 3, 4, 6, 7, 8, 9, 0];
        var data2 = "ALEC1O".GetBytes(Encoding.UTF8);
        var data3 = "Hello World".GetBytes(Encoding.UTF32);

        Primitive primitive = new();

        primitive.Add.Bytes(data1);
        primitive.Add.Bytes(data2);
        primitive.Add.Bytes(data3);

        Assert.Equal(data1, primitive.Get.Bytes());
        Assert.Equal(data2, primitive.Get.Bytes());
        Assert.Equal(data3, primitive.Get.Bytes());

        return Terminate<byte[]>(ref primitive);
    }

    [Fact] // DONE
    public string? String()
    {
        const string text1 = "BYTER";
        const string text2 = "IS";
        const string text3 = "CREATED";
        const string text4 = "BY";
        const string text5 = "ALEC1O";

        Primitive primitive = new();

        primitive.Add.String(text1);
        primitive.Add.String(text2);
        primitive.Add.String(text3);
        primitive.Add.String(text4);
        primitive.Add.String(text5);

        Assert.Equal(text1, primitive.Get.String());
        Assert.Equal(text2, primitive.Get.String());
        Assert.Equal(text3, primitive.Get.String());
        Assert.Equal(text4, primitive.Get.String());
        Assert.Equal(text5, primitive.Get.String());

        return Terminate<string>(ref primitive);
    }

    private T? Terminate<T>(ref Primitive primitive)
    {
        Terminate(ref primitive);

        return default;
    }

    private void Terminate(ref Primitive primitive)
    {
        // EXTRA
        Assert.True(primitive.IsValid);
        _ = primitive.Get.Bool();
        Assert.False(primitive.IsValid);
    }

    [Fact] // DONE
    public void _Enum()
    {
        Primitive primitive = new();

        primitive.Add.Enum(TypeCode.Char);
        primitive.Add.Enum(TypeCode.Byte);
        primitive.Add.Enum(TypeCode.String);
        primitive.Add.Enum(TypeCode.Decimal);

        Assert.Throws<InvalidOperationException>(() => primitive.Add.Enum(int.MaxValue));

        Assert.Equal(TypeCode.Char, primitive.Get.Enum<TypeCode>());
        Assert.Equal(TypeCode.Byte, primitive.Get.Enum<TypeCode>());
        Assert.Equal(TypeCode.String, primitive.Get.Enum<TypeCode>());
        Assert.Equal(TypeCode.Decimal, primitive.Get.Enum<TypeCode>());

        Terminate(ref primitive);
    }

    [Fact]
    public void _Class()
    {
        Primitive primitive = new();

        var myClass = new MyFilmClass
        {
            Title = Guid.NewGuid().ToString(),
            Director = Guid.NewGuid().ToString(),
            ReleaseYear = System.DateTime.Now.Millisecond
        };
        
        primitive.Add.Class(myClass);

        var myPrimitiveClass = primitive.Get.Class<MyFilmClass>();
        
        Assert.True(primitive.IsValid);
        Assert.NotNull(myPrimitiveClass);
        Assert.Equal(myClass.Title, myPrimitiveClass.Title);
        Assert.Equal(myClass.Director, myPrimitiveClass.Director);
        Assert.Equal(myClass.ReleaseYear, myPrimitiveClass.ReleaseYear);
        
        Terminate(ref primitive);
    }

    [Fact]
    public void _Struct()
    {
        Primitive primitive = new();

        var myStruct = new MyFilmStruct()
        {
            Title = Guid.NewGuid().ToString(),
            Director = Guid.NewGuid().ToString(),
            ReleaseYear = System.DateTime.Now.Millisecond
        };
        
        primitive.Add.Struct(myStruct);

        var myPrimitiveClass = primitive.Get.Struct<MyFilmStruct>();
        
        Assert.True(primitive.IsValid);
        Assert.Equal(myStruct.Title, myPrimitiveClass.Title);
        Assert.Equal(myStruct.Director, myPrimitiveClass.Director);
        Assert.Equal(myStruct.ReleaseYear, myPrimitiveClass.ReleaseYear);

        Terminate(ref primitive);
    }

    [Fact]
    public void _Array()
    {
        Primitive primitive = new();


        List<string> list = new();

        const int round = 100;

        for (int i = 0; i < round; i++)
        {
            list.Add(Guid.NewGuid().ToString());
        }

        string[] array = list.ToArray();

        primitive.Add.Array(array);
        string[] content = primitive.Get.Array<string>();

        for (int i = 0; i < round; i++)
        {
            Assert.Equal(array[i], content[i]);
        }

        Assert.Equal(100, round);

        Terminate(ref primitive);
    }

    [Fact]
    public void _List()
    {
        Primitive primitive = new();

        List<string> list = new();

        const int round = 100;

        for (int i = 0; i < round; i++)
        {
            list.Add(Guid.NewGuid().ToString());
        }

        primitive.Add.List(list);

        var content = primitive.Get.List<string>();

        for (int i = 0; i < round; i++)
        {
            Assert.Equal(list[i], content[i]);
        }

        Assert.Equal(100, round);

        Terminate(ref primitive);
    }

    [Fact]
    public void TestComplexClass()
    {
        Primitive primitive = new();

        var real = ComplexClass.GetRandom();
        
        primitive.Add.Class(real);
        
        Assert.True(primitive.IsValid);

        var clone = primitive.Get.Class<ComplexClass>();
        
        Assert.True(primitive.IsValid);
        
        // Complex Test
        {
            Assert.NotNull(clone);
            // TODO: impl...
        }
        
        Terminate(ref primitive);
    }    [Fact]
    public void TestComplexStruct()
    {
        Primitive primitive = new();

        var real = ComplexStruct.GetRandom();
        
        primitive.Add.Struct(real);
        
        Assert.True(primitive.IsValid);

        var clone = primitive.Get.Struct<ComplexStruct>();
        
        Assert.True(primitive.IsValid);
        
        // Complex Test
        {
#pragma warning disable xUnit2002
            Assert.NotNull(clone);
#pragma warning restore xUnit2002
            // TODO: impl...
        }
        
        Terminate(ref primitive);
    }
    
    #region Unused

    public T? Enum<T>()
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

    public T[]? Array<T>()
    {
        return default;
    }

    public List<T>? List<T>()
    {
        return default;
    }

    #endregion
}