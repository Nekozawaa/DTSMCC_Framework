using API.Context;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerusahaanController : ControllerBase
    {
        MyContext myContext;
        public PerusahaanController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = myContext.Perusahaans.ToList();
            if (data.Count == 0)
                return Ok(new { message = "sukses mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", statusCode = 200, data = data });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = myContext.Perusahaans.Find(id);
            if (data == null)
                return Ok(new { message = "sukses mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", statusCode = 200, data = data });
        }

        //UPDATE
        [HttpPut]
        public IActionResult Put(int id, Perusahaan perusahaan)
        {
            var data = myContext.Perusahaans.Find(id);
            data.tipePerusahaan = perusahaan.tipePerusahaan;
            myContext.Perusahaans.Update(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil mengupdate data" });
            return BadRequest(new { statusCode = 400, message = "gagal mengupdate data" });
        }

        //CREATE
        [HttpPost]
        public IActionResult Post(Perusahaan perusahaan)
        {
            myContext.Perusahaans.Add(perusahaan);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menambahkan data" });
            return BadRequest(new { statusCode = 400, message = "gagal menambahkan data" });
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = myContext.Perusahaans.Find(id);
            myContext.Perusahaans.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menghapus data" });
            return BadRequest(new { statusCode = 400, message = "gagal menghapus data" });
        }
    }
}
