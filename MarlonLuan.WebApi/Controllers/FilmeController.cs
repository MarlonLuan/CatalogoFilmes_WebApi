using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MarlonLuan.Dominio.Models;
using MarlonLuan.Infraestrutura.DataContexts;
using System.Web.Http.Cors;

namespace MarlonLuan.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FilmeController : ApiController
    {
        private MarlonLuanDataContext db = new MarlonLuanDataContext();
        
        [Route("filmes")]
        public HttpResponseMessage GetFilmes()
        {
            var result = db.Filmes.Include("Categoria").ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("filmes/{id}")]
        public HttpResponseMessage GetFilmes(int id)
        {
            if (id <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var result = db.Filmes.Include("Categoria").Where(x => x.Id == id).FirstOrDefault();

            if (result != null)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi possível recuperar o filme");
        }
        

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}