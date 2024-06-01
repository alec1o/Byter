namespace Byter
{
    public struct Float2
    {
        public float X { get; set; }
        public float Y { get; set; }
      
        public Float2(float x, float y)
        {
            X = x;
            Y = y;
        }
    
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
