
using Abstraction;
using AutoMapper;
using Buisness.DTOs.Command.Order;
using Domen.DTOs.CommandDTOs.OrderDTOs;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen.DTOs.CommandDTOs.CustomerDTOs;
using Infrastructure.Repositories.CommandRepositories;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_customer;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_order;
using Abstraction.Abstractions._write_Abstractions._write_Abstractions_product;

namespace Buisness.Handlers.OrderHandler
{
    public class _order_PutHandler : IRequestHandler<_order_UpdateDTO_request, _order_UpdateDTO_respons>
    {
        private readonly IMapper mapper;
        private readonly IValidator<_order_UpdateDTO_request> validator;
        private readonly IRepository_order_update order_Repository_update;
        private readonly IRepository_order_respons order_Repository_respons;
        private readonly IRepository_product_respons product_Repository_respons;
        private readonly IRepository_customer_respons customer_Repository_respons;
        private readonly IRepository_UnitOfWork unitOfWork_Repository;

        public _order_PutHandler(IMapper mapper, IValidator<_order_UpdateDTO_request> validator, IRepository_order_update order_Repository_update, IRepository_order_respons order_Repository_respons, IRepository_product_respons product_Repository_respons, IRepository_customer_respons customer_Repository_respons, IRepository_UnitOfWork unitOfWork_Repository)
        {
            this.mapper = mapper;
            this.validator = validator;
            this.order_Repository_update = order_Repository_update;
            this.order_Repository_respons = order_Repository_respons;
            this.product_Repository_respons = product_Repository_respons;
            this.customer_Repository_respons = customer_Repository_respons;
            this.unitOfWork_Repository = unitOfWork_Repository;
        }

        public async Task<_order_UpdateDTO_respons> Handle(_order_UpdateDTO_request order_UpdateDTO_request, CancellationToken cancellationToken)
        {
            //Validation
            var result = await validator.ValidateAsync(order_UpdateDTO_request);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    throw new Exception($"Validation Error: {error.ErrorMessage} for the property: {error.PropertyName}");
                }
            }

            // Updating to database
            await order_Repository_update._order_Method_update(order_UpdateDTO_request._order_oldCode, order_UpdateDTO_request._order_newCode, order_UpdateDTO_request._order_newDeedline);

            //Saving changes
            await unitOfWork_Repository.Save(cancellationToken);

            //Result
            var orderFromdb = await order_Repository_respons._order_Method_respons(order_UpdateDTO_request._order_newCode);

            // Mapping Entity to DTO
            var respons = mapper.Map<_order_UpdateDTO_respons>(orderFromdb);
            var customer = await customer_Repository_respons._customer_Method_respons(orderFromdb._order_customer_PIN);
            var product = await product_Repository_respons._product_Method_respons(orderFromdb._order_product_Barcode);
            respons._order_customer_Name = customer._customer_Name;
            respons._order_product_Name = product._product_Name;

            //Respons
            return respons;
        }
    }
}
