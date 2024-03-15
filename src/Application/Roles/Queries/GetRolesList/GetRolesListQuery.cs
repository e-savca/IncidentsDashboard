using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Application.Roles.Queries.GetRolesList
{
    public class GetRolesListQuery : IGetRolesListQuery
    {
        private readonly IDatabaseService _database;
        public GetRolesListQuery(
            IDatabaseService database
            )
        {
            _database = database;
        }
        public async Task<List<RolesListItemModel>> ExecuteAsync()
        {
            var roles = await _database.Roles.ToListAsync();
            var roleDtos = roles.ConvertAll(r => new RolesListItemModel
            {
                Id = r.Id,
                Name = r.Name
            });
            return roleDtos;
        }
    }
}
