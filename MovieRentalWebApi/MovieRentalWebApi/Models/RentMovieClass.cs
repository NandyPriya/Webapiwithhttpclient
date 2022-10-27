using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalWebApi.Models
{
    public class RentMovieClass
    {
        private int rentid;

        public int Rentid
        {
            get { return rentid; }
            set { rentid = value; }
        }
        private int movieid;

        public int Movieid
        {
            get { return movieid; }
            set { movieid = value; }
        }
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private string moviename;

        public string Moviename
        {
            get { return moviename; }
            set { moviename = value; }
        }



    }
}