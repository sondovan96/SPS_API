using MediatR;
using Microsoft.AspNetCore.Http;
using SPS.Core.Models.Photos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.ProductImages.Command.AddProductImage
{
    public class AddImageRequest :IRequest<ProductImageModel>
    {
        public IFormFile File { get; set; }
        public Guid ProductId { get; set; }
    }
}
