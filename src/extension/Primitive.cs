namespace Byter
{
    public static class PrimitiveExtension
    {
        public static T ToPrimitive<T>(this T value, Primitive primitive)
        {
            return value;
        }
        
        public static T FromPrimitive<T>(this T value, Primitive primitive)
        {
            return value;
        }
    }
}