using Best_Practices.Infrastructure.Factories;
using Best_Practices.ModelBuilders;
using Best_Practices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Best_Practices.Infrastructure.Factories
{
    public class FordExplorerCreator : IVehicleFactory
    {
        public Vehicle CreateVehicle()
        {
            var builder = new CarBuilder()
                .SetBrand("Ford")
                .SetModel("Explorer")
                .SetColor("Black");
            return builder.Build();
        }
    }
}
