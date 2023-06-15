

namespace RealizationOfApp.MovableObjects
{
    public class Aim:IMovableObject
    {
        public CircleShape circle;
        public Aim(in CircleShape circle)
        {
            this.circle = new CircleShape(circle);
        }
        public virtual bool IsNeedToRemove { get; set; } = false;
        public float ForceOfTrenie { get; set; } = 0;
        public float HeightCoord { get; set; }
        public float LeftCoord { get; set; }
        public float RightCoord { get; set; }
        public float BottomCoord { get; set; }
        public Clock Clocks { get => null; }
        public float DeltaX { get; set; }

        public float DeltaY { get; set; }

        public float Rotate { get => circle.Rotation; set => circle.Rotation = value; }
        public float MassOfObject { get; set; }

        public bool IsGravityOn { get; set; } = false;
        public Vector2f Position { get => circle.Position; set => circle.Position = value; }
        public Vector2f Origin { get => circle.Origin; set => circle.Origin = value; }
        public Vector2f Scale { get => circle.Scale; set => circle.Scale = value; }
        public Vector2f Size { get => new(circle.Radius,circle.Radius); set => circle.Radius = value.X; }
        public IEnumerable<FloatRect> GetBounds() => new FloatRect[1] { circle.GetGlobalBounds() };
        public void Move(float x, float y) => circle.Position += new Vector2f(x, y);
        public bool Contains(float x, float y) => circle.GetGlobalBounds().Contains(x, y);
        public bool Contains(params FloatRect[] floatRects)
        {
            bool flag = false;
            FloatRect curr = circle.GetGlobalBounds();
            foreach (FloatRect floatRect in floatRects)
            {
                flag = curr.Intersects(floatRect);
                if (flag)
                    break;
            }
            return flag;
        }
        public void Collision(object? sender, IEnumerable<IGameObject> gameObjecstCollisions)
        {
           
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            Move(DeltaX, DeltaY);
            target.Draw(circle,states);
        }

    }
}
