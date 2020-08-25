using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FIT5032_Week04_CodeFirst.Models;

namespace FIT5032_Week04_CodeFirst.StudentUnitDAL
{
    public class StudentUnitInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StudentUnitContext>
    {
        protected override void Seed(StudentUnitContext context)
        {
            var students = new List<Student> {
                new Student{ FirstName="Jiancong", LastName="Lei"}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var Units = new List<Unit> {
                new Unit{ Name="Internet applications development", Description="Goooood!"}
            };

            Units.ForEach(s => context.Units.Add(s));
            context.SaveChanges();
        }
    }
}