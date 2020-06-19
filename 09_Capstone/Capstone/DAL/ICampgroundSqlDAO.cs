using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAL
{
    public interface ICampgroundSqlDAO
    {
        IList<Campground> GetCampgroundsByParkID(int parkID);
    }
}