<p align="center"><img src="_media/contoso-university-02.png"></p>

# Contoso University Razor Project
The Microsoft Contoso University sample web app demonstrates how to create an ASP.NET Core Razor Pages app using Entity Framework (EF) Core. The project is based upon the tutorial on [docs.microsoft.com](https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-2.2&tabs=visual-studio). The projects that I will creating be refactored to reflect the clean architecture pattern using a pragmatic approach to software development. SOLID design principles and fundamental OOP will be used.  

Thanks to folks like @ardalis, @EduardoPires, @garymcleanhall, & @jbogard for sharing lots of great patterns in their various GitHub repos & projects!

## Getting Started
Use these instructions to get the project up and running.

### Prerequisites
You will need the following tools:

* [Visual Studio Code or 2017](https://www.visualstudio.com/downloads/)
* [.NET Core SDK 2.2](https://www.microsoft.com/net/download/dotnet-core/2.2)
* [SQL Server Management Studio](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)
* [SQL Server Developer Edition](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) - Recommended because I'm a data honk who likes control over persistance :-)

### Environment Setup
1. Clone or fork the project
2. Open the master branch
3. Create a new SQL Database (preferrably named ContosoUniversity).
4. In the database_package folder, open [ContosoUniversity_Database_Package.sql](.\database_package\ContosoUniversity_Database_Package.sql) using your preferred .sql file editor.
5. Update the DatabaseName in line 34 to the database name created in step 3 and close the file. <p align="left"><img src="_media/change_automation_package.png"></p>
6. Back in Windows Explorer, enter CMD in the address bar and press the Enter key which will open a command prompt window. If command prompt is blocked then enter POWERSHELL in the address bar and press the Enter key which will open a PowerShell window.
    * Note: The path should be defaulted to the database_package folder.
7.  Paste the following code and press the enter key to deploy the databse code. 
    ```
    sqlcmd.exe -b -S "MICK" -o ".\contosouniversity.txt" -i ".\ContosoUniversity_Database_Package.sql"
    ```
8. Back in Winodws Explorer, open the output file named contosouniversity.txt to verify that the database was created successfully.
9. In Visual Studio, open the ContosoUniverity.sln, navigate to the ContosoUniversity.Web project, edit the appsettings.json file setting the proper database and server name. <p align="left"><img src="_media/app_settings.png"></p>

### Database Diagram
A database diagram to help with understanding my take on this project is located here: [ContosoUniversityDatabaseDiagram](_media\ContosoUniversityDatabaseDiagram.pdf)

## Technologies
* .NET Core 3.0
* ASP.NET Core 3.0
* Entity Framework Core 3.0

## Packages Utilized 
* [Automapper](https://github.com/AutoMapper/AutoMapper)
* [BundlerMinifier](https://github.com/madskristensen/BundlerMinifier)
* [FluentValidation](https://github.com/JeremySkinner/FluentValidation)
* [Red Gate SQL Change Automation](https://www.red-gate.com/products/sql-development/sql-change-automation/)
* [X.PagedList](https://github.com/dncuug/X.PagedList)

## License

This project is licensed under the [MIT License](LICENSE.md).
