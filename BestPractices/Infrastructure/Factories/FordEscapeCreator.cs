using Best_Practices.ModelBuilders;
using Best_Practices.Models;

namespace Best_Practices.Infrastructure.Factories
{
    public class FordEscapeCreator : IVehicleFactory
    {
        public Vehicle CreateVehicle()
        {
            var builder = new CarBuilder()
                .SetBrand("Ford")
                .SetModel("Escape")
                .SetColor("Blue");
            return builder.Build();
        }
    }
}
