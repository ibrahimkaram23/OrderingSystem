using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Localization;
using OrderingSystem.Core.Bases;
using OrderingSystem.Core.Features.Orders.Commands.Models;
using OrderingSystem.Core.Resources;
using OrderingSystem.infrastructure.Data;

namespace OrderingSystem.Core.Features.Orders.Commands.Handlers
{
    public class UpdateOrderStatusCommandHandler : ResponseHandler, IRequestHandler<UpdateOrderStatusCommand, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly APPDBContext _context;

        public UpdateOrderStatusCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, APPDBContext context) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _context = context;
        }

        public async Task<Response<string>> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FindAsync(request.OrderId);
            if (order == null)
            {
                return NotFound<string>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }
            order.StatusId = (int)request.StatusId;
            order.StatusUpdateDate = DateTime.UtcNow;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync(cancellationToken);
            return Success<string>(_stringLocalizer[SharedResourcesKeys.Success]);
        }
    }
}
