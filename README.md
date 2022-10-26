
# Introduction  
Building Api on .Net 6 for backend task for Covid


Project Structere:
- ASP.NET Core Web API application
- REST API principles, CRUD operations
- SqlServer database
-Dependency injection
- CQRS and Mediator 
- Swagger Open API implementation
- FluentValidation
- Repository Pattern Implementation


# Getting Started
To start run the Project:
1. Clone the project to your local machine,open it with Visual studio.
2.	Open Package Manager Console for update Database , use the follwoing commands.
3. choose default project (Persistence),must change the connection string on appsettings.json 
4. update-database
5. Project is ready to run and test. 

# Build and Test
 To start Test the Application:
 1. Run the app and you can see documentation for the API in the Swagger UI.
 2. From the lookup create vaccine, TotalNumOfDose must be greater than zero and the Name is not empty
 3. Create patient 
 4. after that you can take the vaccine Id and patient Id in order to create vaccine for your patient,DoseNum must be greater than zero and the Name is not empty


