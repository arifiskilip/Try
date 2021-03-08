using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEducatorDal : EfEntityRepositoryBase<Educator, UdemyContext>, IEducatorDal
    {
        Educator educator;
        public void DeleteId(int id)
        {
            using (UdemyContext context = new UdemyContext())
            {
                educator = (from i in context.Educators where (i.Id == id) select i)
                    .FirstOrDefault<Educator>();
                if (educator!=null)
                {
                    context.Remove(educator);
                    context.SaveChanges();
                    Console.WriteLine("Success!");
                }
                else
                {
                    Console.WriteLine("Unsuccessful!");
                }
            }
        }
    }
}
