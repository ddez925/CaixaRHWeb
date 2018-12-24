using CaixaRHWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CaixaRHWeb.Controllers
{
    public class AvaFuncionarioController : Controller
    {

        public List<AvaFuncionarioModel> _listaAvaFuncionario = new List<AvaFuncionarioModel>();

        public ActionResult AvaFuncionarioView()
        {            
            PreFuncionarioController PreFunController = new PreFuncionarioController();
            var ListPreFun = PreFunController._listaPerguntasFun();
            return View(ListPreFun);
        }


    }
}
 