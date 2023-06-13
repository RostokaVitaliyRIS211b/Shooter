﻿

namespace RealizationOfApp
{
    public class MovableRectOfPlayer : IMovableObject
    {
        protected Clock clock = new();
        protected float deltaX, deltaY, massOfObject,bottom,trenie,left,right,up;
        protected bool isGravityOn;
        protected RectangleShape rectangle;
        public MovableRectOfPlayer(in RectangleShape rectangle,float bottom,float trenie, float left, float right, float up)
        {
            this.rectangle = new(rectangle);
            isGravityOn = true;
            deltaX = 0;
            deltaY = 0;
            massOfObject = 1;
            this.bottom = bottom;
            this.trenie = trenie;
            this.left = left;
            this.right = right;
            this.up = up;
        }
        public float ForceOfTrenie
        {
            get => trenie;
            set
            {
                if (value>=0)
                    trenie = value;
                else
                    throw new ArgumentException("Force trenia cant be less than zero");
            }
        }
        public float HeightCoord { get => up; set => up=value; }
        public float LeftCoord { get => left; set => left=value; }
        public float RightCoord { get => right; set => right=value; }
        public float BottomCoord { get => bottom; set => bottom=value; }
        public Clock Clocks { get => clock; }
        public float DeltaX 
        {
            get => deltaX; 
            set
            {
                if (Math.Abs(deltaX)>=ForceOfTrenie || Math.Abs(deltaX-value)>ForceOfTrenie)
                    deltaX=value;
                else
                    deltaX = 0;
            }
        }
        public float DeltaY 
        { 
            get => deltaY;
            set
            {
                if (Math.Abs(rectangle.Position.Y + rectangle.Size.Y/2-bottom)<=1 && value>0)
                    deltaY=0;
                else
                    deltaY = value;
            }
        }
        public float Rotate { get => rectangle.Rotation; set => rectangle.Rotation=value; }
        public float MassOfObject
        {
            get => massOfObject;
            set
            {
                if (value>0)
                    massOfObject = value;
                else
                    throw new ArgumentException("Mass cant be less than or equal zero ");
            }
        }
        public bool IsGravityOn { get => isGravityOn; set => isGravityOn=value; }
        public Vector2f Position { get => rectangle.Position; set => rectangle.Position=value; }
        public Vector2f Origin { get => rectangle.Origin; set => rectangle.Origin=value; }
        public Vector2f Scale { get => rectangle.Scale; set => rectangle.Scale=value; }
        public Vector2f Size { get => rectangle.Size; set => rectangle.Size=value; }
        public IEnumerable<FloatRect> GetBounds() => new FloatRect[1] { rectangle.GetGlobalBounds() };
        public void Move(float x, float y) => rectangle.Position += new Vector2f(x, y);
        public bool Contains(float x, float y) => rectangle.GetGlobalBounds().Contains(x, y);
        public bool Contains(params FloatRect[] floatRects)
        {
            bool flag = false;
            FloatRect curr = rectangle.GetGlobalBounds();
            foreach(FloatRect floatRect in floatRects)
            {
                flag = curr.Intersects(floatRect);
                if (flag)
                    break;
            }
            return flag;
        }
        public void Draw(RenderTarget target,RenderStates states)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                DeltaX = -4;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                DeltaX = 4;
            }
            Move(DeltaX, DeltaY);
            if (bottom - (rectangle.Position.Y + rectangle.Size.Y/2) < 0 && deltaY > 0)
            {
                rectangle.Position = new(rectangle.Position.X, bottom - rectangle.Size.Y/2 + 1);
                deltaY = 0;
            }
            if(up - (rectangle.Position.Y - rectangle.Size.Y/2)>0 && deltaY < 0)
            {
                rectangle.Position = new(rectangle.Position.X, up + rectangle.Size.Y/2 + 1);
                deltaY = 0;
            }
            if(right - (rectangle.Position.X+rectangle.Size.X/2)<0 && deltaX>0)
            {
                rectangle.Position = new(right-rectangle.Size.X/2, rectangle.Position.Y);
                deltaX = 0;
            }
            if (left - (rectangle.Position.X-rectangle.Size.X/2)>0 && deltaX<0)
            {
                rectangle.Position = new(left+rectangle.Size.X/2, rectangle.Position.Y);
                deltaX = 0;
            }
            target.Draw(rectangle);
        }

    }
}
