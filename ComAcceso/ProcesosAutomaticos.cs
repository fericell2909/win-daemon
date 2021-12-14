using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComAcceso
{
    public class ProcesosAutomaticos
    {
        private Records oRecords = null;

        public ProcesosAutomaticos()
        {
            oRecords = new Records();
        }
        private Records getInstanceRecords()
        {
            return this.oRecords == null ? new Records() : this.oRecords;
        }
        public List<ComValue.IngresoPam> Ejecutar_IngresoPam()
        {
            List<ComValue.IngresoPam> oListIngresoPam = new List<ComValue.IngresoPam>();

            oListIngresoPam = this.getInstanceRecords().GetIngresoPams();
            return oListIngresoPam;
        }

        public List<ComValue.GridProceso> List_Procesos_Automaticos()
        {

            List<ComValue.GridProceso> oLisGridProceso = new List<ComValue.GridProceso>();

            Records oRecords = new Records();

            oLisGridProceso = oRecords.getListaProcesos();
            return oLisGridProceso;

        }
    }
}
