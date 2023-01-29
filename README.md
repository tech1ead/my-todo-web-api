# MyToDoWebApi

Implementation of a ASP.NET Web API with Code First approach using .net6, Entity Framework Core 7.0.2 and the following patterns:
- UnitOfWork Pattern
- Repository Service Pattern
## appsettings.json

Add this appsettings.json to the MyToDoWebApi.Api project

```
{
  "ConnectionStrings": {
    "ToDoConnection": "Data Source=(LocalDB)\\mssqllocaldb;database=ToDo;integrated security=True;Trusted_Connection=True"
  }
}
```

## Creating the Database
Open the Package Manager Console and add this command to create a Migration

```
Add-Migration [Name] -StartupProject MyToDoWebApi.Api -Context ToDoContext -Project MyToDoWebApi.Database
```
