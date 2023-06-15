using static SfmlAppLib.Geometry;

namespace RealizationOfApp.Weapons
{

    public class WeaponProjectile : IWeapon
    {
        Vector2f playerPos, aimPos;
        public double SpeedInPixelSeconds = 10;
        public void Attack(object? sender, IMovableObject objOfPlayer,Aim aim, KeyEventArgs e)
        {
            playerPos = objOfPlayer.Position;
            aimPos = aim.Position;
            float angle = (float)Angle(playerPos, aimPos);
            float additionalPixl = (float)Math.Sqrt(objOfPlayer.Size.X * objOfPlayer.Size.X / 4 + objOfPlayer.Size.Y * objOfPlayer.Size.Y / 4);
            float finalAdd = (float)(10 + additionalPixl * (Math.Cos(0.79) / SYKA(angle)));
            float yAngle = aimPos.Y < playerPos.Y ? 1 - angle * angle : -(1 - angle * angle);
            if (sender is GGO ggo)
            {
                CircleShape circleShape = new();
                circleShape.Radius = 5;
                circleShape.Origin = new(5, 5);
                circleShape.FillColor = Color.Magenta;
                circleShape.OutlineColor = Color.Black;
                circleShape.OutlineThickness = 2;

                circleShape.Position = new Vector2f(objOfPlayer.Position.X + (objOfPlayer.Size.X / 2 + finalAdd) * angle, objOfPlayer.Position.Y - (objOfPlayer.Size.Y / 2 + finalAdd) * yAngle);
                Projectile projectile = new(circleShape, 720, 0, 0, 1280, 0);
                double time = Dlina(playerPos, aimPos) / SpeedInPixelSeconds;
                projectile.DeltaX = (float)((aimPos.X - playerPos.X) / time);
                projectile.DeltaY = (float)((aimPos.Y - playerPos.Y) / time);
                ggo.gameObjects.Add(projectile);
            }
            else
                throw new ArgumentException($"Wrong sender {sender}");
        }
        public float SYKA(float angle) => Math.Abs(angle) > 0.56 ? Math.Abs(angle) : 1 - angle * angle;
    }
}
