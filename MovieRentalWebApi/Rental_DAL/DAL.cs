using Rental_BAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_DAL
{
    public class DAL
    {
        public List<BAL> MovieList()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Moviedb"].ConnectionString);

            SqlCommand cmdlist = new SqlCommand("select * from  rentmovies", cn);
            cn.Open();
            SqlDataReader dr = cmdlist.ExecuteReader();
            List<BAL> emplist = new List<BAL>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    BAL bal = new BAL();
                    bal.Rentid = Convert.ToInt32(dr["rentid"]);
                    bal.Username = dr["username"].ToString();
                    bal.Moviename = dr["moviename"].ToString();
                    bal.Movieid = Convert.ToInt32(dr["movieid"]);
                    
                    emplist.Add(bal);
                }
            }
            cn.Close();
            cn.Dispose();
            return emplist;

        }
        public bool InsertRentMovie(BAL book1)
        {

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Moviedb"].ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into rentmovies values(@rentid,@username,@movieid,@moviename)", cn);
            cmd.Parameters.AddWithValue("@rentid", book1.Rentid);
            cmd.Parameters.AddWithValue("@username", book1.Username);
            cmd.Parameters.AddWithValue("@movieid", book1.Movieid);
            cmd.Parameters.AddWithValue("@moviename", book1.Moviename);
           
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            cn.Close();
            cn.Dispose();
            Console.WriteLine(status);
            return status;

        }

    }
}
