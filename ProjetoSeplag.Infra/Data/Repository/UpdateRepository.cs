using Microsoft.EntityFrameworkCore;
using ProjetoSeplag.Domain.Updates.Entitys;
using ProjetoSeplag.Domain.Updates.Repository;
using ProjetoSeplag.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSeplag.Infra.Data.Repository
{
    public class UpdateRepository : IUpdateRepository
    {
        private readonly AplicationContext aplicationContext;
        protected readonly DbSet<UpdateEntity> DbSet;

        public UpdateRepository(AplicationContext aplicationContext)
        {
            this.aplicationContext = aplicationContext;
            DbSet = aplicationContext.Set<UpdateEntity>();
        }

        public async Task<List<UpdateEntity>> GetAll()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<UpdateEntity> GetById(string Id)
        {
            return await DbSet.AsNoTracking().Where(c => c.ID == Id).FirstOrDefaultAsync();
        }

        public async Task Insert(UpdateEntity Dto)
        {
            try
            {
                await DbSet.AddAsync(Dto);
                await aplicationContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task Update(UpdateEntity Dto)
        {
            try
            {
                DbSet.Attach(Dto);
                await aplicationContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
