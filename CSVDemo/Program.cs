using System.Globalization;
using CSVDemo;
using CsvHelper;

const string path = "customers-100000.csv";
IEnumerable<Customer> customers;

StreamReader sr = new(path);

CsvReader csvReader = new(sr, CultureInfo.InvariantCulture);
customers = csvReader.GetRecords<Customer>();

foreach (Customer customer in customers)
{ 
    Console.WriteLine(customer.FirstName + " " + customer.LastName + " - " + customer.Company);
}