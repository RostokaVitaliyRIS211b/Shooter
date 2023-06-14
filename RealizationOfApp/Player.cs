

namespace RealizationOfApp
{
    public class Player:AbstractEventDrawable,IMovableObject
    {
        public IMovableObject movable;
        public Player(AbstractPlayerFactory factory):base(factory)
        {
            movable = factory.GetMovableObject();
        }
        public Clock Clocks { get => movable.Clocks; }
        public float ForceOfTrenie { get => movable.ForceOfTrenie; set => movable.ForceOfTrenie=value; }
        public float HeightCoord { get => movable.HeightCoord; set => movable.HeightCoord=value; }
        public float LeftCoord { get => movable.LeftCoord; set => movable.LeftCoord=value; }
        public float RightCoord { get => movable.RightCoord; set => movable.RightCoord=value; }
        public float BottomCoord { get => movable.BottomCoord; set => movable.BottomCoord=value; }
        public float DeltaX { get => movable.DeltaX; set => movable.DeltaX=value; }
        public float DeltaY { get => movable.DeltaY; set => movable.DeltaY=value; }
        public float Rotate { get => movable.Rotate; set => movable.Rotate=value; }
        public float MassOfObject{get => movable.MassOfObject;set => movable.MassOfObject = value;}
        public bool IsGravityOn { get => movable.IsGravityOn; set => movable.IsGravityOn=value; }
        public Vector2f Position { get => movable.Position; set => movable.Position=value; }
        public Vector2f Origin { get => movable.Origin; set => movable.Origin=value; }
        public Vector2f Scale { get => movable.Scale; set => movable.Scale=value; }
        public Vector2f Size { get => movable.Size; set => movable.Size=value; }
        public IEnumerable<FloatRect> GetBounds() => movable.GetBounds() ;
        public void Move(float x, float y) => movable.Move(x,y);
        public bool Contains(float x, float y) => movable.Contains(x, y);
        public bool Contains(params FloatRect[] floatRects) => movable.Contains(floatRects);
        public void Collision(object? sender, IEnumerable<IGameObject> gameObjectCollision)
        {
            movable.Collision(sender, gameObjectCollision);
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
            movable.Draw(target, states);
        }
    }
}
