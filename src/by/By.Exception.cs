using System;
using System.Linq;

namespace Byter
{
    public partial class By : IBy
    {
        private static void ThrowExceptionIfInvalidType(Type type)
        {
            if (type == typeof(object))
            {
                throw new NotSupportedException($"[Byter.By] Error: {type} Isn't supported!");
            }
        }
    }
}