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
            return $"Park Id:{this.Park_ID}, Name: {this.Name}, Location: {this.Location}, Establish Date: {this.Establish_Date}, Area: {this.Area}, Visitors: {this.Visitors}, Description: {this.Description}. ";

        }
    }
}
