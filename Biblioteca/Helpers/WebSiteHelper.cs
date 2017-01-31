using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Biblioteca.Helpers
{
    public static class WebSiteHelper
    {
        static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        static readonly string[] Extensions = { ".txt" };

        public static string ObterTamanhoDeArquivo(Int64 value)
        {
            if (value < 0) { return "-" + ObterTamanhoDeArquivo(-value); }

            int i = 0;
            decimal dValue = (decimal)value;

            while (Math.Round(dValue / 1024) >= 1)
            {
                dValue /= 1024;
                i++;
            }

            return string.Format("{0:n1} {1}", dValue, SizeSuffixes[i]);
        }

        public static bool SalvarArquivo(HttpPostedFileBase postedFile, string fileName, string diretorio)
        {
            bool retorno = false;

            if (!string.IsNullOrEmpty(diretorio))
            {
                try
                {
                    string savedFileName = Path.Combine(HttpContext.Current.Server.MapPath(diretorio), fileName);

                    postedFile.SaveAs(savedFileName);
                    retorno = true;
                }
                catch (Exception)
                {
                }
            }

            return retorno;
        }

        public static List<string> LerArquivo(string pathFile, string cabecalho, string fileName)
        {
            string diretorio = ConfigurationManager.AppSettings[pathFile].ToString();
            var cabecalhoArquivo = ConfigurationManager.AppSettings[cabecalho];

            List<string> retorno = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath(diretorio) + fileName))
                {
                    string linha = sr.ReadToEnd();
                    string[] array = linha.Split('\t');
                    var linhaCabecalho = cabecalhoArquivo.Split(',').ToList<string>();

                    for (int i = 0; i < array.Length; i++)
                    {
                        if (!linhaCabecalho.Contains(array[i].ToUpper()))
                        {
                            if (array[i].Contains("\n"))
                            {
                                //array[i] = array[i].Substring(array[i].IndexOf("\n")).Replace("\n", "");

                                var quebraDeLinha = array[i].Split('\n');

                                if (quebraDeLinha.Contains("Fornecedor"))
                                {
                                    retorno.Add(quebraDeLinha[1]);
                                }
                                else if (quebraDeLinha.Length == 2)
                                {
                                    retorno.Add(quebraDeLinha[0]);
                                    retorno.Add(quebraDeLinha[1]);
                                }

                                continue;
                            }

                            retorno.Add(array[i]);
                        }
                    }

                    //var item0 = array[0];
                    //var item1 = array[1];
                    //var item2 = array[2];
                }
            }
            catch (Exception)
            {
                retorno = null;
                throw;
            }
            return retorno;
        }
    }
}
