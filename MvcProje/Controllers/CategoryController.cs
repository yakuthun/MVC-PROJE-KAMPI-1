using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList() //listeleme
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
            
        }
        [HttpGet]//ilk get devreye girer. butona tıklandığında post devreye girer.
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]//sayfada bir şey post edildiğinde çalış
        public ActionResult AddCategory(Category p) //ekleme
        {
            //cm.CategoryAddBL(p);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("GetCategoryList");//ekleme işlemi gerçekleştirdikten sonra listeleme metoduna gönder.
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
    }
}