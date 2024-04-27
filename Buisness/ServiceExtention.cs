using Abstraction;
using Infrastructure.Repositories.CommandRepositories;
using Infrastructure.Repositories.QueryRepositories;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Buisness.DTOs.Command.Customer;
using Buisness.DTOs.Command.Order;
using Buisness.DTOs.CommandDTOs.Product;
using Buisness.ActionFilters.CommandActionFilter.CustomerActionFilters;
using Domen.DTOs.QueryDTO;
using Domen.DTOs.CommandDTOs.CustomerDTOs;
using Domen.DTOs.CommandDTOs.OrderDTOs;
using Buisness.DTOs.Command.Product;
using Domen.DTOs.CommandDTOs.ProductDTOs;
using Infrastructure.Repositories.CommandRepositories.CustomerRepository;
using Infrastructure.Repositories.CommandRepositories.ProductRepository;
using Infrastructure.Repositories.CommandRepositories.OrderRepository;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_customer;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_order;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_product;
using Abstraction.Abstractions._read_Abstractions;
using Buisness.FluentValidations.Customer;
using Buisness.Buisness.FluentValidations.Customer;
using Buisness.FluentValidations.Order;
using Buisness.FluentValidations.Product;

namespace Buisness
{
    public static class ServiceExtention
    {
        public static void ConfigureBuisness(this IServiceCollection services)
        {
            //MEDIATOR//
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            //MAPPER//
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            //FLUENT VALIDATOR//
            //Customer
            services.AddValidatorsFromAssemblyContaining<CustomerPostDTOValidation>();
            services.AddScoped<IValidator<CustomerRequestPostDTO>, CustomerPostDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<CustomerUpdateDTOValidation>();
            services.AddScoped<IValidator<CustomerRequestUpdateDTO>, CustomerUpdateDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<CustomerRemoveDTOValidation>();
            services.AddScoped<IValidator<CustomerRequestDeleteDTO>, CustomerRemoveDTOValidation>();
            //Order
            services.AddValidatorsFromAssemblyContaining<OrderPostDTOValidation>();
            services.AddScoped<IValidator<OrderRequestPostDTO>, OrderPostDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<OrderUpdateDTOValidation>();
            services.AddScoped<IValidator<OrderRequestUpdateDTO>, OrderUpdateDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<OrderDeleteDTOValidation>();
            services.AddScoped<IValidator<OrderRequestDeleteDTO>, OrderDeleteDTOValidation>();
            //Product
            services.AddValidatorsFromAssemblyContaining<ProductPostDTOValidation>();
            services.AddScoped<IValidator<ProductRequestPostDTO>, ProductPostDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<ProductUpdateDTOValidation>();
            services.AddScoped<IValidator<ProductRequestUpdateDTO>, ProductUpdateDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<ProductDeleteDTOValidation>();
            services.AddScoped<IValidator<ProductRequestDeleteDTO>, ProductDeleteDTOValidation>();
        

            //JWT//
            services.AddTransient<IJwtAuthRepository, JwtRepositoryauth>();


            //REPOSITORIES//
            //Customer
            services.AddScoped<ICustomerRepositoryPost, CustomerRepositoryPost>();
            services.AddScoped<ICustomerRepositoryUpdate, CustomerRepositoryUpdate>();
            services.AddScoped<ICustomerRepositoryRemove, CustomerRepositoryRemove>();
            services.AddScoped<ICustomerRepositoryResponse, CustomerRepositoryResponse>();
            //Product
            services.AddScoped<IProductRepositoryPost, ProductRepositoryPost>();
            services.AddScoped<IProductRepositoryUpdate, ProductRepositoryUpdate>();
            services.AddScoped<IProductRepositoryRemove, ProductRepositoryRemove>();
            services.AddScoped<IProductRepositoryResponse, ProductRepositoryResponse>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            //Order
            services.AddScoped<IOrderRepositoryPost, OrderRepositoryPost>();
            services.AddScoped<IOrderRepositoryUpdate, OrderRepositoryUpdate>();
            services.AddScoped<IOrderRepositoryRemove, OrderRepositoryRemove>();
            services.AddScoped<IOrderRepositoryResponse, OrderRepositoryResponse>();
            //CustomerOrderProduct
            services.AddScoped<ICOPReadRepository, COPReadRepository>();


            //UNIT OF WORK//
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            //ACTION FILTER//
            services.AddScoped<postCustomerActionFilter>();
        }
    }
}
