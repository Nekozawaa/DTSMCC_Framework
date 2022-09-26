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
    public class PerusahaanController : Controller
    {
        MyContext myContext;

        public PerusahaanController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public IActionResult Index()
        {
            List<Perusahaan> perusahaans = myContext.Perusahaans.ToList();
            return View(perusahaans);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Perusahaan perusahaan)
        {
            if (ModelState.IsValid)
            {
                myContext.Perusahaans.Add(perusahaan);
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
            var result = myContext.Perusahaans.Where(c => c.idPerusahan == Id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Perusahaan perusahaan)
        {
            myContext.Attach(perusahaan);
            myContext.Entry(perusahaan).State = EntityState.Modified;
            myContext.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var result = myContext.Perusahaans.Where(c => c.idPerusahan == Id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(Perusahaan perusahaan)
        {
            myContext.Attach(perusahaan);
            myContext.Entry(perusahaan).State = EntityState.Deleted;
            myContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
