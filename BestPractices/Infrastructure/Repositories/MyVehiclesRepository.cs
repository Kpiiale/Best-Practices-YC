using Best_Practices.Infrastructure.Factories;
using Best_Practices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Best_Practices.Infrastructure.Repositories
{
    public class MyVehiclesRepository : IVehicleRepository
    {
        private readonly List<Vehicle> _vehicles = new List<Vehicle>();

        public ICollection<Vehicle> GetVehicles()
        {
            return _vehicles;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public Vehicle Find(string id)
        {
            return _vehicles.FirstOrDefault(v => v.ID.ToString() == id);
        }
    }
}
