using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VehicleRecord.Models;

namespace VehicleRecord.VehicleRecordService
{
    public class RecordService
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-JAQHC5A\\SQLEXPRESS;Initial Catalog=VehicleRecord;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        /// <summary>
        /// Calls a procedure that gets
        /// list of all records with all data
        /// </summary>
        /// <returns></returns>
        public RecordModel GetAllRecords()
        {
            RecordModel model = new RecordModel();
            model.records = new List<Record>();
            model.vehicles = new List<Vehicle>();
            model.statuses = new List<Status>();
            using (connection)
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("usp_GetAllRecords", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Record record = new Record();
                        record.Vehicle = new Vehicle();
                        record.Vehicle.Brand = new Brand();
                        record.Vehicle.BrandModel = new BrandModel();
                        record.Vehicle.FuelType = new FuelType();
                        record.Status = new Status();
                        record.ID = int.Parse(rdr["Id"].ToString());
                        record.Vehicle.ID = int.Parse(rdr["VehicleId"].ToString());
                        record.Vehicle.Brand.BrandName = rdr["BrandName"].ToString();
                        record.Vehicle.BrandModel.ModelName = rdr["ModelName"].ToString();
                        record.Vehicle.ChassisNumber = int.Parse(rdr["ChassisNumber"].ToString());
                        record.Vehicle.MotorNumber = int.Parse(rdr["MotorNumber"].ToString());
                        record.Vehicle.MotorPower = int.Parse(rdr["MotorPower"].ToString());
                        record.Vehicle.FuelType.ID = int.Parse(rdr["FuelTypeId"].ToString());
                        record.Vehicle.FuelType.TypeName = rdr["TypeName"].ToString();
                        record.Vehicle.YearOfProduction = int.Parse(rdr["YearOfProduction"].ToString());
                        record.DateFrom = DateTime.Parse(rdr["DateFrom"].ToString()).Date;
                        record.TimeFrom = TimeSpan.Parse(rdr["TimeFrom"].ToString());
                        record.DateTo = DateTime.Parse(rdr["DateTo"].ToString()).Date;
                        record.TimeTo = TimeSpan.Parse(rdr["TimeTo"].ToString());
                        record.LocationFrom = rdr["LocationFrom"].ToString();
                        record.LocationTo = rdr["LocationTo"].ToString();
                        record.DriverName = rdr["DriverName"].ToString();
                        record.DriverSurname = rdr["DriverSurname"].ToString();
                        record.NumberOfPassangers = int.Parse(rdr["NumberOfPassangers"].ToString());
                        record.Status.ID = int.Parse(rdr["StatusId"].ToString());
                        record.Status.StatusName = rdr["StatusName"].ToString();
                        model.records.Add(record);
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

                    rdr.NextResult();
                    while (rdr.Read())
                    {
                        if (rdr.HasRows)
                        {
                            Status status = new Status();
                            status.ID = int.Parse(rdr["Id"].ToString());
                            status.StatusName = rdr["StatusName"].ToString();
                            model.statuses.Add(status);
                        }
                    }


                }
                connection.Close();
            }

            return model;
        }

        /// <summary>
        /// Calls a procedure that saves 
        /// record for specified data
        /// </summary>
        /// <returns></returns>
        public string SaveRecord(Record record)
        {
            string message = "";

            using (connection)
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("dbo.usp_SaveRecord", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", record.ID));
                cmd.Parameters.Add(new SqlParameter("@VehicleId", record.Vehicle.ID));
                cmd.Parameters.Add(new SqlParameter("@DateFrom", record.DateFrom));
                cmd.Parameters.Add(new SqlParameter("@TimeFrom", record.TimeFrom));
                cmd.Parameters.Add(new SqlParameter("@DateTo", record.DateTo));
                cmd.Parameters.Add(new SqlParameter("@TimeTo", record.TimeTo));
                cmd.Parameters.Add(new SqlParameter("@LocationFrom", record.LocationFrom));
                cmd.Parameters.Add(new SqlParameter("@LocationTo", record.LocationTo));
                cmd.Parameters.Add(new SqlParameter("@DriverName", record.DriverName));
                cmd.Parameters.Add(new SqlParameter("@DriverSurname", record.DriverSurname));
                cmd.Parameters.Add(new SqlParameter("@NumberOfPassangers", record.NumberOfPassangers));
                cmd.Parameters.Add(new SqlParameter("@StatusId", record.Status.ID));

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        if (rdr.HasRows)
                        {
                            message = rdr["Message"].ToString();
                        }
                    }

                }
                connection.Close();
            }

            return message;
        }

        /// <summary>
        /// Calls a procedure that updates
        /// record status with specified value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="statusId"></param>
        public void UpdateRecordStatus(int id, int statusId)
        {
            using (connection)
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("dbo.usp_UpdateRecordStatus", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                cmd.Parameters.Add(new SqlParameter("@StatusId", statusId));
                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }
        
    }
}