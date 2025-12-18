using Best_Practices.Infrastructure.Factories;
using Best_Practices.Infrastructure.Repositories;
using Best_Practices.Infrastructure.Singletons;
using Best_Practices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Best_Practices.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleFactory _vehicleFactory;

        public HomeController(
            IVehicleRepository vehicleRepository,
            IVehicleFactory vehicleFactory,
            ILogger<HomeController> logger)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleFactory = vehicleFactory;
            _logger = logger;
        }

        public IActionResult Index(string? error = null)
        {
            var model = new HomeViewModel
            {
                Vehicles = _vehicleRepository.GetVehicles()
            };

            ViewBag.ErrorMessage = error;
            return View(model);
        }

        [HttpGet("/Home/AddVehicle/{type}")]
        public IActionResult AddVehicle(string type)
        {
            try
            {
                IVehicleFactory factory = type.ToLower() switch
                {
                    "mustang" => new FordMustangCreator(),
                    "explorer" => new FordExplorerCreator(),
                    "escape" => new FordEscapeCreator(),
                    _ => throw new ArgumentException("Modelo de vehículo desconocido.")
                };

                var vehicle = factory.CreateVehicle();
                _vehicleRepository.AddVehicle(vehicle);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar vehículo");
                return RedirectToAction(nameof(Index), new { error = ex.Message });
            }
        }

        [HttpGet("/Home/StartEngine/{id}")]
        public IActionResult StartEngine(string id) => TryAction(() =>
        {
            var vehicle = _vehicleRepository.Find(id);
            vehicle.StartEngine();
        });

        [HttpGet("/Home/StopEngine/{id}")]
        public IActionResult StopEngine(string id) => TryAction(() =>
        {
            var vehicle = _vehicleRepository.Find(id);
            vehicle.StopEngine();
        });

        [HttpGet("/Home/AddGas/{id}")]
        public IActionResult AddGas(string id) => TryAction(() =>
        {
            var vehicle = _vehicleRepository.Find(id);
            vehicle.AddGas();
        });

        private IActionResult TryAction(Action action)
        {
            try
            {
                action();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Error en acción de vehículo");
                return RedirectToAction(nameof(Index), new { error = ex.Message });
            }
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}