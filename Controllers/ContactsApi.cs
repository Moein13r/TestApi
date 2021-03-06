using Microsoft.AspNetCore.Mvc;
using TestApi.DataAccess;
using TestApi.Interfaces;
using TestApi.Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsApi : ControllerBase
    {
        IExternalDataResolver _dataResolver { get; }
        public ContactsApi(IExternalDataResolver dataResolver)
        {
            _dataResolver = dataResolver;
            ContactdataAccess = new ContactsDataAccess(dataResolver);
        }
        private ContactsDataAccess ContactdataAccess;
        // GET api/<ContactsApi>/5
        [HttpGet("[action]")]
        public ActionResult<Contact> GetContactsByname(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest("The Field Name Is Required!");    
                }
                var contacts = ContactdataAccess.GetContactsByName(name);
                return Ok(contacts);
            }
            catch (Exception e)
            {

                return BadRequest("An Error Occured Please Try Agian Or Call Supports Team!");
            }
        }
        // GET api/<ContactsApi>/5
        [HttpGet("[action]")]
        public ActionResult<Contact> GetAllContacts()
        {
            try
            {
                var contacts = ContactdataAccess.GetAllContacts();
                return Ok(contacts);
            }
            catch (Exception e)
            {

                return BadRequest("An Error Occured Please Try Agian Or Call Supports Team!");
            }
        }
    }
}
