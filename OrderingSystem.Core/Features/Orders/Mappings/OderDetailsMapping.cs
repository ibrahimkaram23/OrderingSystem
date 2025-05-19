using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using OrderingSystem.Data.Entities.Orders;
using OrderingSystem.Shared.DTOs.Orders;

namespace OrderingSystem.Core.Features.Orders.Mappings
{
    public class OderDetailsMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Order, OrderDTO>()
                .Map(dest => dest.CustomerName, src => src.Customer != null ? src.Customer.FullName : string.Empty)
                .Map(dest => dest.StatusName, src => src.Status != null ? src.Status.Name : string.Empty)
                .Map(dest => dest.OrderItems, src => src.OrderItems!.Select(item => new OrderItemDTO
                {
                    ProductName = item.Product != null ? item.Product.Name.GetLocalized() : string.Empty,
                    Quantity = item.Quantity,
                    Price = item.Price,
                }).ToList());
        }
    }
}
