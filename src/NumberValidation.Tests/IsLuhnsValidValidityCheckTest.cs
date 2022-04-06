using NumberValidation.Validator.ValidityChecks;
using NUnit.Framework;

namespace NumberValidation.Tests;

public class IsLuhnsValidValidityCheckTest
{
    [Test]
    //[TestCase("8112189876", true)]
    //[TestCase("198107249289", true)]
    //[TestCase("4607137454", true)]
    //[TestCase("0004314567", false)]
    //[TestCase("9112324567", false)]
    //[TestCase("201701272394", false)]
    //[TestCase("190910799824", true)]
    //[TestCase("165566016399", true)]
    [TestCase("16556601-6399", true)]
    [TestCase("16556601+6399", true)]
    [TestCase("165566016398", false)]
    public void IsLuhnsValidValidityCheck_Test(string number, bool expected)
    {
        var check = new IsLuhnsValid();
        var result = check.Validate(number);
        Assert.AreEqual(expected, result.IsValid);
    }
}