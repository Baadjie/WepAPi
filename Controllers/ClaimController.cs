using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApiApplication.Models;

namespace WebApiApplication.Controllers
{
    public class ClaimController : ApiController
    {
        ClaimDbHelper claimHelper = new ClaimDbHelper();

        [HttpPost]
        public IHttpActionResult addClaims([FromBody] Claims value)
        {
            ClaimDbHelper claimHelper = new ClaimDbHelper();

            Claims claim = new Claims();
            claim.IDClient = value.IDClient;
            claim.Status1 = value.Status1;
            //claim.TypeOfClaim = value.TypeOfClaim;
           
            claim.Comments = value.Comments;
            // claim.UserName = value.UserName;
            claim.UnpaidReason = value.UnpaidReason;
            try
            {

                if (!ModelState.IsValid)
                {

                    return BadRequest(ModelState);
                }
                claimHelper.AddClaim(claim);
                return Ok("Success");
            }
            catch (Exception)
            {

                return Ok("Something Went Wrong");
            }
        }


    }
}