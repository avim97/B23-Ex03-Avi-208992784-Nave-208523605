using Ex03.ConsoleUI.Controller;

namespace Ex03.ConsoleUI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            GarageController garageController = new GarageController();

            garageController.Start();
        }
    }
}
