using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleUI
{
    
    class Program
    {

        static void Main(string[] args)
        {
            Login();
        a:
            Menu();
            switch (Selection())
            {
                case 1:
                    Clear(); CourseMenu();
                    switch (Selection())
                    {
                        case 1: Clear(); CourseGetAll(); Clear(); goto a;
                        case 2: Clear(); CourseAdd(); Clear(); goto a;
                        case 3: Clear(); CourseGetAll(); CourseDelete(); Clear(); goto a;
                        case 4: Clear(); CourseUpdate(); goto a;
                        case 5: Clear(); CourseGetById(); goto a;
                        case 6: Clear(); goto a;
                        case 7: break;
                    }
                    break;
                case 2:
                    Clear(); EducatorMenu();
                    switch (Selection())
                    {
                        case 1: Clear(); EducatorGetAll(); Clear(); goto a;
                        case 2: Clear(); EducatorAdd(); Clear(); goto a;
                        case 3: Clear(); EducatorDelete(); Clear(); goto a;
                        case 4: Clear(); ; Clear(); EducatorUpdate(); goto a;
                        case 5: Clear(); EducatorGet(); Clear(); goto a;
                        case 6: Clear(); goto a;
                        case 7: break;
                    }
                    break;
                case 3:
                    Clear(); CourEduMenu();
                    switch (Selection())
                    {
                        case 1: Clear(); CourEduGetAll(); Clear(); goto a;
                        case 2: Clear(); CourEduAdd(); Clear(); goto a;
                        case 3: Clear(); CourEduDelete(); Clear(); goto a;
                        case 4: Clear(); CourEduUpdate(); Clear(); goto a;
                        case 5: Clear(); CourEduGetById(); Clear (); goto a;
                        case 6: Clear();goto a;
                        case 7: break;

                    }
                    break;
            }
            
        }

        //CourEduManager
        private static void CourEduGetById()
        {
            try
            {
                ICourEduService service = new CourEduManager(new EfCourEduDal());
                foreach (var item in service.GetById(ToId()))
                {
                    Console.WriteLine(item.Id + " " + item.EducatorsId + " " + item.CoursId);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        private static void CourEduUpdate()
        {
            try
            {
                ICourEduService service = new CourEduManager(new EfCourEduDal());
                service.Update(new CourEdu() { Id = ToId(), CoursId = ToCourseId(), EducatorsId = ToEducatorId() });
                Console.WriteLine("Update succesful");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        private static void CourEduDelete()
        {
            try
            {
                ICourEduService service = new CourEduManager(new EfCourEduDal());
                service.DeleteId(ToId());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        private static void CourEduGetAll()
        {
            try
            {
                ICourEduService service = new CourEduManager(new EfCourEduDal());
                foreach (var item in service.GetAll())
                {
                    Console.WriteLine(item.courEduId+" " + item.CourseName + " " + item.Comment + " " + item.AuthorName + " " + item.AuthorSurname);
                    Console.WriteLine("--------------------------------------------------");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        private static void CourEduAdd()
        {
            try
            {
                ICourEduService service = new CourEduManager(new EfCourEduDal());
                ICourseService a = new CourseManager(new EfCourseDal());
                IEducatorService b = new EducatorManager(new EfEducatorDal());
                int x = 0, courseıd, educatorıd;
                courseıd = ToCourseId();
                educatorıd = ToEducatorId();
                foreach (var item in a.GetById(courseıd))
                {
                    foreach (var item2 in b.GetById(educatorıd))
                    {
                        x += 1;
                    }
                }
                if (x == 1) // true
                {
                    Console.WriteLine("Enter ıd");
                    service.Add(new CourEdu() { Id = ToId(), CoursId = courseıd, EducatorsId = educatorıd });
                    Console.WriteLine("Success");
                }
                else // false
                {
                    Console.WriteLine("İnsertion failed!!!");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        //EducatorManager  
        private static void EducatorDelete()
        {
            try
            {
                EducatorGetAll();
                IEducatorService service = new EducatorManager(new EfEducatorDal());
                service.DeleteById(ToId());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void EducatorUpdate()
            {
            try
            {
                IEducatorService service = new EducatorManager(new EfEducatorDal());
                service.Update(new Educator() { Id = ToId(), Name = ToName(), Surname = ToSurname() });
                Console.WriteLine("Update succesful");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
                
            }   
        private static void EducatorAdd()
        {
            try
            {
                IEducatorService service = new EducatorManager(new EfEducatorDal());
                int id; string name, surname;
                Console.Write("Please to ıd=");
                id = Convert.ToInt16(Console.ReadLine());
                Console.Write("Please to Name=");
                name = Console.ReadLine();
                Console.WriteLine("Please to surname=");
                surname = Console.ReadLine();
                service.Add(new Educator { Id = id, Name = name, Surname = surname });
                Console.WriteLine("Succes");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
        private static void EducatorGet()
        {
            try
            {
                IEducatorService service = new EducatorManager(new EfEducatorDal());
                foreach (var item in service.GetById(ToId()))
                {
                    Console.WriteLine(item.Id + " " + item.Name + " " + item.Surname);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
            Console.ReadLine();
        }
        private static void EducatorGetAll()
        {
            try
            {
                IEducatorService service = new EducatorManager(new EfEducatorDal());
                foreach (var item in service.GetAll())
                {
                    Console.WriteLine(item.Id + " " + item.Name + " " + item.Surname);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();         
        }

        //CourseManager
        private static void CourseDelete()
        {
            try
            {
                ICourseService service = new CourseManager(new EfCourseDal());
                service.DeleteById(ToId());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        private static void CourseGetById()
        {
            try
            {
                ICourseService service = new CourseManager(new EfCourseDal());
                foreach (var item in service.GetById(ToId()))
                {
                    Console.WriteLine(item.Id + " " + item.CourseName + " " + item.Comment);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        private static void CourseUpdate()
        {
            try
            {
                ICourseService service = new CourseManager(new EfCourseDal());
                service.Update(new Course() { Id = ToId(), CourseName = ToName(), Comment = ToComment() });
                Console.WriteLine("Update succesful");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        private static void CourseGetAll()
        {
            try
            {
                ICourseService service = new CourseManager(new EfCourseDal());
                foreach (var item in service.GetAll())
                {
                    Console.WriteLine(item.Id + " " + item.CourseName + " " + item.Comment);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        private static void CourseAdd()
        {
            try
            {
                ICourseService service = new CourseManager(new EfCourseDal());
                int id; string name, comment;
                Console.Write("Please to ıd=");
                id = Convert.ToInt16(Console.ReadLine());
                Console.Write("Please to Name=");
                name = Console.ReadLine();
                Console.WriteLine("Please to Comment=");
                comment = Console.ReadLine();
                service.Add(new Course { Id = id, CourseName = name, Comment = comment });
                Console.WriteLine("Succes");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        
        }

        //Tools
        private static int ToId()
        {
            try
            {
                Console.Write("To id=");
                int id = Convert.ToInt16(Console.ReadLine());
                return id;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return 0;                                 
        }
        private static int ToCourseId()
        {
            try
            {
                Console.Write("To Course id=");
                int id = Convert.ToInt16(Console.ReadLine());
                return id;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return 0;
        }
        private static int ToEducatorId()
        {
            try
            {
                Console.Write("To Educator id=");
                int id = Convert.ToInt16(Console.ReadLine());
                return id;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return 0;
        }
        private static string ToName()
        {
            Console.Write("Name to update:");
            string name = Console.ReadLine();
            return name;
        }
        private static string ToComment()
        {
            Console.Write("Comment to update:");
            string name = Console.ReadLine();
            return name;
        }
        private static string ToSurname()
        {
            Console.Write("Surname to update:");
            string surname = Console.ReadLine();
            return surname;
        }
        private static void Clear()
        {
            Console.Clear();
        }
        static int Selection()
        {
            int select;
            try
            {               
                Console.Write("Please choose=");
                select = Convert.ToByte(Console.ReadLine());
                return select;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return 0;
        }

        //Menü
        static void CourseMenu()
        {
            Console.WriteLine("1- Show courses\n2- Add to course\n3- Delete to course\n4- Update to course\n5- Search to course\n6- To menu\n7- Exit");
        }
        static void EducatorMenu()
        {
            Console.WriteLine("1- Show Educators\n2- Add to Educator\n3- Delete to Educator\n4- Update to Educator\n5- Search to Educator\n6- To menu\n7- Exit");
        }
        private static void Login()
        {
            string UserName, Password;
            try
            {
                while (true)
                {
                    Console.WriteLine("Please a enter to username=");
                    UserName = Console.ReadLine();
                    if (UserName == "Admin")
                    {
                        Console.WriteLine("Please a enter to password=");
                        Password = Console.ReadLine();
                        if (Password == "290388")
                        {
                            Console.WriteLine("Connection to server.");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    }
                    Console.WriteLine("Username or password is wrong!!!");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.Clear();
        }
        
        static void Menu()
        {
            Console.WriteLine("1- Courses\n2- Educators\n3- Puplications");
        }
        static void CourEduMenu()
        {
            Console.WriteLine("1- Show couredu\n2- Add to couredu\n3- Delete to couredu\n4- Update to couredu\n5- Search to couredu\n6- To menu\n7- Exit");
        }
    }
}
