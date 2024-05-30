using System;
using Byter;
using Xunit;

namespace Test.Primitives;

public partial class Primitives
{
    [Fact]
    public void _ByteArray()
    {
        Primitive primitive = new();

        var a = Guid.NewGuid().ToString().GetBytes();
        var b = Guid.NewGuid().ToString().GetBytes();

        primitive.Add.Bytes(a);
        primitive.Add.Bytes(b);

        Assert.Equal(a, primitive.Get.Bytes());
        Assert.Equal(b, primitive.Get.Bytes());
        Assert.True(primitive.IsValid);
    }
}