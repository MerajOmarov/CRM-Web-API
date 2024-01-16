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
using Buisness._write_FluentValidations.CustomerFluentValidation;
using Buisness._write_FluentValidations.ProductFluentValidation;
using Buisness._write_FluentValidations.OrderFluentValidation;

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
            services.AddValidatorsFromAssemblyContaining<_customer_Validation_postDTO>();
            services.AddScoped<IValidator<_customer_PostDTO_request>, _customer_Validation_postDTO>();

            services.AddValidatorsFromAssemblyContaining<_customer_Validation_updateDTO>();
            services.AddScoped<IValidator<_customer_UpdateDTO_request>, _customer_Validation_updateDTO>();

            services.AddValidatorsFromAssemblyContaining<_customer_DeleteDTO_Validation>();
            services.AddScoped<IValidator<_customer_DeleteDTO_request>, _customer_DeleteDTO_Validation>();
            //Order
            services.AddValidatorsFromAssemblyContaining<_order_Validation_postDTO>();
            services.AddScoped<IValidator<_order_PostDTO_request>, _order_Validation_postDTO>();

            services.AddValidatorsFromAssemblyContaining<_order_Validation_updateDTO>();
            services.AddScoped<IValidator<_order_UpdateDTO_request>, _order_Validation_updateDTO>();

            services.AddValidatorsFromAssemblyContaining<_order_Validation_deleteDTO>();
            services.AddScoped<IValidator<_order_DeleteDTO_request>, _order_Validation_deleteDTO>();
            //Product
            services.AddValidatorsFromAssemblyContaining<_product_Validation_postDTO>();
            services.AddScoped<IValidator<_product_PostDTO_request>, _product_Validation_postDTO>();

            services.AddValidatorsFromAssemblyContaining<_product_Validation_updateDTO>();
            services.AddScoped<IValidator<_product_UpdateDTO_request>, _product_Validation_updateDTO>();

            services.AddValidatorsFromAssemblyContaining<_product_Validation_deleteDTO>();
            services.AddScoped<IValidator<_product_DeleteDTO_request>, _product_Validation_deleteDTO>();
        

            //JWT//
            services.AddTransient<IRepository_jwt_auth, _jwt_Repository_auth>();


            //REPOSITORIES//
            //Customer
            services.AddScoped<IRepository_customer_post, _customer_Repository_post>();
            services.AddScoped<IRepository_customer_update, _customer_Repository_update>();
            services.AddScoped<IRepository_customer_remove, _customer_Repository_remove>();
            services.AddScoped<IRepository_customer_respons, _customer_Repository_respons>();
            //Product
            services.AddScoped<IRepository_product_post, _product_Repository_post>();
            services.AddScoped<IRepository_product_update, _product_Repository_update>();
            services.AddScoped<IRepository_product_remove, _product_Repository_remove>();
            services.AddScoped<IRepository_product_respons, _product_Repository_respons>();
            services.AddScoped<IRepository_product_get, _product_Repository_get>();
            //Order
            services.AddScoped<IRepository_order_post, _order_Repository_post>();
            services.AddScoped<IRepository_order_update, _order_Repository_update>();
            services.AddScoped<IRepository_order_remove, _order_Repository_remove>();
            services.AddScoped<IRepository_order_respons, _order_Repository_respons>();
            //CustomerOrderProduct
            services.AddScoped<IRepository_cop_get, _cop_Repository_get>();


            //UNIT OF WORK//
            services.AddScoped<IRepository_UnitOfWork, UnitOfWork>();


            //ACTION FILTER//
            services.AddScoped<postCustomerActionFilter>();
        }
    }
}
