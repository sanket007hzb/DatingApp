using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        
        public ValuesController(DataContext context)
        {
            this._context = context;

        }
        [AllowAnonymous]
        [HttpGet]
         public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]

        public IActionResult GetValues(int id)
        {
            //var value = _context.Values.Find(id);
            var value = _context.Values.FirstOrDefault(x => x.Id == id);

            if(value == null)
                return NoContent();
            else
                return Ok(value);
        }

        // public ActionResult<string> Get(int id)
        // {
        //     return "value";
        // }

        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}