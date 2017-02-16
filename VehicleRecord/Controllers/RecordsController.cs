using System;
using System.Collections.Generic;
using System.Web.Mvc;
using VehicleRecord.Models;
using VehicleRecord.VehicleRecordService;

namespace VehicleRecord.Controllers
{
    public class RecordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private RecordService recordService = new RecordService();

        /// <summary>
        /// Calls service method that
        /// returns list of all records
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            RecordModel model = recordService.GetAllRecords();
            return View(model);
        }

        /// <summary>
        /// Creates record model, and calls service method 
        /// that saves vehicle for specified parameters
        /// </summary>
        /// <param name="recordId"></param>
        /// <param name="vehicleId"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="locationFrom"></param>
        /// <param name="locationTo"></param>
        /// <param name="driverName"></param>
        /// <param name="driverSurname"></param>
        /// <param name="numOfPassangers"></param>
        /// <param name="statusId"></param>
        /// <returns></returns>
        [HttpPost]
        public string SaveRecord(int recordId, int vehicleId, DateTime dateFrom, TimeSpan timeFrom, DateTime dateTo, TimeSpan timeTo, string locationFrom, string locationTo, string driverName, string driverSurname, int numOfPassangers, int statusId)
        {
            Record record = new Record();
            record.Vehicle = new Vehicle();
            record.Status = new Status();
            record.ID = recordId;
            record.Vehicle.ID = vehicleId;
            record.DateFrom = dateFrom;
            record.TimeFrom = timeFrom;
            record.DateTo = dateTo;
            record.TimeTo = timeTo;
            record.LocationFrom = locationFrom;
            record.LocationTo = locationTo;
            record.DriverName = driverName;
            record.DriverSurname = driverSurname;
            record.NumberOfPassangers = numOfPassangers;
            record.Status.ID = statusId;

            return recordService.SaveRecord(record);
        }

        /// <summary>
        /// Calls service method that updates
        /// record status for specified value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="statusId"></param>
        [HttpPost]
        public void UpdateRecordStatus(int id, int statusId)
        {
            recordService.UpdateRecordStatus(id, statusId);
        }
    }
}
