# fun-in-motion
This is an inprogress POC of gif galleries developed in ASP.NET MVC with SQL Server as backend

The application was developer in Visual Studio 2015 using ASP.NET MVC
The application connects to MSSQLSERVER. Download the two scripts inside the folder named "Database Script".

Run first the GifCollection.sql inorder to generate tables
then run the CatgorySeedData.sql for the initial content of the category table.

You will to change your connectionstring as well under web.config file to point to your server and database. The web.config file is located at "FunInMotion.Giphy.Web" project.

This is the value of the existing connectionstring that you need to replace.
 <connectionStrings>
    <add name="GifCollectionEntities" connectionString="metadata=res://*/FunInMotionModel.csdl|res://*/FunInMotionModel.ssdl|res://*/FunInMotionModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=CHARLIE;initial catalog=GifCollection;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>
