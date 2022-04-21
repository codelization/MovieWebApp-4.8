using MovieWebApp.BusinessLogic.Classes;
using MovieWebApp.BusinessLogic.Classes.IMDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieWebApp.Models.Home
{
    public class MovieDetailModel
    {
        public string Genres { get; set; }
        public string Title { get; set; }
        public string IMDbRating { get; set; }
        public string RuntimeStr { get; set; }
        public string Plot { get; set; }
        public string Stars { get; set; }
        public string ContentRating { get; set; }
        public string Year { get; set; }
        public List<StarShort> StarList { get; set; }
        public string Image { get; set; }
    }
}