using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Threading.Tasks;
using Bank.ViewModel.Helpers;

namespace Bank.Tests
{
    [TestClass]
    public class ConvertersUnitTest
    {
        [TestMethod]
        public void StringToDateTest()
        {
            var date = Converters.StringToDate("2015-04-20");
            Assert.IsTrue(date.Day == 20);
            Assert.IsTrue(date.Month == 4);
            Assert.IsTrue(date.Year == 2015);
        }

        [TestMethod]
        public void GetStatusTest()
        {
            Assert.IsTrue(Converters.GetStatus("open") == ViewModel.BillStatus.Open);
            Assert.IsTrue(Converters.GetStatus("closed") == ViewModel.BillStatus.Closed);
            Assert.IsTrue(Converters.GetStatus("future") == ViewModel.BillStatus.Future);
            Assert.IsTrue(Converters.GetStatus("overdue") == ViewModel.BillStatus.Overdue);
        }

        [TestMethod]
        public void AmountConverterTest()
        {
            Assert.IsTrue(Converters.AmountConverter(1250) == "12.50");
        }
         
    }
}
