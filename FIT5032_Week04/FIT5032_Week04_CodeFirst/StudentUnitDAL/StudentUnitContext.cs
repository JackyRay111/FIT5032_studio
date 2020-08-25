using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FIT5032_Week04_CodeFirst.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace FIT5032_Week04_CodeFirst.StudentUnitDAL
{
    public class StudentUnitContext : DbContext
    {
        public StudentUnitContext() : base("StudentUnitContext")
        { }

        public DbSet<Student> Students
        {
            get; set; }

        public DbSet<Unit> Units
        {
            get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}