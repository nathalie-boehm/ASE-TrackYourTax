using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using NUnit.Framework;
using TrackYourTax.BusinessLogicDomain;
using TrackYourTax.DataObjects;
using TrackYourTax.Enums;

namespace TrackYourTaxTests
{
    [TestFixture]
    public class AdvertisingCostCalculatorTests
    {
    }

    [TestFixture]
    public class ExceptionalCostCalculatorTests
    {
    }

    [TestFixture]
    public class CostDirectorTests
    {
        private IRepository _repository;

        [SetUp]
        public void Setup()
        {
            _repository = Substitute.For<IRepository>();
            _repository.Settings.Returns(new List<Settings> { new Settings { KilometerPrice = 30 } });
            _repository.Rides.Returns(new List<Ride>
            {
                new Ride { AttendanceCounter = 100, Route =
                    new Route { Destination = new Location { LocationCategory = LocationCategory.ErsteTaetigkeitsstaette}, Distance = 10}},
                new Ride { AttendanceCounter = 100, Route =
                    new Route { Destination = new Location { LocationCategory = LocationCategory.Krankheit}, Distance = 10}}
            });
            _repository.Expenses.Returns(new List<Expenses>());

        }

        [Test]
        public void AdvertisingCosts_GetTotalSumTest()
        {
            var testee = new CostDirector(_repository, new CommercialCostCalculator(_repository));

            Assert.AreEqual(300, testee.GetTotalCosts());
        }

        [Test]
        public void ExceptionalCosts_GetTotalSumTest()
        {
            var testee = new CostDirector(_repository, new ExceptionalCostCalculator(_repository));

            Assert.AreEqual(600, testee.GetTotalCosts());
        }

    }

}