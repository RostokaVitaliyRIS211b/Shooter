

namespace RealizationOfApp
{
    public interface IGameObject:Drawable
    {
        public Vector2f Position { get; set; }
        public Vector2f Size { get; set; }
        public Vector2f Origin { get; set; }
        public Vector2f Scale { get; set; }
        public float Rotate { get; set; }
        public IEnumerable<FloatRect> GetBounds();
        public void Move(float x, float y);
        public bool Contains(float x, float y);
        public bool Contains(params FloatRect[] floatRects);
    }
}
