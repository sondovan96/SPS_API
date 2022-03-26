using MediatR;
using SPS.Core.Models.Role;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPS.Service.Roles.Queries.GetRoles
{
    public class GetRoleRequest:IRequest<List<RoleModel>>
    {
    }
}
