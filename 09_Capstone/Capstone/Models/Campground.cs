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

    }
}
