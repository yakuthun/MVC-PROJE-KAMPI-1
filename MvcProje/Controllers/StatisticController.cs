using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{


    public class StatisticController : Controller
    {


        Context c = new Context();
        // GET: Statistic
        public ActionResult Index()
        {
            //Toplam kategori sayısı
            var deger1 = c.Categories.Count().ToString();
            ViewBag.d1 = deger1;

            //Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
            var deger2 = c.Headings.Where(c => c.CategoryID == 22).Count().ToString();
            ViewBag.d2 = deger2;

            //Yazar adında 'a' harfi geçen yazar sayısı
            var deger3 = c.Writers.Where(c => c.WriterName.Contains("a")).Count().ToString();
            ViewBag.d3 = deger3;


            //En fazla başlığa sahip kategori adı

            var deger4 = c.Headings.Where(u => u.CategoryID == c.Headings.GroupBy(x => x.CategoryID).OrderByDescending(x => x.Count())
                .Select(x => x.Key).FirstOrDefault()).Select(x => x.Category.CategoryName).FirstOrDefault();
            ViewBag.d4 = deger4;

            //Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark

            var deger5 = c.Categories.Count(x => x.CategoryStatus == true); // Kategoriler tablosundaki aktif kategori sayisi
            ViewBag.d5 = deger5;


            return View();
        }


    }
}