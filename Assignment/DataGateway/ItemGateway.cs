using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway
{
    public class ItemGateway : DatabaseGateWay
    {

        protected override string InsertionSQL { get; } = "INSERT INTO Items (ItemName, Quantity, ItemPrice ,EmployeeName) VALUES (@name, @quantity,@itemPrice ,@employeeName)";


        protected override void DoInsertion(MySqlCommand command, object objectToInsert)
        {
            throw new NotImplementedException();
        }
    }
}