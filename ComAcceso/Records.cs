using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Newtonsoft.Json;

namespace ComAcceso
{
    internal class Records
    {
        private Conexion objCon;
        private OracleConnection objOraConnect;
        private QueryMedysin objQueryMedysin;
        private OracleDataReader objDataReader;
        private OracleCommand objComand;
        private List<ComValue.StringProcesos> objStringProcesos;

        List<ComValue.GridProceso> oListResultGridProceso;

        private string s_ingreso_pam;
        public Records()
        {

            objCon = new Conexion();
            objOraConnect = objCon.conectar();
            objQueryMedysin = new QueryMedysin();
            oListResultGridProceso = new List<ComValue.GridProceso>();
            objStringProcesos = new List<ComValue.StringProcesos>();
            this.setStringProcesos();
            
        }

        private void setStringProcesos()
        {

            ComValue.StringProcesos objStrAuxProceso = new ComValue.StringProcesos("1", ComValue.Enum.ingreso_pam, "Ingreso flujo PAM","L-M-M-J-V a las 07:30 am y 15:00 pm");

            ComValue.StringProcesos objStrAuxProceso2 = new ComValue.StringProcesos("2", ComValue.Enum.recaudacion, "Recaudacion", "L-M-M-J-V a las 07:30 am");

            objStringProcesos.Add(objStrAuxProceso2);
            objStringProcesos.Add(objStrAuxProceso);

            objStrAuxProceso2 = null;
            objStrAuxProceso = null;

        }
        public List<ComValue.IngresoPam> GetIngresoPams(string d_ini , string d_end) {
            
            List<ComValue.IngresoPam> oListResult = new List<ComValue.IngresoPam>();
            // d_ini : 2021-01-02
            // d_end : 2021-01-03
            try
            {

                objOraConnect.Open();

                objComand = new OracleCommand(objQueryMedysin.ingreso_pam(d_ini, d_end), objOraConnect);
                //objComand = new OracleCommand("select ccp.* from cta_consumos_prestacion ccp where rownum= 1", objOraConnect);
                
                objComand.CommandType = System.Data.CommandType.Text;
                objDataReader = objComand.ExecuteReader();

                while (objDataReader.Read())
                {
                    ComValue.IngresoPam oClsIngresoPam = new ComValue.IngresoPam();

                    oClsIngresoPam.Agregar(
                        objDataReader.GetValue(0), objDataReader.GetValue(1), objDataReader.GetValue(2), objDataReader.GetValue(3), objDataReader.GetValue(4), objDataReader.GetValue(5), objDataReader.GetValue(6), objDataReader.GetValue(7), objDataReader.GetValue(8), objDataReader.GetValue(9), objDataReader.GetValue(10), objDataReader.GetValue(11), objDataReader.GetValue(12), objDataReader.GetValue(13), objDataReader.GetValue(14), objDataReader.GetValue(15), objDataReader.GetValue(16), objDataReader.GetValue(17), objDataReader.GetValue(18), objDataReader.GetValue(19));
                   
                    oListResult.Add(oClsIngresoPam);
                    oClsIngresoPam = null;
                }


            }

            catch (Exception ex)
            {
                string e = ex.Message.ToString();
                //nTipoResultado = oclsErrores.nErrorConexionBaseDatos;
                //cTipoMensajeError = ex.Message.ToString() + " " + "PC_SP_VENTAS_GNV" + " " + ConfigurationManager.ConnectionStrings("cn").ConnectionString;
                //oLogErroresRutaLocal.CreateLogFiles();
                //oLogErroresRutaLocal.ErrorLog(cRutaLog, ex.Message.ToString() + " " + "PC_SP_VENTAS_GNV" + " " + ConfigurationManager.ConnectionStrings("cn").ConnectionString + " " + ex.StackTrace);
            }


            return oListResult;
        }

        public List<ComValue.GridProceso> getListaProcesos()
        {
            
            this.setListaGridProceso();

            return this.oListResultGridProceso;

        }

        private string getUltimaFechaProceso(string proceso)
        {

            string result = String.Empty;
            HttpClient httpClient = new HttpClient();

            result = httpClient.LeerWS("", "GET", "last_proc?nombre=" + proceso);
            ComValue.Ultimaejecucion fechaejec = JsonConvert.DeserializeObject<ComValue.Ultimaejecucion>(result);
            result = fechaejec.ultima_ejecucion;
            
            return result;

        }

        private void setListaGridProceso()
        {

            
               foreach(ComValue.StringProcesos obj in this.objStringProcesos)
                {
                    ComValue.GridProceso ogrid = new ComValue.GridProceso();

                DateTime fechaIng =  Convert.ToDateTime(this.getUltimaFechaProceso(obj.nombre));

                DateTime fechaIngActualizado =    fechaIng.Subtract(TimeSpan.FromDays(1));
               
                DateTime hastaIng = DateTime.Today.Subtract(TimeSpan.FromDays(1));
               
               ogrid.add(obj.id, obj.description, obj.description, fechaIng.ToString().Substring(0,10), fechaIngActualizado.ToString().Substring(0, 10), fechaIng.ToString().Substring(0, 10), hastaIng.ToString().Substring(0, 10), obj.tiempo);

                this.oListResultGridProceso.Add(ogrid);
                }

        }


        public List<ComValue.Recaudacion> GetRecaudacion(string d_ini, string d_end)
        {

            List<ComValue.Recaudacion> oListResult = new List<ComValue.Recaudacion>();
            // d_ini : 2021-01-02
            // d_end : 2021-01-03
            try
            {

                objOraConnect.Open();

                objComand = new OracleCommand(objQueryMedysin.recaudacion(d_ini, d_end), objOraConnect);
                //objComand = new OracleCommand("select ccp.* from cta_consumos_prestacion ccp where rownum= 1", objOraConnect);

                objComand.CommandType = System.Data.CommandType.Text;
                objDataReader = objComand.ExecuteReader();

                while (objDataReader.Read())
                {
                    ComValue.Recaudacion oClsRecaudacion = new ComValue.Recaudacion();

                    oClsRecaudacion.Agregar(
                        objDataReader.GetValue(0), objDataReader.GetValue(1), objDataReader.GetValue(2), objDataReader.GetValue(3), objDataReader.GetValue(4), objDataReader.GetValue(5), objDataReader.GetValue(6), objDataReader.GetValue(7), objDataReader.GetValue(8), objDataReader.GetValue(9), objDataReader.GetValue(10), objDataReader.GetValue(11), objDataReader.GetValue(12), objDataReader.GetValue(13), objDataReader.GetValue(14), objDataReader.GetValue(15), objDataReader.GetValue(16), objDataReader.GetValue(17), objDataReader.GetValue(18), objDataReader.GetValue(19), objDataReader.GetValue(20));

                    oListResult.Add(oClsRecaudacion);
                    oClsRecaudacion = null;
                }


            }

            catch (Exception ex)
            {
                string e = ex.Message.ToString();
                //nTipoResultado = oclsErrores.nErrorConexionBaseDatos;
                //cTipoMensajeError = ex.Message.ToString() + " " + "PC_SP_VENTAS_GNV" + " " + ConfigurationManager.ConnectionStrings("cn").ConnectionString;
                //oLogErroresRutaLocal.CreateLogFiles();
                //oLogErroresRutaLocal.ErrorLog(cRutaLog, ex.Message.ToString() + " " + "PC_SP_VENTAS_GNV" + " " + ConfigurationManager.ConnectionStrings("cn").ConnectionString + " " + ex.StackTrace);
            }


            return oListResult;
        }

    }

}
