namespace Byter
{
    public struct Float4
    {
        public float X, Y, Z, W;
      
        public Float2(float x, float y, float z, float w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }
    
        public override ToString()
        {
            return $"({X}, {Y}, {Z}, {W})";
        }
    }
}
