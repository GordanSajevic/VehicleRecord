using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleRecord.Models
{
    public class VehicleModel
    {
        public List<Vehicle> vehicles { get; set; }
        public List<Brand> brands { get; set; }
        public List<BrandModel> brandModels { get; set; }
        public List<FuelType> fuelTypes { get; set; }
    }
}