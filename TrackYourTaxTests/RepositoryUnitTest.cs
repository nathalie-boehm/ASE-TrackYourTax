using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TrackYourTax.DataObjects;

namespace TrackYourTaxTests
{
    [TestFixture]
    class RepositoryUnitTest
    {
        [Test]
        public void GetCurrentOfDescendingSettingsTest()
        {
            var testee = new Repository();
            testee.Settings = new List<Settings> { new Settings { Income = 10000, Year = 2020 }, new Settings { Income =9000, Year = 2019 },  new Settings { Income = 8000, Year = 2018 }};
            var result = testee.GetCurrentSetting();
            Assert.AreEqual(result.Year, 2020);
        }

        [Test]
        public void GetCurrentOfAscendingSettingsTest()
        {
            var testee = new Repository();
            testee.Settings = new List<Settings> { new Settings { Income = 8000, Year = 2018 }, new Settings { Income = 9000, Year = 2019 }, new Settings { Income = 10000, Year = 2020 } };
            var result = testee.GetCurrentSetting();
            Assert.AreEqual(result.Year, 2020);
        }
    }
}
