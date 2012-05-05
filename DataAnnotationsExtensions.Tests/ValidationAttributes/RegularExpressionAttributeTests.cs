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
	}
}