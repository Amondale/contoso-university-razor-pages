namespace ContosoUniversity.Application.ViewModels
{
    public class AssignedCourseViewModel
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public bool HasInstructorAssigned { get; set; }
    }
}
