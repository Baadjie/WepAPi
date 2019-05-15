using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiApplication.Models
{
    public interface IClientRepository
    {

        //For retriving
        IEnumerable<Client> All { get; }
        Client Find(int id);
        void Insert(Client item);
        void Update(Client item);
        void Delete(Client item);


    }
}