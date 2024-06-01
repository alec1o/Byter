namespace Byter
{
    public struct Float3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Float3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }
}