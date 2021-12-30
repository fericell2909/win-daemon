using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComAcceso
{
    public class Eject
    {
        private string proceso = String.Empty;

        public Eject(string proceso)
        {
            string ruta_csv = String.Empty;

            this.proceso = proceso;
            ComAcceso.CsvExport oExport = new ComAcceso.CsvExport(proceso, ref ruta_csv);


            // send to Intranet

        }

    }
}
