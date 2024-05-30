using System;
using Byter;
using Xunit;

namespace Test.Primitives;

public partial class Primitives
{
    [Fact]
    public void _DateTime()
    {
        Primitive primitive = new();

        var a = new DateTime(1000, 1, 2, 4, 5, 7, 100, 1);
        var b = new DateTime(2000, 2, 3, 5, 6, 8, 200, 2);

        primitive.Add.DateTime(a);
        primitive.Add.DateTime(b);

        Assert.Equal(a, primitive.Get.DateTime());
        Assert.Equal(b, primitive.Get.DateTime());
        Assert.True(primitive.IsValid);
    }
}