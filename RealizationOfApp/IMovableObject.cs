
namespace RealizationOfApp
{
    public interface IMovableObject:IGameObject
    {
        public float DeltaX { get; set; }
        public float DeltaY { get; set; }
        public float BottomCoord { get; set; }
        public float HeightCoord { get; set; }
        public float RightCoord { get; set; }
        public float LeftCoord { get; set; }
        public float ForceOfTrenie { get; set; }
        public Clock Clocks { get; }
        public float MassOfObject { get; set; }
        public bool IsGravityOn { get; set; }
        public void Collision(object? sender, IEnumerable<IGameObject> gameObjectCollision);
    }
}
