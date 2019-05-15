using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace WebApiApplication.Models
{
    public class ClaimDbHelper
    {
        protected static string GetStringConnect()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }


        //Insert into Retentions table
        public void AddClaim(Claims makeClaim)
        {
            //int reg = 0;
            //try
            //{

            using (SqlConnection con = new SqlConnection(GetStringConnect()))
            {
                string sql = "usp_Iclaims";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDClient", makeClaim.IDClient);
                    cmd.Parameters.AddWithValue("@Status1", makeClaim.Status1);
                    //cmd.Parameters.AddWithValue("@TypeOfClaim", makeClaim.TypeOfClaim);
      
                    cmd.Parameters.AddWithValue("@Comments", makeClaim.Comments);
                    //cmd.Parameters.AddWithValue("@UserName", makeClaim.UserName);
                    cmd.Parameters.AddWithValue("@UnpaidReason", makeClaim.UnpaidReason);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            // return reg;
            //}
            //catch
            //{
            // throw;
            //} 
        }

        //Upload File
        public void UploadFile(File file)
        {
            //int reg = 0;
            //try
            //{

            using (SqlConnection con = new SqlConnection(GetStringConnect()))
            {
                string sql = "AddFileDetails";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FileName", file.FileName);
                    cmd.Parameters.AddWithValue("@filePath", file.filePath);
        
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            // return reg;
            //}
            //catch
            //{
            // throw;
            //} 
        }

        public Retention GetClaim(int IDClient)
        {


            try
            {
               
                using (SqlConnection con = new SqlConnection(GetStringConnect()))
                {
                    string sql = "usp_GetRetentions";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ClientID", IDClient);
                        con.Open();

                        Retention retention = new Retention();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {


                            if (dr != null)
                            {
                                while (dr.Read())
                                {


                                    retention.IDClient = Convert.ToInt32(dr["IDClient"]);
                                    retention.Make = dr["Make"].ToString();
                                    retention.Status1 = dr["Status1"].ToString();
                                    retention.Comments = dr["Comments"].ToString();
                                    retention.UnpaidReason = dr["UnpaidReason"].ToString();
                                    retention.Make = dr["Make"].ToString();
                                }
                                con.Close();
                            }

                        }
                        return retention;
                    }
                }
            }
            catch
            {

                throw;
            }


        
           
        }




        public List<Retention> GetClaimTypes(string RetentionType)
        {

            List<Retention> claimList = new List<Retention>();

            using (SqlConnection con = new SqlConnection(GetStringConnect()))
            {
                string sql = "usp_getRetentionType";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RetentionType", RetentionType);
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {


                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Retention claim = new Retention();

                                claim.IDRetentionTask = Convert.ToInt32(dr["IDRetentionTask"]);
                                claim.RetentionStatus = dr["RetentionStatus"].ToString();
                                claimList.Add(claim);
                            }
                            con.Close();
                        }
                        return claimList;
                    }
                }
            }
        }




        public void sendEmail()
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.xinixinsurance.co.za", 587);
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("support2@xinixinsurance.co.za", "willbe123");
                MailMessage msg = new MailMessage();
                msg.To.Add("support1@xinixinsurance.co.za");
                msg.From = new MailAddress("support2@xinixinsurance.co.za");
                msg.Subject = "test data";
                msg.Body = "Testing smtp email";
                client.Send(msg);


            }
            catch (Exception ex)
            {

            }
        }

    }
}