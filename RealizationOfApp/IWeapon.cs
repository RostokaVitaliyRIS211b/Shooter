

namespace RealizationOfApp
{
    public interface IWeapon
    {
        public void Attack(object? sender, IMovableObject objOfPlayer, MouseButtonEventArgs e);
    }
}
