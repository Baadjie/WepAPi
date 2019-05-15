using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using WebApiApplication.Models;
using WebApiApplication.Utils;

namespace WebApiApplication.Controllers
{
    public class RegisterController : ApiController
    {
        ClientDbHelper clientDbHelper = new ClientDbHelper();

        [HttpPost]
        public IHttpActionResult AddUserProfile([FromBody] Client value)
        {


            ClientDbHelper clientDbHelper = new ClientDbHelper();

            Client clientInfo = new Client();
            //
            //dbContext.Add(user);
            //dbContext.SaveChanges();
            //return JsonConvert.SerializeObject("Register succesful");

            clientInfo.EmailAddress = value.EmailAddress;
            clientInfo.FirstName = value.FirstName;
            clientInfo.LastName = value.LastName;
            clientInfo.IsMale = value.IsMale;
            clientInfo.Salt = Convert.ToBase64String(Common.GetRandomSalt(16));
            clientInfo.Password = Convert.ToBase64String(Common.saltHashPassword(Encoding.ASCII.GetBytes(value.Password),
                Convert.FromBase64String(clientInfo.Salt)));
            try
            {

                if (!ModelState.IsValid)
                {

                    return BadRequest(ModelState);
                }
                clientDbHelper.AddUserProfile(clientInfo);
                return Ok("Success");
            }
            catch (Exception)
            {

                return Ok("Something Went Wrong");
            }

        }

        [HttpGet]
        public IEnumerable<confirmOTP> GetconfirmOTP()
        {
            ClientDbHelper claimHelper = new ClientDbHelper();
            return claimHelper.GetOTP();
        }

        [HttpPut]
        public IHttpActionResult resertPassword([FromBody] Client value)
        {
            Client user = new Client();

            user.EmailAddress = value.EmailAddress;
            user.Salt = Convert.ToBase64String(Common.GetRandomSalt(16));
            user.Password = Convert.ToBase64String(Common.saltHashPassword(Encoding.ASCII.GetBytes(value.Password),
                Convert.FromBase64String(user.Salt)));
            try
            {

                if (!ModelState.IsValid)
                {

                    return BadRequest(ModelState);
                }
                clientDbHelper.resertPassword(user);
                return Ok("Success");
            }
            catch (Exception)
            {

                return Ok("Something Went Wrong");
            }
        }
    }
}