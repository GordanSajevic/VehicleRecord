using System;
using System.Collections.Generic;
using System.Web.Mvc;
using VehicleRecord.Models;
using VehicleRecord.VehicleRecordService;

namespace VehicleRecord.Controllers
{
    public class VehiclesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private VehicleService vehicleService = new VehicleService();

        /// <summary>
        /// Calls service method that
        /// returns list of all vehicles
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            VehicleModel list = vehicleService.GetAllVehicles();
            return View(list);
        }

        /// <summary>
        /// Creates vehicle model, and calls service method 
        /// that saves vehicle for specified parameters
        /// </summary>
        /// <param name="id"></param>
        /// <param name="brandId"></param>
        /// <param name="brandName"></param>
        /// <param name="brandModelId"></param>
        /// <param name="brandModelName"></param>
        /// <param name="chassisNumber"></param>
        /// <param name="motorNumber"></param>
        /// <param name="motorPower"></param>
        /// <param name="fuelType"></param>
        /// <param name="yearOfProduction"></param>
        /// <returns></returns>
        [HttpPost]
        public void SaveVehicle(int id, int brandId, int brandModelId, int chassisNumber, int motorNumber, int motorPower, int motorPower_Hp, int fuelTypeId, int yearOfProduction)
        {
            Vehicle vehicle = new Vehicle();
            vehicle.ID = id;
            vehicle.Brand = new Brand();
            vehicle.BrandModel = new BrandModel();
            vehicle.FuelType = new FuelType();
            vehicle.Brand.ID = brandId;
            vehicle.BrandModel.ID = brandModelId;
            vehicle.BrandModel.BrandId = brandId;
            vehicle.FuelType.ID = fuelTypeId;
            vehicle.ChassisNumber = chassisNumber;
            vehicle.MotorNumber = motorNumber;
            vehicle.MotorPower = motorPower;
            vehicle.MotorPower_Hp = motorPower_Hp;
            vehicle.YearOfProduction = yearOfProduction;
            vehicleService.SaveVehicle(vehicle);
        }

        /// <summary>
        /// Calls service method that deletes
        /// vehicle for specified id
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        [HttpPost]
        public void DeleteVehicle(int vehicleId)
        {
            vehicleService.DeleteVehicle(vehicleId);
        }

    }
}
