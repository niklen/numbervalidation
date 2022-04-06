namespace NumberValidation.Validator.Models;

public class ValidationSummary
{
    public ValidationSummary()
    {
        ValidSocialSecurityNumbers = new List<string>();
        ValidOrganisationNumbers = new List<string>();
        ValidCoOrdninationNumbers = new List<string>();
    }
    public List<string> ValidSocialSecurityNumbers { get; set; }
    public List<string> ValidOrganisationNumbers { get; set; }
    public List<string> ValidCoOrdninationNumbers { get; set; }


    public void AddValidSocialSecurityNumber(string number)
    {
        ValidSocialSecurityNumbers.Add(number);
    }

    public void AddValidOrganisationNumber(string number)
    {
        ValidOrganisationNumbers.Add(number);
    }

    public void AddValidCoOrdninationNumber(string number)
    {
        ValidCoOrdninationNumbers.Add(number);
    }
}