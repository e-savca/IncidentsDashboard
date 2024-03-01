using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class Entity<TId> : IEntity<TId>
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>

        public TId Id { get; set; }
    }
}
