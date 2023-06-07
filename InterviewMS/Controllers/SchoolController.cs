using AutoMapper;
using HandleLogicService.Dto;
using HandleLogicService.HandleLogic.InterfaceLogic;
using InterviewMS.Models;
using InterviewMS.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace InterviewMS.Controllers
{
    public class SchoolController : Controller
    {
        private readonly ISchoolLogicHandler _schoolLogicHandler;
        private readonly IMapper _mapper;

        public SchoolController(ISchoolLogicHandler schoolLogicHandler, IMapper mapper)
        {
            _schoolLogicHandler = schoolLogicHandler;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<Response> AddList(List<AddedStudentRequest> request)
        {
            if (request is null)
                return new Response { Message = "Request is null", Status = false };
            try
            {
                await _schoolLogicHandler.AddListData(_mapper.Map<List<AddedStudentRequestDto>>(request));
                return new Response { Message = "Success", Status = true };
            }
            catch (Exception ex)
            {
                return new Response { Message = ex.Message, Status = false };
            }
        }

        [HttpGet]
        public List<LoadTeacherResponse> LoadTeachers()
        {
            var result = new List<LoadTeacherResponse>();
            var teachers = _schoolLogicHandler.LoadTeachers();
            foreach (var teacher in teachers)
            {
                foreach (var crossRef in teacher.CrossReferences)
                {
                    result.Add(new LoadTeacherResponse
                    {
                        TeacherName = teacher.FullName,
                        StudentName = crossRef.Student.FullName,
                        DOB = crossRef.Student.DOB
                    });
                }
            }
            return result;
        }

        [HttpGet]
        public List<LoadTeacherResponse> SearchStudents(string name)
        {
            try
            {
                if (name is null)
                    throw new Exception("filter is null");
                var result = new List<LoadTeacherResponse>();
                var students = _schoolLogicHandler.SearchByName(name);
                foreach (var student in students)
                {
                    foreach (var crossRef in student.CrossReferences)
                    {
                        result.Add(new LoadTeacherResponse
                        {
                            TeacherName = crossRef.Teacher.FullName,
                            StudentName = student.FullName,
                            DOB = student.DOB
                        });
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }


        [HttpGet]
        public async Task<List<LoadTeacherResponse>> LoadTeachers3000()
        {
            List<AddedStudentRequest> request = new List<AddedStudentRequest>();
            for (int i = 0; i < 3100; i++)
            {
                request.Add(new AddedStudentRequest
                {
                    FullName = $"student {i + 1}",
                    DOB = DateTime.Now,
                    TeacherFullName = $"Teacher {(i + 3) / 3}"
                });
            }
            await _schoolLogicHandler.AddListData3000(_mapper.Map<List<AddedStudentRequestDto>>(request));

            var result = new List<LoadTeacherResponse>();
            var teachers = _schoolLogicHandler.LoadTeachers();
            foreach (var teacher in teachers)
            {
                foreach (var crossRef in teacher.CrossReferences)
                {
                    result.Add(new LoadTeacherResponse
                    {
                        TeacherName = teacher.FullName,
                        StudentName = crossRef.Student.FullName,
                        DOB = crossRef.Student.DOB
                    });
                }
            }
            return result.OrderBy(x =>  x.TeacherName).ThenBy(x => x.DOB).ToList();
        }
    }
}
