using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class Teacher
    {
        [Key]
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public List<CrossReference> CrossReferences { get; set; }
    }
}
