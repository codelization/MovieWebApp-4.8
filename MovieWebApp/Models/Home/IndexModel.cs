using MovieWebApp.BusinessLogic.Classes;
using MovieWebApp.BusinessLogic.Classes.IMDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieWebApp.Models.Home
{
    public class IndexModel
    {
        public IEnumerable<Top250DataDetail> Items { get; set; }
    }
}