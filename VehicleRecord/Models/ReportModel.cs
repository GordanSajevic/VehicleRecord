using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleRecord.Models
{
    public class ReportModel
    {
        public List<Report> reports { get; set; }
        public List<Vehicle> vehicles { get; set; }
    }
}