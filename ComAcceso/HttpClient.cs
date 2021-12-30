using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ComAcceso
{
    internal class HttpClient
    {
        private HttpWebRequest peticion;
        private int production;
        private string urlWS;

        public HttpClient()
        {

            production = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["production"]);

            if (production == 1)
            {
                this.urlWS = System.Configuration.ConfigurationManager.AppSettings["url_intranet_production"];
            }
            else
            {
                this.urlWS = System.Configuration.ConfigurationManager.AppSettings["url_intranet_staging"];
            }

        }
        public string LeerWS(string datos, string metodo, string path)
        {
            string json = string.Empty;

            string url = this.urlWS + path;
            byte[] data = UTF8Encoding.UTF8.GetBytes(datos);

            try
            {
                HttpWebRequest peticion;
                peticion = WebRequest.Create(url) as HttpWebRequest;
                peticion.Method = metodo;
                peticion.ContentLength = data.Length;
                peticion.ContentType = "application/json; charset=utf-8";

                HttpWebResponse respuesta = peticion.GetResponse() as HttpWebResponse;
                System.IO.StreamReader lectura = new System.IO.StreamReader(respuesta.GetResponseStream(), Encoding.Default);
                json = lectura.ReadToEnd();
            }
            catch (Exception ex)
            {
                json = String.Empty;
            }

            return json;
        }
        public void sendToIntranet(string filename, string url )
        {

            HttpClient httpClient = new HttpClient();


        }


    }
}
