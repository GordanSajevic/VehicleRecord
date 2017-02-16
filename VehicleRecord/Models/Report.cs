using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleRecord.Models
{
    public class Report
    {
        public int ID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string LocationFrom { get; set; }
        public string LocationTo { get; set; }
        public string DriverName { get; set; }
        public string DriverSurname { get; set; }
        public int NumberOfPassangers { get; set; }
        public string StatusName { get; set; }
    }
}