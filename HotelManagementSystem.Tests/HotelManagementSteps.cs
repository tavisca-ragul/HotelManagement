using FluentAssertions;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class HotelManagementSteps
    {
        private Hotel _hotel = new Hotel();
        private Hotel _addHotelResponse;
        private List<Hotel> _hotels = new List<Hotel>();


        [Given(@"User provided valid Id '(.*)'  and '(.*)'for hotel")]
        public void GivenUserProvidedValidIdAndForHotel(int id, string name)
        {
            _hotel.Id = id;
            _hotel.Name = name;
        }

        [Given(@"User has added required details for hotel")]
        public void GivenUseHasAddedRequiredDetailsForHotel()
        {
            SetHotelBasicDetails();
        }

        [Given(@"User called AddHotel api")]
        [When(@"User calls AddHotel api")]
        public void WhenUserCallsAddHotelApi()
        {
            _hotels = HotelsApiCaller.AddHotel(_hotel);
        }


        [When(@"User calls GethotelById api '(.*)'")]
        public void WhenUserGetsHotelById(int id)
        {
            _hotel = HotelsApiCaller.GetHotelById(id);
        }

        [When(@"User calls GetAllHotels api")]
        public void WhenUserCallsGetAllHotelsApi()
        {
            _hotels = HotelsApiCaller.GetAllHotels();
        }


        [Then(@"Hotel with name '(.*)' should be present in the response")]
        public void ThenHotelWithNameShouldBePresentInTheResponse(string name)
        {
            _hotel = _hotels.Find(htl => htl.Name.ToLower().Equals(name.ToLower()));
            _hotel.Should().NotBeNull(string.Format("Hotel with name {0} not found in response", name));
        }

        [Then(@"Hotel with name '(.*)' which got by id should be present in the response")]
        public void ThenHotelWithNameWhichGotByIdShouldBePresentInTheResponse(string name)
        {
            _hotel.Name.Should().Be(name);
        }

        [Then(@"Hotel with names '(.*)' should be present in the response")]
        public void ThenHotelWithNamesShouldBePresentInTheResponse(string names)
        {
            var hotelNames = names.Split(',');
            foreach(string name in hotelNames)
            {
                _hotel = _hotels.Find(htl => htl.Name.ToLower().Equals(name.ToLower()));
                _hotel.Should().NotBeNull(string.Format("Hotel with name {0} not found in response", name));
            }
        }
        


        private void SetHotelBasicDetails()
        {
            _hotel.ImageURLs = new List<string>() { "image1", "image2" };
            _hotel.LocationCode = "Location";
            _hotel.Rooms = new List<Room>() { new Room() { NoOfRoomsAvailable = 10, RoomType = "delux" } };
            _hotel.Address = "Address1";
            _hotel.Amenities = new List<string>() { "swimming pool", "gymnasium" };
        }
    }
}
