using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.ui_command
{

    // This class implements the Null Object design pattern
    public class NullCommand : UI_Command
    {

        public NullCommand()
        {
        }

        public void Execute()
        {
        }
    }
}
