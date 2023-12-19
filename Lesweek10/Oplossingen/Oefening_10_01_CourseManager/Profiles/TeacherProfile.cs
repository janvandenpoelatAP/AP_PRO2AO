using AutoMapper;
using Oefening_10_01_CourseManager.Entities;
using Oefening_10_01_CourseManager.Models;

namespace Oefening_10_01_CourseManager.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherForCreationDto, Teacher>();
        }
    }
}
