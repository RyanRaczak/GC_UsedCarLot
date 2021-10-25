using System;
using System.Collections.Generic;

namespace GC_UsedCarLot
{
    class CarLot
    {
        List<Car> Cars = new List<Car>();

        public CarLot()
        {
            //Initiate database
            Cars.Add(new Car("Kia", "Soul Turbo", 2021, 26000));
            Cars.Add(new Car("Ford", "F-350", 2022, 75000));
            Cars.Add(new Car("Dodge", "Ram", 2021, 55000));
            Cars.Add(new UsedCar("Chevy", "HHR", 2007, 5500, 85123));
            Cars.Add(new UsedCar("Plymouth", "Breeze", 1997, 800, 167000));
            Cars.Add(new UsedCar("Mazda", "6", 2007, 8500, 65354));
        }
        public void AddCar()
        {
            //Grabs input from user to add car to list of cars. 
            string make, model;
            int year;
            decimal price;
            double mileage;

            string carType = GetInput("\nPlease enter a New or Used: ");

            //If user selected new, will create a new Car object
            if (carType.Trim().ToLower() == "new")
            {
                try
                {
                    make = GetInput("\nPlease enter a make: ");
                    model = GetInput("\nPlease enter a model: ");
                    year = int.Parse(GetInput("\nPlease enter the year: "));
                    if (YearValidator(year))
                    {
                        price = decimal.Parse(GetInput("\nPlease enter a price: "));
                        Cars.Add(new Car(make, model, year, price));
                        Console.WriteLine($"\n::Your {year} {make} {model} has been added::");
                        return;  
                    }
                    else
                    {
                        Console.WriteLine("\n~INVALID INPUT: Enter a proper year~");
                        AddCar();
                    }
                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n~INVALID INPUT: Please enter a number~");
                    AddCar();
                }

            }
            //If user selected used, will add a UsedCar object
            else if (carType.Trim().ToLower() == "used")
            {
                try
                {
                    make = GetInput("\nPlease enter a make: ");
                    model = GetInput("\nPlease enter a model: ");
                    year = int.Parse(GetInput("\nPlease enter the year: "));
                    if (YearValidator(year))
                    {
                        price = decimal.Parse(GetInput("\nPlease enter a price: "));
                        mileage = double.Parse(GetInput("\nPlease enter the mileage: "));
                        Cars.Add(new Car(make, model, year, price));
                        Console.WriteLine($"\n::Your {year} {make} {model} has been added::");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\n~INVALID INPUT: Enter a proper year~");
                        AddCar();
                    }
                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n~INVALID INPUT: Please enter a number~");
                    AddCar();
                }
            }
            //Choosing anything else loops the method. 
            else
            {
                Console.WriteLine("\n~INVALID INPUT: Please enter new or used~");
                AddCar();
            }
        }
        public void RemoveCar()
        {
            Console.WriteLine();
            for (int i = 0; i < Cars.Count; i++)
            {
                Console.WriteLine($"\n===Vehicle Number [{i + 1}]====");
                Console.WriteLine($"{Cars[i]}");
            }
            Console.WriteLine("\n===Enter [0] to cancel====");
            try
            {
                int input = int.Parse(GetInput("\nWhich vehicle number would you like to buy? "));
                if (input == 0)
                {
                    Console.WriteLine("\n::Purchase Cancelled::");
                    return;
                }
                else if (input - 1 >= 0 && input - 1 < Cars.Count)
                {
                    Console.WriteLine($"\n::You have purchased the {Cars[input - 1].Year} {Cars[input - 1].Make}" +
                        $" {Cars[input - 1].Model}");
                    Cars.RemoveAt(input - 1);
                    Console.WriteLine("::Thank you. Spend more please::");
                    return;
                }
                //If user does not enter a number from list, will loop method.
                else
                {
                    Console.WriteLine("\n~INVALID INPUT: Please pick a number from the list~");
                    RemoveCar();
                }
            }
            //If user does not enter a number from list, will loop method. 
            catch (FormatException)
            {
                Console.WriteLine("\n~INVALID INPUT: Please pick a number from the list~");
                RemoveCar();
            }
        }
        public void ListCars()
        {
            foreach (var car in Cars)
            {
                Console.WriteLine(car);
            }
        }
        public void AdminMode()
        {
            //USERNAME IS ADMIN
            //PASSWORD IS ADMIN
            Console.Write("\nUsername: ");
            string userName = Console.ReadLine();
            Console.Write("\nPassword: ");
            string userPass = Console.ReadLine();
            if (userName == "ADMIN" && userPass == "ADMIN")
            {
                while (true)
                {
                    Console.Write("\n::ADMIN MENU::" +
                        "\n1) Add Car" +
                        "\n2) Remove Car" +
                        "\n3) List Cars" +
                        "\n4) Main Menu" +
                        "\n:: ");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1": //ADD CAR
                            AddCar();
                            break;
                        case "2": //REMOVE CAR
                            RemoveCar();
                            break;
                        case "3": //LIST CARS
                            ListCars();
                            break;
                        case "4": //MAIN MENU
                            return;
                        default:
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\n~INCORRECT USERNAME OR PASSWORD~");
            }
        }
        public bool YearValidator(int year)
        {
            if (year <= 2022 && year >= 1886)
            {
                if (year >= 1886 && year <= 1940)
                {
                    Console.WriteLine("\n~...you sure it runs?...~");
                    return true;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
