using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Products.Commands.DeleteProduct
{
    public class DeleteProductRequest:IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
