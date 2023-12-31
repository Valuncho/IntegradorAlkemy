﻿using Integrador.DataAccess;
using TechOil.DataAccess.Repositories;

namespace Integrador.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UserRepository UserRepository { get; private set; }
        public JobRepository JobRepository { get; private set; }
        public ServiceRepository ServiceRepository { get; private set; }
        public ProjectRepository ProjectRepository { get; private set; }

        public UnitOfWorkService(ApplicationDbContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            JobRepository = new JobRepository(_context);
            ServiceRepository = new ServiceRepository(_context);
            ProjectRepository = new ProjectRepository(_context);

        }

        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }
    }
}
