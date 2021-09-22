using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AbimMall.Database;
using AbimMall.Models;

namespace AbimMall.Controllers
{
    public class ContactsController : Controller
    {
        private readonly AbimMallDbContext _context;

        public ContactsController(AbimMallDbContext context)
        {
            _context = context;
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacts.ToListAsync());
        }

        // GET: Contacts/Details/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return View();
        }

        public ViewResult CreateContact()
        {
            return View();
        }


    }
}
