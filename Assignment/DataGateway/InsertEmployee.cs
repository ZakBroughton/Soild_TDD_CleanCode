using Assignment.Libary;
using MySqlConnector;
using System;

namespace Assignment.DataGateway
{
    public class InsertEmployee : DatabaseInserter<Employee>
    {
        protected override string GetSQL()
        {
            return
                "INSERT INTO Employee (EmployeeName) " +
                "VALUES (@employee_name)";
        }

        protected override int DoInsert(MySqlCommand command, Employee employeeToInsert)
        {
            command.Parameters.AddWithValue("@employee_name", employeeToInsert.EmployeeName);
            command.Prepare();
            int numRowsAffected = command.ExecuteNonQuery();

            if (numRowsAffected != 1)
            {
                throw new Exception("ERROR: Employee not inserted");
            }
            return numRowsAffected;
        }
    }
}