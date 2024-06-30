using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class DeleteAddressCommand
    {
        public int AddressId { get; set; }

        public DeleteAddressCommand(int addressId)
        {
            AddressId = addressId;
        }
    }
}
