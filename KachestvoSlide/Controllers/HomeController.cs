using KachestvoSlide.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KachestvoSlide.Controllers
{
    public class HomeController : Controller
    {
        private string constr = "datasource=127.0.0.1;port=3306;username=root;password=;database=kachestvo;";

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Slide1()
        {
            List<sliderModel> slider = new List<sliderModel>();

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT Id, Name, Description, Image FROM Slider";

                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            slider.Add(new sliderModel
                            {
                                Id = Convert.ToInt32(sdr["Id"]),
                                Name = sdr["Name"].ToString(),
                                Description = sdr["Description"].ToString(),
                                Image = sdr["Image"].ToString(),
                            });

                            int totalSlide = slider.Count();
                            ViewBag.Total_Page_Count = totalSlide;


                        }
                    }
                    con.Close();
                }
            }
            return View(slider);
        }

        public ActionResult Slide2()
        {
            return View();
        }

        public ActionResult Slide3()
        {
            return View();
        }

    }
}