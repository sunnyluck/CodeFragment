using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplicationTest.DataAccessLayer;

namespace WebApplicationTest.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        //[Required(ErrorMessage = "Enter First Name")]
        [@CustomValidation]
        public string FirstName { get; set; }
        //[StringLength(5, MinimumLength = 3, ErrorMessage = "Last Name length should not be greater than 5")]
        [@CustomValidation]
        public string LastName { get; set; }
    }
}