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
Add this appsettings.json to the MyToDoWebApi.Database project

```
{
  "ConnectionStrings": {
    "ToDoConnection": "Data Source=(LocalDB)\\mssqllocaldb;database=ToDo;integrated security=True;Trusted_Connection=True"
  }
}
```

## Creating the Database
Open the Package Manager Console and navigate to the Database project. Apply your own migration with:

```
dotnet ef migrations add "yourMigration"
```
or just create the Database using this command:
```
dotnet ef database update
```
