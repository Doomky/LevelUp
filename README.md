LevelUp
=======

<div style="text-align:center">
    <img src="logo.svg" style="width: 200px">
</div>

***LevelUp*** is a Mobile (Android and IOS) and a Web application where the user has a customisable and personal **avatar**
which support him to get better by helping him in multiple **themes**: *nutrition*, *physical activities* and *sleep*.
Furthermore, the avatar can give **advices** to the user in these different themes.
To incite the user to come back regularly on the app, **quests** are available with several types (*daily*, *weekly*, *monthly*)
and complete them will offer the user some xp to **level up** ! They can also gain multiple **rewards** by completing quests.

## Description

This repository is the **.NET Core** backend of the application and contains multiple **Visual Studio** projects:

- ***LevelUpAPI*** : the API composed of controllers accessible by multiple endpoints, request handlers that represent the business layer, 
models of the database (**Entity Framework**) and repositories to manage all the database objects (Dbo).
- ***LevelUpClient*** : a console application to test the different endpoints of the API.
- ***LevelUpDatabase*** : the SQL project containing all the tables and views of the database needed for the API to work.
- ***LevelUpIdentityServer*** : the authentication server based on the **Identity Server** package
- ***LevelUpDTO*** : contains the classes representing all the possible DTO (requests and responses).

## Requirements

- [Visual Studio 2019](https://visualstudio.microsoft.com/fr/vs/) (at least the **Community** version)
- .Net Core SDK
- [SQL Server 2019](https://www.microsoft.com/fr-fr/sql-server/sql-server-downloads)
- SQL Server Data Tools
- SQL Server Management Studio (SSMS) (optional but **highly recommended**)

## Prepare the database

1. Create an instance of SQL Server (if you don't have one already).
2. Create a new SQL Server database "**levelup**" in your SQL Server instance with SSMS or with these commands if it's not installed
(replace *servername* and *instancename* with yours) :

        sqlcmd -S (servername)\(instancename)
        create database levelup
        go

3. Open the solution in **Visual Studio**.
4. Right-click on the ***LevelUpDatabase*** project in the **Solution Explorer**.
5. Select **Schema comparison** and for the target of the comparison, choose the newly created database.
6. Click **Compare** and when it's done with comparison, click **Update** to create all the tables necessary for the database.
7. Open the **Packet Manager Console**, select ***LevelUpAPI*** as starting project, go to its directory
and apply all the migrations with the command :

        dotnet ef database update

## Start the solution

1. Select ***LevelUpIdentityServer*** as starting project.
2. Replace the *servername* and *instancename* by yours in the connection string "DefaultConnection" in **appsettings.Development.json**:

        {  
            "Logging": {
            "LogLevel": {
                "Default": "Information",
                "Microsoft": "Warning",
                "Microsoft.Hosting.Lifetime": "Information"
                }
            },
            "ConnectionStrings": {
                "DefaultConnection": "Server=(servername)\\(instancename);Database=levelup;Trusted_Connection=True;"
            }
        }
3. Start the project (your web brower should open with a blank page).
4. Open a new **Visual Studio**.
5. Select ***LevelUpAPI*** as starting project.
6. As for the ***LevelUpIdentityServer*** project, replace the *servername* and *instancename* by yours in the connection string "DefaultConnection" in **appsettings.Development.json**.
7. Start the project (your web brower should open with the **Swagger** documentation page).
8. The API is now ready to use !