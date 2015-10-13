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
    //[Authorize]
    //public class ValuesController : ApiController
    //{
    //    public HttpResponseMessage Get(int id) { ... }
    //    public HttpResponseMessage Post() { ... }
    //}

    public class ClienteController : ApiController
    {
        private DBContext db = new DBContext();
        
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        [Route("api/addclient")]
        [HttpPost]
        public HttpResponseMessage CadastroCliente(Cliente cliente, string password)
        {
            try
            {
                //System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                //var data = js.Deserialize<Cliente>(dataCliente);
                db.Database.CreateIfNotExists();
                //var c = data.cliente;
                //db.Cliente.Add(c);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        
    }
}
