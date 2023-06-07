﻿using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandleLogicService.Dto
{
    public class TeacherDto
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public List<CrossReferenceDto> CrossReferences { get; set; }
    }
}
