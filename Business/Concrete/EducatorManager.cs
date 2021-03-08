using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class EducatorManager : IEducatorService
    {
        IEducatorDal _educatorDal;

        public EducatorManager(IEducatorDal educatorDal)
        {
            _educatorDal = educatorDal;
        }

        public void Add(Educator educator)
        {
            _educatorDal.Add(educator);
        }

        public void Delete(Educator educator)
        {
            _educatorDal.Delete(educator);
        }

        public void DeleteById(int id)
        {
            _educatorDal.DeleteId(id);
        }

        public List<Educator> GetAll()
        {
            return _educatorDal.GetAll();
        }

        public List<Educator> GetById(int id)
        {
            return _educatorDal.GetAll(p=>p.Id==id);
        }

        public List<Educator> GetByName(string key)
        {
            return _educatorDal.GetAll(p => p.Name.ToLower().Contains(key.ToLower()));
        }

        public void Update(Educator educator)
        {
            _educatorDal.Update(educator);
        }
    }
}
