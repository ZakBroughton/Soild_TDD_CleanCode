using Assignment.Libary;
using MySqlConnector;
using System;
using System.Diagnostics.Metrics;

namespace Assignment.DataGateway
{
    public class FindEmployeeByName : DatabaseSelector<Employee>
    {
        private readonly string employeeName;

        public FindEmployeeByName(string employeeName)
        {
            this.employeeName = employeeName;
        }

        protected override string GetSQL()
        {
            return "SELECT EmployeeName FROM Employee WHERE EmployeeName = @EmployeeName";
        }

        protected override Employee DoSelect(MySqlCommand command)
        {
            Employee employee = null;

            try
            {
                command.Parameters.AddWithValue("@EmployeeName", employeeName);
                command.Prepare();
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    employee = new Employee(dr.GetString("EmployeeName"));
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: Retrieval of Employee failed", e);
            }

            return employee;
        }
    }
}