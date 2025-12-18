using Best_Practices.Models;
using System.Collections.Generic;
using System.Linq;

namespace Best_Practices.Infrastructure.Repositories
{
    public class InMemoryVehicleRepository : IVehicleRepository
    {
        private readonly List<Vehicle> _vehicles = new List<Vehicle>();

        public ICollection<Vehicle> GetVehicles() => _vehicles;

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
