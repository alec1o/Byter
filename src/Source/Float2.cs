namespace Byter
{
    public struct Float2
    {
        public float X, Y;
      
        public Float2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
    
        public override ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
