using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiApplication.Models
{
    public class LoginRepository : ILoginRepository
    {
        private List<Login> _login;

        public LoginRepository()
        {
            InitializaDados();
        }
        //Login
        private void InitializaDados()
        {
            _login = DalHelper.GetLogin();
        }


        public IEnumerable<Login> All
        {
            get
            {
                return _login;
            }
        }



        //Delete
        public void Delete(Login login)
        {
            if (login == null)
            {
                throw new ArgumentNullException("login");


            }
            DalHelper.DeleteUser(login);
        }


        //Update User
        public void Update(Login login)
        {

            if (login == null)
            {
                throw new ArgumentNullException("login");


            }
            DalHelper.UpdateUser(login);
        }

        //Update Client
        public void UpdateClient(ClientInfo clientInfo)
        {
            if (clientInfo == null)
            {
                throw new ArgumentNullException("clientInfo");


            }
            // DalHelper.UpdateUser(clientInfo);
           // ClientDbHelper.UpdateClientInfo(clientInfo);
        }

        public Login Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Login item)
        {
            throw new NotImplementedException();
        }

     

        //public void Delete(Login item)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(Login item)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
    