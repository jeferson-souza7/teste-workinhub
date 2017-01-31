using Biblioteca.Helpers;
using Dominio.Contratos.Upload;
using Negocio.Upload;
using Site.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Site.Controllers
{
    public class HomeController : BaseController
    {
        private IUploadFileRep _uploadRep;

        public HomeController(IUploadFileRep uploadRep)
        {
            _uploadRep = uploadRep;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFiles()
        {
            var lstFileResult = new List<UploadFileVm>();
            var sucesso = false;

            try
            {
                foreach (string file in Request.Files)
                {
                    HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                    string fileName = Path.GetFileName(hpf.FileName);
                    string extension = Path.GetExtension(fileName);

                    if (hpf.ContentLength > 0)
                    {
                        if (extension.Equals(".txt", StringComparison.OrdinalIgnoreCase))
                        {
                            string diretorio = VerificarDiretorio("PathRelative.Conferencia");

                            if (WebSiteHelper.SalvarArquivo(hpf, fileName, diretorio))
                            {
                                List<string> dadosArquivo = WebSiteHelper.LerArquivo("PathRelative.Conferencia", "PathRelative.Conferencia.Cabecalho", fileName);

                                new UploadFileNeg(_uploadRep).Inserir(dadosArquivo);

                                sucesso = true;
                            }
                            else
                            {
                                ViewBag.Mensagem = "Estamos com problema para salvar o arquivo, por favor reinicie o processo.";
                            }
                        }
                        {
                            ViewBag.Mensagem = "Selecione um arquivo com extensão .txt.";
                        }
                    }
                    else
                    {
                        ViewBag.Mensagem = "Selecione algum arquivo para realizar o upload.";
                    }
                }
            }
            catch (Exception ex)
            {
                dynamic log = new ExpandoObject();

                log.Tipo = "Erro";
                log.Exception = ex.Message;
                log.StackTrace = ex.StackTrace;
                log.Mensagem = string.Format("Erro ao tentar fazer o upload do arquivo do Atendimento. objeto Enviado: {0}", Environment.NewLine, new JavaScriptSerializer().Serialize(Request.Files));

                this.Log.Salvar(log);

                ViewBag.MsgAviso = "Perdão, estamos enfrentando problemas para efetuar o upload do arquivo, por favor reinicie o processo!";
            }

            //return Content("{\"name\":\"" + lstFileResult[0].Name + "\",\"type\":\"" + lstFileResult[0].Type + "\",\"size\":\"" + string.Format("{0} bytes", lstFileResult[0].Length) + "\"}", "application/json");

            return Json(sucesso, JsonRequestBehavior.AllowGet);
        }
    }
}