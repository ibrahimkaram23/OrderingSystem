using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using OrderingSystem.Core.Features.Orders.Commands.Models;

namespace OrderingSystem.Core.Features.Orders.Commands.Validators
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer ID is required.");
            RuleFor(x => x.OrderItems)
                .NotEmpty().WithMessage("Order items are required.");
            RuleForEach(x => x.OrderItems)
                .ChildRules(orderItem =>
                {
                    orderItem.RuleFor(x => x.ProductId)
                        .NotEmpty().WithMessage("Product ID is required.");
                    orderItem.RuleFor(x => x.Quantity)
                        .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
                });
        }
    }
}
