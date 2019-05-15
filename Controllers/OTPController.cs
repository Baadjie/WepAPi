using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApiApplication.Models;

namespace WebApiApplication.Controllers
{
    public class OTPController : ApiController
    {
        OTPDbHelper otpHelper = new OTPDbHelper();

        [HttpPut]
        public IHttpActionResult saveOTP([FromBody] confirmOTP value)
        {
            confirmOTP otp = new confirmOTP();
            otp.EmailAddress = value.EmailAddress;
            otp.OTP = value.OTP;
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                otpHelper.SaveOTP(otp);
                return Ok("Success");
            }
            catch (Exception)
            {

                return Ok("Something Went Wrong");
            }
        }
    }
}