using System.ComponentModel.DataAnnotations;

namespace Bai2222.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string? StudentName { get; set;}
        public List<StudentCourse>? studentCourses { get; set; }

    }
}
