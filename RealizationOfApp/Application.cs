
namespace RealizationOfApp
{
    public class Application
    {
        public RenderWindow window;
        public List<AbstractEventDrawable> abstractEventDrawables;
        public readonly uint ScreenHeight, ScreenWidth,FrameRate;
        public static Text degubText = new("text", new Font("ofontruImpact.ttf"));
        public Application(AbstractEventHandlerFac fac,uint scrHeight = 1280,uint scrWidth = 720,uint framRate=60)
        {
            ScreenHeight = scrHeight;
            ScreenWidth = scrWidth;
            FrameRate = framRate;
            window = new RenderWindow(new VideoMode(ScreenHeight, ScreenWidth), "Shooter");
            window.SetFramerateLimit(FrameRate);
            abstractEventDrawables = new(fac.CreateInteractiveObjects());
            window.MouseButtonPressed+=MouseButtonPressed;
            window.MouseButtonReleased+=MouseButtonReleased;
            window.MouseMoved+=MouseMoved;
            window.KeyPressed+=KeyPressed;
            window.KeyReleased += KeyReleased;
            window.MouseWheelScrolled+=MouseWheelScrolled;
            window.Closed += Closed;
        }
        static Application()
        {
            degubText.Position = new(10, 10);
            degubText.FillColor = Color.Black;
            degubText.CharacterSize = 14;
        }
        public void Start()
        {
            while (window.IsOpen)
            {
                window.DispatchEvents();
                DeleteObjects();
                window.Clear(Color.White);
                foreach (AbstractEventDrawable drawable in abstractEventDrawables)
                    window.Draw(drawable);
                window.Draw(degubText);
                window.Display();
            }
        }
        public void DeleteObjects()
        {
            for(int i=0;i<abstractEventDrawables.Count;++i )
            {
                if (abstractEventDrawables[i].IsNeedToRemove)
                {
                    abstractEventDrawables.RemoveAt(i);
                    --i;
                }
            }
        }

        private void MouseWheelScrolled(object? sender, MouseWheelScrollEventArgs e)
        {
            foreach(AbstractEventDrawable drawable in abstractEventDrawables)
            {
                drawable.InvokeAction(this, EventType.MouseWheelScrolled, e);
            }
        }

        private void KeyPressed(object? sender, KeyEventArgs e)
        {
            foreach (AbstractEventDrawable drawable in abstractEventDrawables)
            {
                drawable.InvokeAction(this, EventType.KeyPressed, e);
            }
        }

        private void KeyReleased(object? sender, KeyEventArgs e)
        {
            foreach (AbstractEventDrawable drawable in abstractEventDrawables)
            {
                drawable.InvokeAction(this, EventType.KeyReleased, e);
            }
        }

        private void MouseMoved(object? sender, MouseMoveEventArgs e)
        {
            foreach (AbstractEventDrawable drawable in abstractEventDrawables)
            {
                drawable.InvokeAction(this, EventType.MouseMoved, e);
            }
        }

        private void MouseButtonReleased(object? sender, MouseButtonEventArgs e)
        {
            foreach (AbstractEventDrawable drawable in abstractEventDrawables)
            {
                drawable.InvokeAction(this, EventType.MouseButtonReleased, e);
            }
        }

        private void MouseButtonPressed(object? sender, MouseButtonEventArgs e)
        {
            foreach (AbstractEventDrawable drawable in abstractEventDrawables)
            {
                drawable.InvokeAction(this, EventType.MouseButtonPressed, e);
            }
        }

        private void Closed(object? sender, EventArgs e)
        {
            window.Close();
        }
    }
}
