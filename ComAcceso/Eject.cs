using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComAcceso
{
    public class Eject
    {

        public object sendTointranet(string proceso , int second = 0)
        {

            string ruta_csv = String.Empty;
            object result_proceso_post = null;

            ComAcceso.CsvExport oExport = new ComAcceso.CsvExport(proceso, ref ruta_csv, second);

            if (ruta_csv != "")
            {

                HttpClient httpClient = new HttpClient();
                result_proceso_post = httpClient.rest_client(proceso, ruta_csv);

            }

            return result_proceso_post;


        }

        private byte[] getBytesByRoute(string ruta)
        {

            byte[] contenido = null;

            try
            {
               
                byte[] buffer = null;
                int longitud;
                var PathfileName = string.Empty;
                PathfileName = @"" + ruta;
                using (var fs = new FileStream(PathfileName, FileMode.Open, FileAccess.Read))
                {
                    buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, (int)fs.Length);
                    longitud = (int)fs.Length;
                }
                contenido = buffer;
            }
            catch (Exception ex)
            {
                contenido = null;
            }


            return contenido;

        }

    }

    
}
