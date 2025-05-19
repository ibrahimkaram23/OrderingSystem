
using MediatR;
using Microsoft.Extensions.Localization;
using OrderingSystem.Core.Bases;
using OrderingSystem.Core.Features.Orders.Commands.Models;
using OrderingSystem.Core.Resources;
using OrderingSystem.Data.Entities.Orders;
using OrderingSystem.infrastructure.Data;

namespace OrderingSystem.Core.Features.Orders.Commands.Handlers
{
    public class CreateOrderCommandHandler : ResponseHandler, IRequestHandler<CreateOrderCommand, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly APPDBContext _context;

        public CreateOrderCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, APPDBContext context) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _context = context;
        }

        public async Task<Response<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            using (var trans = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var order = new Order
                    {
                        CustomerId = request.CustomerId,
                        OrderDate = DateTime.UtcNow,
                        StatusId = 1,
                        StatusUpdateDate = DateTime.UtcNow,
                    };
                    await _context.Orders.AddAsync(order, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                    foreach (var item in request.OrderItems)
                    {
                        var product = await _context.Products.FindAsync(item.ProductId);
                        if (product != null)
                        {
                            if (product.StockQuantity < item.Quantity)
                            {
                                await trans.RollbackAsync();
                                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.InsufficientStock]);
                            }
                            var orderItem = new OrderItem
                            {
                                OrderId = order.Id,
                                ProductId = item.ProductId,
                                Quantity = item.Quantity,
                                Price = product.SystemPrice,
                            };
                            await _context.OrderItems.AddAsync(orderItem, cancellationToken);
                            product.StockQuantity -= item.Quantity;
                            _context.Products.Update(product);
                        }
                        else 
                        {
                            await trans.RollbackAsync();
                            return NotFound<string>(_stringLocalizer[SharedResourcesKeys.ProductNotFound]);
                        }
                    }
                    await _context.SaveChangesAsync(cancellationToken);
                    trans.Commit();
                    return Success<string>(_stringLocalizer[SharedResourcesKeys.OrderCreatedSuccessfully]);
                }
                catch (Exception)
                {
                    await trans.RollbackAsync();
                    return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FaildToAddOrder]);
                }
            }
        }
    }
}
