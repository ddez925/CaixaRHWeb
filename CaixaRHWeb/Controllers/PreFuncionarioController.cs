using CaixaRHWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaixaRHWeb.Controllers
{
    public class PreFuncionarioController : Controller
    {
       // GET: PreFuncionario
            public static List<PreFuncionarioModel> _listaPerguntasFuncionario = new List<PreFuncionarioModel>()
        {
            new PreFuncionarioModel() { Id=1,NomePergunta="Considere o quanto você atua diretamente em seu próprio desenvolvimento e age antecipadamente e com velocidade, sem que lhe peçam, demonstrando atitude de dono do processo",
               NomeResposta ="Não atende", NomeResposta2 ="Atende parcialmente",  NomeResposta3 ="Atende o esperado", NomeResposta4 ="Supera o esperado", Ativo =false },
           new PreFuncionarioModel() { Id=2,NomePergunta="Considere o quanto você apresenta capacidade de explorar novas ideias para além do contexto atual, propondo tendências de novos produtos e serviços", Ativo=true },
           new PreFuncionarioModel() { Id=3,NomePergunta="Considere o quanto você é visto como uma pessoa que trabalha bem em grupo e coopera com todos, valorizando a comunicação interpessoal e o consenso", Ativo=false },
           new PreFuncionarioModel() { Id=4,NomePergunta="Considere o quanto você realiza um atendimento ao cliente interno ou externo que demonstre disponibilidade, simpatia, alinhamento de expectativas e foco na resolução de problemas", Ativo=false },
           new PreFuncionarioModel() { Id=5,NomePergunta="Considere o quanto você consegue se comunicar com clareza, demonstrando segurança, sendo capaz de expressar suas opiniões e respeitando os diferentes pontos de vista", Ativo=false },
           new PreFuncionarioModel() { Id=6,NomePergunta="Considere o quanto você demonstra habilidade nas atividades que realiza, assimilando o trabalho com facilidade e mantendo o ritmo", Ativo=false },
           new PreFuncionarioModel() { Id=7,NomePergunta="Considere o quanto você se compromete com as entregas, visando qualidade e cumprimento de prazos", Ativo=false },
           new PreFuncionarioModel() { Id=8,NomePergunta="Você se sente satisfeito em relação as suas expectativas iniciais relacionadas à empresa?", Ativo=false },
         };

            public List<PreFuncionarioModel> _listaPerguntasFun()
            {
                return (_listaPerguntasFuncionario);
            }
                   
            public ActionResult PreFuncionarioView()
            {
                return View(_listaPerguntasFuncionario);
            }

            [HttpPost]
       
            public ActionResult GetPergunta(int id)
            {
                return Json(_listaPerguntasFuncionario.Find(x => x.Id == id));
            }

            [HttpPost]
           
            public ActionResult DeletePergunta(int id)
            {
                var ret = false;

                var registroBD = _listaPerguntasFuncionario.Find(x => x.Id == id);
                if (registroBD != null)
                {
                    _listaPerguntasFuncionario.Remove(registroBD);
                    ret = true;
                }

                return Json(ret);
            }

            [HttpPost]
      
            public ActionResult SavePergunta(PreFuncionarioModel model)
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
                        var registroBD = _listaPerguntasFuncionario.Find(x => x.Id == model.Id);

                        if (registroBD == null)
                        {
                            registroBD = model;
                            registroBD.Id = _listaPerguntasFuncionario.Max(x => x.Id) + 1;
                            _listaPerguntasFuncionario.Add(registroBD);
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