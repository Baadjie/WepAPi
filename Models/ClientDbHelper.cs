using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApiApplication.Models
{


   
    public class ClientDbHelper
    {

        //string trainingConnection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        protected static string GetStringConnect()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public ClientDbHelper()
        {

        }

        //Retrive client Information
        public static List<Client> GetClient()
        {
            List<Client> _client = new List<Client>();
            using (SqlConnection con = new SqlConnection(GetStringConnect()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Client WHERE Id =1", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var clientInfo = new Client();
                                clientInfo.Id = Convert.ToInt32(dr["Id"]);
                                clientInfo.FirstName = dr["FirstName"].ToString();
                                clientInfo.LastName = dr["LastName"].ToString();
                                clientInfo.EmailAddress = dr["EmailAddress"].ToString();                       
                                clientInfo.IsMale = Convert.ToBoolean(dr["IsMale"]);
                                clientInfo.TitleId = Convert.ToInt32(dr["TitleId"]);
                                clientInfo.DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]);

                                clientInfo.MaritalStatusId = Convert.ToInt32(dr["MaritalStatusId"]);
                                clientInfo.IdentityNo = dr["IdentityNo"].ToString();
                                clientInfo.HomeAddress = dr["HomeAddress"].ToString();
                                clientInfo.HomeSurburb = dr["HomeSurburb"].ToString();
                                clientInfo.HomePostalCode = dr["HomePostalCode"].ToString();

                  
                                clientInfo.BusinessPhone = dr["BusinessPhone"].ToString();
                                clientInfo.MobilePhone = dr["MobilePhone"].ToString();
                                clientInfo.ITCCheck = Convert.ToBoolean(dr["ITCCheck"]);
                                clientInfo.Employer = dr["Employer"].ToString();
                                clientInfo.Occupation = dr["Occupation"].ToString();


                                clientInfo.Category = dr["Category"].ToString();
                                clientInfo.SequestratedOrLiquidated = Convert.ToBoolean(dr["SequestratedOrLiquidated"]);

                                clientInfo.City = dr["City"].ToString();
                                clientInfo.Comment = dr["Comment"].ToString();
                                clientInfo.ClientStatusId = Convert.ToInt32(dr["ClientStatusId"]);
                                clientInfo.CompanyName = dr["CompanyName"].ToString();
                                clientInfo.PassportNumber = dr["PassportNumber"].ToString();
                                clientInfo.UnderDebtReview = Convert.ToBoolean(dr["UnderDebtReview"]);
                                _client.Add(clientInfo);
                            }
                        }
                        return _client;
                    }
                }
            }
        }


        //Login
        public ClientLogin LoginDb(string email/*, string password*/)
        {

            try
            {
                ClientLogin clientLogin = new ClientLogin();
                using (SqlConnection con = new SqlConnection(GetStringConnect()))
                {
                    // string sqlQuery = "SELECT * from Client_Login where EmailAddress='" + email + "' and Password = '" + password + "'"; ;
                    //string sqlQuery = "SELECT * FROM Client_Login WHERE EmailAddress='pastorR@gmail.com' and Password='1234'";// + email + "and Password ='1234'" + password;
                    string sqlQuery = "SELECT * from Client_Login where EmailAddress='" + email+"'";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        clientLogin.Id = Convert.ToInt32(dr["Id"]);
                        clientLogin.ClientID = Convert.ToInt32(dr["ClientID"]);
                        clientLogin.EmailAddress = dr["EmailAddress"].ToString();
                        clientLogin.Password = dr["Password"].ToString();
                        clientLogin.Salt = dr["Salt"].ToString();

                        clientLogin.Roles = dr["Roles"].ToString();
                    }
                }


                return clientLogin;
            }
            catch
            {
                throw;
            }
        }

        public virtual DbSet<ClientLogin> ClientLoginn { get; set; }

        //retrive by id
        //https://ankitsharmablogs.com/crud-operations-asp-net-core-using-angular-5-ado-net/

        //public Client GetClientByID(string email)
        public  List<Client> GetClientByID(string email)
        {
            try
            {
               
                List<Client> client_list = new List<Client>();

                using (SqlConnection con = new SqlConnection(GetStringConnect()))
                {


                    string sqlQuery = "SELECT * FROM Client WHERE EmailAddress='" + email + "'";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var clientInfo = new Client();
                                clientInfo.Id = Convert.ToInt32(dr["Id"]);
                                clientInfo.FirstName = dr["FirstName"].ToString();
                                clientInfo.LastName = dr["LastName"].ToString();
                                clientInfo.EmailAddress = dr["EmailAddress"].ToString();
                                clientInfo.IsMale = Convert.ToBoolean(dr["IsMale"]);
                                clientInfo.TitleId = Convert.ToInt32(dr["TitleId"]);
                                clientInfo.DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]);

                                clientInfo.MaritalStatusId = Convert.ToInt32(dr["MaritalStatusId"]);
                                clientInfo.IdentityNo = dr["IdentityNo"].ToString();
                                clientInfo.HomeAddress = dr["HomeAddress"].ToString();
                                clientInfo.HomeSurburb = dr["HomeSurburb"].ToString();
                                clientInfo.HomePostalCode = dr["HomePostalCode"].ToString();


                                clientInfo.BusinessPhone = dr["BusinessPhone"].ToString();
                                clientInfo.MobilePhone = dr["MobilePhone"].ToString();
                                clientInfo.ITCCheck = Convert.ToBoolean(dr["ITCCheck"]);
                                clientInfo.Employer = dr["Employer"].ToString();
                                clientInfo.Occupation = dr["Occupation"].ToString();


                                clientInfo.Category = dr["Category"].ToString();
                                clientInfo.SequestratedOrLiquidated = Convert.ToBoolean(dr["SequestratedOrLiquidated"]);

                                clientInfo.City = dr["City"].ToString();
                                clientInfo.Comment = dr["Comment"].ToString();
                                clientInfo.ClientStatusId = Convert.ToInt32(dr["ClientStatusId"]);
                                clientInfo.CompanyName = dr["CompanyName"].ToString();
                                clientInfo.PassportNumber = dr["PassportNumber"].ToString();
                                clientInfo.UnderDebtReview = Convert.ToBoolean(dr["UnderDebtReview"]);

                                client_list.Add(clientInfo);
                            }
                            
                        }
                        return client_list;
                    }
                }

               
            }
            catch
            {
                throw;
            }
        }
        //Register new Client
        public void AddUserProfile(Client clientInfo)
        {

           
            SqlConnection conn2 = new SqlConnection(GetStringConnect());

            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn2;



                    cmd.CommandText = "usp_IClient";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", clientInfo.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", clientInfo.LastName);
                    cmd.Parameters.AddWithValue("@EmailAddress", clientInfo.EmailAddress);
                    cmd.Parameters.AddWithValue("@Password", clientInfo.Password);
                    cmd.Parameters.AddWithValue("@Salt", clientInfo.Salt);
                    cmd.Parameters.AddWithValue("@IsMale", clientInfo.IsMale);
                  
                    conn2.Open();
                    cmd.ExecuteNonQuery();
                    conn2.Close();


                }


            }

        }

        //Add File
        //Register new Client
        public void SaveFile(File file)
        {

            if(file.FileName !="" && file.filePath != "")
            {

                SqlConnection conn2 = new SqlConnection(GetStringConnect());

                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn2;



                        cmd.CommandText = "AddFileDetails";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@FileName", file.FileName);
                        //cmd.Parameters.AddWithValue("@FileContent", file.FileContent);
                        cmd.Parameters.AddWithValue("@filePath", file.filePath);



                        conn2.Open();
                        cmd.ExecuteNonQuery();
                        conn2.Close();


                    }


                }


            }
            else
            {
                SqlConnection conn2 = new SqlConnection(GetStringConnect());

                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn2;



                        cmd.CommandText = "AddFileDetails";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@FileName", "fggfgfgf");
                        //cmd.Parameters.AddWithValue("@FileContent", file.FileContent);
                        cmd.Parameters.AddWithValue("@filePath", "gfgfgfgfgf");



                        conn2.Open();
                        cmd.ExecuteNonQuery();
                        conn2.Close();


                    }


                }
            }
   

        }



        //Update Client info

        public static void UpdateClientInfo(Client clientInfo)
        {
            SqlConnection conn2 = new SqlConnection(GetStringConnect());

            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn2;



                    cmd.CommandText = "usp_UClient";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", clientInfo.Id);
                    //cmd.Parameters.AddWithValue("@FirstName", clientInfo.FirstName);
                    //cmd.Parameters.AddWithValue("@LastName", clientInfo.LastName);
                    //cmd.Parameters.AddWithValue("@Username", clientInfo.Username);
                    //cmd.Parameters.AddWithValue("@Password", clientInfo.Password);
                    //cmd.Parameters.AddWithValue("@Salt", clientInfo.Salt);
                    cmd.Parameters.AddWithValue("@IsMale", clientInfo.IsMale);
                    cmd.Parameters.AddWithValue("@TitleId", clientInfo.TitleId);
                    cmd.Parameters.AddWithValue("@DateOfBirth", clientInfo.DateOfBirth);
                    cmd.Parameters.AddWithValue("@MaritalStatusId", clientInfo.MaritalStatusId);
                    cmd.Parameters.AddWithValue("@IdentityNo", clientInfo.IdentityNo);
                    cmd.Parameters.AddWithValue("@HomeAddress", clientInfo.HomeAddress);
                    cmd.Parameters.AddWithValue("@HomeSurburb", clientInfo.HomeSurburb);

                    cmd.Parameters.AddWithValue("@HomePostalCode", clientInfo.HomePostalCode);
                    cmd.Parameters.AddWithValue("@BusinessPhone", clientInfo.BusinessPhone);
                    cmd.Parameters.AddWithValue("@MobilePhone", clientInfo.MobilePhone);
                    cmd.Parameters.AddWithValue("@ITCCheck", clientInfo.ITCCheck);
                    cmd.Parameters.AddWithValue("@Occupation", clientInfo.Occupation);
                    cmd.Parameters.AddWithValue("@Category", clientInfo.Category);
                    cmd.Parameters.AddWithValue("@SequestratedOrLiquidated", clientInfo.SequestratedOrLiquidated);

                    cmd.Parameters.AddWithValue("@City", clientInfo.City);
                    cmd.Parameters.AddWithValue("@Comment", clientInfo.Comment);
                    cmd.Parameters.AddWithValue("@ClientStatusId", clientInfo.ClientStatusId);
                    cmd.Parameters.AddWithValue("@CompanyName", clientInfo.CompanyName);
                    cmd.Parameters.AddWithValue("@PassportNumber", clientInfo.PassportNumber);
                    cmd.Parameters.AddWithValue("@UnderDebtReview", clientInfo.UnderDebtReview);

                    conn2.Open();
                    cmd.ExecuteNonQuery();
                    conn2.Close();


                }


            }

        }


        //reset username
        public void resertUsername(Client client)
        {
            //int reg = 0;
            using (SqlConnection con1 = new SqlConnection(GetStringConnect()))
            {

                string sql = "usp_UResertUsername";
                using (SqlCommand cmd = new SqlCommand(sql, con1))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@Id", client.Id);
                    cmd.Parameters.AddWithValue("@EmailAddress", client.EmailAddress);
                    cmd.Parameters.AddWithValue("@NewEmail", client.NewEmail);
                    cmd.Parameters.AddWithValue("@Password", client.Password);
                    cmd.Parameters.AddWithValue("@Salt", client.Salt);

                    con1.Open();
                    cmd.ExecuteNonQuery();
                    con1.Close();
                }
                // return reg;
            }
        }


        //Resert password
        public void resertPassword(Client client)
        {
            //int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConnect()))
            {
                string sql = "usp_UResertPassword";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmailAddress", client.EmailAddress);
                    cmd.Parameters.AddWithValue("@Password", client.Password);
                    cmd.Parameters.AddWithValue("@Salt", client.Salt);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                // return reg;
            }
        }


        public IEnumerable<confirmOTP> GetOTP()
        {
            List<confirmOTP> _otp = new List<confirmOTP>();
            using (SqlConnection con = new SqlConnection(GetStringConnect()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Login_OTP", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var otpInfo = new confirmOTP();
                                otpInfo.Id = Convert.ToInt32(dr["Id"]);
                                otpInfo.EmailAddress = dr["EmailAddress"].ToString();
                                otpInfo.OTP = dr["OTP"].ToString();
                                _otp.Add(otpInfo);
                            }
                            con.Close();
                        }
                        return _otp;
                    }
                }
            }
        }

    }
}