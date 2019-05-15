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
    public class ClientInfoController : ApiController
    {

        private readonly IClientRepository _clientRespository;

        public ClientInfoController()
        {
            _clientRespository = new ClientRepository();

        }

    

        //[HttpPost]
        //public IHttpActionResult AddUserProfile([FromBody] Client value)
        //{


        //    ClientDbHelper clientDbHelper = new ClientDbHelper();

        //    Client clientInfo = new Client();
        //    //
        //    //dbContext.Add(user);
        //    //dbContext.SaveChanges();
        //    //return JsonConvert.SerializeObject("Register succesful");

        //    clientInfo.EmailAddress = value.EmailAddress;
        //    clientInfo.FirstName = value.FirstName;
        //    clientInfo.LastName = value.LastName;
        //    clientInfo.IsMale = value.IsMale;
        //    clientInfo.Salt = Convert.ToBase64String(Common.GetRandomSalt(16));
        //    clientInfo.Password = Convert.ToBase64String(Common.saltHashPassword(Encoding.ASCII.GetBytes(value.Password),
        //        Convert.FromBase64String(clientInfo.Salt)));
        //    try
        //    {

        //        if (!ModelState.IsValid)
        //        {

        //            return BadRequest(ModelState);
        //        }
        //        clientDbHelper.AddUserProfile(clientInfo);
        //        return Ok("Success");
        //    }
        //    catch (Exception)
        //    {

        //        return Ok("Something Went Wrong");
        //    }

        //}


        //GET: api/Client to retrive client list
        [HttpGet]
        public IEnumerable<Client> List()
        {
            return _clientRespository.All;
        }


        [HttpPut]
        public void Put(int id, [FromBody] Client clientInfo)
        {

            clientInfo.Id = id;
            _clientRespository.Update(clientInfo);
            
        }

        [HttpPost]

        public List<Client>  Details(Client value)
        {

            ClientDbHelper clientDbHelper = new ClientDbHelper();
            return clientDbHelper.GetClientByID(value.EmailAddress);
        }

        //  [HttpGet]



    }
}