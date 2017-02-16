using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VehicleRecord.Models;

namespace VehicleRecord.VehicleRecordService
{
    public class ReportService
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-JAQHC5A\\SQLEXPRESS;Initial Catalog=VehicleRecord;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        /// <summary>
        /// Calls a stored procedure that gets
        /// records report for specified parameters
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="dateFrom"></param>
        /// <param name="DateTo"></param>
        /// <returns></returns>
        public ReportModel GetAllReports()
        {
            ReportModel model = new ReportModel();
            model.reports = new List<Report>();
            model.vehicles = new List<Vehicle>();

            using (connection)
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("usp_GetAllRecordReports", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Report report = new Report();
                        report.ID = int.Parse(rdr["Id"].ToString());
                        report.DateFrom = DateTime.Parse(rdr["DateFrom"].ToString());
                        report.DateTo = DateTime.Parse(rdr["DateTo"].ToString());
                        report.LocationFrom = rdr["LocationFrom"].ToString();
                        report.LocationTo = rdr["LocationTo"].ToString();
                        report.DriverName = rdr["DriverName"].ToString();
                        report.DriverSurname = rdr["DriverSurname"].ToString();
                        report.NumberOfPassangers = int.Parse(rdr["NumberOfPassangers"].ToString());
                        report.StatusName = rdr["StatusName"].ToString();
                        model.reports.Add(report);
                    }

                    rdr.NextResult();
                    while (rdr.Read())
                    {
                        if (rdr.HasRows)
                        {
                            Vehicle vehicle = new Vehicle();
                            vehicle.Brand = new Brand();
                            vehicle.BrandModel = new BrandModel();
                            vehicle.FuelType = new FuelType();
                            vehicle.ID = int.Parse(rdr["Id"].ToString());
                            vehicle.Brand.ID = int.Parse(rdr["BrandId"].ToString());
                            vehicle.Brand.BrandName = rdr["BrandName"].ToString();
                            vehicle.BrandModel.ID = int.Parse(rdr["BrandModelId"].ToString());
                            vehicle.BrandModel.ModelName = rdr["ModelName"].ToString();
                            vehicle.BrandModel.BrandId = vehicle.Brand.ID;
                            vehicle.ChassisNumber = int.Parse(rdr["ChassisNumber"].ToString());
                            vehicle.MotorNumber = int.Parse(rdr["MotorNumber"].ToString());
                            vehicle.MotorPower = float.Parse(rdr["MotorPower"].ToString());
                            vehicle.MotorPower_Hp = float.Parse(rdr["MotorPower_Hp"].ToString());
                            vehicle.FuelType.ID = int.Parse(rdr["FuelTypeId"].ToString());
                            vehicle.FuelType.TypeName = rdr["TypeName"].ToString();
                            vehicle.YearOfProduction = int.Parse(rdr["YearOfProduction"].ToString());
                            vehicle.CanBeDeleted = bool.Parse(rdr["CanBeDeleted"].ToString());
                            model.vehicles.Add(vehicle);
                        }
                    }
                }

            }

            return model;
        }

        /// <summary>
        /// Calls a stored procedure that gets
        /// records report for specified parameters
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="dateFrom"></param>
        /// <param name="DateTo"></param>
        /// <returns></returns>
        public ReportModel GetReport(int vehicleId, DateTime dateFrom, TimeSpan timeFrom, DateTime dateTo, TimeSpan timeTo)
        {
            ReportModel model = new ReportModel();
            model.reports = new List<Report>();
            model.vehicles = new List<Vehicle>();

            using (connection)
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("usp_GetRecordReport", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@VehicleId", vehicleId));
                cmd.Parameters.Add(new SqlParameter("@DateFrom", dateFrom));
                cmd.Parameters.Add(new SqlParameter("@TimeFrom", timeFrom));
                cmd.Parameters.Add(new SqlParameter("@DateTo", dateTo));
                cmd.Parameters.Add(new SqlParameter("@TimeTo", timeTo));

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Report report = new Report();
                        report.ID = int.Parse(rdr["Id"].ToString());
                        report.DateFrom = DateTime.Parse(rdr["DateFrom"].ToString());
                        report.DateTo = DateTime.Parse(rdr["DateTo"].ToString());
                        report.LocationFrom = rdr["LocationFrom"].ToString();
                        report.LocationTo = rdr["LocationTo"].ToString();
                        report.DriverName = rdr["DriverName"].ToString();
                        report.DriverSurname = rdr["DriverSurname"].ToString();
                        report.NumberOfPassangers = int.Parse(rdr["NumberOfPassangers"].ToString());
                        report.StatusName = rdr["StatusName"].ToString();
                        model.reports.Add(report);
                    }

                    rdr.NextResult();
                    while (rdr.Read())
                    {
                        if (rdr.HasRows)
                        {
                            Vehicle vehicle = new Vehicle();
                            vehicle.Brand = new Brand();
                            vehicle.BrandModel = new BrandModel();
                            vehicle.FuelType = new FuelType();
                            vehicle.ID = int.Parse(rdr["Id"].ToString());
                            vehicle.Brand.ID = int.Parse(rdr["BrandId"].ToString());
                            vehicle.Brand.BrandName = rdr["BrandName"].ToString();
                            vehicle.BrandModel.ID = int.Parse(rdr["BrandModelId"].ToString());
                            vehicle.BrandModel.ModelName = rdr["ModelName"].ToString();
                            vehicle.BrandModel.BrandId = vehicle.Brand.ID;
                            vehicle.ChassisNumber = int.Parse(rdr["ChassisNumber"].ToString());
                            vehicle.MotorNumber = int.Parse(rdr["MotorNumber"].ToString());
                            vehicle.MotorPower = float.Parse(rdr["MotorPower"].ToString());
                            vehicle.MotorPower_Hp = float.Parse(rdr["MotorPower_Hp"].ToString());
                            vehicle.FuelType.ID = int.Parse(rdr["FuelTypeId"].ToString());
                            vehicle.FuelType.TypeName = rdr["TypeName"].ToString();
                            vehicle.YearOfProduction = int.Parse(rdr["YearOfProduction"].ToString());
                            vehicle.CanBeDeleted = bool.Parse(rdr["CanBeDeleted"].ToString());
                            model.vehicles.Add(vehicle);
                        }
                    }
                }
            }

            return model;
        }
    }
}