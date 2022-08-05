using System.Collections.Generic;

namespace EfCore7.NamingIssue.Domain;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Country Country { get; set; }
    public int CountryId { get; set; }
    public List<Aircraft> Assets { get; set; } = new List<Aircraft>();
}