using Rental_BAL;
using Rental_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Helper
{
    public class Helper
    {
        DAL dl = null;
        public Helper()
        {
            dl = new DAL();
        }
        public bool addmovierent(BAL book1)
        {
            bool status = dl.InsertRentMovie(book1);
            Console.WriteLine(status);
            return status;

        }
        public List<BAL> ShowRentalMovieList()
        {
            return dl.MovieList();
        }
    }
}
