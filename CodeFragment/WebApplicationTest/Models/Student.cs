using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationTest.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}