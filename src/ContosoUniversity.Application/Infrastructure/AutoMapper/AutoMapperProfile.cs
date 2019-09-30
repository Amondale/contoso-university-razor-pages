using AutoMapper;
using System.Reflection;
using ContosoUniversity.Application.ViewModels;
using ContosoUniversity.Core.Entities;

namespace ContosoUniversity.Application.Infrastructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Domain to ViewModel
            CreateMap<Student, StudentViewModel>();

            CreateMap<Course, CourseViewModel>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName));

            CreateMap<Instructor, InstructorViewModel>();
            CreateMap<Department, DepartmentViewModel>()
                .ForMember(dest => dest.DepartmentChairName, opt => opt.MapFrom(src =>src.DepartmentChair.FullName));
                
            // ViewModel to Domain
            CreateMap<StudentViewModel, Student>();
            CreateMap<CourseViewModel, Course>();
            CreateMap<InstructorViewModel, Instructor>();
            CreateMap<DepartmentViewModel, Department>();

            LoadStandardMappings();
            LoadCustomMappings();
            LoadConverters();
        }

        private void LoadConverters()
        {

        }

        private void LoadStandardMappings()
        {
            var mapsFrom = MapperProfileHelper.LoadStandardMappings(Assembly.GetExecutingAssembly());

            foreach (var map in mapsFrom)
            {
                CreateMap(map.Source, map.Destination).ReverseMap();
            }
        }

        private void LoadCustomMappings()
        {
            var mapsFrom = MapperProfileHelper.LoadCustomMappings(Assembly.GetExecutingAssembly());

            foreach (var map in mapsFrom)
            {
                map.CreateMappings(this);
            }
        }
    }
}
