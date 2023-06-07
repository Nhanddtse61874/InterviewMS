using Infrastructure.Models;

namespace HandleLogicService.Dto
{
    public class CrossReferenceDto
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        public Guid TeacherId { get; set; }

        public Student Student { get; set; }

    }
}
