using Abstraction;
using Abstraction.Abstractions.Read;
using Abstraction.Abstractions.Write.Customer;
using Abstraction.Abstractions.Write.Order;
using Abstraction.Abstractions.Write.Product;
using Buisness.ActionFilters.CommandActionFilter.CustomerActionFilters;
using Buisness.Buisness.FluentValidations.Customer;
using Buisness.DTOs.Command.Customer;
using Buisness.DTOs.Command.Order;
using Buisness.DTOs.CommandDTOs.Product;
using Buisness.FluentValidations.Customer;
using Buisness.FluentValidations.Order;
using Buisness.FluentValidations.Product;
using Domen.DTOs.Write.Customer;
using Domen.DTOs.Write.Order;
using Domen.DTOs.Write.Product;
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
            services.AddScoped<IValidator<PostCustomerRequest>, CustomerPostDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<UpdateCustomerRequestValidation>();
            services.AddScoped<IValidator<UpdateCustomerRequest>, UpdateCustomerRequestValidation>();

            services.AddValidatorsFromAssemblyContaining<DeleteCustomerRequestValidation>();
            services.AddScoped<IValidator<DeleteCustomerRequest>, DeleteCustomerRequestValidation>();


            //Order
            services.AddValidatorsFromAssemblyContaining<OrderPostDTOValidation>();
            services.AddScoped<IValidator<PostOrderRequest>, OrderPostDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<OrderUpdateDTOValidation>();
            services.AddScoped<IValidator<UpdateOrderRequest>, OrderUpdateDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<DeleteOrderRequestValidation>();
            services.AddScoped<IValidator<DeleteOrderRequest>, DeleteOrderRequestValidation>();


            //Product
            services.AddValidatorsFromAssemblyContaining<ProductPostDTOValidation>();
            services.AddScoped<IValidator<PostProductRequest>, ProductPostDTOValidation>();

            services.AddValidatorsFromAssemblyContaining<UpdateProductRequestValidation>();
            services.AddScoped<IValidator<UpdateProductRequest>, UpdateProductRequestValidation>();

            services.AddValidatorsFromAssemblyContaining<DeleteProductRequestValidation>();
            services.AddScoped<IValidator<DeleteProductRequest>, DeleteProductRequestValidation>();
        

            //JWT//
            services.AddTransient<IJwtAuth, JwtRepositoryauth>();


            //REPOSITORIES//
            //Customer
            services.AddScoped<IPostCustomer, PostCustomer>();

            services.AddScoped<IUpdateCustomer, UpdateCustomer>();

            services.AddScoped<IDeleteCustomer, DeleteCustomer>();

            //Product
            services.AddScoped<IPostProduct, PostProduct>();

            services.AddScoped<IUpdateProduct, UpdateProduct>();

            services.AddScoped<IDeleteProduct, DeleteProduct>();

            services.AddScoped<IGetProduct, GetProduct>();


            //Order
            services.AddScoped<IPostOrder, PostOrder>();

            services.AddScoped<IUpdateOrder, UpdateOrder>();

            services.AddScoped<IDeleteOrder, DeleteOrder>();


            //CustomerOrderProduct
            services.AddScoped<IGetCustomerObjectProduct, GetCustomerOrderProduct>();


            //UNIT OF WORK//
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            //ACTION FILTER//
            services.AddScoped<PostFilterCustomer>();
        }
    }
}
