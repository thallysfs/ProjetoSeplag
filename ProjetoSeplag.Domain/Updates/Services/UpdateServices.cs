using AutoMapper;
using ProjetoSeplag.Aplication.Updates.Dtos;
using ProjetoSeplag.Aplication.Updates.Services;
using ProjetoSeplag.Domain.Updates.Entitys;
using ProjetoSeplag.Domain.Updates.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSeplag.Domain.Updates.Services
{
    public class UpdateServices : IUpdateServices
    {
        private readonly IUpdateRepository updateRepository;
        private readonly IMapper mapper;

        public UpdateServices(IUpdateRepository updateRepository, IMapper mapper)
        {
            this.updateRepository = updateRepository;
            this.mapper = mapper;
        }

        public async Task<List<ValuesDto>> GetAll()
        {
            var lista = await updateRepository.GetAll();
            return mapper.Map<List<ValuesDto>>(lista);
        }

        public async Task<UpdatesDto> GetById(string Id)
        {
            var dto = await updateRepository.GetById(Id);
            return mapper.Map<UpdatesDto>(dto);
        }

        public async Task Insert(UpdatesDto Dto)
        {
            foreach (var item in Dto.value)
            {
                try
                {
                    //var entity = await GetById(item.ID);
                    //if (entity != null)
                    //{
                    //    await updateRepository.Update(mapper.Map<UpdateEntity>(item));
                    //}
                    //else
                    //{
                        await updateRepository.Insert(mapper.Map<UpdateEntity>(item));
                    //}
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }

        public async Task Update(UpdatesDto Dto)
        {
            await updateRepository.Update(mapper.Map<UpdateEntity>(Dto));
        }
    }
}
