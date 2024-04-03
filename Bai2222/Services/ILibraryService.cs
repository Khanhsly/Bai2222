using Bai2222.Models;

namespace Bai2222.Services
{
    public interface ILibraryService
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(int id);
        Task<Student> AddStudentAsync(Student student); // POST New Student
        Task<Student> UpdateStudentAsync(Student student); // PUT Student
        Task<(bool, string)> DeleteStudentAsync(Student student); // DELETE Student


        Task<List<Course>> GetCoursesAsync(); // GET All Courses
        Task<Course> GetCourseAsync(int id); // Get Single Course
        Task<Course> AddCourseAsync(Course course); // POST New Course
        Task<Course> UpdateCourseAsync(Course course); // PUT Course
        Task<(bool, string)> DeleteCourseAsync(Course course); // DELETE Course
    }
}
