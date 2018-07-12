using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuisBot
{
    public class FairTrainEnquiry
    {
        public class Rootobject
        {
            public int debit { get; set; }
            public int response_code { get; set; }
            public Train[] trains { get; set; }
            public int total { get; set; }
        }

        public class Train
        {
            public string name { get; set; }
            public string dest_arrival_time { get; set; }
            public string number { get; set; }
            public To_Station to_station { get; set; }
            public string src_departure_time { get; set; }
            public From_Station from_station { get; set; }
            public Day[] days { get; set; }
            public Class1[] classes { get; set; }
            public string travel_time { get; set; }
        }

        public class To_Station
        {
            public float lat { get; set; }
            public float lng { get; set; }
            public string name { get; set; }
            public string code { get; set; }
        }

        public class From_Station
        {
            public float lat { get; set; }
            public float lng { get; set; }
            public string name { get; set; }
            public string code { get; set; }
        }

        public class Day
        {
            public string runs { get; set; }
            public string code { get; set; }
        }

        public class Class1
        {
            public string name { get; set; }
            public string code { get; set; }
        }

    }

    public class Rootobject1
    {
        public Station[] stations { get; set; }
        public int debit { get; set; }
        public int response_code { get; set; }
    }

    public class Station
    {
        public string code { get; set; }
        public float lat { get; set; }
        public string name { get; set; }
        public float lng { get; set; }
    }

    public class Rootobject2
    {
        public int response_code { get; set; }
        public int debit { get; set; }
        public string pnr { get; set; }
        public string doj { get; set; }
        public int total_passengers { get; set; }
        public bool chart_prepared { get; set; }
        public From_Station from_station { get; set; }
        public To_Station to_station { get; set; }
        public Boarding_Point boarding_point { get; set; }
        public Reservation_Upto reservation_upto { get; set; }
        public Train train { get; set; }
        public Journey_Class journey_class { get; set; }
        public Passenger[] passengers { get; set; }
    }

    public class From_Station
    {
        public string name { get; set; }
        public string code { get; set; }
    }

    public class To_Station
    {
        public string name { get; set; }
        public string code { get; set; }
    }

    public class Boarding_Point
    {
        public string name { get; set; }
        public string code { get; set; }
    }

    public class Reservation_Upto
    {
        public string name { get; set; }
        public string code { get; set; }
    }

    public class Train
    {
        public string name { get; set; }
        public string number { get; set; }
    }

    public class Journey_Class
    {
        public string name { get; set; }
        public string code { get; set; }
    }

    public class Passenger
    {
        public int no { get; set; }
        public string current_status { get; set; }
        public string booking_status { get; set; }
    }


}