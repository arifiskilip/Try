using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IEducatorService
    {
        List<Educator> GetAll();
        List<Educator> GetById(int id);
        void Add(Educator educator);
        void Delete(Educator educator);
        void Update(Educator educator);
        List<Educator> GetByName(string key);
        void DeleteById(int id);

    }
}
