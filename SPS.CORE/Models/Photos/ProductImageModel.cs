using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Core.Models.Photos
{
    public class ProductImageModel
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
    }
}
