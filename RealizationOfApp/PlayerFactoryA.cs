


namespace RealizationOfApp
{
    public class PlayerFactoryA:AbstractPlayerFactory
    {
        public MovableRectOfPlayer movableRect;
        public Keyboard.Key key;
        public PlayerFactoryA()
        {
            RectangleShape shape = new();
            shape.Size = new(50, 50);
            shape.Origin = new Vector2f(25, 25);
            shape.Position = new(665, 600);
            float b = shape.GetGlobalBounds().Top;
            shape.FillColor = Color.Blue;
            shape.OutlineColor = Color.Black;
            shape.OutlineThickness = 1;
            movableRect = new MovableRectOfPlayer(shape, 720,0.1f,0,1280,0);
        }
        public override IMovableObject GetMovableObject() => movableRect;
        public override Dictionary<EventType, WinEventHandler<EventArgs>> GetActions()
        {
            WinEventHandler<KeyEventArgs> keyPressed = (x, y) =>
            {
                double a = Math.Abs(movableRect.Position.Y + movableRect.Size.Y/2 - movableRect.BottomCoord);
                if (y.Code == Keyboard.Key.W && a<=1)
                {
                    movableRect.DeltaY = -10;
                }
            };
            WinEventHandler<KeyEventArgs> keyRelesed = (x, y) =>
            {

            };
            return new Dictionary<EventType, WinEventHandler<EventArgs>>()
            {
                {
                    EventType.MouseButtonPressed,
                    (x,y)=>
                    { }
                },
                {
                    EventType.MouseButtonReleased,
                    (x,y)=>
                    { }
                },
                {
                    EventType.MouseMoved,
                    (x,y)=>
                    { }
                },
                {
                    EventType.KeyPressed,
                    DelegateCaster.CastToEvHan(keyPressed)
                },
                {
                    EventType.KeyReleased,
                    DelegateCaster.CastToEvHan(keyRelesed)
                },
                {
                    EventType.MouseWheelScrolled,
                    (x,y)=>
                    { }
                }
            };
        }
    }
}
