using System.Globalization;
using Interview.SalaryIncrease;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");

Employee employee = new();
employee.ReadSalaryIn();
employee.CalculateSalary();
employee.PrinfInformations();