namespace SchoolGradingSystem.Migrations
{
    using SchoolGradingSystem.Constants;
    using SchoolGradingSystem.Data;
    using SchoolGradingSystem.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolDbContext db)
        {
            // Seed Data Below

            Teacher mathTeacher = new Teacher()
            {
                FirstName = "Joseph",
                LastName = "Falcon",
                Email = UserConstants.TEACHER_EMAILONE,
                Password = UserConstants.TEACHER_PASSWORD,
                Major = UserConstants.TEACHER_MAJOR_MATH,
            };

            Teacher englishTeacher = new Teacher()
            {
                FirstName = "Gina",
                LastName = "Brown",
                Email = UserConstants.TEACHER_EMAILTWO,
                Password = UserConstants.TEACHER_PASSWORD,
                Major = UserConstants.TEACHER_MAJOR_ENG,
            };

            Student studentOne = new Student()
            {
                FirstName = "Evie",
                LastName = "Frye",
                StudentNumber = UserConstants.STUDENT_NUMBERONE,
                Password = UserConstants.STUDENT_PASSWORD,
            };

            Student studentTwo = new Student()
            {
                FirstName = "Jacob",
                LastName = "Frye",
                StudentNumber = UserConstants.STUDENT_NUMBERTWO,
                Password = UserConstants.STUDENT_PASSWORD,
            };

            List<Student> englishClassStudents = new List<Student>();
            List<Student> mathClassStudents = new List<Student>();

            englishClassStudents.Add(studentOne);

            mathClassStudents.Add(studentOne);
            mathClassStudents.Add(studentTwo);

            Class englishClass = new Class()
            {
                Name = "A-001",
                Capacity = 10,
                Teacher = englishTeacher,
                Students = englishClassStudents,
            };

            Class mathClass = new Class()
            {
                Name = "A-002",
                Teacher = mathTeacher,
                Students = mathClassStudents,
            };

            if (!db.Teachers.Any())
            {
                db.Teachers.Add(mathTeacher);
                db.Teachers.Add(englishTeacher);
            }

            if (!db.Students.Any())
            {
                db.Students.Add(studentOne);
                db.Students.Add(studentTwo);
            }

            if (!db.Classes.Any())
            {
                db.Classes.Add(englishClass);
                db.Classes.Add(mathClass);
            }

            db.SaveChanges();
        }
    }
}
