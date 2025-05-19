using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderingSystem.Core.Bases;
using OrderingSystem.Shared.Enums;

namespace OrderingSystem.Core.Features.Orders.Commands.Models
{
    public class UpdateOrderStatusCommand : IRequest<Response<string>>
    {
        public int OrderId { get; set; }
        public OrderStatusEnum StatusId { get; set; }
    }
}
