using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoU.Models;

namespace ContosoU.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student{FirstMidName="Carson", LastName="Alexander", EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Student{FirstMidName="Meredith", LastName="Alonso", EnrollmentDate=DateTime.Parse("2002-09-01")}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{CourseID=1050, Title="Chemistry", Credits=3},
                new Course{CourseID=4022, Title="Microeconomics", Credits=3}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1, CourseID=1050, Grade=Grade.A},
                new Enrollment{StudentID=1, CourseID=4022},
                new Enrollment{StudentID=2, CourseID=4022, Grade=Grade.B}
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}
