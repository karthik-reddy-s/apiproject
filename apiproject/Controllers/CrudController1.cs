using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        List<string> companies = new List<string>()
        {
            "facebook","netflix","apple","amazon","disney"
        }; 
        [HttpGet, Route("getAllCompanies")]
        public IActionResult GetCompanies()
        {
          
            var res = companies.Where(w => w.StartsWith('a')).ToArray();
            if (res.Length > 0)
            {
                return Ok(res);
            }
            return NotFound(
                "Datanotfound");
        }
        [HttpGet("{letter}"), Route("fromuser")]
        public IActionResult GetFromUser([FromQuery] string letter)
        {
            try
            {
                var res = companies.Where(w => w.StartsWith(letter)).ToArray();
                if (res.Length > 0)
                {
                    return Ok(res);
                }
                return NotFound(
                    "Datanotfound");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
    }
}