
using Abstraction;
using AutoMapper;
using Buisness.DTOs.Command.Order;
using Buisness.DTOs.CommandDTOs.Order;
using Domen.DTOs.CommandDTOs.OrderDTOs;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Buisness.DTOs.CommandDTOs.Customer;
using Domen.Models.CommandModels;
using Infrastructure.Repositories.CommandRepositories;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_customer;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_order;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_product;

namespace Buisness.Handlers.OrderHandler
{
    public class _order_PostHandler : IRequestHandler<_order_PostDTO_request, _order_PostDTO_respons>
    {
        private readonly IMapper mapper;
        private readonly IValidator<_order_PostDTO_request> validator;
        private readonly IRepository_order_post order_Repository_post;
        private readonly IRepository_customer_respons customer_Repository_respons;
        private readonly IRepository_product_respons product_Repository_respons;
        private readonly IRepository_order_respons order_Repository_respons;
        private readonly IRepository_UnitOfWork unitOfWork_Respository;

        public _order_PostHandler(IMapper mapper, IValidator<_order_PostDTO_request> validator, IRepository_order_post order_Repository_post, IRepository_customer_respons customer_Repository_respons, IRepository_product_respons product_Repository_respons, IRepository_order_respons order_Repository_respons, IRepository_UnitOfWork unitOfWork_Respository)
        {
            this.mapper = mapper;
            this.validator = validator;
            this.order_Repository_post = order_Repository_post;
            this.customer_Repository_respons = customer_Repository_respons;
            this.product_Repository_respons = product_Repository_respons;
            this.order_Repository_respons = order_Repository_respons;
            this.unitOfWork_Respository = unitOfWork_Respository;
        }

        public async Task<_order_PostDTO_respons> Handle(_order_PostDTO_request order_PostDTO_request, CancellationToken cancellationToken)
        {
            //Validation
            var result = await validator.ValidateAsync(order_PostDTO_request);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    throw new Exception($"Validation Error: {error.ErrorMessage} for the property: {error.PropertyName}");
                }
            }

            //Mapping DTO to Entity
            var orderTodb = mapper.Map<_order_Model_write>(order_PostDTO_request);
            var customerToOrder = await customer_Repository_respons._customer_Method_respons(order_PostDTO_request._order_customer_PIN);
            var productToOrder = await product_Repository_respons._product_Method_respons(order_PostDTO_request._order_product_Barcode);
            orderTodb._customer_ID = customerToOrder._customer_ID;
            orderTodb._product_ID = productToOrder._product_ID;
            //throw new Exception($"Merac {orderTodb._order_custome_PIN}");

            // Adding to database
            await order_Repository_post._order_Method_post(orderTodb);

            //Saving changes
            await unitOfWork_Respository.Save(cancellationToken);

            //Result
            var orderFromdb = await order_Repository_respons._order_Method_respons(orderTodb._order_Code);

            // Mapping Entity to DTO
            var respons = mapper.Map<_order_PostDTO_respons>(orderFromdb);
            respons._order_customer_Name = customerToOrder._customer_Name;
            respons._order_product_Name = productToOrder._product_Name;

            //Respons
            return respons;
        }
    }
}
