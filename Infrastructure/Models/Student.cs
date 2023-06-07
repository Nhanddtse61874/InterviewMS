using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public DateTime DOB { get; set; }

        public List<CrossReference> CrossReferences { get; set; }
    }
}
