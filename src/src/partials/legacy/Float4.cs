namespace Byter.Legacy
{
    public struct Float4
    {
        public float X, Y, Z, W;
      
        public Float4(float x, float y, float z, float w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }
    
        public override string ToString()
        {
            return $"({X}, {Y}, {Z}, {W})";
        }
    }
}
