using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApiApplication.Models
{
    public class DalHelper
    {
        protected static string GetStringConnect()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
        public static List<Login> GetLogin()
        {
            List<Login> _login = new List<Login>();
            using (SqlConnection con = new SqlConnection(GetStringConnect()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Training_User where IsDeleted=0", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var loginInfo = new Login();
                                loginInfo.Id = Convert.ToInt32(dr["Id"]);
                                loginInfo.Username = dr["Username"].ToString();
                                loginInfo.Password = dr["Password"].ToString();
                                _login.Add(loginInfo);
                            }
                        }
                        return _login;
                    }
                }
            }
        }


        public static int DeleteUser(Login login)
        {
            int raw = 0;


            using (SqlConnection con = new SqlConnection(GetStringConnect()))
            {
                // con.Open();
                using (SqlCommand cmd = new SqlCommand("Update Training_User set IsDeleted =1 where Id=@Id", con))
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id", login.Id);
                  
                    con.Open();
                    raw = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return raw;

            }

        }
        public static int UpdateUser(Login login)
        {
            int raw = 0;


            using (SqlConnection con = new SqlConnection(GetStringConnect()))
            {
               // con.Open();
                using (SqlCommand cmd = new SqlCommand("Update Training_User set Username =@Username,Password = @Password where Id=@Id", con))
                {
               
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Id", login.Id);
                    cmd.Parameters.AddWithValue("@Username", login.Username);
                    cmd.Parameters.AddWithValue("@Password", login.Password);
                    con.Open();
                    raw = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return raw;

            }

        }

    }
}