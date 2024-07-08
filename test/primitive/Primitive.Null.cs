using System.Collections.Generic;
using Byter;
using Xunit;

namespace Test.Primitives;

public partial class Primitives
{
    [Fact]
    public void Null()
    {
        Primitive primitive = new();

        primitive.Add.Bytes(null);
        primitive.Add.Bytes([]);

        primitive.Add.String(NullConfig.EmptyString);
        primitive.Add.String(NullConfig.NullString);

        primitive.Add.Array(NullConfig.EmptyArray);
        primitive.Add.Array(NullConfig.NullArray);

        primitive.Add.List(NullConfig.EmptyList);
        primitive.Add.List(NullConfig.NullList);

        primitive.Add.Class(NullConfig.TheEmptyClass);
        primitive.Add.Class(NullConfig.TheNullClass);

        primitive.Add.Struct(NullConfig.TheEmptyStruct);
        primitive.Add.Struct(NullConfig.TheNullStruct);

        primitive.Add.Enum(NullConfig.TheEmptyEnum);
        primitive.Add.Enum(NullConfig.TheNullEnum);

        primitive.Add.Bool(default);
        primitive.Add.Byte(default);
        primitive.Add.SByte(default);
        primitive.Add.Char(default);
        primitive.Add.Short(default);
        primitive.Add.UShort(default);
        primitive.Add.Int(default);
        primitive.Add.UInt(default);
        primitive.Add.Float(default);
        primitive.Add.Long(default);
        primitive.Add.ULong(default);
        primitive.Add.Double(default);
        primitive.Add.DateTime(default);
        primitive.Add.Decimal(default);
        primitive.Add.String(default);
        primitive.Add.BigInteger(default);

        // read

        _ = primitive.Get.Bytes(); // empty bytes
        _ = primitive.Get.Bytes(); // null bytes

        _ = primitive.Get.String(); // empty
        _ = primitive.Get.String(); // null      

        _ = primitive.Get.Array<byte>(); // empty
        _ = primitive.Get.Array<byte>(); // null    

        _ = primitive.Get.List<byte>(); // empty
        _ = primitive.Get.List<byte>(); // null    

        _ = primitive.Get.Class<NullConfig.EmptyClass>(); // empty
        _ = primitive.Get.Class<NullConfig.NonEmptyClass>(); // null 

        _ = primitive.Get.Struct<NullConfig.EmptyStruct>(); // empty
        _ = primitive.Get.Struct<NullConfig.NonEmptyStruct>(); // null

        _ = primitive.Get.Enum<NullConfig.EmptyEnum>(); // empty
        _ = primitive.Get.Enum<NullConfig.NonEmptyEnum>(); // null

        _ = primitive.Get.Bool();
        _ = primitive.Get.Byte();
        _ = primitive.Get.SByte();
        _ = primitive.Get.Char();
        _ = primitive.Get.Short();
        _ = primitive.Get.UShort();
        _ = primitive.Get.Int();
        _ = primitive.Get.UInt();
        _ = primitive.Get.Float();
        _ = primitive.Get.Long();
        _ = primitive.Get.ULong();
        _ = primitive.Get.Double();
        _ = primitive.Get.DateTime();
        _ = primitive.Get.Decimal();
        _ = primitive.Get.String();
        _ = primitive.Get.BigInteger();

        Assert.True(primitive.IsValid);
    }

    public static class NullConfig
    {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        public static readonly string EmptyString = "";
        public static readonly string NullString = null;

        public static readonly byte[] EmptyArray = [];

        public static readonly byte[] NullArray = null;

        public static readonly List<byte> EmptyList = [];
        public static readonly List<byte> NullList = null;

        public static readonly NonEmptyClass TheEmptyClass = new();
        public static readonly NonEmptyClass TheNullClass = null;

        public static readonly EmptyStruct TheEmptyStruct = new();
        public static readonly NonEmptyStruct TheNullStruct = default;

        public static readonly EmptyEnum TheEmptyEnum = new();
        public static readonly NonEmptyEnum TheNullEnum = default;

        // ReSharper disable once ClassNeverInstantiated.Global
        public class EmptyClass
        {
        }

        public struct EmptyStruct
        {
        }

        public class NonEmptyClass
        {
            public byte Byte { get; set; }
        }

        public struct NonEmptyStruct
        {
            public byte Byte { get; set; }
        }

        public enum NonEmptyEnum
        {
            Unique
        }

        public enum EmptyEnum
        {
        }
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }
}