using Assignment.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway
{
    // This interface illustrates the Interface Segregation Principle
    public interface ISelector<T>
    {
        public T Select();


    }


}
