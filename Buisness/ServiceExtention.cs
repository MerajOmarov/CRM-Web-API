using Abstraction;
using Abstraction.Abstractions.Read;
using Abstraction.Abstractions.Write.Customer;
using Abstraction.Abstractions.Write.Order;
using Abstraction.Abstractions.Write.Product;
using Buisness.ActionFilters.CommandActionFilter.CustomerActionFilters;
using Buisness.Buisness.FluentValidations.Customer;
using Buisness.DTOs.Command.Customer;
using Buisness.DTOs.Command.Order;
using Buisness.DTOs.Command.Product;
using Buisness.DTOs.CommandDTOs.Product;
using Buisness.FluentValidations.Customer;
using Buisness.FluentValidations.Order;
using Buisness.FluentValidations.Product;
using Domen.DTOs.CommandDTOs.CustomerDTOs;
using Domen.DTOs.CommandDTOs.OrderDTOs;
using Domen.DTOs.CommandDTOs.ProductDTOs;
using FluentValidation;
using Infrastructure;
using Infrastructure.Repositories.CommandRepositories.CustomerRepository;
using Infrastructure.Repositories.CommandRepositories.OrderRepository;
using Infrastructure.Repositories.CommandRepositories.ProductRepository;
using Infrastructure.Repositories.QueryRepositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
            services.AddScoped<ICustomerPostRepository, CustomerPostRepository>();

            services.AddScoped<ICustomerUpdateRepository, CustomerUpdateRepository>();

            services.AddScoped<ICustomerRemoveRepository, CustomerRemoveRepository>();

            services.AddScoped<ICustomerResponseRepository, CustomerResponseRepository>();


            //Product
            services.AddScoped<IProductPostRepository, ProductPostRepository>();

            services.AddScoped<IProductUpdateRepository, ProductUpdateRepository>();

            services.AddScoped<IProductRemoveRepository, ProductRemoveRepository>();

            services.AddScoped<IProductResponseRepository, ProductResponseRepository>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();


            //Order
            services.AddScoped<IOrderPostRepository, OrderPostRepository>();

            services.AddScoped<IOrderUpdateRepository, OrderUpdateRepository>();

            services.AddScoped<IOrderRemoveRepository, OrderRemoveRepository>();

            services.AddScoped<IOrderResponseRepository, OrderResponseRepository>();


            //CustomerOrderProduct
            services.AddScoped<ICOPReadRepository, COPReadRepository>();


            //UNIT OF WORK//
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            //ACTION FILTER//
            services.AddScoped<postCustomerActionFilter>();
        }
    }
}
