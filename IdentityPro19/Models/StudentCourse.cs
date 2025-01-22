using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityPro19.Models
{
    public class StudentCourse
    {
        public int StudentCourseId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
