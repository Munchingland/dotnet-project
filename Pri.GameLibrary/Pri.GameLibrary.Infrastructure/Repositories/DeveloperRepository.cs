﻿using Microsoft.Extensions.Logging;
using Pri.GameLibrary.Core.Entities;
using Pri.GameLibrary.Core.Interfaces.Repositories;
using Pri.GameLibrary.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.GameLibrary.Infrastructure.Repositories
{
    public class DeveloperRepository : BaseRepository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(ApplicationDbContext applicationDbContext, ILogger<BaseRepository<Developer>> logger) : base(applicationDbContext, logger)
        {
        }
    }
}
