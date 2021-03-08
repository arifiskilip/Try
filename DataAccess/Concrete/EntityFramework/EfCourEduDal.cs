using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCourEduDal : EfEntityRepositoryBase<CourEdu,UdemyContext>,ICourEduDal
    {
 
        public void DeleteId(int id)
        {
            CourEdu courEdu;
            using (UdemyContext context = new UdemyContext())
            {
                courEdu = (from i in context.CourEdus where (i.Id == id) select i).FirstOrDefault<CourEdu>();
                if (courEdu != null)
                {
                    context.CourEdus.Remove(courEdu);
                    context.SaveChanges();
                    Console.WriteLine("Succes!");
                }
                else
                {
                    Console.WriteLine("Unsuccessful!");
                }
            }
            Console.ReadLine();
        }

        public List<AuthorDetailDto> GetAuthorDetail()
        {
            using (UdemyContext context = new UdemyContext())
            {
                var result = from c in context.Courses
                             join
                             ce in context.CourEdus on c.Id equals ce.CoursId
                             join e in context.Educators on ce.EducatorsId equals e.Id                            
                             select new AuthorDetailDto
                             { AuthorName = e.Name, AuthorSurname = e.Surname, CourseId = c.Id, CourseName = c.CourseName, EducatorId = e.Id,Comment=c.Comment,courEduId=ce.Id };
                return result.ToList();
            }
        }

    }
}


// var result = from p in context.Products
// join c in context.Categories
// on p.CategoryId equals c.CategoryId
// select new ProductDetailDto
// { CategoryName = c.CategoryName, ProductId = p.ProductId, ProductName = p.ProductName, UnitsInStock = p.UnitsInStock };
// return result.ToList();