using AutoMapper;
using GalinhaCaipira.Domain.Entities;
using GalinhaCaipira.MVC.AutoMapper;
using GalinhaCaipira.MVC.Infrastructure.ErrorHandlers;
using GalinhaCaipira.MVC.ViewModels;
using GalinhaCaipira.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GalinhaCaipira.MVC.Controllers
{
    public class AuthenticationController : GalinhaControllerBase
    {
        private readonly IControleAcessoService controleAcessoService;
        private readonly IMapper mapper;

        public AuthenticationController(IControleAcessoService controleAcessoService, IMapper mapper)
        {
            this.controleAcessoService = controleAcessoService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(RegistroViewModel registro)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = controleAcessoService.RegistrarUsuario(mapper.Map<Usuario>(registro), registro.NomeGranja);

                if (usuario.Valid)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    RegistrarModelError(usuario);
                }
            }

            return View(registro);
        }
    }
}