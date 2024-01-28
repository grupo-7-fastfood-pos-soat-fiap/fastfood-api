using Dapper;
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Domain.Models.Enums;
using FastFoodFIAP.Domain.Models.PedidoAggregate;
using FastFoodFIAP.Domain.Models.ProdutoAggregate;
using FastFoodFIAP.Infra.Data.Context;
using GenericPack.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Text.Json.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FastFoodFIAP.Infra.Data.Repository
{
    public class PedidoRepository: IPedidoRepository
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<Pedido> DbSet;
        public readonly IDbConnection Connection;

        public PedidoRepository(AppDbContext context, IDbConnection connection)
        {
            Db = context;
            DbSet = Db.Set<Pedido>();

            Connection = connection;
            Connection.ConnectionString = Db.Database.GetConnectionString();
        }
        public IUnitOfWork UnitOfWork => Db;

        public async Task<IEnumerable<Pedido>> GetAll()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Pedido>> GetAllAtivos(List<Guid> lista)
        {
            try
            {
                return await DbSet.AsNoTracking()
                .Where(c => lista.Any(id => c.Id == id))
                .ToListAsync();                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Pedido>> GetAllBySituacao(List<Guid> lista)
        {            
            return await DbSet.AsNoTracking()
                 .Where(c => lista.Any(id => c.Id == id))
                 .ToListAsync();        
        }

        public async Task<Pedido?> GetById(Guid id)
        {
            return await DbSet.AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public void Add(Pedido pedido)
        {
            DbSet.Add(pedido);                    
        }

        public void Remove(Pedido pedido)
        {
            DbSet.Remove(pedido);
        }

        public void Update(Pedido pedido)
        {
            var combos = Db.PedidosCombos!.Where(p => p.PedidoId == pedido.Id).AsNoTracking();
            if (combos != null) 
                Db.PedidosCombos!.RemoveRange(combos);

            DbSet.Update(pedido);          
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
