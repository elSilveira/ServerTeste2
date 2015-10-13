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
        public HttpResponseMessage CadastroCliente(JObject model)
        {
            try
            {
                //System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                //var data = js.Deserialize<Cliente>(dataCliente);
                //db.Database.CreateIfNotExists();
                ////var c = data.cliente;
                ////db.Cliente.Add(c);
                //db.SaveChanges();

                dynamic json = model;

                var cliente = json.cliente.ToObject<Cliente>();
                var senha = json.password.ToString();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }


        [Route("api/getclient")]
        public HttpResponseMessage GetCliente()
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

    }
}
/*
exemplo de envio: (RAW)

{
    "password":"minhasenhamalucacriptografada",
    "cliente": {
        "nomeCliente": "nomeCliente",
        "sobrenomeCliente": "sobrenomeCliente",
        "telefoneCliente": "telefoneCliente",
        "emailCliente": "emailCliente",
        "cidadeCliente": "cidadeCliente",
        "estadoCliente": "estadoCliente",
        "geoLatitudeCliente": "geoLatitudeCliente",
        "geoLongitudeCliente": "geoLongitudeCliente"
    }
}

*/
