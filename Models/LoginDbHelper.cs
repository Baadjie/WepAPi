using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApiApplication.Models
{
    public class LoginDbHelper
    {
        public LoginDbHelper()
        {


        }

        protected static string GetStringConnect()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
        public ClientLogin LoginDb(string email/*, string password*/)
        {

            try
            {
                ClientLogin clientLogin = new ClientLogin();
                using (SqlConnection con = new SqlConnection(GetStringConnect()))
                {
                    string sqlQuery = "SELECT * FROM Client WHERE Id= " + email /*"SELECT * FROM Client_Login WHERE EmailAddress= '" + email + "' and Password='" + password + "'"*/;
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

    }
}