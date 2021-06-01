using System;
using System.Collections.Generic;
using System.Text;

namespace TrackYourTax.DataObjects
{
    public class Ride:IComparable<Ride>
    {
        public Route Route { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int AttendanceCounter { get; set; }
        public int AbsenceCounter { get; set; }


        public int CompareTo(Ride other)
        {
            return other.Start.CompareTo(this.Start);
        }
    }
}
