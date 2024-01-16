# CRM-Web-API
ASP.NET Core Web API (.NET 7)
#### CRM Web API Project

As the name suggests, this project facilitates data exchange between customers and company. Customers can browse the products provided by the company and create orders for the desired products. Customer side can create customer, view products and create order while the company has the ability to add, update, delete products and view whole order (customer-order-product).
The Project is developed in ASP.Net (.Net7) and MSSQL is used as a database.


### Operations

--Create product
--Update product
--Delete product
--Create customer
--Update customer
--Delete customer
--Create order
--Update order
--Delete order


### Structure (there two sides C# and MSSQL) 
## C# Side

# Models

--_customer_Model_write (write model)
--_protuct_Model_write (write model)
--_order_Model_write (write model)
--_product_Model_read (read model)
--_cop_Model_read (customer-order-product read model)


# ORM

--Entity Framework Core (EF)
--Fluent API


# Security

--Jeson Web Token (JWT)


# Desing Patterns

--Repository
  _customer_Repository
  _product_Repository
  _order_Respository
  _cop_Repository

--Mediator
  _customer_Handler
  _product_Handler
  _order_Handler
  _customer_PostDTO_request
  _product_PostDTO_request
  _order_PostDTO_request

--CQRS
  All classes are seperated into write and read models.


# Architecture style 

  Clean Architecture:
  --Abstraction
  --Buisness
  --Domen
  --Infrastructure
  --Presentation


# Validation

--Fluent Validation
--Data Annotation
--Action Filters

# Mapping


MSSQL Side

There are 3 databases:
--_command_DB
   This DB is used for create, update and delete operations. 
--_query_client_DB
   This DB is used for get operation (Customer Side).
--_query_company_DB
   This DB is used for get opreation (Company Side).
Inside _command_DB:
--_product_InsertTrigger
--_product_Update_Trigger
--_product_Remove_Trigger
--_order_InsertTrigger
--_order_UpdateTrigger
--_order_RemoveTrigger
those tiggers is created for sychronizing with _query_client_DB and _query_company_DB.





