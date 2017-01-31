using Biblioteca.Helpers;
using Dominio.Contratos.Upload;
using Negocio.Upload;
using Site.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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
            return View(UploadFileVm.ParaViewModel(new UploadFileNeg(_uploadRep).ListarTodos()));
        }

        [HttpPost]
        public ActionResult UploadFiles()
        {
            var lstFileResult = new List<UploadFileVm>();
            var sucesso = false;
            List<string> dadosArquivo = new List<string>();

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
                                dadosArquivo = WebSiteHelper.LerArquivo("PathRelative.Conferencia", "PathRelative.Conferencia.Cabecalho", fileName);

                                new UploadFileNeg(_uploadRep).Inserir(dadosArquivo);

                                sucesso = true;
                                TempData["Mensagem"] = "[SUCESSO] Upload realizado com sucesso.";
                            }
                            else
                            {
                                TempData["Mensagem"] = "[ERRO] Estamos com problema para salvar o arquivo, por favor reinicie o processo.";
                            }
                        }
                        else
                        {
                            TempData["Mensagem"] = "[AVISO]Selecione um arquivo com extensão .txt.";
                        }
                    }
                    else
                    {
                        TempData["Mensagem"] = "[AVISO] Selecione algum arquivo para realizar o upload.";
                    }
                }
            }
            catch (Exception ex)
            {
                dynamic log = new ExpandoObject();

                log.XmlEnviado = ex;
                log.XmlRecebido = null;
                log.Protocolo = null;
                log.CodigoDoErro = null;
                log.MensagemDeErro = string.Format("Erro ao tentar fazer o upload do arquivo. objeto Enviado: {0}", Environment.NewLine, new JavaScriptSerializer().Serialize(Request.Files));
                log.TipoDeErro = "Error";
                log.MetodoDeChamadaInterno = new StackTrace(ex).GetFrame(0).GetMethod().Name;

                this.Log.Salvar(log);

                TempData["Mensagem"] = "[ERRO] Perdão, estamos enfrentando problemas para efetuar o upload do arquivo, por favor reinicie o processo!";
            }

            //return Content("{\"name\":\"" + lstFileResult[0].Name + "\",\"type\":\"" + lstFileResult[0].Type + "\",\"size\":\"" + string.Format("{0} bytes", lstFileResult[0].Length) + "\"}", "application/json");
            int qtdColunas = ConfigurationManager.AppSettings["PathRelative.Conferencia.Cabecalho"].ToString().Split(',').ToList<string>().Count;

            TempData["TotalRegistro"] = (dadosArquivo.Count / qtdColunas);

            return Json(sucesso, JsonRequestBehavior.AllowGet);
        }
    }
}