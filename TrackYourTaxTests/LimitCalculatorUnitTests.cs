using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using TrackYourTax.BusinessLogicDomain;
using TrackYourTax.DataObjects;

namespace TrackYourTaxTests
{
    [TestFixture]
    public class LimitCalculatorTest
    {
        [Test]
        public void GetLimitWithLowIncomeTest()
        {
            var repository = Substitute.For<IRepository>();
            repository.Settings.Returns(new List<Settings> {new Settings {Income = 10000, Year = 2020}});

            var testee = new LimitCalculator(repository);
            var limit = testee.GetExtraordinaryExpenseLimit();
            Assert.AreEqual(limit, 500);
        }

        [Test]
        public void GetLimitWithMaxLowIncomeTest()
        {
            var repository = Substitute.For<IRepository>();
            repository.Settings.Returns(new List<Settings> { new Settings { Income = 15339, Year = 2020 } });

            var testee = new LimitCalculator(repository);
            var limit = testee.GetExtraordinaryExpenseLimit();
            Assert.AreEqual(limit, 766);
        }

        [Test]
        public void GetLimitWithMinMiddleIncomeTest()
        {
            var repository = Substitute.For<IRepository>();
            repository.Settings.Returns(new List<Settings> { new Settings { Income = 15340, Year = 2020 } });

            var testee = new LimitCalculator(repository);
            var limit = testee.GetExtraordinaryExpenseLimit();
            Assert.AreEqual(limit, 920);
        }

        [Test]
        public void GetLimitWithMiddleIncomeTest()
        {
            var repository = Substitute.For<IRepository>();
            repository.Settings.Returns(new List<Settings> { new Settings { Income = 35000, Year = 2020 } });

            var testee = new LimitCalculator(repository);
            var limit = testee.GetExtraordinaryExpenseLimit();
            Assert.AreEqual(limit, 2100);
        }

        [Test]
        public void GetLimitWithMaxMiddleIncomeTest()
        {
            var repository = Substitute.For<IRepository>();
            repository.Settings.Returns(new List<Settings> { new Settings { Income = 51129, Year = 2020 } });

            var testee = new LimitCalculator(repository);
            var limit = testee.GetExtraordinaryExpenseLimit();
            Assert.AreEqual(limit, 3067);
        }

        [Test]
        public void GetLimitWithMinHighIncomeTest()
        {
            var repository = Substitute.For<IRepository>();
            repository.Settings.Returns(new List<Settings> { new Settings { Income = 51130, Year = 2020 } });

            var testee = new LimitCalculator(repository);
            var limit = testee.GetExtraordinaryExpenseLimit();
            Assert.AreEqual(limit, 3579);
        }

        [Test]
        public void GetLimitWithHighIncomeTest()
        {
            var repository = Substitute.For<IRepository>();
            repository.Settings.Returns(new List<Settings> { new Settings { Income = 100000, Year = 2020 } });

            var testee = new LimitCalculator(repository);
            var limit = testee.GetExtraordinaryExpenseLimit();
            Assert.AreEqual(limit, 7000);
        }

        [Test]
        public void GetLimitOutOfTwoDescendingSettingsTest()
        {
            var repository = Substitute.For<IRepository>();
            repository.Settings.Returns(new List<Settings> { new Settings { Income = 10000, Year = 2020 }, new Settings { Income =9000, Year = 2019 },  new Settings { Income = 8000, Year = 2018 } });

            var testee = new LimitCalculator(repository);
            var limit = testee.GetExtraordinaryExpenseLimit();
            Assert.AreEqual(limit, 500);
        }

        [Test]
        public void GetLimitOutOfTwoAscendingSettingsTest()
        {
            var repository = Substitute.For<IRepository>();
            repository.Settings.Returns(new List<Settings> { new Settings { Income = 8000, Year = 2018 }, new Settings { Income = 9000, Year = 2019 }, new Settings { Income = 10000, Year = 2020 }});

            var testee = new LimitCalculator(repository);
            var limit = testee.GetExtraordinaryExpenseLimit();
            Assert.AreEqual(limit, 500);
        }
         
    }
}

