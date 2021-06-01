using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackYourTax.DataObjects;
using TrackYourTax.Enums;

namespace TrackYourTax
{
    public class DataExamples
    {
        public void FillRepository()
        {
            Repository.Access.Locations.AddRange(new List<Location>(){new Location(){Name="zu Hause", LocationCategory = LocationCategory.Wohnort},
                new Location(){Name="WG", LocationCategory = LocationCategory.Wohnort},
                new Location(){Name="DHBW", LocationCategory = LocationCategory.ZweiteTaetigkeitsstaette},
                new Location(){Name="Arbeit", LocationCategory = LocationCategory.ErsteTaetigkeitsstaette},
                new Location(){Name="Bib", LocationCategory = LocationCategory.ZweiteTaetigkeitsstaette},
                new Location(){Name="Arzt XY", LocationCategory = LocationCategory.Krankheit},
                new Location(){Name="Apotheke XY", LocationCategory = LocationCategory.Krankheit},
            });

            Repository.Access.Settings.Add(new Settings(){Year=2020, KilometerPrice = 30, Income = 12000, CateringAdditionalExpenses = 14, CommercialFlatCharge = 1000});
            Repository.Access.Settings.Add(new Settings(){Year=2019, KilometerPrice = 30, Income = 11000, CateringAdditionalExpenses = 14, CommercialFlatCharge = 1000});

            UpdateRoutes();
        }

        private void UpdateRoutes()
        {
            Repository.Access.Routes.AddRange(
                Repository.Access.Locations.Where(home => home.LocationCategory == LocationCategory.Wohnort).SelectMany(home =>
                    Repository.Access.Locations.Where(location => location.LocationCategory != LocationCategory.Wohnort)
                        .Select(location => new Route {Destination = location, Start = home, Distance = 0}))
                    .Where(newRoute => ! Repository.Access.Routes.Any(route => route.Equals(newRoute))));
        }
    }
}
