using System;
using System.Collections.Generic;
using System.Text;
using TrackYourTax.Enums;

namespace TrackYourTax.DataObjects
{
    public class Route
    {
        public Location Start { get; set; }
        public Location Destination { get; set; }
        public int Distance { get; set; }
        //public int YearCount { get; set; }
        public override bool Equals(object? obj)
        {
            var route = obj as Route;

            return Equals(route?.Destination,this.Destination) && Equals(route?.Start, this.Start);
        }

        protected bool Equals(Route other)
        {
            return Equals(Start, other.Start) && Equals(Destination, other.Destination);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Start, Destination);
        }

        public override string ToString()
        {
            return $"{Start} -> {Destination}";
        }
    }
}