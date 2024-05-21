namespace Byter.Legacy
{
    public struct ByFloat2
    {
        public float X, Y;
      
        public ByFloat2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
    
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
