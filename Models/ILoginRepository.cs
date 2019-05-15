using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiApplication.Models
{
    public interface ILoginRepository
    {
        IEnumerable<Login> All { get; }
        Login Find(int id);
        void Insert(Login item);
        void Update(Login item);
        void Delete(Login item);
        void UpdateClient(ClientInfo item);
    }
}
