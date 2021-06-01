using System;
using System.Collections.Generic;
using System.Text;

namespace TrackYourTax.DataObjects
{
    public class Settings
    {
        public int Income { get; set; }
        public int Year { get; set;  }
        public int KilometerPrice { get; set; }
        public int CateringAdditionalExpenses { get; set; }
        public int CommercialFlatCharge { get; set; }

        public override bool Equals(object? obj)
        {
            var setting = obj as Settings;

            return Equals(setting?.Year, this.Year);
        }

        protected bool Equals(Settings other)
        {
            return Equals(this.Year, other.Year);
        }

        public override int GetHashCode()
        {
            return Year != null ? Year : 0;
        }
    }
}
