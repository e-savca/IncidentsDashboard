using Application.Interfaces;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public IDbSet<User> Users { get; set; }

        public DatabaseService() : base("name=DefaultConnection")
        {
            
        }
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
