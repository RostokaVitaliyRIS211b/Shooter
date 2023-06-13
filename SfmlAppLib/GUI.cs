
namespace SfmlAppLib
{
    public sealed class GUI:AbstractEventDrawable
    {
        public View viewOfGUI;
        public IList<AbscractEventDrawableGUI> elementsOfGUI;
        public GUI(AbstractGUIFactory factory):base(factory)
        {
            elementsOfGUI = factory.CreateGUI();
            viewOfGUI = factory.GetView();
            IsAlive = factory.GetState();
        }
        public override void InvokeAction(object source, EventType eventType, EventArgs eventArgs)
        {
            foreach(AbscractEventDrawableGUI abscractEvent in elementsOfGUI)
            {
                abscractEvent.InvokeAction(source,eventType, elementsOfGUI, eventArgs);
            }
            DeleteObjects();
        }
        public void DeleteObjects()
        {
            List<AbscractEventDrawableGUI> isNeedRemove = new(from elem in elementsOfGUI
                                                      where (elem.IsNeedToRemove)
                                                      select elem);
            foreach (AbscractEventDrawableGUI eventDrawable in isNeedRemove)
                elementsOfGUI.Remove(eventDrawable);
        }
        public override void Draw(RenderTarget target, RenderStates states) 
        {
            foreach (AbscractEventDrawableGUI eventDrawableGUI in elementsOfGUI)
                eventDrawableGUI.Draw(target, states);
        }
        public override void AddAction(EventType eventType, WinEventHandler<EventArgs> action)
        {

        }
        public override void ClearAction(EventType eventType)
        {

        }
    }
}
