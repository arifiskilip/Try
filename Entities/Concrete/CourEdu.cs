using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CourEdu
    {
        public int Id { get; set; }
        public int CoursId { get; set; }
        public int EducatorsId { get; set; }

    }
}
