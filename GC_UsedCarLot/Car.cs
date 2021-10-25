using System;
using System.Collections.Generic;
using System.Text;

namespace GC_UsedCarLot
{
    class Car
    {
        public string Make { get; set; } = "NA";
        public string Model { get; set; } = "NA";
        public int Year { get; set; } = 0000;
        public decimal Price { get; set; } = 0;


        public Car() { }
        public Car(string Make, string Model, int Year, decimal Price)
        {
            this.Make = Make;
            this.Model = Model;
            this.Year = Year;
            this.Price = Price;
        }
        public override string ToString()
        {
            return $"\nMake: {Make}\nModel: {Model}\nYear: {Year}\nPrice: {Price:c}";
        }
    }
}
