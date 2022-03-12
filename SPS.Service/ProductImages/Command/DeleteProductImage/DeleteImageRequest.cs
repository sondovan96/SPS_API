using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.ProductImages.Command.DeleteProductImage
{
    public class DeleteImageRequest:IRequest<bool>
    {
        public string Id { get; set; }
        public Guid ProductId { get; set; }
    }
}
