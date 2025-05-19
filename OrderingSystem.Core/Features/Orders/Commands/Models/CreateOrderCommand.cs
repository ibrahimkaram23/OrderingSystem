using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OrderingSystem.Core.Bases;

namespace OrderingSystem.Core.Features.Orders.Commands.Models
{
    public class CreateOrderCommand : IRequest<Response<string>>
    {
        public int CustomerId { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
    }
    public class OrderItemDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}