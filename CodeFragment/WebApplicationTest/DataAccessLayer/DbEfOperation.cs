using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplicationTest.Models;

namespace WebApplicationTest.DataAccessLayer
{
    public class DbEfOperation : DbContext
    {
        public DbEfOperation() : base("MvcEfSqlServer") { }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<User> UserList { get; set; }

        public DbSet<Person> PersonList { get; set; }

        public DbSet<Student> StudentList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("TblEmployee");
            modelBuilder.Entity<User>().ToTable("TblUser");
            modelBuilder.Entity<Person>().ToTable("TblPerson");
            modelBuilder.Entity<Student>().ToTable("TblStudent");
            base.OnModelCreating(modelBuilder);
        }
    }
}