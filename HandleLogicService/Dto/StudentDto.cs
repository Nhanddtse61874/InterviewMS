﻿namespace HandleLogicService.Dto
{
    public class StudentDto
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public DateTime DOB { get; set; }

        public List<CrossReferenceDto> CrossReferences { get; set; }
    }
}
