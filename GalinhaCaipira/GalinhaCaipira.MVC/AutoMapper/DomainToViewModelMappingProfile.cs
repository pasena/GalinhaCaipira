using AutoMapper;
using GalinhaCaipira.Domain.Entities;
using GalinhaCaipira.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalinhaCaipira.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, RegistroViewModel>();
        }
    }
}