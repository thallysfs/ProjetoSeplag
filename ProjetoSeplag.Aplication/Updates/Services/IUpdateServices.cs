using ProjetoSeplag.Aplication.Updates.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSeplag.Aplication.Updates.Services
{
    public interface IUpdateServices
    {
        void Insert(UpdatesDto Dto);

        UpdatesDto GetById(string Id);

        List<UpdatesDto> GetAll();


            

    }
}
