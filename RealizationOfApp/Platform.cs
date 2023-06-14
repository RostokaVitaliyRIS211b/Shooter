
namespace RealizationOfApp
{
    public class Platform:IGameObject
    {
        public RectangleShape shape;
        public Platform(Vector2f coords)
        {
            shape = new();
            shape.Size = new(200, 25);
            shape.Origin = new Vector2f(shape.Size.X/2, shape.Size.Y/2);
            shape.Position = coords;
            shape.FillColor = Color.Green;
            shape.OutlineColor = Color.Black;
            shape.OutlineThickness = 2;
        }
        public Platform(in RectangleShape shape)
        {
            this.shape = new(shape);
        }
        public bool IsNeedToRemove { get; set; }
        public Vector2f Position { get => shape.Position; set => shape.Position=value; }
        public Vector2f Origin { get => shape.Origin; set => shape.Origin=value; }
        public Vector2f Scale { get => shape.Scale; set => shape.Scale=value; }
        public Vector2f Size { get => shape.Size; set => shape.Size=value; }
        public float Rotate { get => shape.Rotation; set => shape.Rotation=value; }
        public IEnumerable<FloatRect> GetBounds() => new FloatRect[1] { shape.GetGlobalBounds() };
        public void Move(float x, float y) => shape.Position += new Vector2f(x, y);
        public bool Contains(float x, float y) => shape.GetGlobalBounds().Contains(x, y);
        public bool Contains(params FloatRect[] floatRects)
        {
            bool flag = false;
            FloatRect curr = shape.GetGlobalBounds();
            foreach (FloatRect floatRect in floatRects)
            {
                flag = curr.Intersects(floatRect);
                if (flag)
                    break;
            }
            return flag;
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(shape, states);
        }
    }
}
