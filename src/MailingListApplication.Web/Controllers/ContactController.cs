using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailingListApplication.Core.Entities;
using MailingListApplication.SharedKernal.Interfaces;
using MailingListApplication.Web.Models;
using Microsoft.AspNetCore.Mvc;


namespace MailingListApplication.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IRepository _repository;

        public ContactController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var model = new ContactDTO();

            return View(model);
        }

        public IActionResult Add(ContactDTO model)
        {
            // basic model checking.
            if(!ModelState.IsValid)
            {
                return View("Index", model);
            }

            _repository.Add<Contact>(new Contact
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            });

            return View();

        }
    }
}