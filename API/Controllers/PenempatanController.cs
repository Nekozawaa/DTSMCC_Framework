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
    public class PenempatanController : ControllerBase
    {
        MyContext myContext;
        public PenempatanController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = myContext.Penempatans.ToList();
            if (data.Count == 0)
                return Ok(new { message = "sukses mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", statusCode = 200, data = data });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = myContext.Penempatans.Find(id);
            if (data == null)
                return Ok(new { message = "sukses mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", statusCode = 200, data = data });
        }

        //UPDATE
        [HttpPut]
        public IActionResult Put(int id, Penempatan penempatan)
        {
            var data = myContext.Penempatans.Find(id);
            data.namaPerusahaan = penempatan.namaPerusahaan;
            myContext.Penempatans.Update(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil mengupdate data" });
            return BadRequest(new { statusCode = 400, message = "gagal mengupdate data" });
        }

        //CREATE
        [HttpPost]
        public IActionResult Post(Penempatan penempatan)
        {
            myContext.Penempatans.Add(penempatan);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menambahkan data" });
            return BadRequest(new { statusCode = 400, message = "gagal menambahkan data" });
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = myContext.Penempatans.Find(id);
            myContext.Penempatans.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menghapus data" });
            return BadRequest(new { statusCode = 400, message = "gagal menghapus data" });
        }
    }
}
