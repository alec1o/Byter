using Byter;
using Xunit;

namespace Test.Primitives;

public partial class Primitives
{
    [Fact]
    public void _Decimal()
    {
        Primitive primitive = new();

        var a = decimal.MinValue;
        var b = decimal.MaxValue;

        primitive.Add.Decimal(a);
        primitive.Add.Decimal(b);

        Assert.Equal(a, primitive.Get.Decimal());
        Assert.Equal(b, primitive.Get.Decimal());
        Assert.True(primitive.IsValid);
    }
}