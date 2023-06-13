namespace Shooter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application application = new(new AppFabricA());
            application.Start();
        }
    }
}