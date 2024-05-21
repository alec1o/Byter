namespace Byter.Legacy
{
    public struct ByFloat4
    {
        public float X, Y, Z, W;
      
        public ByFloat4(float x, float y, float z, float w)
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
