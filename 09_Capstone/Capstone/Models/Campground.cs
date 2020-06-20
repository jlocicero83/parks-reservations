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

        public static string GetHeader()
        {
            return $"{"ID",-5} {"Name",-35} {"Open",-15} {"Close",-15} {"Daily Fee",-15}\n{"--",-6}{"----", -36}{"----", -16}{"----", -16}{"---------", -16}";
        }

        public override string ToString()
        {
            return $"#{this.Campgound_ID,-4} {this.Name, -35} {months[Open_From], -15} {months[Open_To], -15} {this.Daily_Fee,5:C}";
        }

    }
}
