using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using WebApiApplication.Models;
namespace WebApiApplication.Controllers
{
    public class LoginController : ApiController
    {
        private readonly ILoginRepository _loginRepository;
        public LoginController()
        {
            _loginRepository = new LoginRepository();
        }

        //GET: api/Login
        [HttpGet]
        public IEnumerable<Login> List()
        {
            return _loginRepository.All;
        }
        //Put

        [HttpPut]
        public void Put(int id,[FromBody] Login login)
        {

            login.Id = id;
            _loginRepository.Update(login);
        }




    }
}