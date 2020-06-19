using Capstone.Models;
using System;
using System.Collections.Generic;

namespace Capstone.DAL
{
    public interface ISiteSqlDAO
    {
        IList<Site> SearchSitesByDate(int campgroundID, DateTime fromDate, DateTime toDate);
    }
}