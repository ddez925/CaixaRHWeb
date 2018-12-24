using CaixaRHWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CaixaRHWeb.Controllers
{
    public class PreGestorController : Controller
    {
        // GET: PreGestor
        private static List<PreGestorModel> _listaPerguntasGestor = new List<PreGestorModel>()
        {
           new PreGestorModel() { Id=1, NomePergunta="Considere o quanto atua diretamente em seu próprio desenvolvimento e age antecipadamente e com velocidade, sem que lhe peçam, demonstrando atitude de dono do processo",
               NomeResposta ="Não atende", NomeResposta2 ="Atende parcialmente",  NomeResposta3 ="Atende o esperado", NomeResposta4 ="Supera o esperado", Ativo =false },
           new PreGestorModel() { Id=2, NomePergunta="Considere o quanto apresenta capacidade de explorar novas ideias para além do contexto atual, propondo tendências de novos produtos e serviços", Ativo=false },
           new PreGestorModel() { Id=3, NomePergunta="Considere o quanto é visto como uma pessoa que trabalha bem em grupo e coopera com todos, valorizando a comunicação interpessoal e o consenso", Ativo=false },
           new PreGestorModel() { Id=4, NomePergunta="Considere o quanto realiza um atendimento ao cliente interno ou externo que demonstre disponibilidade, simpatia, alinhamento de expectativas e foco na resolução de problemas", Ativo=false },
           new PreGestorModel() { Id=5, NomePergunta="Considere o quanto consegue se comunicar com clareza, demonstrando segurança, sendo capaz de expressar suas opiniões e respeitando os diferentes pontos de vista", Ativo=false },
           new PreGestorModel() { Id=6, NomePergunta="Considere o quanto demonstra habilidade nas atividades que realiza, assimilando o trabalho com facilidade e mantendo o ritmo", Ativo=false },
           new PreGestorModel() { Id=7, NomePergunta="Considere o quanto se compromete com as entregas, visando qualidade e cumprimento de prazos", Ativo=false },
           new PreGestorModel() { Id=8, NomePergunta="Você acredita que o seu funcionário está adaptado com a cultura da Caixa Seguradora, demonstrando integração com as atividades, responsabilidades do cargo e às normas e políticas da Empresa?", Ativo=false },
           new PreGestorModel() { Id=9, NomePergunta="Foram identificadas necessidades de desenvolvimento quanto: Competências técnicas", Ativo=false }
        };


        public ActionResult PreGestorView()
        {
            return View(_listaPerguntasGestor);
        }

        public List<PreGestorModel> _listaPerguntasGes()
        {
            return (_listaPerguntasGestor);
        }

        [HttpPost]
        public ActionResult RecuperarGrupoPergunta(int id)
        {
            return Json(_listaPerguntasGestor.Find(x => x.Id == id));
        }

        [HttpPost]

        public ActionResult ExcluirGrupoPerguntaGes(int id)
        {
            var ret = false;

            var registroBD = _listaPerguntasGestor.Find(x => x.Id == id);
            if (registroBD != null)
            {
                _listaPerguntasGestor.Remove(registroBD);
                ret = true;
            }

            return Json(ret);
        }

        [HttpPost]

        public ActionResult SalvarGrupoPerguntaGes(PreGestorModel model)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var idSalvo = string.Empty;

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var registroBD = _listaPerguntasGestor.Find(x => x.Id == model.Id);

                    if (registroBD == null)
                    {
                        registroBD = model;
                        registroBD.Id = _listaPerguntasGestor.Max(x => x.Id) + 1;
                        _listaPerguntasGestor.Add(registroBD);
                    }
                    else
                    {
                        registroBD.NomePergunta = model.NomePergunta;
                        registroBD.NomeResposta = model.NomeResposta;
                        registroBD.NomeResposta2 = model.NomeResposta2;
                        registroBD.NomeResposta3 = model.NomeResposta3;
                        registroBD.NomeResposta4 = model.NomeResposta4;
                        registroBD.Ativo = model.Ativo;
                    }
                    idSalvo = registroBD.Id.ToString();
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }
            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
        }


    }
}