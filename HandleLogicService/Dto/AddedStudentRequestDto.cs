using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleLogicService.Dto
{
    public class AddedStudentRequestDto
    {
        public string FullName { get; set; }

        public DateTime DOB { get; set; }

        public string TeacherFullName { get; set; }
    }
}
