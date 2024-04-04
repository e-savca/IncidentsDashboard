using Application.Interfaces;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Data.Entity;
using Common.Models;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User.Queries.GetUsersList
{
    public class GetUsersListQuery : IRequest<DataTableResponseModel<UsersListItemModel>>
    {
        public string Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public string Search { get; set; }
        public string SortColumnName { get; set; }
        public string SortDirection { get; set; }
    }
    public class GetUsersListHandler : IRequestHandler<GetUsersListQuery, DataTableResponseModel<UsersListItemModel>>
    {
        private readonly IDatabaseService _database;
        private readonly IMapper _mapper;

        public GetUsersListHandler(
            IDatabaseService database,
            IMapper mapper
            )
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task<DataTableResponseModel<UsersListItemModel>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            // Get data from database as IQueryable for better query composition and deferred execution
            var usersQuery = _database.Users
                .Include(u => u.UserRoles.Select(ur => ur.Role))
                .AsQueryable();

            int _recordsTotal = usersQuery.Count();

            // search
            if (!string.IsNullOrEmpty(request.Search))
            {
                usersQuery = usersQuery.Where(x =>
                    x.Username.ToLower().Contains(request.Search.ToLower())
                    || x.FirstName.ToLower().Contains(request.Search.ToLower())
                    || x.LastName.ToLower().Contains(request.Search.ToLower())
                    || x.Email.ToLower().Contains(request.Search.ToLower())
                    || x.UserRoles.Select(ur => ur.Role.Name)
                        .Any(r => r.ToLower().Contains(request.Search.ToLower()))
                );
            }

            // sort
            if (!string.IsNullOrEmpty(request.SortColumnName) && !string.IsNullOrEmpty(request.SortDirection))
            {
                usersQuery = usersQuery.OrderBy($"{request.SortColumnName} {request.SortDirection}");
            }
            else
            {
                usersQuery = usersQuery.OrderByDescending(x => x.Username);
            }

            int _recordsFiltered = usersQuery.Count();

            // paging
            var users = await usersQuery.Skip(request.Start).Take(request.Length).ToListAsync(cancellationToken);

            var response = new DataTableResponseModel<UsersListItemModel>
            {
                draw = request.Draw,
                recordsTotal = _recordsTotal,
                recordsFiltered = _recordsFiltered,
                data = _mapper.Map<List<UsersListItemModel>>(users)
            };

            return response;
        }
    }
}
