using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Transactions;

namespace Capstone.Tests
{
    [TestClass]
    public class NationalParksTests
    {
        private string connectionString = @"Server=.\sqlexpress;database=npcampground; trusted_connection=true;";
        private TransactionScope transaction;

        private int park_id;
        private int campground_id;
        private int site_id;
     

        [TestInitialize]
        public void SetupDB()
        {
            transaction = new TransactionScope();

            string sqlScript = File.ReadAllText("Setup.sql");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlScript, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    park_id = Convert.ToInt32(rdr["park_id"]);
                    campground_id = Convert.ToInt32(rdr["campground_id"]);
                    site_id = Convert.ToInt32(rdr["site_id"]);
                }
            }
        }
        [TestCleanup]
        public void CleanupDB()
        {
            transaction.Dispose();
        }

        [TestMethod]
        public void GetCampgrounds()
        {
            CampgroundSqlDAO dao = new CampgroundSqlDAO(connectionString);

            IList<Campground> list = dao.GetCampgroundsByParkID(park_id);

            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void GetParks()
        {
            ParkSqlDAO dao = new ParkSqlDAO(connectionString);

            IList<Park> list = dao.GetAllParks();

            Assert.AreEqual(1, list.Count);
        }
        [TestMethod]
        public void TestSearch()
        {
            SiteSqlDAO dao = new SiteSqlDAO(connectionString);

            DateTime fromDate = Convert.ToDateTime(06 - 18 - 2020);
            DateTime toDate = Convert.ToDateTime(06 - 19 - 2020);

            IList<Site> list = dao.SearchSitesByDate(campground_id, fromDate, toDate);

            Assert.AreEqual(1, list.Count);
        }
        [TestMethod]
        public void TestCreateReservation()
        {
            ReservationSqlDAO dao = new ReservationSqlDAO(connectionString);

            DateTime fromDate = Convert.ToDateTime(06 - 18 - 2020);
            DateTime toDate = Convert.ToDateTime(06 - 19 - 2020);

            int reservation = dao.BookReservation(site_id, "Bob", fromDate, toDate);

            Assert.IsNotNull(reservation);
        }
    }
}
