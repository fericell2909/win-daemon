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
        private string proceso = String.Empty;
        private ComAcceso.Records oRecords;
        public CsvExport(string proceso, ref string ruta){
            cRutaCSV = System.Configuration.ConfigurationManager.AppSettings["ruta_csv"];
            this.proceso = proceso;
            this.oRecords = new ComAcceso.Records();
            string ruta_csv = string.Empty;
            this.generateCSV(ref ruta_csv);
            ruta = ruta_csv;
        }
        private Boolean generateCSV(ref string ruta_csv)
        {
            Boolean bresult = false;
            string ruta = string.Empty;

            if (this.proceso == ComValue.Enum.ingreso_pam)
            {
                this.ingreso_pam(ref ruta);
            }

            if (this.proceso == ComValue.Enum.recaudacion)
            {
                this.recaudacion(ref ruta);
            }
            ruta_csv = ruta;

            return bresult;
        }

        private void ingreso_pam(ref string ruta)
        {

            List<ComValue.IngresoPam> oListIngresoPam;

            oListIngresoPam = oRecords.GetIngresoPams("2021-01-02", "2021-01-03");

            ruta = @"" + this.cRutaCSV + "" + this.getNameCSV(ComValue.Enum.recaudacion);

            CreateCSV(oListIngresoPam, ruta);

        }
        private string getNameCSV(string tipo)
        {
            return DateTime.Now.ToString(ComValue.Enum.format_fecha_hora_csv) + "-" + tipo + "-u-" + Environment.UserName + ".csv";
        }

        private void recaudacion(ref string ruta)
        {

           List<ComValue.Recaudacion> oListRecaudacion;

            oListRecaudacion = oRecords.GetRecaudacion("2021-12-29", "2021-12-29");
            ruta = @"" + this.cRutaCSV + "" + this.getNameCSV(ComValue.Enum.recaudacion);

            CreateCSV(oListRecaudacion, ruta);

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

    }
}
