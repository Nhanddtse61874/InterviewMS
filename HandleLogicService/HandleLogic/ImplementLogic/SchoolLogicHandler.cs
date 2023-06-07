using AutoMapper;
using HandleLogicService.Dto;
using HandleLogicService.HandleLogic.InterfaceLogic;
using Infrastructure.Models;
using Infrastructure.Repository.InterfaceRepository;

namespace HandleLogicService.HandleLogic.ImplementLogic
{
    public class SchoolLogicHandler : ISchoolLogicHandler
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly ICrossReferenceRepository _crossReferenceRepository;
        private readonly IMapper _mapper;

        public SchoolLogicHandler(IStudentRepository studentRepository,
            IMapper mapper,
            ITeacherRepository teacherRepository,
            ICrossReferenceRepository crossReferenceRepository)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _teacherRepository = teacherRepository;
            _crossReferenceRepository = crossReferenceRepository;
        }

        public async Task AddListData(List<AddedStudentRequestDto> request)
        {
            if (request is null)
                throw new Exception("request is null");


            if (request.Select(x => x.FullName).Distinct().Count() < 3)
                throw new Exception("Student have to more than 10");

            if (request.Select(x => x.TeacherFullName).Distinct().Count() < 2)
                throw new Exception("Techers have to more than 2");

            var namesOfTeachers = request.Select(x => x.TeacherFullName).Distinct().ToList();
            var teachers = await AddTeacherListAsync(namesOfTeachers);
            
            await AddStudentListAsync(request, teachers);
        }

        public async Task AddListData3000(List<AddedStudentRequestDto> request)
        {
            if (request is null)
                throw new Exception("request is null");


            if (request.Select(x => x.FullName).Distinct().Count() < 3000)
                throw new Exception("Student have to more than 3000");

            if (request.Select(x => x.TeacherFullName).Distinct().Count() < 2)
                throw new Exception("Techers have to more than 2");

            var namesOfTeachers = request.Select(x => x.TeacherFullName).Distinct().ToList();
            var teachers = await AddTeacherListAsync(namesOfTeachers);

            await AddStudentListAsync(request, teachers);
        }

        public List<TeacherDto> LoadTeachers()
        {
            var teachers =  _mapper.Map<List<TeacherDto>>(_teacherRepository.GetAll());
            foreach (var teacher in teachers)
            {
                teacher.CrossReferences = teacher.CrossReferences.OrderBy(x => x.Student.DOB).ToList();
            }
            return teachers;
        }

        private async Task<List<TeacherDto>> AddTeacherListAsync(List<string> teacherNames)
        {
            List<TeacherDto> values = new List<TeacherDto>();
            List<TeacherDto> newTeacher = new List<TeacherDto>();
            foreach (var name in teacherNames)
            {
                var teacherDto = new TeacherDto();
                var item = _teacherRepository.SearchByNameExactly(name);
                teacherDto.Id = item == null ?  Guid.NewGuid() :  item.Id;
                teacherDto.FullName = name;
                values.Add(teacherDto);
                if(item == null)
                {
                    newTeacher.Add(teacherDto);
                }
            }
            await _teacherRepository.AddTeacherListAsync(_mapper.Map<List<Teacher>>(newTeacher));
            return values;
        }

        private async Task AddStudentListAsync(List<AddedStudentRequestDto> request, List<TeacherDto> teachers)
        {
            var crossRefs = new List<CrossReferenceDto>(); 
            
            foreach (var teacher in teachers)
            {
                var listNotExistedStudent = new List<StudentDto>();
                var studentDto = new StudentDto();
                var data = request.Where(x => x.TeacherFullName == teacher.FullName).ToList();
                foreach (var item in data)
                {
                    var student = _studentRepository.SearchByNameExactly(item.FullName);
                    if (student is not null)
                    {
                        if (!CheckRelations(teacher.Id, student.Id))
                        {
                            crossRefs.Add(new CrossReferenceDto
                            {
                                StudentId = student.Id,
                                TeacherId = teacher.Id,
                                Id = Guid.NewGuid()
                            });
                        }
                    }
                    else
                    {
                        var id = Guid.NewGuid();
                        listNotExistedStudent.Add(new StudentDto
                        {
                            Id = id,
                            FullName = item.FullName,
                            DOB = item.DOB
                        });

                        crossRefs.Add(new CrossReferenceDto
                        {
                            StudentId = id,
                            TeacherId = teacher.Id,
                            Id = Guid.NewGuid()
                        });
                    }
                }
                await _studentRepository.AddStudentListAsync(_mapper.Map<List<Student>>(listNotExistedStudent));
            }
            await AddCrossReferenceListAsync(crossRefs);
        }

        private async Task AddCrossReferenceListAsync(List<CrossReferenceDto> referenceDtos)
        {
            await _crossReferenceRepository.AddListCrossReferenceAsync(_mapper.Map<List<CrossReference>>(referenceDtos));
        }

        private bool CheckRelations(Guid teacherId, Guid studentId)
        {
            return _crossReferenceRepository.CheckExistedRelation(teacherId, studentId);
        }
    }
}
