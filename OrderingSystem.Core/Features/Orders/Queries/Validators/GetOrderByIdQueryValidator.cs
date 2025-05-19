
using FluentValidation;
using OrderingSystem.Core.Features.Orders.Queries.Models;

namespace OrderingSystem.Core.Features.Orders.Queries.Validators
{
    public class GetOrderByIdQueryValidator : AbstractValidator<GetOrderByIdQuery>
    {
        public GetOrderByIdQueryValidator()
        {
            RuleFor(x => x.OrderId)
                .NotEmpty()
                .WithMessage("Order ID is required.");
        }
    }
}
