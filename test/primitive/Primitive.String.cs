using System;
using Byter;
using Xunit;

namespace Test.Primitives;

public partial class Primitives
{
    [Fact]
    public void _String()
    {
        Primitive primitive = new();

        var a = Guid.NewGuid().ToString();
        var b = Guid.NewGuid().ToString();

        primitive.Add.String(a);
        primitive.Add.String(b);

        Assert.Equal(a, primitive.Get.String());
        Assert.Equal(b, primitive.Get.String());
        Assert.True(primitive.IsValid);
    }
}