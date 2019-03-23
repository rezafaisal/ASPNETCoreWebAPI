using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using HelloWebAPI.Models;

namespace HelloWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> Get()
        {
            return new Mahasiswa[] { 
                new Mahasiswa{NIM = "123", Nama = "Nama123", Alamat = "Alamat123", Jurusan = "Jurusan123"},
                new Mahasiswa{NIM = "234", Nama = "Nama234", Alamat = "Alamat234", Jurusan = "Jurusan234"},
                new Mahasiswa{NIM = "345", Nama = "Nama345", Alamat = "Alamat345", Jurusan = "Jurusan345"} 
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Mahasiswa> Get(string id)
        {
            return new Mahasiswa{NIM = "123", Nama = "Nama123", Alamat = "Alamat123", Jurusan = "Jurusan123"};
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Mahasiswa value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Mahasiswa value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
        }
    }
}
