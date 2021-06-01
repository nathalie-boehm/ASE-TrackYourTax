using System;
using System.Collections.Generic;
using System.Text;

namespace TrackYourTax.DataObjects
{
    public class Repository
    {
        public static readonly Repository Access = new Repository();
        public List<Expenses> Expenses { get; set; } = new List<Expenses>();
        public List<Location> Locations { get; set; } = new List<Location>();
        public List<Ride> Rides { get; set; } = new List<Ride>();
        public List<Route> Routes { get; set; } = new List<Route>();
        public List<Settings> Settings { get; set; } = new List<Settings>();
        
    }
}
