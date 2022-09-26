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
        public IActionResult Edit(int Id)
        {
            List<Provinsi> list = myContext.Provinsis.ToList();
            Provinsi provinsi = myContext.Provinsis.Where(provinsi.idProvinsi == Id);
            return View(provinsi);
        }

        [HttpPost]
        public IActionResult Edit(Provinsi provinsi)
        {
            myContext.Attach(provinsi);
            myContext.Entry(provinsi).State = EntityState.Modified;
            myContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
