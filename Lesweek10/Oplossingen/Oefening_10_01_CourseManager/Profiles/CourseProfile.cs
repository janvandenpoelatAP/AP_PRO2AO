using AutoMapper;
using Oefening_10_01_CourseManager.Entities;
using Oefening_10_01_CourseManager.Models;

namespace Oefening_10_01_CourseManager.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>()
                .ForMember(
                    d => d.TeacherId,
                    o => o.MapFrom(s => s.Teachers.Count > 0 ? s.Teachers.First().Id : Guid.Empty));
            CreateMap<CourseForCreationDto, Course>();
        }
    }
}
