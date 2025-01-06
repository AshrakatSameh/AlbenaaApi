using AlbenaaAPi.Dto;
using AlbenaaAPi.Entities;
using AlbenaaAPi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlbenaaAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourses _courses;

        public CoursesController(ICourses courses)
        {
            _courses = courses;
        }

        [HttpPost("addCourse")]
        public async Task<IActionResult> AddCourse(CoursesDto dto)
        {
            var courses = await _courses.Add(dto);
            return Ok(courses);
        }

        [HttpGet("getAllCourses")]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courses.GetAll();
            return Ok(courses);
        }

        [HttpGet("Get{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            if (id == null)
            {
                return BadRequest("Not Found");
            }
            var myCourses = await _courses.GetById(id);

            if (myCourses == null)
            {
                return BadRequest("Not Found");
            }

            return Ok(myCourses);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCourses(int id, CoursesDto dto)
        {
            var existingCourses = await _courses.GetById(id);

            if (existingCourses == null)
            {
                return BadRequest("not found");
            }

            try
            {
                existingCourses.Title = dto.Title;
                existingCourses.Description = dto.Description;
                existingCourses.Duration = dto.Duration;
                existingCourses.Price = dto.Price;
                existingCourses.TrainerName = dto.TrainerName;

                var updatedCourses = await _courses.Update(existingCourses);

                if (updatedCourses == null)
                {
                    return BadRequest("Failed to update ");
                }

                return Ok(updatedCourses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Courses>> Delete(int id)
        {


            try
            {
                var courses = await _courses.GetById(id);
                if (courses == null)
                {
                    return BadRequest("Not Found");
                }

                return await _courses.Delete(id);

            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error deleting data");
            }
        }

    }
}
