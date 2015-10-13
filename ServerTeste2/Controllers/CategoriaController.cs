using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServerTeste2.Models;

namespace ServerTeste2.Controllers
{
    public class CategoriaController : ApiController
    {
        private DBContext db = new DBContext();
        [Route("api/addcategoria")]
        [HttpPost]
        public HttpResponseMessage CadastroCategoria(Categoria c)
        {
            try
            {
                db.Database.CreateIfNotExists();
                db.Categoria.Add(c);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Cadastro da categoria " + c.nomeCategoria + " realizado.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }
    }
}
