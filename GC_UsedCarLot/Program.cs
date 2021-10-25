using System;

namespace GC_UsedCarLot
{
    class Program
    {
        static void Main(string[] args)
        {
            CarLot c = new CarLot();
            bool userContinue = true;
            while (userContinue)
            {
                Console.Write("\n::MENU::" +
                    "\n1) List Cars" +
                    "\n2) Buy Car" +
                    "\n3) Admin Mode" +
                    "\n4) Exit" +
                    "\n:: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1": //LIST CARS
                        c.ListCars();
                        break;
                    case "2": //BUY CAR
                        c.RemoveCar();
                        break;
                    case "3": //ADMIN MODE
                        c.AdminMode();
                        break;
                    case "4": //EXIT
                        Console.WriteLine("\n::GOODBYE::");
                        userContinue = false;
                        break;
                    default:
                        Console.WriteLine("\n~INVALID INPUT: Enter a number from the menu~");
                        break;
                }

            }
        }
    }
}
