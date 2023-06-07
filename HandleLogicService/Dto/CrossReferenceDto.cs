using Infrastructure.Models;

namespace HandleLogicService.Dto
{
    public class CrossReferenceDto
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        public Guid TeacherId { get; set; }

        public StudentDto Student { get; set; }

        public TeacherDto Teacher { get; set; }
    }
}
