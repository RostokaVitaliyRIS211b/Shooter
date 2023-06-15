namespace RealizationOfApp.MovableObjects
{
    public class Player : AbstractEventDrawable, IMovableObject
    {
        public IMovableObject movable;
        public Aim aim;
        public float angle;
        public float yAngle;
        public IList<Keyboard.Key> controls;
        protected bool isAbove = true;
        public Player(AbstractPlayerFactory factory) : base(factory)
        {
            movable = factory.GetMovableObject();
            controls = factory.GetControls();
            aim = factory.GetAim();
            angle = ((float)Geometry.Angle(aim.Position, movable.Position));
            yAngle = isAbove ? -(1-angle*angle) : (1-angle*angle);
        }
        public Clock Clocks { get => movable.Clocks; }
        public override bool IsNeedToRemove { get => movable.IsNeedToRemove; set => movable.IsNeedToRemove = value; }
        public float ForceOfTrenie { get => movable.ForceOfTrenie; set => movable.ForceOfTrenie = value; }
        public float HeightCoord { get => movable.HeightCoord; set => movable.HeightCoord = value; }
        public float LeftCoord { get => movable.LeftCoord; set => movable.LeftCoord = value; }
        public float RightCoord { get => movable.RightCoord; set => movable.RightCoord = value; }
        public float BottomCoord { get => movable.BottomCoord; set => movable.BottomCoord = value; }
        public float DeltaX { get => movable.DeltaX; set => movable.DeltaX = value; }
        public float DeltaY { get => movable.DeltaY; set => movable.DeltaY = value; }
        public float Rotate { get => movable.Rotate; set => movable.Rotate = value; }
        public float MassOfObject { get => movable.MassOfObject; set => movable.MassOfObject = value; }
        public bool IsGravityOn { get => movable.IsGravityOn; set => movable.IsGravityOn = value; }
        public Vector2f Position { get => movable.Position; set => movable.Position = value; }
        public Vector2f Origin { get => movable.Origin; set => movable.Origin = value; }
        public Vector2f Scale { get => movable.Scale; set => movable.Scale = value; }
        public Vector2f Size { get => movable.Size; set => movable.Size = value; }
        public IEnumerable<FloatRect> GetBounds() => movable.GetBounds();
        public void Move(float x, float y) => movable.Move(x, y);
        public bool Contains(float x, float y) => movable.Contains(x, y);
        public bool Contains(params FloatRect[] floatRects) => movable.Contains(floatRects);
        public void Collision(object? sender, IEnumerable<IGameObject> gameObjectCollision)
        {
            movable.Collision(sender, gameObjectCollision);
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(movable, states);
            float speed = 0.05f;
            float radius = 70;
            if (Keyboard.IsKeyPressed(controls[0]) || Keyboard.IsKeyPressed(controls[1]))
            {
                bool isRight = Keyboard.IsKeyPressed(controls[1]);
                angle = isRight == isAbove ? angle+speed : angle-speed;
                if(Math.Abs(angle)>1)
                {
                    isAbove = !isAbove;
                    angle = angle>0 ? 0.99f : -0.99f;
                }
                yAngle = isAbove ? -(1-angle*angle) : (1-angle*angle);
            }
            aim.Position = new(movable.Position.X+radius*angle,movable.Position.Y+radius*yAngle);
            target.Draw(aim,states);
        }
    }
}
