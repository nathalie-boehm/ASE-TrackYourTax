using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackYourTax.Enums;

namespace TrackYourTax.DataObjects
{
    public class Repository: IRepository
    {
        public static readonly Repository Access = new Repository();
        public List<Expenses> Expenses { get; set; } = new List<Expenses>();
        public List<Location> Locations { get; set; } = new List<Location>();
        public List<Ride> Rides { get; set; } = new List<Ride>();
        public List<Route> Routes { get; set; } = new List<Route>();
        public List<Settings> Settings { get; set; } = new List<Settings>();

        public void UpdateRoutes()
        {
            Access.Routes.AddRange(
                Access.Locations.Where(home => home.LocationCategory == LocationCategory.Wohnort).SelectMany(home =>
                        Access.Locations.Where(location => location.LocationCategory != LocationCategory.Wohnort)
                            .Select(location => new Route { Destination = location, Start = home, Distance = 0 }))
                    .Where(newRoute => !Access.Routes.Any(route => route.Equals(newRoute))));
        }

        public Settings GetCurrentSetting() => Settings.OrderByDescending(setting => setting.Year).First();
    }
}
