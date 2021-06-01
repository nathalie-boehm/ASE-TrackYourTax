using System;
using System.Collections.Generic;
using System.Linq;
using TrackYourTax.Enums;

namespace TrackYourTax.ViewModels
{
    public class ExpensesCategoryList : List<ExpensesCategory>
    {
        public ExpensesCategoryList()
        {
            AddRange(Enum.GetValues(typeof(ExpensesCategory)).Cast<ExpensesCategory>());
        }
    }
}