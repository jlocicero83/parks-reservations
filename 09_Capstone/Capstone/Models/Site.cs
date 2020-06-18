﻿using System;
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

    }
}
