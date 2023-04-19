using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FrontendPracticeAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeDept { get; set; }

        public string EmployeeAddress { get; set; }
    }
}
