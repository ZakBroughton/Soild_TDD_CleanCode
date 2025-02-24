using System;
using System.Collections.Generic;

namespace Assignment.Libary
{
    public class EmployeeManager
    {
        private Dictionary<string, Employee> employees;

        public EmployeeManager()
        {
            employees = new Dictionary<string, Employee>();
        }

        public void AddEmployee(Employee e)
        {
            employees.Add(e.EmployeeName, e);
        }

        public Employee FindEmployee(string EmployeeName)
        {
            try
            {
                return employees[EmployeeName];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }


    }
}
