using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServerTeste2.Models;
using Newtonsoft.Json.Linq;

namespace ServerTeste2.Controllers
{
    public class CategoriaController : ApiController
    {
        
        [Route("servicos/listCategoria")]
        [HttpGet]
        [Authorize]
        public HttpResponseMessage ListarCategorias([FromBody]JObject model)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        [Route("addcategoria")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage CadastroCategoria(Categoria c)
        {
            try
            {
                using (DBContext db = new DBContext())
                {
                    db.Database.CreateIfNotExists();
                    db.Categoria.Add(c);
                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Cadastro da categoria " + c.nomeCategoria + " realizado.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }

        }
    }
}
