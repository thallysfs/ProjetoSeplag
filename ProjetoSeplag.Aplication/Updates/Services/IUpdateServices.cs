using ProjetoSeplag.Aplication.Updates.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSeplag.Aplication.Updates.Services
{
    public interface IUpdateServices
    {
        Task Insert(UpdatesDto Dto);

        Task<ValuesDto> GetById(string Id);

        Task<List<ValuesDto>> GetAll();

        Task Update(UpdatesDto Dto);




    }
}
