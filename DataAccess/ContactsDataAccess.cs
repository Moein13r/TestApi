using System.Data.SqlClient;
using TestApi.Interfaces;
using TestApi.Models.Entities;

namespace TestApi.DataAccess
{
    public class ContactsDataAccess
    {
        private IExternalDataResolver _dataResolver { get; }
        public ContactsDataAccess(IExternalDataResolver dataResolver)
        {
            _dataResolver = dataResolver;
        }
        public List<Contact> GetContactsByName(string name)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@name",name)
            };
            var items = _dataResolver.GetFromCommand<Contact>("Select * from Contacts where Name Like '%" + @name + "%'",parameters);
            return items ?? new List<Contact>();
        }
        public List<Contact> GetAllContacts()
        {            
            var items = _dataResolver.GetFromCommand<Contact>("Select * from Contacts");
            return items ?? new List<Contact>();
        }
    }
}