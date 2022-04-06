using NumberValidation.Validator.ValidityChecks;
using NumberValidation.Validator.ValidityChecks.PriorityChecks;
using NUnit.Framework;

namespace NumberValidation.Tests;

public class ThirdNumberNotLessThanTwoTest
{
    [Test]
    [TestCase("16556601-6399", true)]
    //[TestCase("1234567891", true)]
    //[TestCase("123456+7891", true)]
    //[TestCase("12145678912", false)]
    //[TestCase("123456789123", true)]
    //[TestCase("16550601-6399", false)]
    public void IsValidLengthValidityCheck_Test(string number, bool expected)
    {
        var check = new ThirdNumberNotLessThanTwo();
        var result = check.Validate(number);
        Assert.AreEqual(expected, result.IsValid);
    }
}