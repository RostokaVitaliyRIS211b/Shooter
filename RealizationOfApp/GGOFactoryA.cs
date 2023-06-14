

namespace RealizationOfApp
{
    public class GGOFactoryA:AbstractGGOFactory
    {
        public override Dictionary<EventType, WinEventHandler<EventArgs>> GetActions()=> new Dictionary<EventType, WinEventHandler<EventArgs>>();

        public override IList<IGameObject> GetGameObjects()
        {
            return new List<IGameObject>()
            {
                new Player(new PlayerFactoryB()),
                new Player(new PlayerFactoryA(new WeaponProjectile())),
                new Platform(new(1000,600))
            };
        }
    }
}
