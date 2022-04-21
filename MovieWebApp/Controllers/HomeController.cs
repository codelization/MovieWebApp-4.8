using MovieWebApp.BusinessLogic;
using MovieWebApp.BusinessLogic.Classes;
using MovieWebApp.BusinessLogic.Classes.IMDB;
using MovieWebApp.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace MovieWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieBL _movieBL;

        public HomeController()
        {
            if (_movieBL == null)
            {
                _movieBL = new MovieBL();
            }
        }

        public ActionResult Index()
        {
            try
            {
                Top250Data top250Data = _movieBL.GetTop250Movies();

                if (top250Data == null) return View("Error");

                IndexModel indexModel = new IndexModel();
                indexModel.Items = top250Data.Items.Take(10);

                return View(indexModel);
            }
            catch(Exception)
            {
                return View("Error");
            }
            
        }

        public ActionResult Movie(string movieID)
        {
            try
            {
                TitleData titleData = _movieBL.GetTitleData(movieID);

                if (titleData == null) return View("Error");

                MovieDetailModel movieDetailModel = new MovieDetailModel();
                movieDetailModel.Genres = titleData.Genres;
                movieDetailModel.Title = titleData.Title;
                movieDetailModel.IMDbRating = titleData.IMDbRating;
                movieDetailModel.RuntimeStr = titleData.RuntimeStr;
                movieDetailModel.Plot = titleData.Plot;
                movieDetailModel.Stars = titleData.Stars;
                movieDetailModel.ContentRating = titleData.ContentRating;
                movieDetailModel.Year = titleData.Year;
                movieDetailModel.Image = titleData.Image;

                if (titleData.StarList != null)
                {
                    movieDetailModel.StarList = titleData.StarList.Take(3).ToList();
                }

                return View(movieDetailModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}