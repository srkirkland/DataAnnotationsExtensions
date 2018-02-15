using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnnotationsExtensions.Tests
{
    [TestClass]
    public class TestBase
    {
        [TestCleanup]
        public void TestCleanup()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("");
        }
    }
}
