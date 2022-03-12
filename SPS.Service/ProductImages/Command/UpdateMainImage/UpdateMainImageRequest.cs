using MediatR;
using SPS.Core.Models.Photos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.ProductImages.Command.UpdateMainImage
{
    public class UpdateMainImageRequest:IRequest<ProductImageModel>
    {
        public string Id { get; set; }
        public Guid ProductId { get; set; }
        public bool IsMain { get; set; } = false;
    }
}
