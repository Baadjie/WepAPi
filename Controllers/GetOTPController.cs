using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApiApplication.Models;

namespace WebApiApplication.Controllers
{
    public class GetOTPController : ApiController
    {

        [HttpPost]
        public List<confirmOTP> Details(confirmOTP value)
        {
            OTPDbHelper otpHelper = new OTPDbHelper();
            return otpHelper.GetOTP(value.EmailAddress);
        }

        OTPDbHelper otpHelper = new OTPDbHelper();

        [HttpPut]
        public IHttpActionResult usernameOTP([FromBody] confirmOTP value)
        {
            confirmOTP otp = new confirmOTP();
            otp.EmailAddress = value.EmailAddress;
            otp.NewEmail = value.NewEmail;
            otp.OTP = value.OTP;
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                otpHelper.updateUserOTP(otp);
                return Ok("Success");
            }
            catch (Exception)
            {

                return Ok("Something Went Wrong");
            }
        }
    }
}