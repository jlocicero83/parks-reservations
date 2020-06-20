using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Site 
    {
        public int Site_ID { get; set; }
        public int Campground_ID { get; set; }
        public int Site_Number { get; set; }
        public int Max_Occupancy { get; set; }
        public bool IsAccessible { get; set; }
        public int Max_RV_Length { get; set; }
        public bool HasUtilities { get; set; }

        Dictionary<bool, string> accessible = new Dictionary<bool, string>()
        {
            {true, "Yes"},
            {false, "No"}
        };

        Dictionary<bool, string> utilities = new Dictionary<bool, string>()
        {
            {true, "Yes"},
            {false, "N/A"}
        };

        public static string PrintHeader()
        {
            return $"\n\nResults Matching Your Search Criteria\n" +
                $"----------------------------------------------------------------------------------------------\n" +
                $"{"Site No.",-10}{"Max Occup.",-20}{"Accessible?",-20}" +
                $"{"Max RV Length",-20}{"Utility",-20}";
        }

        public override string ToString()
        {
            return $"#{Site_Number, -9}{Max_Occupancy,-20}" +
                $"{accessible[IsAccessible],-20}{Max_RV_Length,-20}{utilities[HasUtilities], -20}";
        }

    }
}
