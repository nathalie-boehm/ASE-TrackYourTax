using System;
using System.Collections.Generic;
using System.Text;
using TrackYourTax.DataObjects;

namespace TrackYourTax.ViewModels
{
    public class RouteList: List<Route>
    {
        public RouteList()
        {
            AddRange(Repository.Access.Routes);
        }
    }
}
