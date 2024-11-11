using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        public IActionResult Index()
        {
            var values = customerManager.GetCustomersListWithJob();
                return View(values);
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer p)
        {
            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult results= validationRules.Validate(p);
            if (results.IsValid)
            {
                customerManager.TInsert(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }            }
            return View();
              
        }
        public IActionResult DeleteCustomer(int id)
        {
            var value=customerManager.GetByID(id);
            customerManager.TDelete(value);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult EditCustomer(int id)
        {
            var value= customerManager.GetByID(id); 
            return View(value);
        }
        [HttpPost]
        public IActionResult EditCustomer(Customer p)
        {
             customerManager.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
