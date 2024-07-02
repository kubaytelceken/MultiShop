using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands
{
    public class DeleteOrderDetailCommand
    {
       
        public int OrderDetailId { get; set; }

        public DeleteOrderDetailCommand(int orderDetailId)
        {
            OrderDetailId = orderDetailId;
        }


    }
}
