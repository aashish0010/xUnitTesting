using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingConsole.Employee
{
    public class EmployeeServices : IEmployeeServices
    {
        public string GetEmployeeDetail(string name)
        {
            return name;
        }
    }
}
