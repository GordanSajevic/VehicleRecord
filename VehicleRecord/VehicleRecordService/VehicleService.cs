using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VehicleRecord.Models;

namespace VehicleRecord.VehicleRecordService
{
    public class VehicleService
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-JAQHC5A\\SQLEXPRESS;Initial Catalog=VehicleRecord;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        /// <summary>
        /// Calls a procedure that gets 
        /// list of all vehicles with all data
        /// </summary>
        /// <returns></returns>
        public VehicleModel GetAllVehicles()
        {
            VehicleModel list = new VehicleModel();
            list.vehicles = new List<Vehicle>();
            list.brands = new List<Brand>();
            list.brandModels = new List<BrandModel>();
            list.fuelTypes = new List<FuelType>();
            using (connection)
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("dbo.usp_GetAllVehicles", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
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
                            list.vehicles.Add(vehicle);
                        }
                    }

                    rdr.NextResult();
                    while (rdr.Read())
                    {
                        if (rdr.HasRows)
                        {
                            Brand brand = new Brand();
                            brand.ID = int.Parse(rdr["Id"].ToString());
                            brand.BrandName = rdr["BrandName"].ToString();
                            list.brands.Add(brand);
                        }
                    }

                    rdr.NextResult();
                    while (rdr.Read())
                    {
                        if (rdr.HasRows)
                        {
                            BrandModel brandModel = new BrandModel();
                            brandModel.ID = int.Parse(rdr["Id"].ToString());
                            brandModel.BrandId = int.Parse(rdr["BrandId"].ToString());
                            brandModel.ModelName = rdr["ModelName"].ToString();
                            list.brandModels.Add(brandModel);
                        }
                    }

                    rdr.NextResult();
                    while (rdr.Read())
                    {
                        if (rdr.HasRows)
                        {
                            FuelType fuelType = new FuelType();
                            fuelType.ID = int.Parse(rdr["Id"].ToString());
                            fuelType.TypeName = rdr["TypeName"].ToString();
                            list.fuelTypes.Add(fuelType);
                        }
                    }
                }
                connection.Close();
            }

            return list;
        }

        /// <summary>
        /// Calls a procedure that saves 
        /// vehicle for specified data
        /// </summary>
        /// <returns></returns>
        public void SaveVehicle(Vehicle vehicle)
        {
            using (connection)
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("dbo.usp_SaveVehicle", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", vehicle.ID));
                cmd.Parameters.Add(new SqlParameter("@BrandId", vehicle.Brand.ID));
                cmd.Parameters.Add(new SqlParameter("@BrandModelId", vehicle.BrandModel.ID));
                cmd.Parameters.Add(new SqlParameter("@ChassisNumber", vehicle.ChassisNumber));
                cmd.Parameters.Add(new SqlParameter("@MotorNumber", vehicle.MotorNumber));
                cmd.Parameters.Add(new SqlParameter("@MotorPower", vehicle.MotorPower));
                cmd.Parameters.Add(new SqlParameter("@MotorPower_Hp", vehicle.MotorPower_Hp));
                cmd.Parameters.Add(new SqlParameter("@FuelTypeId", vehicle.FuelType.ID));
                cmd.Parameters.Add(new SqlParameter("@YearOfProduction", vehicle.YearOfProduction));

                cmd.ExecuteNonQuery();
                connection.Close();
            }

        }

        /// <summary>
        /// Calls a stored procedure that
        /// deletes vehicle for specified id
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        public void DeleteVehicle(int vehicleId)
        {
            using (connection)
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("dbo.usp_DeleteVehicle", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", vehicleId));
                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }

    }
}