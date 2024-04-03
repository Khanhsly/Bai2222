using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bai2222.Models;
using Bai2222.Services;


namespace Bai2222.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public StudentController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _libraryService.GetStudentsAsync();

            if (students == null || students.Count == 0)
            {
                return NotFound();
            }

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _libraryService.GetStudentAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }


        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            var dbStudent = await _libraryService.AddStudentAsync(student);

            if (dbStudent == null)
            {
                return StatusCode(500, $"{student.StudentName} could not be added.");
            }

            return CreatedAtAction("GetStudent", new { id = student.StudentID }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            if (id != student.StudentID)
            {
                return BadRequest();
            }

            Student dbStudent = await _libraryService.UpdateStudentAsync(student);

            if (dbStudent == null)
            {
                return StatusCode(500, $"{student.StudentName} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _libraryService.GetStudentAsync(id);
            (bool status, string message) = await _libraryService.DeleteStudentAsync(student);

            if (status == false)
            {
                return StatusCode(500, message);
            }

            return StatusCode(200, student);
        }
    }
}