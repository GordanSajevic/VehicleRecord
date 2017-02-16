using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleRecord.Models
{
    public class RecordModel
    {
        public List<Record> records { get; set; }
        public List<Vehicle> vehicles { get; set; }
        public List<Status> statuses { get; set; }
    }
}