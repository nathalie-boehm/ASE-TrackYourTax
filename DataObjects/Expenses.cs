using System;
using System.Collections.Generic;
using System.Text;
using TrackYourTax.Enums;

namespace TrackYourTax.DataObjects
{
    public class Expenses
    {
        public ExpensesCategory Category { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
