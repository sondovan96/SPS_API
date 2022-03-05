using MediatR;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Categorys.Commands.UpdateCategory
{
    public class UpdateCategoryRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public Guid? ParentId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
