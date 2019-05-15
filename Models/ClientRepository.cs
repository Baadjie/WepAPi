using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiApplication.Models
{
    public class ClientRepository : IClientRepository
    {

        //====Steps for retriving
        private List<Client> _client;

        public ClientRepository()
        {

            RetriveClientInfo();
        }
        public void RetriveClientInfo()
        {
            _client = ClientDbHelper.GetClient();
        }

        public IEnumerable<Client> All {

            get
            {
                return _client;
            }

        }
        //========

        
        public void Delete(Client item)
        {
            throw new NotImplementedException();
        }

        public Client Find(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Client item)
        {
            throw new NotImplementedException();
        }

        //Update Client Information
        public void Update(Client clientInfo)
        {
            if (clientInfo == null)
            {
                throw new ArgumentNullException("clientInfo");


            }
            // DalHelper.UpdateUser(clientInfo);
            ClientDbHelper.UpdateClientInfo(clientInfo);
        }
    }
}