using System;

namespace Capstone.DAL
{
    public interface IReservationSqlDAO
    {
        int BookReservation(int site_id, string name, DateTime fromDate, DateTime toDate);
    }
}