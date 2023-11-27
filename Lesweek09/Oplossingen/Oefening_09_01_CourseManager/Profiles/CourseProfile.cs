using AutoMapper;
using Oefening_09_01_CourseManager.Entities;
using Oefening_09_01_CourseManager.Models;

namespace CourseManager.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>()
                .ForMember(
                    d => d.TeacherId,
                    o => o.MapFrom(s => s.Teachers.First().Id));
        }
    }
}
