using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
	[TestClass]
	public class RegularExpressionAttributeTests
	{
		[TestMethod]
		public void IsCuitValidTests()
		{
		    var attribute = new RegularExpressionAttribute(Expressions.Cuit);

			Assert.IsTrue(attribute.IsValid(null));
			Assert.IsTrue(attribute.IsValid("20245597151"));
			Assert.IsTrue(attribute.IsValid("20-24559715-1"));
			Assert.IsTrue(attribute.IsValid("27-23840320-6"));
			Assert.IsTrue(attribute.IsValid("27238403206"));
			Assert.IsTrue(attribute.IsValid(27238403206));
			
			Assert.IsFalse(attribute.IsValid("20 24559715 1"));
            Assert.IsFalse(attribute.IsValid("123456789"));
            Assert.IsFalse(attribute.IsValid("aa-aaaaaaaa-a"));
			Assert.IsFalse(attribute.IsValid("4408 0412 3456 7890"));
			Assert.IsFalse(attribute.IsValid(0));
            Assert.IsFalse(attribute.IsValid(123));
		}

        [TestMethod]
        public void IsPhoneNumberValidTests()
        {
            var attribute = new RegularExpressionAttribute(Expressions.PhoneNumber);

            Assert.IsTrue(attribute.IsValid(null));
            Assert.IsTrue(attribute.IsValid(string.Empty));
            Assert.IsTrue(attribute.IsValid("1234567"));
            Assert.IsTrue(attribute.IsValid("20 24559715 1"));
            Assert.IsTrue(attribute.IsValid("123456789"));
            Assert.IsTrue(attribute.IsValid("+1(234)4567789"));
            Assert.IsTrue(attribute.IsValid("+235 7789"));
            Assert.IsTrue(attribute.IsValid("00 27 238.40320"));
            Assert.IsTrue(attribute.IsValid("0011 87 9854 23"));
            Assert.IsTrue(attribute.IsValid("011 777899 854-2356"));
            Assert.IsTrue(attribute.IsValid("0011 (87) 9854 23"));
            Assert.IsTrue(attribute.IsValid("011 (777899) 854-2356"));
            Assert.IsTrue(attribute.IsValid("07778542356"));
            Assert.IsTrue(attribute.IsValid("1.234.567-0000"));
            Assert.IsTrue(attribute.IsValid("1/23/56/000"));
            Assert.IsTrue(attribute.IsValid("1/2/5/0"));
            Assert.IsTrue(attribute.IsValid("4408 0412 3456 7890"));
            Assert.IsTrue(attribute.IsValid("00"));
            Assert.IsTrue(attribute.IsValid(12));
            Assert.IsTrue(attribute.IsValid(123));
            Assert.IsTrue(attribute.IsValid(1234567890));

            Assert.IsFalse(attribute.IsValid("1/2/"));
            Assert.IsFalse(attribute.IsValid("1/23/56/000-"));
            Assert.IsFalse(attribute.IsValid("-1/23/56/000"));
            Assert.IsFalse(attribute.IsValid("a"));
            Assert.IsFalse(attribute.IsValid("0"));
            Assert.IsFalse(attribute.IsValid("+0"));
            Assert.IsFalse(attribute.IsValid("+00 27 238.40320"));
            Assert.IsFalse(attribute.IsValid("+0011 (87) 9854 23"));
            Assert.IsFalse(attribute.IsValid("+011 (777899) 854-2356"));
            Assert.IsFalse(attribute.IsValid("+07778542356"));
            Assert.IsFalse(attribute.IsValid(0));
        }

        [TestMethod]
        public void IsCurrencyCodeValidTests()
        {
            var attribute = new RegularExpressionAttribute(Expressions.CurrencyCode);

            Assert.IsTrue(attribute.IsValid(null));
            Assert.IsTrue(attribute.IsValid(string.Empty));
            Assert.IsTrue(attribute.IsValid("ABC"));
            Assert.IsTrue(attribute.IsValid("XYZ"));
            Assert.IsTrue(attribute.IsValid("123"));
            Assert.IsTrue(attribute.IsValid("789"));

            Assert.IsFalse(attribute.IsValid("AB"));
            Assert.IsFalse(attribute.IsValid("WXYZ"));
            Assert.IsFalse(attribute.IsValid("12"));
            Assert.IsFalse(attribute.IsValid("6789"));
        }

        [TestMethod]
        public void IsCountryCodeValidTests()
        {
            var attribute = new RegularExpressionAttribute(Expressions.CountryCode);

            Assert.IsTrue(attribute.IsValid(null));
            Assert.IsTrue(attribute.IsValid(string.Empty));
            Assert.IsTrue(attribute.IsValid("AB"));
            Assert.IsTrue(attribute.IsValid("XYZ"));
            Assert.IsTrue(attribute.IsValid("123"));
            Assert.IsTrue(attribute.IsValid("789"));

            Assert.IsFalse(attribute.IsValid("A"));
            Assert.IsFalse(attribute.IsValid("WXYZ"));
            Assert.IsFalse(attribute.IsValid("12"));
            Assert.IsFalse(attribute.IsValid("6789"));
        }

        [TestMethod]
        public void IsCultureCodeValidTests()
        {
            var attribute = new RegularExpressionAttribute(Expressions.CultureCode);

            Assert.IsTrue(attribute.IsValid(null));
            Assert.IsTrue(attribute.IsValid(string.Empty));
            Assert.IsTrue(attribute.IsValid("ab"));
            Assert.IsTrue(attribute.IsValid("XYZ"));
            Assert.IsTrue(attribute.IsValid("ab-WxYz"));
            Assert.IsTrue(attribute.IsValid("abc-wXyZ"));
            Assert.IsTrue(attribute.IsValid("ab-cd"));
            Assert.IsTrue(attribute.IsValid("UVW-XYZ"));
            Assert.IsTrue(attribute.IsValid("ab-123"));
            Assert.IsTrue(attribute.IsValid("XYZ-789"));
            Assert.IsTrue(attribute.IsValid("ab-CD-Efgh"));
            Assert.IsTrue(attribute.IsValid("UVW-XYZ-abcd"));
            Assert.IsTrue(attribute.IsValid("ab-123-cdef"));
            Assert.IsTrue(attribute.IsValid("XYZ-789-abcd"));

            Assert.IsFalse(attribute.IsValid("12"));
            Assert.IsFalse(attribute.IsValid("789"));
            Assert.IsFalse(attribute.IsValid("6789"));
            Assert.IsFalse(attribute.IsValid("A"));
            Assert.IsFalse(attribute.IsValid("AB-"));
            Assert.IsFalse(attribute.IsValid("WXYZ"));
            Assert.IsFalse(attribute.IsValid("AB-789-XYZ"));
            Assert.IsFalse(attribute.IsValid("AB-789-VWXYZ"));
            Assert.IsFalse(attribute.IsValid("UVW-XYZ-0000"));
        }
	}
}