namespace IdentityPro19.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Title1 { get; set; }
        public string Title2{ get; set; }
        public string Title3 { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }

    }
}
