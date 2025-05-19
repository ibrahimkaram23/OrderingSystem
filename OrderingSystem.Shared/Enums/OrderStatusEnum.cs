using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Shared.Enums
{
    public enum OrderStatusEnum
    {
        Pending = 1,
        Processing = 2,
        Completed = 3,
        Cancelled = 4,
        Refunded = 5,
        Failed = 6
    }
}
