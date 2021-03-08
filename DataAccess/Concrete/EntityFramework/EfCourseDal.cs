using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCourseDal : EfEntityRepositoryBase<Course, UdemyContext>, ICourseDal
    {       
        public void DeleteId(int id)
        {
            Course course;
            using (UdemyContext context = new UdemyContext())
            {
                course = (from i in context.Courses where (i.Id == id) select i).FirstOrDefault<Course>();
                if (course != null)
                {
                    context.Remove(course);
                    context.SaveChanges();
                    Console.WriteLine("Succes!!");
                }
                else
                {
                    Console.WriteLine("Unsuccessful!!");
                }
                Console.ReadLine();
            }
        }
    }
}
