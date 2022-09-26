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
    public class PenempatanController : Controller
    {
        MyContext myContext;

        public PenempatanController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public IActionResult Index()
        {
            List<Penempatan> penempatans = myContext.Penempatans.ToList();
            return View(penempatans);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Penempatan penempatan)
        {
            if (ModelState.IsValid)
            {
                myContext.Penempatans.Add(penempatan);
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
            var result = myContext.Penempatans.Where(c => c.idPenempatan == Id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(Penempatan penempatan)
        {
            myContext.Attach(penempatan);
            myContext.Entry(penempatan).State = EntityState.Modified;
            myContext.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var result = myContext.Penempatans.Where(c => c.idPenempatan == Id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Delete(Penempatan penempatan)
        {
            myContext.Attach(penempatan);
            myContext.Entry(penempatan).State = EntityState.Deleted;
            myContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
