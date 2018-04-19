using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationTest.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}