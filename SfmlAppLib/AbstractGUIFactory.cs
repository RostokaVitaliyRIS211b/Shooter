
namespace SfmlAppLib
{
    public abstract class AbstractGUIFactory:AbstractDrawableFactory
    {
        public abstract IList<AbscractEventDrawableGUI> CreateGUI();
        public abstract View GetView();
        public abstract bool GetState();
    }
}
