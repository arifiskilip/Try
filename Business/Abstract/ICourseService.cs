using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICourseService
    {
        List<Course> GetAll();
        List<Course> GetById(int id);
        void Add(Course course);
        void Delete(Course course);
        void Update(Course course);
        void DeleteById(int id);
    }
}
