using MovieWebApp.BusinessLogic.Classes;
using MovieWebApp.BusinessLogic.Classes.IMDB;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MovieWebApp.BusinessLogic
{
    public class MovieBL
    {
        private const string API_URL = "https://imdb-api.com/en/API";
        private const string API_KEY = "k_s6f2ybvk";
        private readonly RestClient _restClient;
        private RestRequest _restRequest;
        private IRestResponse _response;

        public MovieBL()
        {
            if (_restClient == null)
            {
                _restClient = new RestClient(API_URL);
            }
        }

        public Top250Data GetTop250Movies()
        {
            var url = string.Format("/Top250Movies/{0}", API_KEY);

            _restRequest = new RestRequest(url);
            _response = _restClient.Execute(_restRequest);

            Top250Data top250Data = JsonConvert.DeserializeObject<Top250Data>(_response.Content);

            return top250Data;
        }

        public TitleData GetTitleData(string movieID)
        {
            if (string.IsNullOrEmpty(movieID)) return null;

            var url = string.Format("/Title/{0}/{1}", API_KEY, movieID);

            _restRequest = new RestRequest(url);
            _response = _restClient.Execute(_restRequest);

            TitleData titleData = JsonConvert.DeserializeObject<TitleData>(_response.Content);

            return titleData;
        }
    }
}