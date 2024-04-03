using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Bai2222.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public List<StudentCourse>? studentCourses { get; set; }
    }
}
