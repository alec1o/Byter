using Byter;
using Xunit;

namespace Test.Primitives;

public partial class Primitives
{
    [Fact]
    public void _Float()
    {
        Primitive primitive = new();

        var a = float.MinValue;
        var b = float.MaxValue;

        primitive.Add.Float(a);
        primitive.Add.Float(b);

        Assert.Equal(a, primitive.Get.Float());
        Assert.Equal(b, primitive.Get.Float());
        Assert.True(primitive.IsValid);
    }
}