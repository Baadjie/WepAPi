using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using WebApiApplication.Models;
using WebApiApplication.Utils;

namespace WebApiApplication.Controllers
{
    public class ClientLoginController : ApiController
    {
        ClientDbHelper clientDbHelper = new ClientDbHelper();

        [HttpPost]

        public ClientLogin Login(ClientLogin clientLogin)
        {

            return clientDbHelper.LoginDb(clientLogin.EmailAddress/*,value.Password*/);

            
        }
       

    }
}