using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApiApplication.Models
{
    public class VehicleDbHelper
    {

        protected static string GetStringConnect()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

       public VehicleDbHelper()
        {

        }

        public Vehicle GetVehicleByClientId(int clientID)
        {
            //Vehicle vehicleInfo = null;
           // List<Vehicle> vehicleInfo_list = new List<Vehicle>();

            using (SqlConnection con = new SqlConnection(GetStringConnect()))
            {
                string sql = "usp_GetVehicleByClientID";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClientID", clientID);
                    con.Open();

                    Vehicle vehicleInfo = new Vehicle();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {


                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                              //  var vehicleInfo = new Vehicle();

                                vehicleInfo.Id = Convert.ToInt32(dr["Id"]);

                                vehicleInfo.ClientID = Convert.ToInt32(dr["ClientID"]);
                                //vehicleInfo.AccessoriesValue = Convert.ToDecimal(dr["AccessoriesValue"]);
                                vehicleInfo.Year = dr["Year"].ToString();
                                vehicleInfo.Make = dr["Make"].ToString();
                                vehicleInfo.Model = dr["Model"].ToString();
                                vehicleInfo.EngineNumber = dr["EngineNumber"].ToString();
                                vehicleInfo.VINNumber = dr["VINNumber"].ToString();
                                vehicleInfo.MMCode = dr["MMCode"].ToString();
                                vehicleInfo.Variant = dr["Variant"].ToString();
                                vehicleInfo.LicensePlate = dr["LicensePlate"].ToString();
                                //vehicleInfo_list.Add(vehicleInfo);
                            }
                            con.Close();
                        }
                        return vehicleInfo;
                    }
                }
            }
        }


        public List<Vehicle> GetVehicleById(string EmailAddress)
        {
            //Vehicle vehicleInfo = null;
            List<Vehicle> vehicleInfo_list = new List<Vehicle>();

            using (SqlConnection con = new SqlConnection(GetStringConnect()))
            {
                string sql = "usp_GetVehicle";
                using (SqlCommand cmd = new SqlCommand(sql,con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmailAddress", EmailAddress);
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
   

                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var vehicleInfo = new Vehicle();

                                vehicleInfo.Id = Convert.ToInt32(dr["Id"]);
                       
                                vehicleInfo.ClientID = Convert.ToInt32(dr["ClientID"]);
                                //vehicleInfo.AccessoriesValue = Convert.ToDecimal(dr["AccessoriesValue"]);
                                vehicleInfo.Year = dr["Year"].ToString();
                                vehicleInfo.Make = dr["Make"].ToString();
                                vehicleInfo.Model = dr["Model"].ToString();
                                vehicleInfo.EngineNumber = dr["EngineNumber"].ToString();
                                vehicleInfo.VINNumber = dr["VINNumber"].ToString();
                                vehicleInfo.MMCode = dr["MMCode"].ToString();
                                vehicleInfo.Variant = dr["Variant"].ToString();
                                vehicleInfo.LicensePlate = dr["LicensePlate"].ToString();
                                vehicleInfo_list.Add(vehicleInfo);
                            }
                            con.Close();
                        }
                        return vehicleInfo_list;
                    }
                }
            }
        }

    }
}