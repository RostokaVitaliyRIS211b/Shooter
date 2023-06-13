

namespace RealizationOfApp
{
    public abstract class AbstractGGOFactory:AbstractDrawableFactory
    {
        public abstract IList<IGameObject> GetGameObjects();
    }
}
