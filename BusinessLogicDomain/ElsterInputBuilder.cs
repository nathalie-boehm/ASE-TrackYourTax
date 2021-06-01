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
        private string _delimiter=";";

        public ElsterInputBuilder()
        {
            _repository= Repository.Access;
            _content=new StringBuilder();
        }

        public void ConstructExpenses()
        {
            var orderedExpenses = _repository.Expenses.OrderBy(expenses => expenses.Category).ToList();
            orderedExpenses.ForEach(expense => AddToContent(expense));
        }
        public void ConstructRidesFirstEmployment()
        {
            var rides = _repository.Rides.FindAll(ride =>
                ride.Route.Destination.LocationCategory == LocationCategory.ErsteTaetigkeitsstaette);
            rides.ForEach(ride => AddToContent(ride));
        }

        public void ConstructRidesSecondEmployment()
        {
        }

        public void ConstructCateringAdditionalExpenses()
        {
        }

        public void ConstructHealthcareExpenses()
        {
        }

        public void Build()
        {
        }

        private void AddToContent(Ride ride)
        {
            _content.AppendLine($"Zeiraum{_delimiter} von {ride.Start}{_delimiter} bis {ride.End}{_delimiter} davon abwesend {ride.AbsenceCounter} Tage");
        }

        private void AddToContent(Expenses expense)
        {
            if (expense.Category == ExpensesCategory.ArbeitsmittelArbeitsplatz)
            {
                var amount = (int)(expense.Amount * 0.5);
                AddLineToContent(expense.Comment, amount);
                return;
            }
            AddLineToContent(expense.Comment, expense.Amount);
        }

        private void AddLineToContent(string comment, int amount)
        {
            _content.AppendLine($"{comment}{_delimiter} {amount}");
        }

       
    }
}
