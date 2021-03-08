using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICourEduService
    {
        void Add(CourEdu courEdu);
        List<AuthorDetailDto> GetAll();
        void DeleteId(int id);
        void Update(CourEdu courEdu);
        List<CourEdu> GetById(int id);
    }
}
