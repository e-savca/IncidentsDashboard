using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public interface IEntity<TId>
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        TId Id { get; set; }
    }
}
