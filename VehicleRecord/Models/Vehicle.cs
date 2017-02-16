using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleRecord.Models
{
    public class Vehicle
    {
        public int ID { get; set; }
        public Brand Brand { get; set; }
        public BrandModel BrandModel { get; set; }
        public int ChassisNumber { get; set; }
        public int MotorNumber { get; set; }
        public float MotorPower { get; set; }
        public float MotorPower_Hp { get; set; }
        public FuelType FuelType{ get; set; }
        public int YearOfProduction { get; set; }
        public bool CanBeDeleted { get; set; }
    }
}