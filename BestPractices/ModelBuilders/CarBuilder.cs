using Best_Practices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Best_Practices.ModelBuilders
{
    public class DefaultCarProperties
    {
        public int Year { get; set; } = DateTime.Now.Year;
        public string EngineType { get; set; } = "V6";
        public int Doors { get; set; } = 4;
        public bool AirConditioning { get; set; } = true;
        public bool ABS { get; set; } = true;
    }

    public class CarBuilder
    {
        private string _color;
        private string _brand;
        private string _model;
        private double _fuelLimit = 10;
        private int _year = DateTime.Now.Year;

        public CarBuilder SetColor(string color)
        {
            _color = color;
            return this;
        }

        public CarBuilder SetBrand(string brand)
        {
            _brand = brand;
            return this;
        }

        public CarBuilder SetModel(string model)
        {
            _model = model;
            return this;
        }

        public CarBuilder SetFuelLimit(double limit)
        {
            _fuelLimit = limit;
            return this;
        }

  
        public CarBuilder SetYear(int year)
        {
            _year = year;
            return this;
        }

        public Car Build()
        {
            var car = new Car(_color, _brand, _model)
            {
                FuelLimit = _fuelLimit
            };

            return car;
        }
    }
}
