using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bai2222.Services;
using Bai2222.Models;

namespace Bai2222.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public CourseController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _libraryService.GetCoursesAsync();
            if (courses == null)
            {
                return StatusCode(204, "No courses in database.");
            }

            return StatusCode(200, courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            Course course = await _libraryService.GetCourseAsync(id);

            if (course == null)
            {
                return StatusCode(204, $"No course found for id: {id}");
            }

            return StatusCode(200, course);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> AddCourse(Course course)
        {
            var dbCourse = await _libraryService.AddCourseAsync(course);

            if (dbCourse == null)
            {
                return StatusCode(500, $"{course.CourseName} could not be added.");
            }

            return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            Course dbCourse = await _libraryService.UpdateCourseAsync(course);

            if (dbCourse == null)
            {
                return StatusCode(500, $"{course.CourseName} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _libraryService.GetCourseAsync(id);
            (bool status, string message) = await _libraryService.DeleteCourseAsync(course);

            if (status == false)
            {
                return StatusCode(500, message);
            }

            return StatusCode(200, course);
        }
    }
}
