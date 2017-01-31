using Biblioteca.Componentes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class BaseController : Controller
    {
        protected Log Log;

        public BaseController()
        {
            this.Log = new Log();
        }

        protected string VerificarDiretorio(string appSettingsKey)
        {
            string diretorio = ConfigurationManager.AppSettings[appSettingsKey].ToString();

            try
            {
                if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(diretorio)))
                {
                    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(diretorio));
                }
            }
            catch (Exception e)
            {
                diretorio = null;
            }

            return diretorio;
        }
    }
}