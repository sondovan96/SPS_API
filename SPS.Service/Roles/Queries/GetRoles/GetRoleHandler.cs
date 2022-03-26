using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SPS.Core.Models.Role;
using SPS.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SPS.Service.Roles.Queries.GetRoles
{
    public class GetRoleHandler : IRequestHandler<GetRoleRequest, List<RoleModel>>
    {
        private readonly RoleManager<Role> _roleManager;

        public GetRoleHandler(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<RoleModel>> Handle(GetRoleRequest request, CancellationToken cancellationToken)
        {
            return await _roleManager.Roles.Select(x => new RoleModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
        }
    }
}
