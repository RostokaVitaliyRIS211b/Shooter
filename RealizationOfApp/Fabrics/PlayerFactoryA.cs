using SFML.Graphics;

namespace RealizationOfApp.Fabrics
{
    public class PlayerFactoryA : AbstractPlayerFactory
    {
        public MovableRectOfPlayer movableRect;
        public Keyboard.Key key;
        public bool isPressed = false;
        public IWeapon weapon;
        public Aim aim;
        protected float radius = 0;
        public PlayerFactoryA(IWeapon weapon)
        {
            this.weapon = weapon;
            RectangleShape shape = new();
            shape.Size = new(50, 50);
            shape.Origin = new Vector2f(shape.Size.X / 2, shape.Size.Y / 2);
            shape.Position = new(665, 600);
            shape.FillColor = Color.Blue;
            shape.OutlineColor = Color.Black;
            shape.OutlineThickness = 1;
            movableRect = new MovableRectOfPlayer(shape, 720, 0.8f, 0, 1280, 0, Keyboard.Key.A, Keyboard.Key.D);
            CircleShape circleShape = new();
            circleShape.Radius = 5;
            circleShape.Origin = new(5, 5);
            circleShape.FillColor = Color.Red;
            circleShape.OutlineColor = Color.Black;
            circleShape.OutlineThickness = 3;
            radius = movableRect.Size.X>movableRect.Size.Y ? movableRect.Size.X : movableRect.Size.Y;
            circleShape.Position = new Vector2f(movableRect.Position.X - radius , movableRect.Position.Y ); 
            aim = new(circleShape);
        }
        public override Aim GetAim() => aim;
        public override IMovableObject GetMovableObject() => movableRect;
        public override Dictionary<EventType, WinEventHandler<EventArgs>> GetActions()
        {
            WinEventHandler<KeyEventArgs> keyPressed = (sender, args) =>
            {
                double a = Math.Abs(movableRect.Position.Y + movableRect.Size.Y / 2 - movableRect.BottomCoord);
                if (args.Code == Keyboard.Key.W && a <= 1)
                {
                    movableRect.DeltaY = -10;
                }
               
                else if (args.Code == Keyboard.Key.LShift && !isPressed)
                {
                    weapon.Attack(sender, movableRect, aim, args);
                    isPressed = true;
                }
            };
            WinEventHandler<KeyEventArgs> keyReleased = (sender, args) =>
            {
                isPressed = !(args.Code == Keyboard.Key.LShift);
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
