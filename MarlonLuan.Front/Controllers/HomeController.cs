using MarlonLuan.Dominio.Models;
using MarlonLuan.Infraestrutura.DataContexts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MarlonLuan.Front.Controllers
{
    public class HomeController : Controller
    {
        private MarlonLuanDataContext db = new MarlonLuanDataContext();
        List<Filme> items = new List<Filme>();

        public ActionResult Index()
        {
            //var filme = db.Filmes;
            var filme = this.GetFromAPI();
            return View(filme.ToList());
        }

        private List<Filme> GetFromAPI()
        {
            string url = @"http://localhost:55267/filmes";
            var json = new WebClient().DownloadString(url);
            items = JsonConvert.DeserializeObject<List<Filme>>(json);
            return items;
        }
    }
}