using Capstone.DAL;
using Capstone.Models;
using System;
using System.Collections.Generic;

namespace CLI
{
    /// <summary>
    /// The top-level menu in our application
    /// </summary>
    public class MainMenu : CLIMenu
    {
        // You may want to store some private variables here.  YOu may want those passed in 
        // in the constructor of this menu
        protected ICampgroundSqlDAO campgroundDAO;
        protected ISiteSqlDAO siteDAO;
        protected IParkSqlDAO parkDAO;
        /// <summary>
        /// Constructor adds items to the top-level menu. You will likely have parameters  passed in
        /// here...
        /// </summary>
        public MainMenu(ICampgroundSqlDAO campgroundDAO, ISiteSqlDAO siteDAO, IParkSqlDAO parkDAO) : base("Main Menu")
        {
            this.campgroundDAO = campgroundDAO;
            this.siteDAO = siteDAO;
            this.parkDAO = parkDAO;
        }

        protected override void SetMenuOptions()
        {
            IList<Park> parks = parkDAO.GetAllParks();
            int key = 1;
            foreach (Park park in parks)
            {
                this.menuOptions.Add(key.ToString(), park.Name + " Park");
                key++;
            }
            
            // A Sample menu.  Build the dictionary here
            //this.menuOptions.Add("1", "Add 2 integers");
            //this.menuOptions.Add("2", "Ask the user for name");
            //this.menuOptions.Add("3", "Go to a sub-menu");
            this.menuOptions.Add("Q", "Quit program");
        }

        /// <summary>
        /// The override of ExecuteSelection handles whatever selection was made by the user.
        /// This is where any business logic is executed.
        /// </summary>
        /// <param name="choice">"Key" of the user's menu selection</param>
        /// <returns></returns>
        protected override bool ExecuteSelection(string choice)
        {
            IList<Park> parks = parkDAO.GetAllParks();
            int key = int.Parse(choice) - 1;
            Park park = parks[key];
            SubMenu1 subMenu1 = new SubMenu1(park, campgroundDAO, siteDAO);
            subMenu1.Run();

            //switch (choice)
            //{
            //    case "1": // Do whatever option 1 is. You may prompt the user for more information
            //                // (using the Helper methods), and then pass those values into some 
            //                //business object to get something done.
            //        int i1 = GetInteger("Enter the first integer: ");
            //        int i2 = GetInteger("Enter the second integer: ");
            //        Console.WriteLine($"{i1} + {i2} = {i1+i2}");
            //        Pause("Press enter to continue");
            //        return true;    // Keep running the main menu
            //    case "2": // Do whatever option 2 is
            //        string name = GetString("What is your name?");
            //        WriteError($"Not yet implemented, {name}.");
            //        Pause("");
            //        return true;    // Keep running the main menu
            //    case "3": 
            //        // Create and show the sub-menu
            //        SubMenu1 sm = new SubMenu1();
            //        sm.Run();
            //        return true;    // Keep running the main menu
            //}
            return true;
        }

        protected override void BeforeDisplayMenu()
        {
            PrintHeader();
            
        }


        private void PrintHeader()
        {
            SetColor(ConsoleColor.Yellow);
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Parks and Recreation"));
            
            SetColor(ConsoleColor.White);
            ResetColor();
        }
    }
}
