namespace RealizationOfApp.Abstraction
{
    public interface IWeapon
    {
        public void Attack(object? sender, IMovableObject objOfPlayer, Aim aim, KeyEventArgs e);
    }
}
