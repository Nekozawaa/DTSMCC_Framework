using Framework.Context;
using Framework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Controllers
{
    public class ProvinsiController : Controller
    {
        MyContext myContext;

        public ProvinsiController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public IActionResult Index()
        {
            List<Provinsi> provinsis = myContext.Provinsis.ToList();
            return View(provinsis);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Provinsi provinsi)
        {
            if (ModelState.IsValid)
            {
                myContext.Provinsis.Add(provinsi);
                var result = myContext.SaveChanges();
                if (result == 1)
                {
                    return RedirectToAction("Index");
                }
            }
            return (View());
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var result = myContext.Provinsis.Where(c => c.idProvinsi == Id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Provinsi provinsi)
        {
            myContext.Attach(provinsi);
            myContext.Entry(provinsi).State = EntityState.Modified;
            myContext.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var result = myContext.Provinsis.Where(c => c.idProvinsi == Id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(Provinsi provinsi)
        {
            myContext.Attach(provinsi);
            myContext.Entry(provinsi).State = EntityState.Deleted;
            myContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
