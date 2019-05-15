using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApiApplication.Models
{
    public class OTPDbHelper
    {
        protected static string GetStringConnect()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public void SaveOTP(confirmOTP otp)
        {
            SqlConnection con = new SqlConnection(GetStringConnect());
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;

                    cmd.CommandText = "usp_IOTP";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmailAddress", otp.EmailAddress);
                    cmd.Parameters.AddWithValue("@OTP", otp.OTP);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public void updateUserOTP(confirmOTP otp)
        {
            SqlConnection con = new SqlConnection(GetStringConnect());
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;

                    cmd.CommandText = "usp_UemailOTP";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmailAddress", otp.EmailAddress);
                    cmd.Parameters.AddWithValue("@NewEmail", otp.NewEmail);
                    cmd.Parameters.AddWithValue("@OTP", otp.OTP);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public List<confirmOTP> GetOTP(string EmailAddress)
        {
            //Vehicle vehicleInfo = null;
            List<confirmOTP> otp_list = new List<confirmOTP>();

            using (SqlConnection con = new SqlConnection(GetStringConnect()))
            {
                string sql = "usp_GetOTP";
                using (SqlCommand cmd = new SqlCommand(sql, con))
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
                                var otp_num = new confirmOTP();

                                otp_num.Id = Convert.ToInt32(dr["Id"]);

                                otp_num.OTP = dr["OTP"].ToString();
                                otp_num.EmailAddress = dr["EmailAddress"].ToString();
                                otp_list.Add(otp_num);
                            }
                            con.Close();
                        }
                        return otp_list;
                    }
                }
            }
        }

    }
}