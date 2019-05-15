using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebApiApplication.Models;
using WebApiApplication.Utils;

namespace WebApiApplication.Controllers
{
    public class SigniController : ApiController
    {

        //NetCoreAuthenticationContext dbContext = new NetCoreAuthenticationContext();

        insuranceDBEntities insuranceDB = new insuranceDBEntities();
        
    // POST api/<controller>
    [HttpPost]
        public string Post([FromBody]tblUser value)
        {


            if (insuranceDB.tblUsers.Any(User=> User.UserName.Equals(value.UserName)))
            {
                tblUser user = insuranceDB.tblUsers.Where(u => u.UserName.Equals(value.UserName)).First();

                var client_post_hash_password = Convert.ToBase64String(
                    Common.saltHashPassword(
                        Encoding.ASCII.GetBytes(value.Password),
                        Convert.FromBase64String(user.Salt)));
                if(client_post_hash_password.Equals(user.Password))
                    return JsonConvert.SerializeObject(user);

                else
                    return JsonConvert.SerializeObject("Wrong Password");
            }

            else
            {

                return JsonConvert.SerializeObject("User not Existing in Database");
            }
            // tblUser user = new tblUser();


            //user.UserName = value.UserName;
            //var client_post_hash_password = Convert.ToBase64String(
            //    Common.saltHashPassword(
            //        Encoding.ASCII.GetBytes(value.Password),
            //        Convert.FromBase64String(user.Salt)));


            //if (client_post_hash_password.Equals(user.Password))
            //{
            //  //  dbContext.Login(user);
            //    return JsonConvert.SerializeObject(user);

            //}
            //else

            //    return JsonConvert.SerializeObject("Wrong Password");






        }

    
    }

}