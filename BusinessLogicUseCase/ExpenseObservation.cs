using System;
using System.Collections.Generic;
using System.Text;
using TrackYourTax.BusinessLogicDomain;
using TrackYourTax.DataObjects;

namespace TrackYourTax.BusinessLogicUseCase
{
    class ExpenseObservation
    {
        public int GetCommercialCostProgress()=> 100*GetTotalCommercialCosts()/ Repository.Access.GetCurrentSetting().CommercialFlatCharge;

        public int GetTotalCommercialCosts()
        {
            var calculator = new CommercialCostCalculator(Repository.Access);
            var director = new CostDirector(Repository.Access, calculator);
            return director.GetTotalCosts();
        }

        public int GetExceptionalCostProgress() => 100 * GetTotalExceptionalCosts() / new LimitCalculator(Repository.Access).GetExtraordinaryExpenseLimit();

        public int GetTotalExceptionalCosts()
        {
            var calculator = new ExceptionalCostCalculator(Repository.Access);
            var director = new CostDirector(Repository.Access, calculator);
            return director.GetTotalCosts();
        }
    }
}
