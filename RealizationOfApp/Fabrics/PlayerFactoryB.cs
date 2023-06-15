namespace RealizationOfApp.Fabrics
{
    public class PlayerFactoryB : AbstractPlayerFactory
    {
        public MovableRectOfPlayer movableRect;
        public Keyboard.Key key;
        public IWeapon weapon;
        public Aim aim;
        public PlayerFactoryB(IWeapon weapon)
        {
            CircleShape circleShape = new();
            circleShape.Radius = 5;
            circleShape.Origin = new(5, 5);
            circleShape.FillColor = Color.Magenta;
            circleShape.OutlineColor = Color.Black;
            circleShape.OutlineThickness = 2;
            aim = new(circleShape);
            RectangleShape shape = new();
            this.weapon = weapon;
            shape.Size = new(50, 50);
            shape.Origin = new Vector2f(shape.Size.X / 2, shape.Size.Y / 2);
            shape.Position = new(100, 600);
            shape.FillColor = Color.Red;
            shape.OutlineColor = Color.Black;
            shape.OutlineThickness = 1;
            movableRect = new MovableRectOfPlayer(shape, 720, 0.1f, 0, 1280, 0, Keyboard.Key.Left, Keyboard.Key.Right);
        }
        public override Aim GetAim() => aim;
        public override IMovableObject GetMovableObject() => movableRect;
        public override Dictionary<EventType, WinEventHandler<EventArgs>> GetActions()
        {
            WinEventHandler<KeyEventArgs> keyPressed = (x, y) =>
            {
                double a = Math.Abs(movableRect.Position.Y + movableRect.Size.Y / 2 - movableRect.BottomCoord);
                if (y.Code == Keyboard.Key.Up && a <= 1)
                {
                    movableRect.DeltaY = -10;
                }
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
                     (x,y)=>
                     { }
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
