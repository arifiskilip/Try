using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class UdemyContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-JA9P259\SQLEXPRESS; Database=Udemy; Trusted_Connection=true");
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Educator> Educators { get; set; }
        public DbSet<CourEdu> CourEdus { get; set; }
    }
}
