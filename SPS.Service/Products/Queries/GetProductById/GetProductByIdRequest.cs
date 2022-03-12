using MediatR;
using SPS.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SPS.Service.Products.Queries.GetProductById
{
    public class GetProductByIdRequest:IRequest<ProductModel>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
