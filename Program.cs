using Microsoft.EntityFrameworkCore;
using task_8_EF.Task_Context;

namespace task_8_EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //fetch data into database
            Mycontext db = new Mycontext();
            Department[] departments =
            {
                new Department(){Name = "A"},
                new Department(){Name = "B"},
                new Department(){Name = "C"},
                new Department(){Name = "D"},
            };
            foreach (var i in departments)
            {
                db.Departments.Add(i);
            }
            Student[] student =
            {
                new Student(){DepartmentId = 1, Name = "ahmed", age = 23 },
                new Student(){DepartmentId = 2, Name = "Mohamed", age = 26},
                new Student(){DepartmentId = 3, Name = "Saleh", age = 20},
                new Student(){DepartmentId = 4, Name = "Omnia", age= 14},
            };
            foreach (var item in student)
            {
                db.Students.Add(item);
            }
            Course[] courses =
            {
                new Course(){Name = "Math"},
                new Course(){Name = "English"},
                new Course(){Name = "France"},
                new Course(){Name = "German"}
            };
            foreach (var item in courses)
            {
                db.Courses.Add(item);
            }
            Instructor[] instructors =
            {
                new Instructor{ Name = "osama", age = 29},
                new Instructor{ Name = "Hadeer", age = 30}
            };
            foreach (var instructor in instructors)
            {
                db.Instructors.Add(instructor);
            }
            Course_Instructor[] course_Instructor = {
                new Course_Instructor{InstructorId = 1, CourseId = 1},
                new Course_Instructor{InstructorId = 1, CourseId = 2},
                new Course_Instructor{InstructorId = 2, CourseId = 3},
                new Course_Instructor{InstructorId= 2, CourseId= 4}
            };
            foreach (var course in course_Instructor)
            {
                db.course_Instructors.Add(course);
            }
            Course_Student[] studentS = {
                new Course_Student { CourseId = 1, StudentId = 8, Grade = 80},
                new Course_Student { CourseId = 2, StudentId = 8, Grade = 90},
                new Course_Student { CourseId = 3, StudentId = 8, Grade = 95},
                new Course_Student { CourseId = 1, StudentId = 9, Grade = 90},
                new Course_Student { CourseId = 1, StudentId = 10, Grade = 92},
                new Course_Student { CourseId = 1, StudentId = 11, Grade = 92},
                new Course_Student { CourseId = 1, StudentId = 12, Grade = 94},
                new Course_Student { CourseId = 4, StudentId = 8, Grade = 90}
            };
            foreach (var item in studentS)
            {
                db.Courses_Students.Add(item);
            }

            //Read database
            var res = db.Students.Find(9);
            Console.WriteLine(res);
            var dept = db.Departments.Include(d => d.Students).FirstOrDefault(d => d.DepartmentId == 1); //Eager loading
            List<Student> students = dept.Students;
            foreach (var item in students)
            {
                Console.WriteLine(item);
            }
            var res = db.Departments.Where(d=> d.Name =="A");
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            db.SaveChanges();
        }
    }
}
