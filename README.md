## Overview

- ASP.Net Core web application using Razor pages and ef.
- oAuth secure JWT token based authentication
- Role based authorization
- Support for customized log4net
- Hashed based password

### Projects
This repository contains below projects :

- **Blogger.DAL** : Data access layer which has below responsibilities:
	- Creates data access models using core EF required for `Code First Migration`. Below are the tables used:
		- `BlogPublishers` : For managing publishers who can post the blogs.
		- `Roles` : Role associated to blog publisher. Currently, below two roles have been added: 
			- `Admin`: Can create and edit all blog posts.
			- `SuperAdmin`: Can create, edit and **delete** all blog posts.
		- `BlogPosts`: For mananging all the blog posts/articles which have been posted by publishers.
	- Creates abstracted database store to perform CRUD operation directly on db.
	- Creates service management layer which can be used as dependency injection for external projects.
	- Persistence layer for seeding test data.
	- Publisher credentials are saved in db using secure one-way hashing algorithm.

- **Blogger.Web** : Front end Web application which uses DAL layer (intern core EF) and Razor pages to perform CRUD operation on blog posts and blog publishers.
	- Below are the razor pages which has main functionalities:
		- `Index` : Application default landing (non-logged in) page which shows the latest blogs posts.
		- `Create`: Allow to create a new blog post [Require Authentication and Authroization of Admin/SuperAdmin]
		- `Edit`: Allow to edit an existing blog post [Require Authentication and Authroization of Admin/SuperAdmin]
		- `Delete`: Allow to delete an existing blog post [Require Authentication and Authroization of SuperAdmin]
	- For `Create/Edit/Delete` operations, authentication is required through `Login` page.
		- Authencation is done using oAuth secure JWT token based authentication.
		- Token default expiry is currently 7 days and is managed in session.
		- To clear the session, please use `Logout` option OR close and reopen the browser.
	- For `Create/Edit/Delete` operations, Along with authentication, role based authorization has been implemented using custom authorization filter.
		- Any publisher having `Admin` or `SuperAdmin` role can perform `Create` and `Edit` operation.
		- Only publisher having `SuperAdmin` role can perform `Delete` operation.
	- For logging, `log4net` has been used which can be customized using `log4net.config`. Below are the appenders currently used.
		- `ConsoleAppender` : Writes log to console
		- `RollingFileAppender`: Writes log to log file (default folder is `Logs`)
	- Database migration: There are two migrations which have been created.
		- `Initial` : This migration has been created using `Release` build configuration and can be used for prod.
		- `InitialWithTestData`: This migration has been created using `Debug` build configuration and can be used for test/development which seeds dummy data in database.
	
- **Blogger.Tests** : Tests project which has unit tests to validate DAL and security layer.

### Important Note related to credential

- For all publishers, credentials are as below:
	- Name: Same as publisher name (`Nitin`, `Ojasvi`, `Neo` etc)
	- Password: `pass123`

### How to run application?

- `git clone https://github.com/stepchange-assessments/ng.git`	
- go to folder `ng` and run `database.bat` which will apply the migration in local database.
	- You might need to install ef tool `dotnet tool install --global dotnet-ef` OR `dotnet tool install --global dotnet-ef --version 3.1.4`
	- You can also apply migration from Visual Studio -> Tools -> Nuget Package Manager -> Package Manage Console -> `update-database` 
	- **NOTE** If you apply from visual studio, please select the `Debug` mode which will apply migration to seed dummy data.
- Right click on `StepChange.Blogger.Web` -> `Set as Start up project`
- Press `Ctrl F5` key to run the application on browser.

## Authors
Nitin Garg
