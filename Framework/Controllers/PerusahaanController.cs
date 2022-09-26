using Framework.Context;
using Framework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
    }
}
