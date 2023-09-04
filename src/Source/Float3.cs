namespace Byter
{
    public struct Float3
    {
        public float X, Y, Z;
      
        public Float3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.X = z;
        }
    
        public override ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }
}
