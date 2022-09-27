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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await myContext.Provinsis.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idProvinsi,namaProvinsi")] Provinsi provinsi)
        {
            if (id != provinsi.idProvinsi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    myContext.Update(provinsi);
                    await myContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(provinsi);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await myContext.Provinsis.FirstOrDefaultAsync(m => m.idProvinsi == id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await myContext.Provinsis.FindAsync(id);
            myContext.Provinsis.Remove(result);
            await myContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
