using System.Collections.Generic;

namespace TrackYourTax.DataObjects
{
    public interface IRepository
    {
        List<Expenses> Expenses { get; }
        List<Location> Locations { get; } 
        List<Ride> Rides { get; }
        List<Route> Routes { get;  } 
        List<Settings> Settings { get; } 
    }
}