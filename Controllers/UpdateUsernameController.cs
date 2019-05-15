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
    public class UpdateUsernameController : ApiController
    {
        ClientDbHelper clientDbHelper = new ClientDbHelper();

        [HttpPut]
        public IHttpActionResult resertUsername([FromBody] Client value)
        {
            Client user = new Client();

            user.EmailAddress = value.EmailAddress;
            user.NewEmail = value.NewEmail;
            user.Salt = Convert.ToBase64String(Common.GetRandomSalt(16));
            user.Password = Convert.ToBase64String(Common.saltHashPassword(Encoding.ASCII.GetBytes(value.Password),
                Convert.FromBase64String(user.Salt)));
            try
            {

                if (!ModelState.IsValid)
                {

                    return BadRequest(ModelState);
                }
                clientDbHelper.resertUsername(user);
                return Ok("Success");
            }
            catch (Exception)
            {

                return Ok("Something Went Wrong");
            }
        }


        //OTPDbHelper otpHelper = new OTPDbHelper();

        //[HttpPut]
        //public IHttpActionResult saveOTP([FromBody] confirmOTP value)
        //{
        //    confirmOTP otp = new confirmOTP();
        //    otp.EmailAddress = value.EmailAddress;
        //    otp.OTP = value.OTP;
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        otpHelper.SaveOTP(otp);
        //        return Ok("Success");
        //    }
        //    catch (Exception)
        //    {

        //        return Ok("Something Went Wrong");
        //    }
        //}
    }
}
