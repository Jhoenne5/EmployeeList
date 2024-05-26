
To proceed with updating the database, kindly adhere to the following steps:

Utilize the designated tools provided for this task, namely:
Go to tools
NuGet Package Manager
Package Manager Console
Within the Package Manager Console, execute the command: Update-Database.

Also change the 
appsettings.Development.json
under apsettings.json

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "EmployeeList": "Server="YourServer";Database=EmployeeListDb; Trusted_Connection=True;TrustServerCertificate=True"
  }
}
