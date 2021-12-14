using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace ComDao
{
    class ProcesosAutomaticos
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
        public  void Ejecutar_IngresoPam()
        {
            List<ComTipos.IngresoPam> oListIngresoPam = new List<ComTipos.IngresoPam>();

            oListIngresoPam = this.getInstanceRecords().GetIngresoPams();

        }

    }
}
