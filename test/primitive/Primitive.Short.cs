using Byter;
using Xunit;

namespace Test.Primitives;

public partial class Primitives
{
    [Fact]
    public void _Short()
    {
        Primitive primitive = new();

        var a = short.MinValue;
        var b = short.MaxValue;

        primitive.Add.Short(a);
        primitive.Add.Short(b);

        Assert.Equal(a, primitive.Get.Short());
        Assert.Equal(b, primitive.Get.Short());
        Assert.True(primitive.IsValid);
    }
}