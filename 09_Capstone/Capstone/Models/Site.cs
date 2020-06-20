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

        public static string GetHeader()
        {
            return $"\n\nResults Matching Your Search Criteria\n" +
                $"----------------------------------------------------------------------------------------------\n" +
                $"{"Site No.",-10}{"Max Occup.",-20}{"Accessible?",-20}" +
                $"{"Max RV Length",-20}{"Utility",-20}{"Cost",-20}";
        }

        public override string ToString()
        {
            return $"#{Site_Number, -9}{Max_Occupancy,-20}" +
                $"{IsAccessible,-20}{Max_RV_Length,-20}{HasUtilities, -20}";
        }

    }
}
