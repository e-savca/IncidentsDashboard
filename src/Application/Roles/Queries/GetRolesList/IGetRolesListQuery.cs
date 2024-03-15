﻿
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Roles.Queries.GetRolesList
{
    public interface IGetRolesListQuery
    {
        Task<List<RolesListItemModel>> ExecuteAsync();
    }
}
