using Byter;
using Xunit;

namespace Test.Primitives;

public partial class Primitives
{
    [Fact]
    public void _Double()
    {
        Primitive primitive = new();

        var a = double.MinValue;
        var b = double.MaxValue;

        primitive.Add.Double(a);
        primitive.Add.Double(b);

        Assert.Equal(a, primitive.Get.Double());
        Assert.Equal(b, primitive.Get.Double());
        Assert.True(primitive.IsValid);
    }
}