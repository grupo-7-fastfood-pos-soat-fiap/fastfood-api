using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Domain.Models.ProdutoAggregate;
using FastFoodFIAP.Infra.Data.Context;
using GenericPack.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodFIAP.Infra.Data.Repository
{
    public class LgpdRepository : ILgpdRepository
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<LgpdCliente> DbSet;

        public LgpdRepository(AppDbContext context)
        {
            Db = context;
            DbSet = Db.Set<LgpdCliente>();
        }
        public IUnitOfWork UnitOfWork => Db;


        public void Add(LgpdCliente lgpdCliente)
        {
            DbSet.Add(lgpdCliente);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<IEnumerable<LgpdCliente>> GetAll()
        {
            return await DbSet.AsNoTracking().OrderBy(x => x.Nome).ToListAsync();
        }

        public async Task<LgpdCliente?> GetById(Guid id)
        {
            return await DbSet.AsNoTracking().FirstAsync(x => x.Id == id);
        }
    }
}
