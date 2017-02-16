using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VehicleRecord.Models;
using VehicleRecord.VehicleRecordService;

namespace VehicleRecord.Controllers
{
    public class ReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ReportService reportService = new ReportService();

        /// <summary>
        /// Calls service method that
        /// returns list of all records
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(reportService.GetAllReports());
        }


        /// <summary>
        /// Calls a method that gets list of
        /// reports for specified parameters
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(int vehicleReportId, DateTime dateFromReport, TimeSpan timeFromReport, DateTime dateToReport, TimeSpan timeToReport)
        {
            ReportModel model = new ReportModel();

            model = reportService.GetReport(vehicleReportId, dateFromReport, timeFromReport, dateToReport, timeToReport);

            return View(model);
        }

    }
}
