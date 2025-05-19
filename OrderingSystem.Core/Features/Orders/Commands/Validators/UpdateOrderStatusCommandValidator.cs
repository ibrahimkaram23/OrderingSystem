using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using OrderingSystem.Core.Features.Orders.Commands.Models;
using OrderingSystem.Shared.Enums;

namespace OrderingSystem.Core.Features.Orders.Commands.Validators
{
    public class UpdateOrderStatusCommandValidator : AbstractValidator<UpdateOrderStatusCommand>
    {
        public UpdateOrderStatusCommandValidator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty()
                .WithMessage("Order ID is required.");
            RuleFor(x => x.StatusId)
                .NotEmpty()
                .WithMessage("Status is required.")
                .IsInEnum()
                .WithMessage("Invalid status value.");


        }
    }
}
