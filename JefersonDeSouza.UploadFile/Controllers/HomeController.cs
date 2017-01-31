using Dominio.Contratos.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JefersonDeSouza.UploadFile.Controllers
{
    public class HomeController : Controller
    {
        private IUploadRep _uploadRep;

        public HomeController(IUploadRep uploadRep)
        {
            _uploadRep = uploadRep;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}