using MovieRentalWebApi.Models;
using Rental_BAL;
using Rental_Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRentalWebApi.Controllers
{
    public class MovieRentalController : ApiController
    {
        Helper helper = null;
        public MovieRentalController()
        {
            helper = new Helper();
        }
        [Route("GetAllRentMovies")]
        public List<RentMovieClass> GetBookList()
        {
            //return new string[] { "value1", "value2" };

            List<BAL> empbal = new List<BAL>(); empbal = helper.ShowRentalMovieList();
            List<RentMovieClass> emps = new List<RentMovieClass>();
            foreach (var item in empbal)
            {
                //Employees emp = new Employees();
                emps.Add(new RentMovieClass { Rentid = item.Rentid, Username = item.Username, Movieid = item.Movieid, Moviename = item.Moviename });
            }
            return emps;

        }
        [Route("AddRentMovies")]
        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] RentMovieClass empdata)
        {

            BAL empbal = new BAL();
            empbal.Rentid = empdata.Rentid;
            empbal.Username = empdata.Username;
            empbal.Movieid = empdata.Movieid;
            empbal.Moviename = empdata.Moviename;


            bool ans = helper.addmovierent(empbal);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }

        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}