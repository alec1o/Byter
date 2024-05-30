using System;
using Byter;
using Xunit;

namespace Test.Primitives;

public partial class Primitives
{
    [Fact]
    public void _Enum()
    {
        Primitive primitive = new();

        var a = TypeCode.Empty;
        var b = TypeCode.Object;
        var c = TypeCode.Boolean;

        primitive.Add.Enum(a);
        primitive.Add.Enum(b);
        primitive.Add.Enum(c);

        Assert.Equal(a, primitive.Get.Enum<TypeCode>());
        Assert.Equal(b, primitive.Get.Enum<TypeCode>());
        Assert.Equal(b, primitive.Get.Enum<TypeCode>());
        Assert.True(primitive.IsValid);
    }
}