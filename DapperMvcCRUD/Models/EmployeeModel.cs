using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperMvcCRUD.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
    }
}