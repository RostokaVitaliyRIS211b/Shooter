using RealizationOfApp.Weapons;

namespace RealizationOfApp.Fabrics
{
    public class GGOFactoryA : AbstractGGOFactory
    {
        public override Dictionary<EventType, WinEventHandler<EventArgs>> GetActions() => new Dictionary<EventType, WinEventHandler<EventArgs>>();

        public override IList<IGameObject> GetGameObjects()
        {
            return new List<IGameObject>()
            {
                new Platform(new(1000,600)),
                new Player(new PlayerFactoryA(new WeaponProjectile())),
            };
        }
    }
}
