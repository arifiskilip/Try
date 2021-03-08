using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class AuthorDetailDto
    {
        public int courEduId { get; set; }
        public int CourseId { get; set; }
        public int EducatorId { get; set; }
        public string CourseName { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string Comment { get; set; }

    }
}
