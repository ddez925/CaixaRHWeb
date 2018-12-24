using CaixaRHWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaixaRHWeb.Controllers
{
    public class AvaGestorController : Controller
    {
        public List<AvaGestorModel> _listaAvaGestor = new List<AvaGestorModel>();

        public ActionResult AvaGestorView()
        {
            PreGestorController PreGesController = new PreGestorController();
            var ListPreGest = PreGesController._listaPerguntasGes();
            return View(ListPreGest);
        }

    }
}