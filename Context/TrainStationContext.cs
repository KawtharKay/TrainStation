using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Model;

namespace TrainStation.Context
{
    public class TrainStationContext
    {
        public static List<Bookings> bookingsDb = new List<Bookings>();
        public static List<Customers> customersDb = new List<Customers>();
        public static List<Stations> stationsDb = new List<Stations>()
        {
            new Stations(1,"MKO","Lagos"),
            new Stations(2,"Fashola","Lagos"),
            new Stations(3,"Soyinka","Abeokuta"),
        };
        public static List<Trains> trainsDb = new List<Trains>();
        public static List<Trip> tripDb = new List<Trip>()
        {
            new Trip(1,1,2,DateTime.Parse("11/30/2025 10:00"),2000)
        };

        public static List<User> userDb = new List<User>()
        {
            new User(1, "kay@gmail.com", "1111", "app_CEO")
        };
    }
}