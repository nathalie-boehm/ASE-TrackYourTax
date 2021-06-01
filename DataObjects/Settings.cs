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
    }
}
