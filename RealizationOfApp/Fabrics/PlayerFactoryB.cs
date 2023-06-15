namespace RealizationOfApp.Fabrics
{
    public class PlayerFactoryB : AbstractPlayerFactory
    {
        public MovableRectOfPlayer movableRect;
        public Keyboard.Key key;
        public IWeapon weapon;
        public Aim aim;
        public bool isPressed;
        public PlayerFactoryB(IWeapon weapon)
        {
           
            RectangleShape shape = new();
            this.weapon = weapon;
            shape.Size = new(50, 50);
            shape.Origin = new Vector2f(shape.Size.X / 2, shape.Size.Y / 2);
            shape.Position = new(100, 600);
            shape.FillColor = Color.Red;
            shape.OutlineColor = Color.Black;
            shape.OutlineThickness = 1;
            movableRect = new MovableRectOfPlayer(shape, 720, 0.8f, 0, 1280, 0, Keyboard.Key.Left, Keyboard.Key.Right);
            CircleShape circleShape = new();
            circleShape.Radius = 5;
            circleShape.Origin = new(5, 5);
            circleShape.FillColor = Color.Magenta;
            circleShape.OutlineColor = Color.Black;
            circleShape.OutlineThickness = 2;
            circleShape.Position = new Vector2f(75, 600);
            aim = new(circleShape);
        }
        public override Aim GetAim() => aim;
        public override IList<Keyboard.Key> GetControls() => new List<Keyboard.Key>() { Keyboard.Key.Comma, Keyboard.Key.Period };
        public override IMovableObject GetMovableObject() => movableRect;
        public override Dictionary<EventType, WinEventHandler<EventArgs>> GetActions()
        {
            WinEventHandler<KeyEventArgs> keyPressed = (sender, args) =>
            {
                double a = Math.Abs(movableRect.Position.Y + movableRect.Size.Y / 2 - movableRect.BottomCoord);
                if (args.Code == Keyboard.Key.Up && a <= 1)
                {
                    movableRect.DeltaY = -10;
                }
                else if (args.Code == Keyboard.Key.RControl && !isPressed)
                {
                    weapon.Attack(sender, movableRect, aim, args);
                    isPressed = true;
                }
            };
            WinEventHandler<KeyEventArgs> keyReleased = (sender, args) =>
            {
                isPressed = !(args.Code == Keyboard.Key.RControl);
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
                    DelegateCaster.CastToEvHan(keyReleased)
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
