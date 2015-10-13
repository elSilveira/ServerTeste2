using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServerTeste2.Models;

namespace ServerTeste2.Controllers
{
    
    public class EmpresaController : ApiController
    {
        private DBContext db = new DBContext();

        [Route("api/addempresa")]
        [HttpPost]
        public HttpResponseMessage CadastroEmpresa(Empresa c)
        {
            try
            {
                db.Database.CreateIfNotExists();
                db.Empresa.Add(c);
                db.SaveChanges();
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
                db.Database.CreateIfNotExists();
                db.EmpresaServicos.Add(c);
                db.SaveChanges();
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
                db.Database.CreateIfNotExists();
                db.EmpresaCliente.Add(c);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Cadastro do servico " + c.cliente.nomeCliente + " na empresa " + c.empresa.nomeEmpresa + " realizado.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
    }
}
