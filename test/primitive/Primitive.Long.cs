using Byter;
using Xunit;

namespace Test.Primitives;

public partial class Primitives
{
    [Fact]
    public void _Long()
    {
        Primitive primitive = new();

        var a = long.MinValue;
        var b = long.MaxValue;

        primitive.Add.Long(a);
        primitive.Add.Long(b);

        Assert.Equal(a, primitive.Get.Long());
        Assert.Equal(b, primitive.Get.Long());
        Assert.True(primitive.IsValid);
    }
}