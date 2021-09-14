using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEmployee.Models.Entities
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public string position { get; set; }
    }
}