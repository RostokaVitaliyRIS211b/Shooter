

namespace SfmlAppLib
{
    public abstract class AbstractDrawableFactory
    {
        public abstract Dictionary<EventType, WinEventHandler<EventArgs>> GetActions();
    }
}
