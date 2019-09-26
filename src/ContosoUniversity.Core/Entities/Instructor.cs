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

        public string Prefix { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Suffix { get; set; }

        public string OfficeLocation { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime HireDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{LastName} , {FirstName} {MiddleName}";

        public ICollection<CourseAssignment> CourseAssignments { get; set; }

        public string[] SelectedCourses { get; set; }

        public void HandleCourses(string[] selectedCourses, IEnumerable<Course> courses)
        {
            if (selectedCourses == null || selectedCourses.Length == 0 || CourseAssignments == null)
            {
                this.CourseAssignments = new List<CourseAssignment>();
                return;
            }

            var selectedCoursesHs = new HashSet<string>(selectedCourses);
            var instructorCourses = new HashSet<Guid>
                (CourseAssignments.Select(c => c.CourseId));

            foreach (var course in courses)
            {
                if (selectedCoursesHs.Contains(course.Id.ToString()))
                {
                    if (!instructorCourses.Contains(course.Id))
                    {
                        CourseAssignments.Add(new CourseAssignment { Course = course, Instructor = this });
                    }
                }
                else
                {
                    if (instructorCourses.Contains(course.Id))
                    {
                        var toRemove = CourseAssignments.Single(ci => ci.CourseId == course.Id);
                        CourseAssignments.Remove(toRemove);
                    }
                }
            }
        }
    }
}