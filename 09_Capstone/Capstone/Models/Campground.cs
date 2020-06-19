using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Campground
    {
        public int Campgound_ID { get; set; }
        public int Park_ID { get; set; }
        public string Name { get; set; }
        public int Open_From { get; set; }
        public int Open_To { get; set; }
        public decimal Daily_Fee { get; set; }

        private Dictionary<int, string> months = new Dictionary<int, string>()
        {
            {1, "January" },
            {2, "February" },
            {3, "March" },
            {4, "April" },
            {5, "May" },
            {6, "June" },
            {7, "July" },
            {8, "August" },
            {9, "September" },
            {10, "October" },
            {11, "November" },
            {12, "December" }

        };


        public override string ToString()
        {
            return $"Campground ID: #{this.Campgound_ID}\n-------\nName: {this.Name}\n-------\nOpen: {months[Open_From]}\n-------\nClose: {months[Open_To]}\n-------\nDaily Fee: {this.Daily_Fee:C}";
        }

    }
}
