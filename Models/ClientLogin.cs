using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiApplication.Models
{
    public class ClientLogin
    {

        public ClientLogin()
        {

        }
        public int Id { get; set; }
        public int ClientID { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Roles { get; set; }
    }
}