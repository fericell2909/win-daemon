using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using System.IO;

namespace ComAcceso
{
     public class CsvExport
    {
        private string cRutaCSV = String.Empty;
        private string cRutaLog = String.Empty;
        private string proceso = String.Empty;
        private ComAcceso.Records oRecords;

        private ComValue.ManejadorLogs oLogErrores  = new ComValue.ManejadorLogs();

        public CsvExport(string proceso, ref string ruta , int second = 0){
            
            cRutaCSV = System.Configuration.ConfigurationManager.AppSettings["ruta_csv"];
            cRutaLog = System.Configuration.ConfigurationManager.AppSettings["ruta_log"];
            this.proceso = proceso;
            this.oRecords = new ComAcceso.Records();
            string ruta_csv = string.Empty;

            oLogErrores.CreateLogFiles();
            oLogErrores.ErrorLog(cRutaLog, ComValue.Enum.log_inicio_csv + proceso);
            
            this.generateCSV(ref ruta_csv, second);

            oLogErrores.ErrorLog(cRutaLog, ComValue.Enum.log_ruta_csv +  ruta_csv);
            oLogErrores.CreateLogFiles();
            oLogErrores.ErrorLog(cRutaLog, ComValue.Enum.log_termino_csv + proceso);

            ruta = ruta_csv;
        }
        private Boolean generateCSV(ref string ruta_csv , int second = 0)
        {
            Boolean bresult = false;
            string ruta = string.Empty;

            if (this.proceso == ComValue.Enum.ingreso_pam)
            {
                this.ingreso_pam(ref ruta,second);
            }

            if (this.proceso == ComValue.Enum.recaudacion)
            {
                this.recaudacion(ref ruta, second);
            }

            if (this.proceso == ComValue.Enum.envio_isapre)
            {
                this.envio_isapre(ref ruta, second);
            }

            if (this.proceso == ComValue.Enum.anulacion_pam)
            {
                this.anulacion_pam(ref ruta, second);
            }

            if (this.proceso == ComValue.Enum.indicador_staff)
            {
                this.indicador_staff(ref ruta, second);
            }

            ruta_csv = ruta;

            return bresult;
        }

        private void ingreso_pam(ref string ruta, int second = 0)
        {

            string d_ini = "";
            string d_last = "";

            oRecords.LastRangoFechaEjecucion(ComValue.Enum.ingreso_pam, ref d_ini, ref d_last, second);

            List<ComValue.IngresoPam> oListIngresoPam;

            oListIngresoPam = oRecords.GetIngresoPams(d_ini, d_last);

            ruta = @"" + this.cRutaCSV + "" + this.getNameCSV(ComValue.Enum.ingreso_pam);

            CreateCSV(oListIngresoPam, ruta);

        }
        private string getNameCSV(string tipo)
        {
            return DateTime.Now.ToString(ComValue.Enum.format_fecha_hora_csv) + "-" + tipo + "-u-" + Environment.UserName + ".csv";
        }

        private void recaudacion(ref string ruta, int second = 0)
        {

            List<ComValue.Recaudacion> oListRecaudacion;
            string d_ini = "";
            string d_last = "";

            oRecords.LastRangoFechaEjecucion(ComValue.Enum.recaudacion, ref d_ini, ref d_last,second);
            oListRecaudacion = oRecords.GetRecaudacion(d_ini, d_last);
            ruta = @"" + this.cRutaCSV + "" + this.getNameCSV(ComValue.Enum.recaudacion);

            CreateCSV(oListRecaudacion, ruta);

        }

        private void envio_isapre(ref string ruta, int second = 0)
        {

            List<ComValue.EnvioIsapre> oListEnvioIsapre;
            string d_ini = "";
            string d_last = "";

            oRecords.LastRangoFechaEjecucion(ComValue.Enum.envio_isapre, ref d_ini, ref d_last,second);
            oListEnvioIsapre = oRecords.GetEnvioIsapre(d_ini, d_last);
            ruta = @"" + this.cRutaCSV + "" + this.getNameCSV(ComValue.Enum.envio_isapre);

            CreateCSV(oListEnvioIsapre, ruta);

        }

        public void WriteCSV<T>(IEnumerable<T> items, string path)
        {
            Type itemType = typeof(T);
            var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                .OrderBy(p => p.Name);

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(string.Join(", ", props.Select(p => p.Name)));

                foreach (var item in items)
                {
                    writer.WriteLine(string.Join(", ", props.Select(p => p.GetValue(item, null))));
                }
            }
        }

        private static void CreateHeader<T>(List<T> list, StreamWriter sw)
        {
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < properties.Length - 1; i++)
            {
                sw.Write(properties[i].Name + ",");
            }
            var lastProp = properties[properties.Length - 1].Name;
            sw.Write(lastProp + sw.NewLine);
        }

        private static void CreateRows<T>(List<T> list, StreamWriter sw)
        {
            foreach (var item in list)
            {
                PropertyInfo[] properties = typeof(T).GetProperties();
                for (int i = 0; i < properties.Length - 1; i++)
                {
                    var prop = properties[i];
                    sw.Write(prop.GetValue(item) + ",");
                }
                var lastProp = properties[properties.Length - 1];
                sw.Write(lastProp.GetValue(item) + sw.NewLine);
            }
        }

        private void CreateCSV<T>(List<T> list, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                CreateHeader(list, sw);
                CreateRows(list, sw);
            }
        }

        private void anulacion_pam(ref string ruta, int second = 0)
        {

            List<ComValue.AnulacionPam> oListAnulacionPam;
            string d_ini = "";
            string d_last = "";

            oRecords.LastRangoFechaEjecucion(ComValue.Enum.anulacion_pam, ref d_ini, ref d_last, second);
            oListAnulacionPam = oRecords.GetAnulacionPam(d_ini, d_last);
            ruta = @"" + this.cRutaCSV + "" + this.getNameCSV(ComValue.Enum.anulacion_pam);

            CreateCSV(oListAnulacionPam, ruta);

        }
        private void indicador_staff(ref string ruta, int second = 0)
        {

            List<ComValue.IndicadorStaff> oListIndicadorStaff;
            string d_ini = "";
            string d_last = "";

            oRecords.LastRangoFechaEjecucion(ComValue.Enum.indicador_staff, ref d_ini, ref d_last, second);
            oListIndicadorStaff = oRecords.GetIndicadorStaff(d_ini, d_last);
            ruta = @"" + this.cRutaCSV + "" + this.getNameCSV(ComValue.Enum.indicador_staff);

            CreateCSV(oListIndicadorStaff, ruta);

        }

    }
}
