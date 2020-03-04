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
        public IActionResult List(string lastName = null, string orderBy = null)
        {
            // alway sort by asc
            var items = _repository.List<Contact>()
                    .OrderBy(x => x.LastName)
                    .ThenBy(x => x.FirstName)
                    .Select(ContactDTO.FromContact);

            // only filter the collection if lastName param was supplied
            if (!string.IsNullOrEmpty(lastName))
            {
                items = items.Where(x => x.LastName.ToLower() == lastName.ToLower());
            }


            // only filter the collection if orderBy param was supplied and is Descending
            if (!string.IsNullOrEmpty(orderBy))
            {
                if(orderBy == "Descending")
                {
                    items = items.OrderByDescending(x => x.LastName).ThenByDescending(x => x.FirstName);
                }
            }

            return Ok(items);
        }
    }
}