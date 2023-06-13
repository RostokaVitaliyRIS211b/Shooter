
namespace SfmlAppLib
{
    public delegate void EventHandlerGUI<in T>(object source, ICollection<AbscractEventDrawableGUI> elementsOfGUI, T eventArgs) where T : EventArgs;
    public abstract class AbscractEventDrawableGUI:Drawable
    {
        protected Dictionary<EventType, EventHandlerGUI<EventArgs>> actions;
        public bool IsAlive { get; set; } = true;
        public bool IsNeedToRemove { get; set; } = false;

        public AbscractEventDrawableGUI(AbstractDrawableGUIFactory factory)
        {
            actions = factory.GetActions();
        }
        public virtual void InvokeAction(object source, EventType eventType, ICollection<AbscractEventDrawableGUI> elementsOfGUI, EventArgs eventArgs)
        {
            actions[eventType].Invoke(source, elementsOfGUI, eventArgs);
        }
        public virtual void AddAction(EventType eventType, EventHandlerGUI<EventArgs> action)
        {
            actions[eventType] += action;
        }
        public virtual void ClearAction(EventType eventType)
        {
            actions[eventType] = new EventHandlerGUI<EventArgs>((x,z, y) => { });
        }
        public abstract void Draw(RenderTarget target, RenderStates states);
    }
}
