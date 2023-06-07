using HandleLogicService.Dto;
using InterviewMS.Models;
using InterviewMS.Models.Request;

namespace InterviewMS.AutoMapperViewModel
{
    public class AutoMapperView : HandleLogicService.AutoMapepr.AutoMapper
    {
        public AutoMapperView()
        {
            CreateMap<StudentDto, StudentViewModel>().ReverseMap();
            CreateMap<TeacherDto, TeacherViewModel>().ReverseMap();
            CreateMap<CrossReferenceDto, CrossReferenceViewModel>().ReverseMap();
            CreateMap<AddedStudentRequestDto, AddedStudentRequest>().ReverseMap();
        }
    }
}
