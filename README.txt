SOLO™ Employee management
is open mock software for demonstration of solution for information system.

This software was delivered as practical assigment of developement basic information system for company according to customer specification available in folder /Documentation as PDF file. Screenshots are also available there.

Technologies: C# .Net, Azure database-as-a-service and WinForms user interface. End user management of this software is temporary solved by using different connection string. It can be implemented on app level later.

Connection secret for connecting to DB is not included in repository! For access to external DB service you can use in-app configurator. File ConnectionString.config is located in folder SoloDemo in form of SQL for Azure DAAS SQL Server (=database layer not included in programme). SQL commands if they are nessesary could be get from SoloDemoData\Migrations. Test data are not provided for security and privacy reasons.

Software is designed as 3 layer model with data, business and UI logic. Practical implementation isn't that strict divided and it should be improved later when app will grow. Inside data fetch is done by Repository pattern.

Data logic is provided by EntityFramework and one of targets was to convert data to object form ASAP. The best usage of provided information is visible in code of ReportingForm where is method RefreshStatistics() where is used object model using natural aproach of person as data structure. Other Forms should be refactored to same model in comming version (if any).

Business logic isn't that strict separated as it could be. Presentation layer is hosted by Windows Forms UI which is nowadays quite oldschool and original ideas was to replace it by web ASP.NET, because app is well designed. From time reasons it wasnt realized yet, but it could be done quite easilly.

Programm implements extra requirements as printing or data export. Visual views are not provided in this version.

Summary: this program demostrate my ability to build non trivial software with good propgramming manners. But it isnt definitelly production app on highest possible level of clean programming. Should be much more improved, but it isn't task of this demonstration. The best way to know how it works is to check it! Software is delivered as solution for Visual Studio, but also compiled version for click-to-run is in archive in root folder.

In case of questions dont hesitate to contact me in standard way.