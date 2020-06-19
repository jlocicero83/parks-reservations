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
            return $"{this.Name} National Park\nLocation: {this.Location, 5}\nEstablished: {this.Establish_Date.ToString(), 5}\nArea: {this.Area} sq km\nAnnual Visitors: {this.Visitors}\n\n{this.Description}\n\n";

        }
    }
}
