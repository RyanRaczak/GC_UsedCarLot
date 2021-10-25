using System;
using System.Collections.Generic;
using System.Text;

namespace GC_UsedCarLot
{
    class UsedCar : Car
    {
        public double Mileage { get; set; } = 0;

        public UsedCar(string Make, string Model, int Year, decimal Price, double Mileage)
            : base(Make, Model, Year, Price)
        {
            this.Mileage = Mileage;
        }

        public override string ToString()
        {
            //Calls parent tostring and adds mileage to the string. 
            return base.ToString() + $"\nMileage: {Mileage}";
        }
    }
}
