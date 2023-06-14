﻿namespace RealizationOfApp
{
    public class PlayerFactoryA : AbstractPlayerFactory
    {
        public MovableRectOfPlayer movableRect;
        public Keyboard.Key key;
        public bool isPressed = false;
        public IWeapon weapon;
        public PlayerFactoryA(IWeapon weapon)
        {
            this.weapon = weapon;
            RectangleShape shape = new();
            shape.Size = new(50, 50);
            shape.Origin = new Vector2f(shape.Size.X/2, shape.Size.Y/2);
            shape.Position = new(665, 600);
            shape.FillColor = Color.Blue;
            shape.OutlineColor = Color.Black;
            shape.OutlineThickness = 1;
            movableRect = new MovableRectOfPlayer(shape, 720, 0.1f, 0, 1280, 0, Keyboard.Key.A, Keyboard.Key.D);
        }
        public override IMovableObject GetMovableObject() => movableRect;
        public override Dictionary<EventType, WinEventHandler<EventArgs>> GetActions()
        {
            WinEventHandler<KeyEventArgs> keyPressed = (sender, args) =>
            {
                double a = Math.Abs(movableRect.Position.Y + movableRect.Size.Y/2 - movableRect.BottomCoord);
                if (args.Code == Keyboard.Key.W && a<=1)
                {
                    movableRect.DeltaY = -10;
                }
            };
            WinEventHandler<MouseButtonEventArgs> mouseButtonPressed = (sender, args) =>
            {
                //if (!isPressed)
                    weapon.Attack(sender,movableRect,args);
                isPressed = true;
            };
            WinEventHandler<MouseButtonEventArgs> mouseButtonReleased = (sender, args) =>
            {
                isPressed = false;
            };
            return new Dictionary<EventType, WinEventHandler<EventArgs>>()
            {
                {
                    EventType.MouseButtonPressed,
                    DelegateCaster.CastToEvHan(mouseButtonPressed)
                },
                {
                    EventType.MouseButtonReleased,
                    DelegateCaster.CastToEvHan(mouseButtonReleased)
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
