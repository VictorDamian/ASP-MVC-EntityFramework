using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEmployee.Models.EmpModel
{
    public class EmployeeModel
    {
        private int id;
        private string name;
        private int age;
        private string email;
        private string position;


        public int Id { get => id; set => id = value; }
        [Required]
        [RegularExpression("^[a-zA-Z ]+$",ErrorMessage="The fiel must be only letter")]
        [StringLength(maximumLength:80, MinimumLength =4)]
        public string Name { get => name; set => name = value; }
        [Required]
        [RegularExpression("([0-9]+)",ErrorMessage ="Age number must be only numbers")]
        public int Age { get => age; set => age = value; }
        [Required]
        [EmailAddress]
        public string Email { get => email; set => email = value; }
        [Required]
        public string Position { get => position; set => position = value; }
    }
}