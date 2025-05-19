using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderingSystem.Core.Bases;
using OrderingSystem.Shared.DTOs.Orders;

namespace OrderingSystem.Core.Features.Orders.Queries.Models
{
    public record GetOrderByIdQuery(int OrderId) : IRequest<Response<OrderDTO>>
    {
        public int OrderId { get; set; } = OrderId;
    }
}
