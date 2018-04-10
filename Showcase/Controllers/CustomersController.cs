using Showcase.Models;
using Showcase.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Showcase.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        
        public CustomersController()
        {
            this._context = new ApplicationDbContext();
        }

        protected override void Dispose(bool dispose)
        {
            this._context.Dispose();
        }

        public ActionResult CustomerForm()
        {
            var customers = this._context.membershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = customers
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {

            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.membershipTypes.ToList()
                };
                return View("CustomerForm",viewModel);
            }

            if (customer.ID == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.ID == customer.ID);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubsribedToNewsLetter = customer.IsSubsribedToNewsLetter;
            }
            this._context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            var viewModel = new CustomersViewModel
            {
                CustomerList = customers
            };
            
            return View(viewModel);
        }

        public ActionResult New()
        {

            var viewModel = new CustomerFormViewModel
            {
                Customer = null,
                MembershipTypes = _context.membershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);
            if(customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.membershipTypes.ToList()
            };
            return View("CustomerForm",viewModel);
        }

        public ActionResult Details(int? id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.ID == id);

            if(customer == null)
                return HttpNotFound();

           
             return View(customer);    
        }

    }
}