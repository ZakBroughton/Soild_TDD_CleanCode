using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway
{
    // This interface illustrates the Interface Segregation Principle
    public interface IInserter<T>
    {
        public int Insert(T itemToInsert);
    }
}