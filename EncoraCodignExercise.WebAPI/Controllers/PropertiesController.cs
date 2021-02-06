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

            var response = await _propertyRepository.Get();

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        // GET api/<PropertiesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var response = await _propertyRepository.Get(id);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        // POST api/<PropertiesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserViewModel user)
        {

            var response = await _propertyRepository.Save(user);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return CreatedAtAction(nameof(Get), new { id = user.Id });
        }


        // PUT api/<PropertiesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UserViewModel user)
        {

            var response = await _propertyRepository.Update(user);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return CreatedAtAction(nameof(Get), new { id = user.Id });
        }

    }
}
