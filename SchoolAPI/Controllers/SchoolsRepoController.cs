using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Models;
using SchoolAPI.Repositories;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsRepoController : ControllerBase
    {
        private readonly IUniversityRepository _repository;

        public SchoolsRepoController(IUniversityRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("get-all-schools")]
        public async Task<ActionResult<IEnumerable<School>>> GetSchools()
        {
            var schools = await _repository.GetAllAsync();
            return Ok(schools);
        }

        [HttpGet("get-school-by-id/{id}")]
        public async Task<ActionResult<School>> GetSchool(int id)
        {
            var school = await _repository.GetByIdAsync(id);
            if (school == null)
                return NotFound();
            return school;
        }

        [HttpGet("search-by-name/{name}")]
        public async Task<ActionResult<IEnumerable<School>>> SearchByName(string name)
        {
            var schools = await _repository.SearchByNameAsync(name);
            return Ok(schools);
        }

        [HttpPost("create-school")]
        public async Task<ActionResult<School>> PostSchool(School school)
        {
            await _repository.AddAsync(school);
            await _repository.SaveAsync();
            return CreatedAtAction(nameof(GetSchool), new { id = school.Id }, school);
        }

        [HttpPut("edit-school/{id}")]
        public async Task<IActionResult> PutSchool(int id, School school)
        {
            if (id != school.Id)
                return BadRequest();

            if (!await _repository.ExistsAsync(id))
                return NotFound();

            await _repository.UpdateAsync(school);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("delete-school/{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            if (!await _repository.ExistsAsync(id))
                return NotFound();

            await _repository.DeleteAsync(id);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}

