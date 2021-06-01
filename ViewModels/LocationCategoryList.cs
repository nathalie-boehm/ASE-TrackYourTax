using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackYourTax.Enums;

namespace TrackYourTax.ViewModels
{
    public class LocationCategoryList: List<LocationCategory>
    {
        public LocationCategoryList()
        {
            AddRange(Enum.GetValues(typeof(LocationCategory)).Cast<LocationCategory>());
        }
    }
}
