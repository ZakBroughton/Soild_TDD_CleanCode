using Assignment.Libary;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;


namespace Assignment.DataGateway
{
    public class EmployeeGateway : DatabaseGateWay
    {
        private EmployeeManager employeeManager;

        public EmployeeGateway()
        {
            employeeManager = new EmployeeManager();
        }

        protected override string InsertionSQL { get; } = "INSERT INTO Employees (EmployeeName) VALUES (@employeeName)";


        public void AddEmployee(Employee employee)
        {
            employeeManager.AddEmployee(employee);

            using (MySqlConnection conn = GetMySQLConnection())
            {
                MySqlCommand command = new MySqlCommand(InsertionSQL, conn);
                command.Parameters.AddWithValue("@employeeName", employee.EmployeeName);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("ERROR: insertion of employee failed", e);
                }
            }
        }

        public Employee FindEmployee(string employeeName)
        {
            return employeeManager.FindEmployee(employeeName);
        }

       
        protected override void DoInsertion(MySqlCommand command, object objectToInsert)
        {
            throw new NotImplementedException("ERROR: Test 6");
        }
    }
}
