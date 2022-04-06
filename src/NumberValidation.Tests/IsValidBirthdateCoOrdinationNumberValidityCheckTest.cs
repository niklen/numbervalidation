using NumberValidation.Validator.ValidityChecks;
using NUnit.Framework;

namespace NumberValidation.Tests;

public class IsValidBirthdateCoOrdinationNumberValidityCheckTest
{
    [Test]
    [TestCase("9410251234", false)]
    [TestCase("0002314567", false)]
    [TestCase("0004314567", false)]
    [TestCase("9112324567", false)]
    [TestCase("9112624567", true)]
    [TestCase("9112624567222", false)]
    public void IsValidBirthdateCoOrdinationNumberValidityCheck_Test(string number, bool expected)
    {
        var check = new IsValidBirthdateCoOrdinationNumber();
        var result = check.Validate(number);
        Assert.AreEqual(expected, result.IsValid);
    }
}