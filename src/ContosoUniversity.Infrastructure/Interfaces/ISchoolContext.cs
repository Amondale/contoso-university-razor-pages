using ContosoUniversity.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Infrastructure.Interfaces
{
    public interface ISchoolContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Enrollment> Enrollments { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Instructor> Instructors { get; set; }
        DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        DbSet<CourseAssignment> CourseAssignments { get; set; }
    }
}