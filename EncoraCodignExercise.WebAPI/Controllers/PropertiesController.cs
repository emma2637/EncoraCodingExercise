using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EncoraCodingExercise.Data.Contract.API;
using EncoraCodingExercise.Data.Contract.DB;
using EncoraCodingExercise.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EncoraCodingExercise.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyRepository _propertyRepository;
        public PropertiesController(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        // GET: api/<PropertiesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var properties = await _propertyRepository.Get();

            if (properties == null)
            {
                return NoContent();
            }

            return Ok(properties);
        }

        // GET api/<PropertiesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var property = await _propertyRepository.Get(id);

            if (property == null)
            {
                return NoContent();
            }

            return Ok(property);
        }

        // POST api/<PropertiesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserViewModel user)
        {
           await _propertyRepository.Save(user);

           return CreatedAtAction(nameof(Get), new { id = user.AccountNumber });
        }


        // PUT api/<PropertiesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PropertiesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
