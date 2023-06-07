using HandleLogicService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleLogicService.HandleLogic.InterfaceLogic
{
    public interface ISchoolLogicHandler
    {
        Task AddListData(List<AddedStudentRequestDto> request);

        Task AddListData3000(List<AddedStudentRequestDto> request);

        List<TeacherDto> LoadTeachers();
    }
}
