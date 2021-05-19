using Microsoft.EntityFrameworkCore;
using ProjetoSeplag.Domain.Updates.Entitys;
using ProjetoSeplag.Domain.Updates.Repository;
using ProjetoSeplag.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public List<UpdateEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public UpdateEntity GetById(string Id)
        {
            return DbSet.Find(Id);
        }

        public void Insert(UpdateEntity Dto)
        {
            DbSet.Add(Dto);
            aplicationContext.SaveChanges();
        }
    }
}
