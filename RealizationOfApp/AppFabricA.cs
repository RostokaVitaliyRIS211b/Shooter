
namespace RealizationOfApp
{
    public class AppFabricA:AbstractEventHandlerFac
    {
        public override ICollection<AbstractEventDrawable> CreateInteractiveObjects()
        {
            return new List<AbstractEventDrawable>()
            {
               new GGO(new GGOFactoryA())
            };
        }
    }
}
