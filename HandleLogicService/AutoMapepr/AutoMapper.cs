using AutoMapper;
using HandleLogicService.Dto;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
