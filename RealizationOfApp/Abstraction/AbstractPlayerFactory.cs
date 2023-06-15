namespace RealizationOfApp.Abstraction
{
    public abstract class AbstractPlayerFactory : AbstractDrawableFactory
    {
        public abstract IMovableObject GetMovableObject();
        public abstract Aim GetAim();
        public abstract IList<Keyboard.Key> GetControls();
    }
}
