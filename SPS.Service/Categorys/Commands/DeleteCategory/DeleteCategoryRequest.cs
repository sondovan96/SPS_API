﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Categorys.Commands.DeleteCategory
{
    public class DeleteCategoryRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
