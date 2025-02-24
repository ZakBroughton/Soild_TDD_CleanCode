using System;
using System.Collections.Generic;
using System.Windows.Input;
using Assignment.DataGateway;
using Assignment.Libary;
using Assignment.ui_command;
using static System.Net.Mime.MediaTypeNames;


namespace Assignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CommandFactory factory = new CommandFactory(new DataGatewayFacade());

                factory
                    .CreateCommand(UI_Command.INITIALISE_DATABASE)
                    .Execute();

                UI_Command displayMenu = factory.CreateCommand(UI_Command.DISPLAY_MENU);

                displayMenu.Execute();
                int choice = GetMenuChoice();

                while (choice != UI_Command.EXIT)
                {
                    factory
                        .CreateCommand(choice)
                        .Execute();

                    displayMenu.Execute();
                    choice = GetMenuChoice();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nERROR: Test 3: " + e.ToString());
            }
        }

        public static int GetMenuChoice()
        {
            int option = ConsoleReader.ReadInteger("\nOption");
            while (option < 1 || option > 10)
            {
                Console.WriteLine("\nChoice not recognised. Please try again");
                option = ConsoleReader.ReadInteger("\nOption");
            }
            return option;
        }
    }
}

