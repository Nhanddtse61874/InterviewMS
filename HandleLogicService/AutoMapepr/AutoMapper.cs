using AutoMapper;
using HandleLogicService.Dto;
using Infrastructure.Models;

namespace HandleLogicService.AutoMapepr
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Teacher, TeacherDto>().ReverseMap();
            CreateMap<CrossReference, CrossReferenceDto>().ReverseMap();
        }   
    }
}
