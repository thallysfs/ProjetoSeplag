using ProjetoSeplag.Domain.Updates.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSeplag.Domain.Updates.Repository
{
    public interface IUpdateRepository
    {
        Task Insert(UpdateEntity Dto);

        Task<UpdateEntity> GetById(string Id);

        Task<List<UpdateEntity>> GetAll();

        Task Update(UpdateEntity Dto);

    }
}
