﻿using Capstone.DAL;
using Capstone.Models;
using CLI;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Capstone.Views
{
    public class SubMenu2 : CLIMenu
    {
        // Store any private variables here....
        private Park park;
        private ICampgroundSqlDAO campgroundDAO;
        private ISiteSqlDAO siteDAO;
        private IList<Campground> campgrounds;
        private IList<Site> sites;

        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public SubMenu2(Park park, ICampgroundSqlDAO campgroundDAO, ISiteSqlDAO siteDAO) :
            base("Sub-Menu 2")
        {
            this.park = park;
            this.campgroundDAO = campgroundDAO;
            this.siteDAO = siteDAO;
        }

        protected override void SetMenuOptions()
        {
            this.menuOptions.Add("1", "Search for Available Reservation");
            this.menuOptions.Add("2", "Return to Previous Screen");
            this.quitKey = "2";
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
                    
                    int campgroundID = GetInteger("Which campground?");

                    Console.Write("What is the arrival date? __/__/____ ");
                    DateTime fromDate = Convert.ToDateTime(Console.ReadLine());

                    Console.Write("What is the departure date? __/__/____ ");
                    DateTime toDate = Convert.ToDateTime(Console.ReadLine());

                    sites = siteDAO.SearchSitesByDate(campgroundID, fromDate, toDate);
                    foreach (Site site in sites)
                    {
                        Console.WriteLine(site);
                    }

                    WriteError("Not yet implemented");
                    Pause("");
                    return true;
                case "2": // Do whatever option 2 is
                    WriteError("When this option is complete, we will exit this submenu by returning false from the ExecuteSelection method.");
                    Pause("");
                    return false;
            }
            return true;
        }

        protected override void BeforeDisplayMenu()
        {
            PrintHeader();
            campgrounds = (campgroundDAO.GetCampgroundsByParkID(park.Park_ID));
            foreach (Campground campground in campgrounds)
            {
                Console.WriteLine(campground.ToString());
            }
        }

        protected override void AfterDisplayMenu()
        {
            base.AfterDisplayMenu();
            SetColor(ConsoleColor.Cyan);
            Console.WriteLine("Display some data here, AFTER the sub-menu is shown....");
            ResetColor();
        }

        private void PrintHeader()
        {
            SetColor(ConsoleColor.Magenta);
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Sub-Menu 2"));
            ResetColor();
        }
    }
}