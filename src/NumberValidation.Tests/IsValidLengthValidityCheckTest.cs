using NumberValidation.Validator.ValidityChecks;
using NumberValidation.Validator.ValidityChecks.PriorityChecks;
using NUnit.Framework;

namespace NumberValidation.Tests
{
    public class IsValidLengthValidityCheckTest
    {
        [Test]
        [TestCase("1234567891", true)]
        [TestCase("123456+7891", true)]
        [TestCase("12345678912", false)]
        [TestCase("123456789123", true)]
        [TestCase("16556601-6399", true)]
        public void IsValidLengthValidityCheck_Test(string number, bool expected)
        {
            var check = new IsValidLength();
            var result = check.Validate(number);
            Assert.AreEqual(expected, result.IsValid);
        }
    }
}