using AutoMapper;
using ProjetoSeplag.Aplication.Updates.Dtos;
using ProjetoSeplag.Domain.Updates.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSeplag.Services.AutoMapper
{
    public class UpdateMappingProfile : Profile
    {
        public UpdateMappingProfile()
        {
            CreateMap<UpdateEntity, ValuesDto>().ReverseMap().ConstructUsing(e => new UpdateEntity(
                e.ID,
                e.Alias,
                e.DocumentTitle,
                e.Severity,
                e.InitialReleaseDate,
                e.CurrentReleaseDate,
                e.CvrfUrl
                ));

        }
    }
}
