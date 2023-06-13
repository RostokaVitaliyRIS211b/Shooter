

namespace SfmlAppLib
{
    public abstract class AbstractDrawableGUIFactory
    {
        public abstract Dictionary<EventType, EventHandlerGUI<EventArgs>> GetActions();
    }
}
