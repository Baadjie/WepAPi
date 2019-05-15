using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApiApplication.Models;

namespace WebApiApplication.Controllers
{
    public class RetentionController : ApiController
    {
        ClaimDbHelper claimHelper = new ClaimDbHelper();
        [HttpPost]
        public List<Retention> GetRetentionType(Retention retention)
        {
            ClaimDbHelper claimHelper = new ClaimDbHelper();
            return claimHelper.GetClaimTypes(retention.RetentionType);
        }



        [HttpGet]
        public Retention Claims(int clientId)
        {
          
            return claimHelper.GetClaim(clientId);
        }
    }
}