using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationClassLibrary;
using System.Collections.Generic;

namespace HotelReservationsTest
{
    [TestClass]
    public class HotelReservationTest
    {
        [TestMethod]
        public void RequestsOutsideOfPlanningPeriodDeclined()
        {
            List<Tuple<int, int>> listOfBookings = new List<Tuple<int, int>>();
            //1a
            listOfBookings.Add(new Tuple<int, int>(-4, 2));
            //1b
            listOfBookings.Add(new Tuple<int, int>(200, 400));

            List<string> expected = new List<string>();
            expected.Add("Decline");
            expected.Add("Decline");

            List<string> actual = new List<string>();

            //size = 1
            HotelReservation hotelReservation = new HotelReservation(1);

            foreach (var tuple in listOfBookings)
            {
                actual.Add(hotelReservation.ReserveRoom(tuple));
            }

            for (int i = 0; i < listOfBookings.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void RequestsAccepted()
        {
            List<Tuple<int, int>> listOfBookings = new List<Tuple<int, int>>();
            listOfBookings.Add(new Tuple<int, int>(0, 5));
            listOfBookings.Add(new Tuple<int, int>(7, 13));
            listOfBookings.Add(new Tuple<int, int>(3, 9));
            listOfBookings.Add(new Tuple<int, int>(5, 7));
            listOfBookings.Add(new Tuple<int, int>(6, 6));
            listOfBookings.Add(new Tuple<int, int>(0, 4));

            List<string> expected = new List<string>();
            expected.Add("Accept");
            expected.Add("Accept");
            expected.Add("Accept");
            expected.Add("Accept");
            expected.Add("Accept");
            expected.Add("Accept");

            List<string> actual = new List<string>();

            //size = 3
            HotelReservation hotelReservation = new HotelReservation(3);

            foreach (var tuple in listOfBookings)
            {
                actual.Add(hotelReservation.ReserveRoom(tuple));
            }

            for (int i = 0; i < listOfBookings.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void RequestsDeclined()
        {
            List<Tuple<int, int>> listOfBookings = new List<Tuple<int, int>>();
            listOfBookings.Add(new Tuple<int, int>(1, 3));
            listOfBookings.Add(new Tuple<int, int>(2, 5));
            listOfBookings.Add(new Tuple<int, int>(1, 9));
            listOfBookings.Add(new Tuple<int, int>(0, 15));

            List<string> expected = new List<string>();
            expected.Add("Accept");
            expected.Add("Accept");
            expected.Add("Accept");
            expected.Add("Decline");

            List<string> actual = new List<string>();

            //size = 3
            HotelReservation hotelReservation = new HotelReservation(3);

            foreach (var tuple in listOfBookings)
            {
                actual.Add(hotelReservation.ReserveRoom(tuple));
            }

            for (int i = 0; i < listOfBookings.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void RequestsAcceptedAfterDeclined()
        {
            List<Tuple<int, int>> listOfBookings = new List<Tuple<int, int>>();
            listOfBookings.Add(new Tuple<int, int>(1, 3));
            listOfBookings.Add(new Tuple<int, int>(0, 15));
            listOfBookings.Add(new Tuple<int, int>(1, 9));
            listOfBookings.Add(new Tuple<int, int>(2, 5));
            listOfBookings.Add(new Tuple<int, int>(4, 9));

            List<string> expected = new List<string>();
            expected.Add("Accept");
            expected.Add("Accept");
            expected.Add("Accept");
            expected.Add("Decline");
            expected.Add("Accept");

            List<string> actual = new List<string>();

            //size = 3
            HotelReservation hotelReservation = new HotelReservation(3);

            foreach (var tuple in listOfBookings)
            {
                actual.Add(hotelReservation.ReserveRoom(tuple));
            }

            for (int i = 0; i < listOfBookings.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void ComplexRequests()
        {
            //This test cant pass with provided expected results

            //Free room is room number: 1
            //Accepted
            //0       1       1       1       0       0       0       0       0       0       0
            //0       0       0       0       0       0       0       0       0       0       0
            //Free room is room number: 2
            //Accepted
            //0       1       1       1       0       0       0       0       0       0       0
            //1       1       1       1       1       0       0       0       0       0       0
            //Declined
            //0       1       1       1       0       0       0       0       0       0       0
            //1       1       1       1       1       0       0       0       0       0       0
            //Free room is room number: 1
            //Accepted
            //0       1       1       1       0       1       0       0       0       0       0
            //1       1       1       1       1       0       0       0       0       0       0
            //Declined
            //0       1       1       1       0       1       0       0       0       0       0
            //1       1       1       1       1       0       0       0       0       0       0
            //Free room is room number: 1
            //Accepted
            //0       1       1       1       0       1       0       0       0       0       1
            //1       1       1       1       1       0       0       0       0       0       0
            //Free room is room number: 1
            //Accepted
            //0       1       1       1       0       1       1       1       0       0       1
            //1       1       1       1       1       0       0       0       0       0       0
            //Free room is room number: 2
            //Accepted
            //0       1       1       1       0       1       1       1       0       0       1
            //1       1       1       1       1       0       0       0       1       1       1
            //Free room is room number: 1
            //Accepted
            //0       1       1       1       0       1       1       1       1       1       1
            //1       1       1       1       1       0       0       0       1       1       1

            List<Tuple<int, int>> listOfBookings = new List<Tuple<int, int>>();
            listOfBookings.Add(new Tuple<int, int>(1, 3));
            listOfBookings.Add(new Tuple<int, int>(0, 4));
            listOfBookings.Add(new Tuple<int, int>(2, 3));
            listOfBookings.Add(new Tuple<int, int>(5, 5));
            listOfBookings.Add(new Tuple<int, int>(4, 10));
            listOfBookings.Add(new Tuple<int, int>(10, 10));
            listOfBookings.Add(new Tuple<int, int>(6, 7));
            listOfBookings.Add(new Tuple<int, int>(8, 10));
            listOfBookings.Add(new Tuple<int, int>(8, 9));

            List<string> expected = new List<string>();
            expected.Add("Accept");
            expected.Add("Accept");
            expected.Add("Decline");
            expected.Add("Accept");
            expected.Add("Accept");
            expected.Add("Accept");
            expected.Add("Accept");
            expected.Add("Decline");
            expected.Add("Accept");

            List<string> actual = new List<string>();

            //size = 2
            HotelReservation hotelReservation = new HotelReservation(2);

            foreach (var tuple in listOfBookings)
            {
                actual.Add(hotelReservation.ReserveRoom(tuple));
            }

            for (int i = 0; i < listOfBookings.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
