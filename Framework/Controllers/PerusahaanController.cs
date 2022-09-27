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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await myContext.Perusahaans.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idPerusahaan,tipePerusahaan")] Perusahaan perusahaan)
        {
            if (id != perusahaan.idPerusahan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    myContext.Update(perusahaan);
                    await myContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(perusahaan);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await myContext.Perusahaans.FirstOrDefaultAsync(m => m.idPerusahan == id);
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
            var result = await myContext.Perusahaans.FindAsync(id);
            myContext.Perusahaans.Remove(result);
            await myContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
