using Byter;
using Xunit;

namespace Test.Primitives;

public partial class Primitives
{
    [Fact]
    public void _Bool()
    {
        Primitive primitive = new();

        var a = true;
        var b = false;

        primitive.Add.Bool(a);
        primitive.Add.Bool(b);

        Assert.Equal(a, primitive.Get.Bool());
        Assert.Equal(b, primitive.Get.Bool());
        Assert.True(primitive.IsValid);
    }
}