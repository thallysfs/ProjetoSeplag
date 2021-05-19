using ProjetoSeplag.Domain.Updates.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSeplag.Domain.Updates.Repository
{
    public interface IUpdateRepository
    {
        void Insert(UpdateEntity Dto);

        UpdateEntity GetById(string Id);

        List<UpdateEntity> GetAll();

    }
}
