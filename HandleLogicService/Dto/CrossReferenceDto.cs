using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
