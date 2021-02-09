using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EncoraCodingExercise.Data.Contract.API;
using EncoraCodingExercise.Data.Contract.DB;
using EncoraCodingExercise.Model.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EncoraCodingExercise.WebAPI.Controllers
{
    //[Authorize]
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
        [ActionName("Create")]
        public async Task<IActionResult> Post([FromBody] UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _propertyRepository.Save(user);
            
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return CreatedAtAction(nameof(Get), new { id = 0 },user);//test
        }


        // PUT api/<PropertiesController>/5
        [HttpPut("{id}")]
        [ActionName("Update")]

        public async Task<IActionResult> Put(int id,UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _propertyRepository.Update(id,user);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return CreatedAtAction(nameof(Get), new { id },user);
        }

    }
}
