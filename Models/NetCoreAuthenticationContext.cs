using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApiApplication.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebApiApplication.Utils
{
    public class NetCoreAuthenticationContext
    {

        string trainingConnection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public NetCoreAuthenticationContext()
        {

        }
        public void AddUser(tblUser user)
        {

            SqlConnection conn2 = new SqlConnection(trainingConnection);

            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn2;



                    cmd.CommandText = "usp_xamarin_IUsers";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Salt", user.Salt);
               

                    conn2.Open();
                    cmd.ExecuteNonQuery();
                    conn2.Close();


                }


            }

        }



        //Login
        public void Login(tblUser user)
        {

            SqlConnection conn2 = new SqlConnection(trainingConnection);

            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn2;



                    cmd.CommandText = "select UserName,Password,Salt from tblUser where UserName=@UserName and Password=@Password";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("Salt", user.Salt);


                    conn2.Open();
                    cmd.ExecuteNonQuery();
                    conn2.Close();


                }


            }






        }

    }
}