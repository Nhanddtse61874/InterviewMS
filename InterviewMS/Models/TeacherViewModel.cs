namespace InterviewMS.Models
{
    public class TeacherViewModel
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public List<CrossReferenceViewModel> CrossReferences { get; set; }

    }
}
