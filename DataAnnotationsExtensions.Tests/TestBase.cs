using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnnotationsExtensions.Tests
{
    [TestClass]
    public class TestBase
    {
        [TestInitialize]
        public void TestInitialize()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("");
        }
    }
}
