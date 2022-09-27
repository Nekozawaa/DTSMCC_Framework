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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await myContext.Penempatans.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idPenempatan,namaPerusahaan,idPerusahaan,idProvinsi")] Penempatan penempatan)
        {
            if (id != penempatan.idPenempatan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    myContext.Update(penempatan);
                    await myContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(penempatan);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await myContext.Penempatans.FirstOrDefaultAsync(m => m.idPenempatan == id);
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
            var result = await myContext.Penempatans.FindAsync(id);
            myContext.Penempatans.Remove(result);
            await myContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
