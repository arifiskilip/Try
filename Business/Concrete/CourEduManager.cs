using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CourEduManager : ICourEduService
    {
        ICourEduDal _courEduDal;

        public CourEduManager(ICourEduDal courEduDal)
        {
            _courEduDal = courEduDal;
        }

        public void Add(CourEdu courEdu)
        {
            _courEduDal.Add(courEdu);
        }

        public List<AuthorDetailDto> GetAll()
        {
            return _courEduDal.GetAuthorDetail();
        }
        public void DeleteId(int id)
        {
            _courEduDal.DeleteId(id);
        }

        public void Update(CourEdu courEdu)
        {
            _courEduDal.Update(courEdu);
        }

        public List<CourEdu> GetById(int id)
        {
            return _courEduDal.GetAll(p => p.Id == id);
        }
    }
}
