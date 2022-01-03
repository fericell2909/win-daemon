using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using RestSharp;

namespace ComAcceso
{
    internal class HttpClient
    {
        private HttpWebRequest peticion;
        private int production;
        private string urlWS;
        private string url_ingreso_pam_post;
        private string url_recaudacion_post;
        private string result_send_recaudacion_post;
        private string cRutaLog = String.Empty;
        private ComValue.ManejadorLogs oLogErrores = new ComValue.ManejadorLogs();
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

            this.url_ingreso_pam_post = this.urlWS + System.Configuration.ConfigurationManager.AppSettings["url_ingreso_pam"];
            this.url_recaudacion_post = this.urlWS + System.Configuration.ConfigurationManager.AppSettings["url_recaudacion"];

            cRutaLog = System.Configuration.ConfigurationManager.AppSettings["ruta_log"];


        }
        public bool AceptarTodosLosCertificados(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public string LeerWS(string datos, string metodo, string path)
        {
            string json = string.Empty;

            string url = this.urlWS + path;
            byte[] data = UTF8Encoding.UTF8.GetBytes(datos);

            try
            {
                if(this.production == 0)
                {
                    ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AceptarTodosLosCertificados);
                }                

                HttpWebRequest peticion;
                peticion = WebRequest.Create(url) as HttpWebRequest;
                peticion.Method = metodo;
                peticion.ContentLength = data.Length;
                peticion.ContentType = ComValue.Enum.contenttype_json;

                HttpWebResponse respuesta = peticion.GetResponse() as HttpWebResponse;
                System.IO.StreamReader lectura = new System.IO.StreamReader(respuesta.GetResponseStream(), Encoding.Default);
                json = lectura.ReadToEnd();
            }
            catch (Exception ex)
            {
                json = "";
            }

            return json;
        }
        public string HttpPost(byte[] file_bytes,string tipo)
        {
            string url = string.Empty;

            if (tipo == ComValue.Enum.ingreso_pam)
            {
                url = this.url_ingreso_pam_post;
            }

            if(tipo == ComValue.Enum.recaudacion)
            {
                url = this.url_recaudacion_post;
            }


            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = ComValue.Enum.method_type_multipar_data;
            httpWebRequest.Method = ComValue.Enum.method_post;


            var asyncResult = httpWebRequest.BeginGetRequestStream((ar) => { GetRequestStreamCallback(ar, file_bytes); }, httpWebRequest);
            return this.result_send_recaudacion_post;
        }

        private void GetRequestStreamCallback(IAsyncResult asynchronousResult, byte[] postData)
        {
            //DON'T KNOW HOW TO PASS "userid=some_user_id"  
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
            Stream postStream = request.EndGetRequestStream(asynchronousResult);
            postStream.Write(postData, 0, postData.Length);
            postStream.Close();
            var asyncResult = request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);
        }

        private void GetResponseCallback(IAsyncResult asynchronousResult)
        {
            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
            Stream streamResponse = response.GetResponseStream();
            StreamReader streamRead = new StreamReader(streamResponse);
            string responseString = streamRead.ReadToEnd();
            streamResponse.Close();
            streamRead.Close();
            response.Close();

            this.result_send_recaudacion_post = responseString;
        }

        public  object rest_client(string tipo , string ruta_csv)
        {
            string url = string.Empty;
            IRestResponse response = null;

            if (tipo == ComValue.Enum.ingreso_pam)
            {
                url = this.url_ingreso_pam_post;
            }

            if (tipo == ComValue.Enum.recaudacion)
            {
                url = this.url_recaudacion_post;
            }

            try 
            {
                oLogErrores.CreateLogFiles();
                oLogErrores.ErrorLog(cRutaLog, "Enviando EJECUTAR  --> CSV : " + ruta_csv  + " -->" + tipo);

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddFile("datos", ruta_csv);
                response = client.Execute(request);

                this.update_fecha_proc(tipo, this.urlWS);

            }
            catch (Exception ex) //bloque catch para captura de error
            {
                oLogErrores.CreateLogFiles();
                oLogErrores.ErrorLog(cRutaLog, ex.Message.ToString() + ex.StackTrace);
            }

            return response;
        }

        private void update_fecha_proc(string tipo, string url)
        {
            string fecha = DateTime.Now.ToString(ComValue.Enum.fomat_fecha_proceso);

            try
            {
                

                var client = new RestClient(url + "update_proc");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AlwaysMultipartFormData = true;
                request.AddParameter("fecha", fecha);
                request.AddParameter("nombre", tipo);

                IRestResponse response = client.Execute(request);

                oLogErrores.CreateLogFiles();
                oLogErrores.ErrorLog(cRutaLog, "Actualizado Fecha: " + fecha + " -->" + tipo);
                response = null;

            }
            catch (Exception ex) //bloque catch para captura de error
            {
                oLogErrores.CreateLogFiles();
                oLogErrores.ErrorLog(cRutaLog, ex.Message.ToString() + ex.StackTrace);
            }

            
                
        }

    }

    
}
