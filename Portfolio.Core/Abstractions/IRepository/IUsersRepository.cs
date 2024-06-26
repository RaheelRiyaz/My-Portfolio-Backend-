using Portfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.Abstractions.IRepository
{
    public interface IUsersRepository : IBaseRepository<User>
    {
    }
}
