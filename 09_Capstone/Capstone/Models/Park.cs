using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Park
    {
        //properties
        public int Park_ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Establish_Date { get; set; }
        public int Area { get; set; }
        public int Visitors { get; set; }
        public string Description { get; set; }


        public override string ToString()
        {
            return $"{this.Name,12} National Park\n" +
                $"**********************************\n" +
                $"{"Location:",-20} {this.Location}\n" +
                $"{"Established:",-20} {this.Establish_Date.ToString("MM/dd/yyyy")}\n" +
                $"{"Area:", -20} {this.Area} sq. km.\n" +
                $"{"Annual Visitors:",-20} {this.Visitors:N0}\n\n" +
                $"{this.Description}\n\n";

        }
    }
}
