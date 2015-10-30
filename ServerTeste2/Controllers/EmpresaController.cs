﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServerTeste2.Models;
using Newtonsoft.Json.Linq;
using System.Data.Common;

namespace ServerTeste2.Controllers
{

    public class EmpresaController : ApiController
    {

        [Route("empresas/listServicos")]
        [HttpPost]
        [Authorize]
        public HttpResponseMessage ListarServicosEmpresa([FromBody]JObject model)
        {
            try
            {
                List<EmpresaServicos> servicos = new List<EmpresaServicos>();
                dynamic json = model;
                int id = 0;
                DBContext db = new DBContext();
                
                    id = json.idEmpresa;
                var query = from es in db.EmpresaServicos
                             join s in db.Servico on es.idServico equals s.idServico
                             join e in db.Empresa on es.idEmpresa equals e.idEmpresa
                             orderby s.idCategoria, s.nomeServico
                             where es.idEmpresa == id

                             select es;

                    foreach (EmpresaServicos es in query)
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
                        "     select es.idEmpresa from EmpresaServicos es where " +
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
                                      join es in db.EmpresaServicos on e.idEmpresa equals es.idEmpresa
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
        public HttpResponseMessage AddCategoria(EmpresaServicos c)
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    db.Database.CreateIfNotExists();
                    db.EmpresaServicos.Add(c);
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
