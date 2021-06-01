using System;
using System.Collections.Generic;
using System.Text;
using TrackYourTax.Enums;

namespace TrackYourTax.DataObjects
{
    public class Location
    {
        public string Name { get; set; }
        public LocationCategory LocationCategory { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            var location = obj as Location;

            return Equals(location?.Name, this.Name);
        }

        protected bool Equals(Location other)
        {
            return Equals(this.Name, other.Name);
        }

        public override int GetHashCode()
        {
            return Name?.GetHashCode()??0;
        }

    }
}
