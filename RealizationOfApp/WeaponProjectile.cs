

using SFML.Graphics;

namespace RealizationOfApp
{
    public class VectorFloat
    {
        public Vector2f VecCoords { get; protected set; }
        public VectorFloat()
        {

        }
        public VectorFloat(Vector2f vector1, Vector2f vector2)
        {
            VecCoords = new(vector1.X-vector2.X, vector1.Y-vector2.Y);
        }
        public double Dlina()
        {
            return Math.Pow(VecCoords.X, 2)+Math.Pow(VecCoords.Y, 2);
        }
        public double Angle(VectorFloat vector1)
        {
            return Math.Acos((this*vector1)/(Dlina()*vector1.Dlina()));
        }
        public static double operator *(VectorFloat one, VectorFloat two)
        {
            return one.VecCoords.X*two.VecCoords.X+one.VecCoords.Y*two.VecCoords.Y;
        }
        public void SetVec(Vector2f vector1, Vector2f vector2)
        {
            VecCoords = new(vector1.X-vector2.X, vector1.Y-vector2.Y);
        }

    }
    public class WeaponProjectile:IWeapon
    {
        Vector2f playerPos, mousePos;
        public float SpeedOfThis = 10;
        public void Attack(object? sender,IMovableObject objOfPlayer,MouseButtonEventArgs e)
        {
            playerPos = objOfPlayer.Position;
            mousePos = new Vector2f(e.X, e.Y);
            float angle = ((float)Angle());
            float additionalPixl = ((float)Math.Sqrt((objOfPlayer.Size.X*objOfPlayer.Size.X)/4 + (objOfPlayer.Size.Y*objOfPlayer.Size.Y)/4));
            float finalAdd = ((float)(10 + additionalPixl*(Math.Cos(0.79)/SYKA(angle))));
            float yAngle = mousePos.Y<playerPos.Y ? (1-angle*angle) : -(1-angle*angle);
            if (sender is GGO ggo)
            {
                CircleShape circleShape = new();
                circleShape.Radius = 5;
                circleShape.FillColor = Color.Magenta;
                circleShape.OutlineColor = Color.Black;
                circleShape.OutlineThickness = 2;
                
                circleShape.Position = new Vector2f(objOfPlayer.Position.X+(objOfPlayer.Size.X/2 + finalAdd)*angle, objOfPlayer.Position.Y-(objOfPlayer.Size.Y/2 + finalAdd)*yAngle);
                Projectile projectile = new(circleShape, 720, 0, 0, 1280, 0);
                projectile.DeltaX = SpeedOfThis * angle;
                projectile.DeltaY = -SpeedOfThis * yAngle;
                ggo.gameObjects.Add(projectile);
            }
            else
                throw new ArgumentException($"Wrong sender {sender}");
        }
        public float SYKA(float angle) => Math.Abs(angle)>0.56 ? Math.Abs(angle) : 1-angle*angle;
        public float Dlina(Vector2f point1, Vector2f point2)
        {
            return (float)Math.Sqrt(Math.Pow(point1.X-point2.X, 2)+Math.Pow(point1.Y-point2.Y, 2));
        }
        public double Angle()
        {
            Vector2f b = new(6, 720);
            Vector2f b1 = new(1000, 720);
            return (new VectorFloat(playerPos, mousePos)*new VectorFloat(b, b1)) /(Dlina(playerPos, mousePos)*Dlina(b, b1));
        }
    }
}
