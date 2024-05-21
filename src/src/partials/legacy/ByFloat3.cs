namespace Byter.Legacy
{
    public struct ByFloat3
    {
        public float X, Y, Z;

        public ByFloat3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }
}
