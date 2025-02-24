﻿using Assignment.Libary;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace Assignment.DataGateway
{
    public class GetAllEmployees : DatabaseSelector<List<Employee>>
    {
        public GetAllEmployees() { }

        protected override string GetSQL()
        {
            return "SELECT EmployeeName FROM Employee"; 
        }

        protected override List<Employee> DoSelect(MySqlCommand command)
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    string employeeName = dr.GetString("EmployeeName"); // Retrieve EmployeeName from the result set
                    Employee employee = new Employee(employeeName);
                    employees.Add(employee);
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of employees failed", e);
            }

            return employees;
        }
    }
}