using System.Text.Json.Serialization;

namespace Bai2222.Models
{
    public class StudentCourse
    {
        public int? StudentID { get; set; }
        public int? CourseID { get; set; }
        [JsonIgnore]
        public Student? student { get; set; }
        [JsonIgnore]
        public Course? course { get; set; }


    }
}
