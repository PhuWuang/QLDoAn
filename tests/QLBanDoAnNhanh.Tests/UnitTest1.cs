using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLBanDoAnNhanh.DAL.Models;

namespace QLBanDoAnNhanh.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void CalculateTotal_BasicCase()
        {
            var total = PriceHelper.CalculateTotal(35000m, 2, 5000m);
            Assert.AreEqual(65000m, total);
        }
    }
}
