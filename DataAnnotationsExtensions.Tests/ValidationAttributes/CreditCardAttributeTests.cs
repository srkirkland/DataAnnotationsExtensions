using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAnnotationsExtensions.Tests.ValidationAttributes
{
	[TestClass]
	public class CreditCardAttributeTests
	{
		[TestMethod]
		public void IsValidTests()
		{
			var attribute = new CreditCardAttribute();

			Assert.IsTrue(attribute.IsValid(null));                  // Don't check for required
			Assert.IsTrue(attribute.IsValid("0000000000000000"));    // Simplest valid value
			Assert.IsTrue(attribute.IsValid("1234567890123452"));    // Good checksum
			Assert.IsTrue(attribute.IsValid("1234-5678-9012-3452")); // Good checksum, with dashes
			Assert.IsTrue(attribute.IsValid("541234567890125"));
			Assert.IsTrue(attribute.IsValid("4408041234567893"));
			Assert.IsTrue(attribute.IsValid("4417123456789113"));
			
			Assert.IsFalse(attribute.IsValid("0000000000000001"));   // Bad checksum
			Assert.IsFalse(attribute.IsValid("1234567890123456"));
			Assert.IsFalse(attribute.IsValid("4417123456789112"));
			Assert.IsFalse(attribute.IsValid("4408041234567890"));
			Assert.IsFalse(attribute.IsValid("4408041234567890ab"));
			Assert.IsFalse(attribute.IsValid("4408 0412 3456 7890"));
			Assert.IsFalse(attribute.IsValid(0));                    // Non-string
		}
	}
}