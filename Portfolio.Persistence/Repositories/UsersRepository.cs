﻿using Portfolio.Core.Abstractions.IRepository;
using Portfolio.Domain.Models;
using Portfolio.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Persistence.Repositories
{
    public class UsersRepository : BaseRepository<User>, IUsersRepository
    {
        public UsersRepository(RaheelPortfolioDbContext dbContext) : base(dbContext)
        {
        }
    }
}
