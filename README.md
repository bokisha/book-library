# Instructions

This solution has been created with ASP.Net core/Angular template using .net core 3.1. 
Project BookLibrary contains start up server logic that serves both web api 
and angular app. This can be done by building and running it inside Visual studio 2019.

# Solution structure by projects

### BookLibrary

BookLibrary contains logic necessary to run server that hosts client and server api. 
Folder ClientApp contains angular project.

### BookLibrary.Api

BookLibrary.Api contains web api controllers, view models and model converters that converts DB entities to view models.
Inside controllers mediator pattern is used pass commands or queries to Infrastructure request handlers.
Commands are used for requests that changes DB state. Queries are used for requests that only read database.
That is part of Command Query Responsibility Segregation pattern.
Possible improvement is that new interface is created inside Core project (ICommand, IQuery) and to remove 
dependency which is that Api knows about Infrastructure inner implementation details for command/queries model.

### BookLibrary.Infrastructure

BookLibrary.Infrastructure contains logic for managing DB state without knowing anything about DB. 
It also contains Command/Queries models and handlers. Handlers are called based on what has been sent from Api project.
Inside Commands/Queries UnitOfWork pattern is used. UnitOfWork can contain multiple DB queries 
that can be bundled into one single transaction. To change DB state CompleteAsync must be called so 
transaction is committed.
Possible future improvement could be introducing services pattern inside handlers when logic of 
those handlers becomes complex.

### BookLibrary.DAL.InMemory

Project is used for accessing DB, in this case InMemory DB provider is used. In this project 
UnitOfWork and Repositories are implemented to manage DB. If needed, another DAL project can be easily created using
diferent DB provider.

### BookLibrary.Core
Core contains essential classes that are used across whole application. It contains DB entity models, interfaces and
other shared data.
