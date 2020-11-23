using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GalinhaCaipira.MVC.Controllers
{
    [Authorize]
    public class GalinhaControllerBase : Controller
    {
        public JsonResult MensagemSucesso(string titulo, string mensagem) => Json(new { success = true, title = titulo, message = mensagem, messageType = 1 }, JsonRequestBehavior.AllowGet);

        public JsonResult MensagemSucessoRedirect(string titulo, string mensagem, string controller, string action) => Json(new { success = true, titulo, mensagem, controller, action, messageType = 1 }, JsonRequestBehavior.AllowGet);

        public JsonResult MensagemAlerta(string titulo, string mensagem) => Json(new { success = false, title = titulo, message = mensagem, messageType = 2 }, JsonRequestBehavior.AllowGet);

        public JsonResult MensagemAlerta(string mensagem) => Json(new { success = false, title = "ATENÇÃO", message = mensagem, messageType = 2 }, JsonRequestBehavior.AllowGet);

        public JsonResult MensagemErro(string mensagem) => Json(new { success = false, title = "ERRO", message = mensagem, messageType = 3 }, JsonRequestBehavior.AllowGet);

        protected void RegistrarModelError(Notifiable model)
        {
            foreach (var notification in model.Notifications)
            {
                ModelState.AddModelError(notification.Property, notification.Message);
            }
        }
    }
}