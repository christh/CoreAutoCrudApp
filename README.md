# .NET Core Auto Crud App

This application is a general playground for experimenting with .NET Core, ASP.NET Web API and ReactJS. 

Implemented here is a CSV importer which loads the contents to a SQLite database using Entity Framework.

There are two flavours of Front End, a traditional MVC version and a React front end.

The React front end talks to the ASP.NET Web API, which then talks to Entity Framework.
The MVC version talks directly to Entity Framework (but also has the CUD parts of CRUD implemented)

Both versions are asynchronous and the React version uses promises.

**USE AT YOUR OWN RISK. NO WARRANTY IS PROVIDED.**

## Installation

    Load the React or Mvc solution into Visual Studio and build it. Then use IIS Express to load the application.
    Everything should be handled by the application.
    There will be a long delay the first time the website is launched due to the initial loading of 100,000 records
    into the SQLite database.

    Using the standard 'dotnet build' and 'dotnet run' commands should also work and will show more log messages.

## Usage
    Access on localhost:5000 when running or via IIS Express.