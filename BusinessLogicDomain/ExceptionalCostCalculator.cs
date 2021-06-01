using System.Collections.Generic;
using TrackYourTax.DataObjects;
using TrackYourTax.Enums;

namespace TrackYourTax.BusinessLogicDomain
{
    public class ExceptionalCostCalculator : CostCalculatorBase
    {
        private static readonly Dictionary<LocationCategory, decimal> RideFactor = new Dictionary<LocationCategory, decimal>
        {
            { LocationCategory.ErsteTaetigkeitsstaette, 0m },
            { LocationCategory.Krankheit, 2m },
            { LocationCategory.Wohnort, 0m },
            { LocationCategory.ZweiteTaetigkeitsstaette, 0m },
        };
        private static readonly Dictionary<ExpensesCategory, decimal> ExpenseFactor = new Dictionary<ExpensesCategory, decimal>
        {
            { ExpensesCategory.ArbeitsmittelArbeitsplatz, 0m },
            { ExpensesCategory.ArbeitsmittelSonsitige, 0m },
            { ExpensesCategory.Krankheitskosten, 1m },
            { ExpensesCategory.WerbungskostenSonstige, 0m },
        };

        public ExceptionalCostCalculator(IRepository repository) : base(repository)
        {
        }
        protected override decimal GetRideFactor(LocationCategory category) => RideFactor[category];
        protected override decimal GetExpensesFactor(ExpensesCategory category) => ExpenseFactor[category];

    }
}