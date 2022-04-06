using NumberValidation.Validator.ValidityChecks;
using NUnit.Framework;

namespace NumberValidation.Tests
{
    public class IsValidBirthdateSocialSecurityNumberValidityCheckTest
    {
        [Test]
        [TestCase("9410251234", true)]
        [TestCase("0002314567", false)]
        [TestCase("0004314567", false)]
        [TestCase("9112324567", false)]
        [TestCase("199112324567", false)]
        public void IsValidBirthdateValidityCheck_Test(string number, bool expected)
        {
            var check = new IsValidBirthdateSocialSecurityNumber();
            var result = check.Validate(number);
            Assert.AreEqual(expected, result.IsValid);
        }
    }
}