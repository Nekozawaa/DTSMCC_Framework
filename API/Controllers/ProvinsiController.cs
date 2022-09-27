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
    public class ProvinsiController : ControllerBase
    {
        MyContext myContext;
        public ProvinsiController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = myContext.Provinsis.ToList();
            if (data.Count == 0)
                return Ok(new { message = "sukses mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", statusCode = 200, data = data });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = myContext.Provinsis.Find(id);
            if (data == null)
                return Ok(new { message = "sukses mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", statusCode = 200, data = data });
        }

        //UPDATE
        [HttpPut]
        public IActionResult Put(int id, Provinsi provinsi)
        {
            var data = myContext.Provinsis.Find(id);
            data.namaProvinsi = provinsi.namaProvinsi;
            myContext.Provinsis.Update(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil mengupdate data" });
            return BadRequest(new { statusCode = 400, message = "gagal mengupdate data" });
        }
        
        //CREATE
        [HttpPost]
        public IActionResult Post(Provinsi provinsi)
        {
            myContext.Provinsis.Add(provinsi);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menambahkan data"});
            return BadRequest(new { statusCode = 400, message = "gagal menambahkan data" });
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = myContext.Provinsis.Find(id);
            myContext.Provinsis.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "berhasil menghapus data" });
            return BadRequest(new { statusCode = 400, message = "gagal menghapus data" });
        }
    }
}
