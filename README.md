This is my test submission for Pinewood Technologies

## Backend
- Found within the `pinewoodBackend/` folder.
- Is an ASP.net WEB API application.
- Uses a database or JSON for data management
- To change between database and JSON, set line 13 in `program.cs` to:
  - `builder.Services.AddSingleton<ICustomerService, CustomerServiceJson>();` for JSON
  - `builder.Services.AddSingleton<ICustomerService, CustomerServiceDb>();` for database
- Set the database connection string on line 12 of `Database/CustomerDbContext.cs`
- To run the migrations, run the command `Update-Database` in the Package Manager Console. 

## Front end
- Found within the `pinewoodFrontend/` folder.
- Is a Blazor WASM application.
