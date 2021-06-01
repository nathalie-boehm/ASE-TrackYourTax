using System.Collections.Generic;
using TrackYourTax.DataObjects;
using TrackYourTax.Enums;

namespace TrackYourTax.BusinessLogicDomain
{
    public class CommercialCostCalculator : CostCalculatorBase
    {
        private static readonly Dictionary<LocationCategory, decimal> RideFactor = new Dictionary<LocationCategory, decimal>
        {
            { LocationCategory.ErsteTaetigkeitsstaette, 1m },
            { LocationCategory.Krankheit, 0m },
            { LocationCategory.Wohnort, 0m },
            { LocationCategory.ZweiteTaetigkeitsstaette, 2m },
        };
        private static readonly Dictionary<ExpensesCategory, decimal> ExpenseFactor = new Dictionary<ExpensesCategory, decimal>
        {
            { ExpensesCategory.ArbeitsmittelArbeitsplatz, 0.5m },
            { ExpensesCategory.ArbeitsmittelSonsitige, 1m },
            { ExpensesCategory.Krankheitskosten, 0m },
            { ExpensesCategory.WerbungskostenSonstige, 1m },
        };

        public CommercialCostCalculator(IRepository repository) : base(repository)
        {
        }

        protected override decimal GetRideFactor(LocationCategory category) => RideFactor[category];
        protected override decimal GetExpensesFactor(ExpensesCategory category) => ExpenseFactor[category];

    }
}