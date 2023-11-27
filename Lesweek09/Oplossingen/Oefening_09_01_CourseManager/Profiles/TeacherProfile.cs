using AutoMapper;
using Oefening_09_01_CourseManager.Entities;
using Oefening_09_01_CourseManager.Models;

namespace CourseManager.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherDto>();
        }
    }
}
