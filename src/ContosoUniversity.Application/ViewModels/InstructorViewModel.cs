//using AutoMapper;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using ContosoUniversity.Core.Entities;

//namespace ContosoUniversity.Application.ViewModels
//{
//    public class InstructorViewModel
//    {
//        public InstructorViewModel()
//        {
//            AssignedCourses = new List<AssignedCourseViewModel>();
//            CourseAssignments = new List<CourseAssignment>();
//            SelectedCourses = new string[0];
//        }

//        public int ID { get; set; }

//        [Required]
//        [Display(Name = "Last Name")]
//        [StringLength(50)]
//        public string LastName { get; set; }

//        [Required]
//        [Column("FirstName")]
//        [Display(Name = "First Name")]
//        [StringLength(50)]
//        public string FirstMidName { get; set; }

//        [DataType(DataType.Date)]
//        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
//        [Display(Name = "Hire Date")]
//        public DateTime HireDate { get; set; }

//        [Display(Name = "Full Name")]
//        public string FullName => LastName + ", " + FirstMidName;

//        public OfficeAssignment OfficeAssignment { get; set; }

//        [IgnoreMap]
//        public string[] SelectedCourses { get; set; }

//        [IgnoreMap]
//        public List<AssignedCourseViewModel> AssignedCourses { get; set; }

//        public List<CourseAssignment> CourseAssignments { get; set; }

//    }
//}
