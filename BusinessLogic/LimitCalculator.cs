
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TrackYourTax.DataObjects;
using TrackYourTax.Enums;

namespace TrackYourTax.BusinessLogic
{
    public class LimitCalculator
    {
        private readonly IRepository _repository;

        public LimitCalculator(IRepository repository)
        {
            _repository = repository;
        }
         
        private List<Tuple<int, IncomeCategory>> _incomeSteps = new List<Tuple<int, IncomeCategory>>()
        {
            new Tuple<int, IncomeCategory>(51130,IncomeCategory.Hoch),
            new Tuple<int, IncomeCategory>(15340,IncomeCategory.Mittel),
            new Tuple<int, IncomeCategory>(0,IncomeCategory.Niedrig),
    };
        private Dictionary<IncomeCategory, decimal> _percentageCalculate= new Dictionary<IncomeCategory, decimal>(){{IncomeCategory.Niedrig, 0.05M}, {IncomeCategory.Mittel, 0.06M},
            {IncomeCategory.Hoch, 0.07M}};

        private IncomeCategory GetIncomeCategory(Settings setting)
        {
            var income = setting.Income;
            return _incomeSteps.FirstOrDefault(step => step.Item1 <= income).Item2;
        }

        public int GetExtraordinaryExpenseLimit()
        {
            var setting = _repository.Settings.OrderByDescending(setting => setting.Year).First();
            var category = GetIncomeCategory(setting);
            var percentage = _percentageCalculate[category];

            return (int)(setting.Income  * percentage);
        }
    }
}