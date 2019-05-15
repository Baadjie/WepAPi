using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApiApplication.Models;

namespace WebApiApplication.Controllers
{
    
    public class DeleteController: ApiController
    {
        private readonly ILoginRepository _loginRepository;

        public DeleteController()
        {
            _loginRepository = new LoginRepository();

        }
        [HttpGet]
        public IEnumerable<Login> List()
        {
            return _loginRepository.All;
        }
        [HttpPut]
        public void Delete(int id, [FromBody] Login login)
        {

            login.Id = id;
           // _loginRepository.Update(login);
            _loginRepository.Delete(login);
        }
    }
}