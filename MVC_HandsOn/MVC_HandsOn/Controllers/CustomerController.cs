using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVC_HandsOn.Models;
using MVC_HandsOn.ViewModel;

namespace MVC_HandsOn.Controllers
{
    public class CustomerController : Controller
    {

        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
           
            var customers = _context.customers.Include("MemberShipType");
            return View(customers);
        }

        public ActionResult Edit(int id)
        {

            var customers = _context.customers.SingleOrDefault(x=> x.id==id);
           
            if (customers == null)
                return HttpNotFound();
            NewCustomerViewModel vm = new NewCustomerViewModel();
            vm.customer = customers;
            vm.MemberShipTypes = _context.MemberShipType;
            return View("New",vm);

        }

        public ActionResult New()
        {
            var mem = _context.MemberShipType;
            
            var vm = new NewCustomerViewModel();
            vm.customer = new customer();
            vm.MemberShipTypes = mem;
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewCustomerViewModel c)
        {
            if(!ModelState.IsValid)
            {
                NewCustomerViewModel nvm = new NewCustomerViewModel();
                nvm.customer = c.customer;
                nvm.MemberShipTypes = _context.MemberShipType;
                return View("New",nvm);

            }
            if(c.customer.id==0)
            {
                _context.customers.Add(c.customer);
            }
            else
            {
                var custindb = _context.customers.Single(x => x.id == c.customer.id);
                custindb.name = c.customer.name;
                custindb.dob = c.customer.dob;
                custindb.MemberShipTypeId = c.customer.MemberShipTypeId;
                custindb.IsSubscribedToNewsLetter = c.customer.IsSubscribedToNewsLetter;

            }
            
            _context.SaveChanges();
             
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Details(int id)
        {

            var c = _context.customers.SingleOrDefault(x => x.id == id);
            if (c == null)
                return HttpNotFound();
            return  View(c);

        }
    }
}