using Capstone.DAL;
using Capstone.Models;
using Capstone.Views;
using System;
using System.Collections.Generic;

namespace CLI
{
    /// <summary>
    /// A sub-menu 
    /// </summary>
    public class SubMenu1 : CLIMenu
    {
        // Store any private variables here....
        private Park park;
        private ICampgroundSqlDAO campgroundDAO;
        private ISiteSqlDAO siteDAO;
        private IList<Campground> campgrounds;
        private IList<Site> sites;
        private IReservationSqlDAO reservationDAO;

        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public SubMenu1(Park park, ICampgroundSqlDAO campgroundDAO, ISiteSqlDAO siteDAO, IReservationSqlDAO reservationDAO) :
            base("Sub-Menu 1")
        {
            this.park = park;
            this.campgroundDAO = campgroundDAO;
            this.siteDAO = siteDAO;
            this.reservationDAO = reservationDAO;
        }

        protected override void SetMenuOptions()
        {
            this.menuOptions.Add("1", "View Campgrounds");
            this.menuOptions.Add("2", "Search for Reservation");
            this.menuOptions.Add("3", "Return to Previous Screen");
            this.quitKey = "3";
        }

        /// <summary>
        /// The override of ExecuteSelection handles whatever selection was made by the user.
        /// This is where any business logic is executed.
        /// </summary>
        /// <param name="choice">"Key" of the user's menu selection</param>
        /// <returns></returns>
        protected override bool ExecuteSelection(string choice)
        {
            switch (choice)
            {
                case "1": // Do whatever option 1 is
                    SubMenu2 submenu2 = new SubMenu2(park, campgroundDAO, siteDAO, reservationDAO);
                    submenu2.Run();
                    //WriteError("Not yet implemented");
                    //Pause("");
                    return true;
                case "2": // Do whatever option 2 is
                    SubMenu2 submenu2A = new SubMenu2(park, campgroundDAO, siteDAO, reservationDAO);
                    submenu2A.Run();
                    WriteError("When this option is complete, we will exit this submenu by returning false from the ExecuteSelection method.");
                    Pause("");
                    return false;
            }
            return true;
        }

        protected override void BeforeDisplayMenu()
        {
            PrintHeader();
            SetColor(ConsoleColor.Blue);
            Console.WriteLine(park.ToString());
            ResetColor();
        }

        protected override void AfterDisplayMenu()
        {
            base.AfterDisplayMenu();
            SetColor(ConsoleColor.Cyan);
            //Console.WriteLine("Display some data here, AFTER the sub-menu is shown....");
            Console.WriteLine();
            ResetColor();
        }

        private void PrintHeader()
        {
            SetColor(ConsoleColor.Magenta);
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Park Info"));
            ResetColor();
        }

    }
}
