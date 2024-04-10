using CsvHelper.Configuration.Attributes;

namespace CSVDemo;

public class Customer
{
    // Index
    // Customer Id
    // First Name
    // Last Name
    // Company
    // City
    // Country
    // Phone 1
    // Phone 2
    // Email
    // Subscription Date
    // Website
    [Name("Index")]
    public int Index { get; set; }
    
    [Name("Customer Id")]
    public string CustomerID { get; set; }
    
    [Name("First Name")]
    public string FirstName { get; set; }
    
    [Name("Last Name")]
    public string LastName { get; set; }
    
    [Name("Company")]
    public string Company { get; set; }
}