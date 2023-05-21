using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
