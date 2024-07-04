using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class DeleteOrderingCommand : IRequest
    {
        public int OrderingId { get; set; }

        public DeleteOrderingCommand(int orderingId)
        {
            OrderingId = orderingId;
        }
    }
}
