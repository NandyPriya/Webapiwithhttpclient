using moviehttpclient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace moviehttpclient.Controllers
{
    public class MovieRentalController : Controller
    {
        // GET: MovieRental
        public ActionResult Index()
        {
            List<MovieClass> emplist = new List<MovieClass>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44360//GetAllRentMovies");

                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readData = result.Content.ReadAsAsync<MovieClass[]>();
                    readData.Wait();
                    var empdata = readData.Result;
                    foreach (var item in empdata)
                    {
                        emplist.Add(new MovieClass { Rentid = item.Rentid, Username = item.Username, Movieid = item.Movieid, Moviename = item.Moviename });

                    }
                }

            }


            return View(emplist);

        
    }
    }
}