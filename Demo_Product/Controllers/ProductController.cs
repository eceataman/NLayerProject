using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        public IActionResult Index()
        {
            var values = productManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            ProductValidator validationRules = new ProductValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                productManager.TInsert(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        public IActionResult DeleteProduct(int id)
        {
            var value = productManager.GetByID(id);
            productManager.TDelete(value);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            var value = productManager.GetByID(id);
           return View(value);
        }
        [HttpPost]
        public IActionResult EditProduct(Product p)
        {
            var value=productManager.GetByID(p.Id);
            productManager.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}
