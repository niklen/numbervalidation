using NumberValidation.Validator.ValidityChecks.PriorityChecks;
using NUnit.Framework;

namespace NumberValidation.Tests
{
    public class IsANumberValidityCheckTest
    {
        [Test]
        [TestCase("1234567891", true)]
        [TestCase("123456-7891", true)]
        [TestCase("123456+7891", true)]
        [TestCase("123456U7891", false)]
        [TestCase("1234567891A", false)]
        [TestCase("16556601-6399", true)]
        public void IsANumberValidityCheck_Test(string number, bool expected)
        {
            var check = new IsNumber();
            var result = check.Validate(number);
            Assert.AreEqual(expected, result.IsValid);
        }
    }
}