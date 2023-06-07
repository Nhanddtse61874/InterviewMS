using HandleLogicService.Dto;

namespace HandleLogicService.HandleLogic.InterfaceLogic
{
    public interface ISchoolLogicHandler
    {
        Task AddListData(List<AddedStudentRequestDto> request);

        Task AddListData3000(List<AddedStudentRequestDto> request);

        List<TeacherDto> LoadTeachers();

        List<StudentDto> SearchByName(string name);
    }
}
