using Microsoft.AspNetCore.Mvc;
using Nokiu.Entities.Models;
using Services;

namespace Nokiu.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly PersonService _service;

        public PersonController()
        {
            NokiuContext _context = new NokiuContext();
            _service = new PersonService(_context);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(_service.Save(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (ModelState.IsValid && _service.Update(person))
            {
                return Ok(new { Message = "Person Updated" });
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] int id)
        {
            if (id > 0)
                return Ok(_service.Delete(id));
            return BadRequest();
        }
    }
}
