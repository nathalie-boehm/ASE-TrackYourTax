using System;
using System.IO;
using System.Linq;
using System.Text;
using TrackYourTax.DataObjects;
using TrackYourTax.Enums;

namespace TrackYourTax.BusinessLogicDomain
{
    public class ElsterInputBuilder
    {
        private readonly Repository _repository;
        private StringBuilder _content;
        private string _delimiter = ";";
        private readonly ICostCalculator _commercialCostCalculator;
        private ICostCalculator _exceptionalCostCalculator;

        public ElsterInputBuilder()
        {
            _repository = Repository.Access;
            _content = new StringBuilder();
            _commercialCostCalculator = new CommercialCostCalculator(_repository);
            _exceptionalCostCalculator = new ExceptionalCostCalculator(_repository);
        }

        public void ConstructExpenses()
        {
            var orderedExpenses = _repository.Expenses.OrderBy(expenses => expenses.Category).ToList();
            orderedExpenses.ForEach(expense => AddToContent(expense));
        }

        public void ConstructRides(LocationCategory category, ICostCalculator calculator, Action<Ride, int> contentAdder)
        {
            foreach (var ride in _repository.Rides.Where(ride => ride.Route.Destination.LocationCategory == category))
            {
                var cost = calculator.ElstarCosts(ride);
                if (cost > 0)
                    contentAdder(ride, cost);
            }
        }


        public void ConstructRidesFirstEmployment() =>
            ConstructRides(LocationCategory.ErsteTaetigkeitsstaette, _commercialCostCalculator, (ride, cost)
                => _content.AppendLine($"Erste-Arbeitsstaette Zeiraum{_delimiter} von {ride.Start}{_delimiter} bis {ride.End}{_delimiter} davon abwesend {ride.AbsenceCounter} Tage {_delimiter} Betrag {cost}\n"));

        public void ConstructRidesSecondEmployment() =>
            ConstructRides(LocationCategory.ZweiteTaetigkeitsstaette, _commercialCostCalculator,
                (ride, cost) => _content.AppendLine($"2.Arbeitsstaette Zeiraum{_delimiter} von {ride.Start}{_delimiter} bis {ride.End}{_delimiter} davon abwesend {ride.AbsenceCounter} Tage {_delimiter} Betrag {cost}\n"));

        public void ConstructCateringAdditionalExpenses()
            => ConstructRides(LocationCategory.ZweiteTaetigkeitsstaette, _commercialCostCalculator, (ride, cost)
                => _content.AppendLine($"2.Arbeitsstaette Zeiraum{_delimiter} Datum {ride.Start}{_delimiter} Verpflegung {_commercialCostCalculator.AdditionalCateringExpenses(ride)}\n"));

        public void ConstructHealthcareExpenses() => ConstructRides(LocationCategory.Krankheit, _exceptionalCostCalculator, (ride, cost)
            => _content.AppendLine($"Arzt-Besuch Fahrkosten Zeiraum{_delimiter} Datum {ride.Start}{_delimiter} Betrag {cost}\n"));


        public void Build()=>File.WriteAllText($"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}Elster.CSV", _content.ToString());

        private void AddToContent(Ride ride, ICostCalculator calculator)
        {
            _content.AppendLine($"Zeiraum{_delimiter} von {ride.Start}{_delimiter} bis {ride.End}{_delimiter} davon abwesend {ride.AbsenceCounter} Tage {_delimiter} Betrag {calculator.ElstarCosts(ride)}\n");
        }

        private void AddToContent(Expenses expense)
        {
            AddLineToContent(expense.Comment, _exceptionalCostCalculator.CalculateCost(expense));
        }

        private void AddLineToContent(string comment, int amount)
        {
            _content.AppendLine($"{comment}{_delimiter} {amount}");
        }


    }
}