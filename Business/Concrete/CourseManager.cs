using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CourseManager : ICourseService
    {
        ICourseDal _courseDal;

        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public void Add(Course course)
        {
            _courseDal.Add(course);
        }

        public void Delete(Course course)
        {
            _courseDal.Delete(course);
        }

        public void DeleteById(int id)
        {
            _courseDal.DeleteId(id);
        }

        public List<Course> GetAll()
        {
           return _courseDal.GetAll();
        }

        public List<Course> GetById(int id)
        {
            return _courseDal.GetAll(p => p.Id == id);
        }

        public void Update(Course course)
        {
            _courseDal.Update(course);
        }
    }
}
