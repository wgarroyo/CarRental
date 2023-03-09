# CarRental README


This README is for an experimental WEBAPI build in C# for car rental.

It contains example documentation for each endpoint at Requests folder (root level). 
Register yourself with Register enpoint and use provided token for the rest of the resources.
Also swagger is emplemented for API documentation.
In case you would like to avoid authentication, remove [Authorize] attribute from APIController.



## Migrations

Database migrations will be run automatically at application startup.

In case you want to run migrations manually, please use the following commands:

- dotnet ef database update -p .\CarRental.Infrastructure\ -s .\CarRental.Api\ --connection "Server=localhost;Database=CarRental;Trusted_Connection=True;Encrypt=false"
- dotnet ef database update 0 -p .\CarRental.Infrastructure\ -s .\CarRental.Api\ --connection "Server=localhost;Database=CarRental;Trusted_Connection=True;Encrypt=false"