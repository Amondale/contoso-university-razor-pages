using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ContosoUniversity.Core.Entities
{
    public class Instructor : BaseEntity
    {
        public Instructor()
        {
            CourseAssignments = new List<CourseAssignment>();
        }

        public int ID { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => LastName + ", " + FirstMidName;

        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        public OfficeAssignment OfficeAssignment { get; set; }

        public string[] SelectedCourses { get; set; }

        public void HandleCourses(string[] selectedCourses, IEnumerable<Course> courses)
        {
            if (selectedCourses == null || selectedCourses.Length == 0 || CourseAssignments == null)
            {
                this.CourseAssignments = new List<CourseAssignment>();
                return;
            }

            var selectedCoursesHs = new HashSet<string>(selectedCourses);
            var instructorCourses = new HashSet<int>
                (CourseAssignments.Select(c => c.CourseId));

            foreach (var course in courses)
            {
                if (selectedCoursesHs.Contains(course.CourseID.ToString()))
                {
                    if (!instructorCourses.Contains(course.CourseID))
                    {
                        CourseAssignments.Add(new CourseAssignment { Course = course, Instructor = this });
                    }
                }
                else
                {
                    if (instructorCourses.Contains(course.CourseID))
                    {
                        var toRemove = CourseAssignments.Single(ci => ci.CourseId == course.CourseID);
                        CourseAssignments.Remove(toRemove);
                    }
                }
            }
        }
    }
}