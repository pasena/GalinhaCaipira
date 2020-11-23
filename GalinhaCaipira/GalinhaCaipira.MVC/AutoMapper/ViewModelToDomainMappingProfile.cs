using AutoMapper;
using GalinhaCaipira.Domain.Entities;
using GalinhaCaipira.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalinhaCaipira.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<RegistroViewModel, Usuario>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ConstructUsing(c=> new Usuario(c.Nome, c.Sobrenome, c.Email, c.Senha));
        }
    }
}