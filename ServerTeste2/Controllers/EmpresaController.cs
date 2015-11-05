using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServerTeste2.Models;
using Newtonsoft.Json.Linq;
using System.Data.Common;
using Newtonsoft.Json;
using System.IO;

namespace ServerTeste2.Controllers
{

    public class EmpresaController : ApiController
    {
        public struct profissional
        {
            public string nomeCliente;
            public int idEmpresaCliente;
            public int idEmpresaServico;
            public string especializacaoCliente;
        }
        

        [Route("empresas/listFuncionarios")]
        [HttpPost]
        [Authorize]
        public HttpResponseMessage ListarFuncionariosEmpresa([FromBody]JObject model)
        {

            try
            {
                dynamic json = model["ListServicosSelecionados"];
                //List<int> idList = json.Object.ToList<>();
                List<profissional> listProfissional = new List<profissional>();
                //List<int> listaId = json.ListServicosSelecionados;
                var xixi = new JsonSerializer().Deserialize(new StringReader(json), typeof(List<Int32>)) as List<Int32>;
                DBContext db = new DBContext();
                foreach (int id in json.ListServicosSelecionados)
                {
                    var query = (from ecs in db.EmpresaClienteServico
                                 join ec in db.EmpresaCliente on ecs.idEmpresaCliente equals ec.idEmpresaCliente
                                 join c in db.Cliente on ec.idCliente equals c.idCliente
                                 where ecs.idEmpresaServico == id
                                 select new profissional
                                 {
                                     nomeCliente = c.nomeCliente + ' ' + c.sobrenomeCliente,
                                     idEmpresaCliente = ec.idEmpresaCliente,
                                     idEmpresaServico = ecs.idEmpresaServico,
                                     especializacaoCliente = ec.especializacaoCliente +
                                         (ec.especializacao2Cliente != "" ? " - " + ec.especializacao2Cliente : "") +
                                         (ec.especializacao3Cliente != "" ? " - " + ec.especializacao3Cliente : "")

                                 }).ToList();

                    foreach (profissional x in query)
                    {
                        listProfissional.Add(x);
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, listProfissional);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("empresas/listServicos")]
        [HttpPost]
        [Authorize]
        public HttpResponseMessage ListarServicosEmpresa([FromBody]JObject model)
        {
            try
            {
                List<EmpresaServico> servicos = new List<EmpresaServico>();
                dynamic json = model;
                int id = 0;
                id = json.idEmpresaServico;
                DBContext db = new DBContext();
                var query = from es in db.EmpresaServico
                            join s in db.Servico on es.idServico equals s.idServico
                            orderby s.idCategoria, s.nomeServico
                            where es.idEmpresa == id
                            select es;

                foreach (EmpresaServico es in query)
                {
                    servicos.Add(es);
                }

                return Request.CreateResponse(HttpStatusCode.OK, servicos);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        [Route("empresas/listEmpresas")]
        [HttpPost]
        [Authorize]
        public HttpResponseMessage ListarCategorias([FromBody]JObject model)
        {
            try
            {
                List<Empresa> empresas = new List<Empresa>();
                dynamic json = model;
                using (DBContext db = new DBContext())
                {

                    var query = db.Empresa.SqlQuery("select e.* from Empresas e " +
                        " where e.idEmpresa in ( " +
                        "     select es.idEmpresa from EmpresaServico es where " +
                        "     es.idServico in (select s.idServico from Servicos s where idCategoria = " + json.idCategoria + ")) " +
                        "     and e.cidadeEmpresa = (Select cli.cidadeCliente from Clientes cli " +
                        "         where cli.idCliente = (select u.idCliente from Usuarios u where idUsuario = " + json.idUsuario + ")) " +
                        "     and e.estadoEmpresa = (Select cli.estadoCliente from Clientes cli " +
                        "         where cli.idCliente = (select u.idCliente from Usuarios u where idUsuario = " + json.idUsuario + ")) " +
                        "     order by e.bairroEmpresa ");
                    foreach (Empresa e in query)
                    {
                        empresas.Add(e);
                    }
                    foreach (Empresa e in empresas)
                    {
                        db.SaveChanges();
                        var query2 = (from s in db.Servico
                                      join es in db.EmpresaServico on e.idEmpresa equals es.idEmpresa
                                      where s.idServico == es.idServico
                                      select s.tipoServico).Distinct();
                        string tipoServico = "";
                        foreach (string tipo in query2)
                        {
                            tipoServico += tipo + " ";
                        }
                        e.tipoServico = tipoServico;

                    }


                }
                return Request.CreateResponse(HttpStatusCode.OK, empresas);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("api/addempresa")]
        [HttpPost]
        [Authorize]
        public HttpResponseMessage CadastroEmpresa(Empresa c)
        {
            try
            {
                using (DBContext db = new DBContext())
                {

                    db.Database.CreateIfNotExists();
                    db.Empresa.Add(c);
                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Cadastro da empresa " + c.nomeEmpresa + " realizado.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [Route("api/empaddservico")]
        [HttpPost]
        public HttpResponseMessage AddCategoria(EmpresaServico c)
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    db.Database.CreateIfNotExists();
                    db.EmpresaServico.Add(c);
                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Cadastro do servico " + c.servico.nomeServico + " na empresa " + c.empresa.nomeEmpresa + " realizado.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [Route("api/empaddempregado")]
        [HttpPost]
        public HttpResponseMessage AddEmpregado(EmpresaCliente c)
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    db.Database.CreateIfNotExists();
                    db.EmpresaCliente.Add(c);
                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Cadastro do servico " + c.cliente.nomeCliente + " na empresa " + c.empresa.nomeEmpresa + " realizado.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
    }
}
