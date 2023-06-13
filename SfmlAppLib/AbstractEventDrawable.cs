
namespace SfmlAppLib
{
    public delegate void WinEventHandler<in T>(object source, T eventArgs) where T : EventArgs;
    public abstract class AbstractEventDrawable:Drawable
    {
        protected Dictionary<EventType, WinEventHandler<EventArgs>> actions;
        public bool IsAlive { get; set; } = true;
        public bool IsNeedToRemove { get; set; } = false;
        
        public AbstractEventDrawable(AbstractDrawableFactory factory)
        {
            actions = factory.GetActions();
        }
        public virtual void InvokeAction(object source,EventType eventType, EventArgs eventArgs)
        {
            actions[eventType].Invoke(source, eventArgs);
        }
        public virtual void AddAction(EventType eventType, WinEventHandler<EventArgs> action)
        {
            actions[eventType] += action;
        }
        public virtual void ClearAction(EventType eventType)
        {
            actions[eventType] = new WinEventHandler<EventArgs>((x, y) => { });
        }
        public abstract void Draw(RenderTarget target, RenderStates states);
    }
}
