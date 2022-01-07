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
        private ComValue.ManejadorLogs oLogErrores = new ComValue.ManejadorLogs();
        private string cRutaLog = String.Empty;
        List<ComValue.GridProceso> oListResultGridProceso;

        private string s_ingreso_pam;
        public Records()
        {

            objCon = new Conexion();
            objOraConnect = objCon.conectar();
            objQueryMedysin = new QueryMedysin();
            oListResultGridProceso = new List<ComValue.GridProceso>();
            objStringProcesos = new List<ComValue.StringProcesos>();
            cRutaLog = System.Configuration.ConfigurationManager.AppSettings["ruta_log"];

            this.setStringProcesos();
            
        }

        private void setStringProcesos()
        {

            ComValue.StringProcesos objStrAuxProceso = new ComValue.StringProcesos("1", ComValue.Enum.ingreso_pam, "Ingreso flujo PAM","L-M-M-J-V a las 07:30 am y 15:00 pm");

            ComValue.StringProcesos objStrAuxProceso2 = new ComValue.StringProcesos("2", ComValue.Enum.recaudacion, "Recaudacion", "L-M-M-J-V a las 07:30 am");

            ComValue.StringProcesos objStrAuxProceso3 = new ComValue.StringProcesos("3", ComValue.Enum.envio_isapre, "Envio a isapre", "L-M-M-J-V a las 07:30 am");


            objStringProcesos.Add(objStrAuxProceso2);
            objStringProcesos.Add(objStrAuxProceso);
            objStringProcesos.Add(objStrAuxProceso3);

            objStrAuxProceso2 = null;
            objStrAuxProceso = null;
            objStrAuxProceso3 = null;

        }
        public List<ComValue.IngresoPam> GetIngresoPams(string d_ini , string d_end) {
            
            List<ComValue.IngresoPam> oListResult = new List<ComValue.IngresoPam>();

            oLogErrores.CreateLogFiles();
            oLogErrores.ErrorLog(cRutaLog, ComValue.Enum.log_fecha_inicio + d_ini + " " + ComValue.Enum.log_fecha_termino + d_end + " " + ComValue.Enum.ingreso_pam);

            try
            {

                objOraConnect.Open();

                objComand = new OracleCommand(objQueryMedysin.ingreso_pam(d_ini, d_end), objOraConnect);
 
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

                oLogErrores.CreateLogFiles();
                oLogErrores.ErrorLog(cRutaLog, ComValue.Enum.log_numero_records + oListResult.Count.ToString() + ComValue.Enum.recaudacion);


            }

            catch (Exception ex)
            {
                oLogErrores.CreateLogFiles();
                oLogErrores.ErrorLog(cRutaLog, ex.Message.ToString() + ex.StackTrace);
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

            try 
            {

                oLogErrores.CreateLogFiles();
                oLogErrores.ErrorLog(cRutaLog, "GET last_proc ? nombre = " + proceso);

                HttpClient httpClient = new HttpClient();

                result = httpClient.LeerWS("", "GET", "last_proc?nombre=" + proceso);
                if(result != "")
                {
                    ComValue.Ultimaejecucion fechaejec = JsonConvert.DeserializeObject<ComValue.Ultimaejecucion>(result);
                    result = fechaejec.ultima_ejecucion;
                } else
                {
                    result = "";
                }
                
            }
            catch (Exception ex) //bloque catch para captura de error
            {
                result = "";
                oLogErrores.CreateLogFiles();
                oLogErrores.ErrorLog(cRutaLog, ex.Message.ToString() + ex.StackTrace);
            }

            
            return result;

        }

        private void setListaGridProceso()
        {

            
               foreach(ComValue.StringProcesos obj in this.objStringProcesos)
                {
                    try
                    {
                        ComValue.GridProceso ogrid = new ComValue.GridProceso();

                        DateTime fechaIng = Convert.ToDateTime(this.getUltimaFechaProceso(obj.nombre));

                        DateTime fechaIngActualizado = fechaIng.Subtract(TimeSpan.FromDays(1));

                        DateTime hastaIng = DateTime.Today.Subtract(TimeSpan.FromDays(1));

                        ogrid.add(obj.id, obj.description, obj.description, fechaIng.ToString().Substring(0, 10), fechaIngActualizado.ToString().Substring(0, 10), fechaIng.ToString().Substring(0, 10), hastaIng.ToString().Substring(0, 10), obj.tiempo);

                        this.oListResultGridProceso.Add(ogrid);
                
                    } catch(Exception ex)
                    {

                        oLogErrores.CreateLogFiles();
                        oLogErrores.ErrorLog(cRutaLog, ex.Message.ToString() + ex.StackTrace);

                    }

                
                }

        }


        public List<ComValue.Recaudacion> GetRecaudacion(string d_ini, string d_end)
        {

            List<ComValue.Recaudacion> oListResult = new List<ComValue.Recaudacion>();

            oLogErrores.CreateLogFiles();
            oLogErrores.ErrorLog(cRutaLog, ComValue.Enum.log_fecha_inicio + d_ini + " " + ComValue.Enum.log_fecha_termino + d_end + " " + ComValue.Enum.recaudacion);

            try
            {

                objOraConnect.Open();

                objComand = new OracleCommand(objQueryMedysin.recaudacion(d_ini, d_end), objOraConnect);
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

                oLogErrores.CreateLogFiles();
                oLogErrores.ErrorLog(cRutaLog, ComValue.Enum.log_numero_records + oListResult.Count.ToString() + ComValue.Enum.recaudacion);

            }

            catch (Exception ex)
            {
                oLogErrores.CreateLogFiles();
                oLogErrores.ErrorLog(cRutaLog, ex.Message.ToString() +  ex.StackTrace);
            }


            return oListResult;
        }

        public List<ComValue.EnvioIsapre> GetEnvioIsapre(string d_ini, string d_end)
        {

            List<ComValue.EnvioIsapre> oListResult = new List<ComValue.EnvioIsapre>();

            oLogErrores.CreateLogFiles();
            oLogErrores.ErrorLog(cRutaLog, ComValue.Enum.log_fecha_inicio + d_ini + " " + ComValue.Enum.log_fecha_termino + d_end + " " + ComValue.Enum.envio_isapre);

            try
            {

                objOraConnect.Open();

                objComand = new OracleCommand(objQueryMedysin.envio_isapre(d_ini, d_end), objOraConnect);
                objComand.CommandType = System.Data.CommandType.Text;
                objDataReader = objComand.ExecuteReader();

                while (objDataReader.Read())
                {
                    ComValue.EnvioIsapre oClsEnvioIsapre = new ComValue.EnvioIsapre();

                    oClsEnvioIsapre.Agregar(
                        objDataReader.GetValue(0), objDataReader.GetValue(1), objDataReader.GetValue(2));

                    oListResult.Add(oClsEnvioIsapre);
                    oClsEnvioIsapre = null;
                }

                oLogErrores.CreateLogFiles();
                oLogErrores.ErrorLog(cRutaLog, ComValue.Enum.log_numero_records + oListResult.Count.ToString() + ComValue.Enum.envio_isapre);

            }

            catch (Exception ex)
            {
                oLogErrores.CreateLogFiles();
                oLogErrores.ErrorLog(cRutaLog, ex.Message.ToString() + ex.StackTrace);
            }


            return oListResult;
        }


        public void LastRangoFechaEjecucion( string proceso , ref string d_ini, ref string d_last, int second = 0)
        {

            string aux_date = this.getUltimaFechaProceso(proceso);

            if( aux_date != "")
            {
                //if(proceso != ComValue.Enum.ingreso_pam)
                //{

                if(second == 0)
                {
                    d_ini = aux_date;
                    d_last = DateTime.Today.Subtract(TimeSpan.FromDays(1)).ToString(ComValue.Enum.fomat_fecha_proceso);

                }

                if(second == 1)
                {

                    d_ini = DateTime.Today.Subtract(TimeSpan.FromDays(1)).ToString(ComValue.Enum.fomat_fecha_proceso);
                    d_last = DateTime.Today.Subtract(TimeSpan.FromDays(1)).ToString(ComValue.Enum.fomat_fecha_proceso);

                }

                //}

            }

        }


    }

    

}
