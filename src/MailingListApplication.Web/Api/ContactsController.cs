using System.Linq;
using MailingListApplication.Core.Entities;
using MailingListApplication.SharedKernal.Interfaces;
using MailingListApplication.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MailingListApplication.Web.Api
{
    public class ContactsController : BaseApiController
    {
        private readonly IRepository _repository;

        public ContactsController(IRepository repository)
        {
            _repository = repository;
        }
        
        // GET: api/contacts
        [HttpGet]
        public IActionResult List()
        {
            var items = _repository.List<Contact>()
                .Select(ContactDTO.FromContact);
            return Ok(items);
        }
    }
}