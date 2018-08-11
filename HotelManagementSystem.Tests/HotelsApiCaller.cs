using HotelManagementSystem.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;



namespace HotelManagementSystem.Tests
{
    public static class HotelsApiCaller
    {
        private static RestClient _client = new RestClient("http://localhost:52475/api");
        public static List<Hotel> AddHotel(Hotel hotel)
        {
            var request = new RestRequest("Hotel", Method.POST);
            string json = JsonConvert.SerializeObject(hotel);
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            IRestResponse response = _client.Execute(request);
            var content = response.Content;
            return JsonConvert.DeserializeObject<List<Hotel>>(content);
        }

        public static Hotel GetHotelById(int id)
        {
            var request = new RestRequest("Hotel/{id}", Method.GET);
            request.AddUrlSegment("id", id);

            IRestResponse response = _client.Execute(request);
            var content = response.Content;
            return JsonConvert.DeserializeObject<Hotel>(content);
        }

        public static List<Hotel> GetAllHotels()
        {
            var request = new RestRequest("Hotel", Method.GET);

            IRestResponse response = _client.Execute(request);
            var content = response.Content;
            return JsonConvert.DeserializeObject<List<Hotel>>(content);
        }
    }
}