
namespace RealizationOfApp
{
    public class Projectile : IMovableObject
    {
        protected float glB, glL, glR, glU;
        protected Clock clock = new();
        protected float deltaX, deltaY, massOfObject, bottom, trenie, left, right, up;
        protected bool isGravityOn,IsNeedToRemo;
        protected CircleShape shell;
        public Projectile(in CircleShape circle, float bottom, float trenie, float left, float right, float up)
        {
            IsNeedToRemo = false;
            this.shell = new(circle);
            isGravityOn = false;
            deltaX = 0;
            deltaY = 0;
            massOfObject = 1;
            this.bottom = bottom;
            this.trenie = trenie;
            this.left = left;
            this.right = right;
            this.up = up;
            glB = this.bottom;
            glL = this.left;
            glR = this.right;
            glU = this.up;
        }
        public virtual bool IsNeedToRemove { get=> IsNeedToRemo; set=> IsNeedToRemo=value; }
        public float ForceOfTrenie
        {
            get => trenie;
            set
            {
                if (value>=0)
                    trenie = value;
                else
                    throw new ArgumentException("Force trenia cant be less than zero");
            }
        }
        public float HeightCoord { get => up; set => up=value; }
        public float LeftCoord { get => left; set => left=value; }
        public float RightCoord { get => right; set => right=value; }
        public float BottomCoord { get => bottom; set => bottom=value; }
        public Clock Clocks { get => clock; }
        public float DeltaX { get => deltaX; set => deltaX=value; }
        public float DeltaY { get => deltaY; set => deltaY=value; }
        public float Rotate { get => shell.Rotation; set => shell.Rotation=value; }
        public float MassOfObject
        {
            get => massOfObject;
            set
            {
                if (value>0)
                    massOfObject = value;
                else
                    throw new ArgumentException("Mass cant be less than or equal zero ");
            }
        }
        public bool IsGravityOn { get => isGravityOn; set => isGravityOn=value; }
        public Vector2f Position { get => shell.Position; set => shell.Position=value; }
        public Vector2f Origin { get => shell.Origin; set => shell.Origin=value; }
        public Vector2f Scale { get => shell.Scale; set => shell.Scale=value; }
        public Vector2f Size { get => new(shell.Radius, shell.Radius); set => shell.Radius=value.X/2+value.Y/2; }
        public IEnumerable<FloatRect> GetBounds() => new FloatRect[1] { shell.GetGlobalBounds() };
        public void Move(float x, float y) => shell.Position += new Vector2f(x, y);
        public bool Contains(float x, float y) => shell.GetGlobalBounds().Contains(x, y);
        public bool Contains(params FloatRect[] floatRects)
        {
            bool flag = false;
            FloatRect curr = shell.GetGlobalBounds();
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
            foreach (IGameObject gameObject in gameObjecstCollisions)
            {
                if (gameObject is Player player)
                {
                    player.IsNeedToRemove = true;
                    this.IsNeedToRemove = true;
                }
                else if (gameObject is Platform platform)
                {
                    bool isOnT = IsIOnTop(Position, platform);
                    DeltaX = isOnT ? DeltaX : -DeltaX;
                    DeltaY = isOnT ? -DeltaY : DeltaY;
                }
            }
        }
        public bool IsIOnTop(Vector2f myPos, IGameObject platform) => Math.Abs(myPos.X-platform.Position.X+platform.Size.X/2)>10 &&
            Math.Abs(myPos.X-platform.Position.X-platform.Size.X/2)>10;
        public void Draw(RenderTarget target, RenderStates states)
        {
            if (Position.X<glL || Position.X > glR || Position.Y>glB || Position.Y<glU)
                IsNeedToRemove = true;
            Move(DeltaX, DeltaY);
            target.Draw(shell);
        }
    }
}
