using Azure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_8_EF.Task_Context
{
    public class Mycontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-M284REV\\SQLEXPRESS; Database = Firstcode_EF ; Trusted_Connection = true ; Encrypt = false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course_Instructor>()
           .HasKey(ci => new { ci.CourseId, ci.InstructorId });
            modelBuilder.Entity<Course_Student>()
           .HasKey(cs => new { cs.CourseId, cs.StudentId });
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Course_Student> Courses_Students { get; set; }
        public DbSet<Course_Instructor> course_Instructors { get; set; }
    }
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        [ForeignKey("Deparment")]
        public int DepartmentId { get; set; }
        public Department Department  { get; set; }
        List<Course_Student> Course_Student { get; set; }

        public override string ToString()
        {
            return $"Id: {StudentId}, Name: {Name}, age: {age}, DepartmentId: {DepartmentId}";
        }
    }
    public class Department { 
    
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public override string ToString()
        {
            return $"Id: {DepartmentId}, Name: {Name}, Students: {Students}";
        }
    }
    public class Instructor
    {
        [Key]
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public List<Course_Instructor> Course_Instructor { get; set; }
        public override string ToString()
        {
            return $"Id: {InstructorId}, Name: {Name}, age: {age}, Course_Instructor: {Course_Instructor}";
        }

    }
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public List <Course_Instructor> Course_Instructor { get; set; }
        public List<Course_Student> Course_Student { get; set; }
        public override string ToString()
        {
            return $"Id: {CourseId}, Name: {Name}, Course_Instructor: {Course_Instructor}, Course_Student:{Course_Student}";
        }
    }
    public class Course_Instructor
    {
        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        public Instructor  instructor { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
    public class Course_Student
    {
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student student { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course course {  get; set; }
        public int Grade {  get; set; }
    }
}
