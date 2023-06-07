using Infrastructure.Models;

namespace InterviewMS.Models
{
    public class CrossReferenceViewModel
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        public Guid TeacherId { get; set; }

        public StudentViewModel Student { get; set; }

    }
}
