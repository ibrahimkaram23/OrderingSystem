using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using OrderingSystem.Core.Bases;
using OrderingSystem.Core.Features.Orders.Queries.Models;
using OrderingSystem.Core.Resources;
using OrderingSystem.infrastructure.Data;
using OrderingSystem.Shared.DTOs.Orders;

namespace OrderingSystem.Core.Features.Orders.Queries.Handlers
{

    public class GetOrderByIdQueryHandler : ResponseHandler, IRequestHandler<GetOrderByIdQuery, Response<OrderDTO>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        private readonly APPDBContext _context;
        public GetOrderByIdQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper, APPDBContext context) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _context = context;
        }
        public async Task<Response<OrderDTO>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)!
                .ThenInclude(oi => oi.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken);
            if (order == null)
            {
                return NotFound<OrderDTO>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            }
            var orderDto = _mapper.Map<OrderDTO>(order);
            return Success(orderDto);
        }
    }
}
