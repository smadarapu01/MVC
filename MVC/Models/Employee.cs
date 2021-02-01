﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public int DeptId { get; set; }
    }
}