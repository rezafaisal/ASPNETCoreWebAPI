using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContohMethodController : ControllerBase
    {
        // GET api/ContohMethod
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            return new string[] { "value1", "value2", "value3", "value4" };
        }

        // GET api/ContohMethod/5
        [HttpGet("{id}")]
        public ActionResult<string> GetById(int id)
        {
            string result = "value" + id;
            return result;
        }

        // GET api/ContohMethod?id1=1&id2=2
        [HttpGet("{id1}/{id2}")]
        public ActionResult<IEnumerable<string>> GetByTwo(int id1, int id2)
        {
            return new string[] { "value"+id1, "value"+id2 };
        }
    }
}
