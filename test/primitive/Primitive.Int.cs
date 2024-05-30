using Byter;
using Xunit;

namespace Test.Primitives;

public partial class Primitives
{
    [Fact]
    public void _Int()
    {
        Primitive primitive = new();

        var a = int.MinValue;
        var b = int.MaxValue;

        primitive.Add.Int(a);
        primitive.Add.Int(b);

        Assert.Equal(a, primitive.Get.Int());
        Assert.Equal(b, primitive.Get.Int());
        Assert.True(primitive.IsValid);
    }
}