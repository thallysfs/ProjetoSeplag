using AutoMapper;
using ProjetoSeplag.Aplication.Updates.Dtos;
using ProjetoSeplag.Aplication.Updates.Services;
using ProjetoSeplag.Domain.Updates.Entitys;
using ProjetoSeplag.Domain.Updates.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public List<UpdatesDto> GetAll()
        {
            return mapper.Map<List<UpdatesDto>>(updateRepository.GetAll());
        }

        public UpdatesDto GetById(string Id)
        {
            return mapper.Map<UpdatesDto>(updateRepository.GetById(Id));
        }

        public void Insert(UpdatesDto Dto)
        {
            foreach (var item in Dto.Value)
            {
                updateRepository.Insert(mapper.Map<UpdateEntity>(item));
            }
        }
    }
}
