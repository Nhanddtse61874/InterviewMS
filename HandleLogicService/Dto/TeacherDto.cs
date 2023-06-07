namespace HandleLogicService.Dto
{
    public class TeacherDto
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public List<CrossReferenceDto> CrossReferences { get; set; }
    }
}
