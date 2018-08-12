using FluentAssertions;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class AddHotelSteps
    {
        private Hotel hotel = new Hotel();
        private int[] ids = new int[10];
        private int index = 0;
        //private Hotel addHotelResponse;
        private List<Hotel> hotels = new List<Hotel>();


        [Given(@"User provided valid Id '(.*)'  and '(.*)'for hotel")]
        public void GivenUserProvidedValidIdAndForHotel(int id, string name)
        {
            hotel.Id = id;
            hotel.Name = name;
            ids[index++] = id;
        }

        [Given(@"Use has added required details for hotel")]
        public void GivenUseHasAddedRequiredDetailsForHotel()
        {
            SetHotelBasicDetails();
        }
        [Given(@"User calls AddHotel api")]
        [When(@"User calls AddHotel api")]
        public void WhenUserCallsAddHotelApi()
        {
            hotels = HotelsApiCaller.AddHotel(hotel);
        }

        [Then(@"Hotel with Id '(.*)' should be present in the response")]
        public void ThenHotelWithNameShouldBePresentInTheResponse(int id)
        {
            hotel = hotels.Find(x => x.Id==id);
            hotel.Should().NotBeNull(string.Format("Hotel with name {0} not found in response",hotel.Name));
        }

        [Given(@"User added a new hotel with id (.*) and name (.*)")]
        public void GivenUserAddedANewHotelWithIdAndNameHotel(int id, string name)
        {
            hotel.Id = id;
            hotel.Name = name;
            ids[index++] = id;
        }

        [When(@"User calls GetHotelById (.*) api")]
        public void WhenUserCallsGetHotelByIdApi(int id)
        {
            //ScenarioContext.Current.Pending();
            hotel = HotelsApiCaller.Get_Hotel_By_Id(id);
        }

        [Then(@"Hotel with id (.*) should be present")]
        public void ThenHotelWithIdShouldBePresent(int id)
        {
            //ScenarioContext.Current.Pending();
            hotel.Id.Should().Be(id,"Hotel with this id not present");
        }

        [When(@"User calls Get All Hotels")]
        public void WhenUserCallsGetAllHotels()
        {
            //ScenarioContext.Current.Pending();
            hotels = HotelsApiCaller.GetAllHotels();
        }

        [Then(@"All Hotels should be present")]
        public void ThenAllHotelsShouldBePresent()
        {
            //ScenarioContext.Current.Pending();
            for(int i = 0; i < index; i++)
            {
                hotel = hotels.Find(x => x.Id == ids[i]);
                hotel.Should().NotBeNull(string.Format("Hotel with name {0} not found in response", hotel.Name));
            }
        }

        private void SetHotelBasicDetails()
        {
            hotel.ImageURLs = new List<string>() { "image1", "image2" };
            hotel.LocationCode = "Location";
            hotel.Rooms = new List<Room>() { new Room() { NoOfRoomsAvailable = 10, RoomType = "delux" } };
            hotel.Address = "Address1";
            hotel.Amenities = new List<string>() { "swimming pool", "gymnasium" };
        }
    }
}
