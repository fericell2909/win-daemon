using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
namespace ComDao
{
    class Records
    {
        private Conexion objCon;
        private OracleConnection objOraConnect;
        private QueryMedysin objQueryMedysin;
        private OracleDataReader objDataReader;
        private OracleCommand objComand;
        public Records()
        {

            objCon = new Conexion();
            objOraConnect = objCon.conectar();
            objQueryMedysin = new QueryMedysin();
        }

        public List<ComTipos.IngresoPam> GetIngresoPams() {
            
            List<ComTipos.IngresoPam> oListResult = new List<ComTipos.IngresoPam>();

            try
            {

                objOraConnect.Open();

                objComand = new OracleCommand(objQueryMedysin.Get_ingreso_pam(null,null), objOraConnect);
                objComand.CommandType = System.Data.CommandType.Text;
                objDataReader = objComand.ExecuteReader();

                while (objDataReader.Read())
                {
                    ComTipos.IngresoPam oClsIngresoPam = new ComTipos.IngresoPam();

                    oClsIngresoPam.Agregar(
                        objDataReader.GetValue(0), objDataReader.GetValue(1), objDataReader.GetValue(2), objDataReader.GetValue(3), objDataReader.GetValue(4), objDataReader.GetValue(5), objDataReader.GetValue(6), objDataReader.GetValue(7), objDataReader.GetValue(8), objDataReader.GetValue(9), objDataReader.GetValue(10), objDataReader.GetValue(11), objDataReader.GetValue(12), objDataReader.GetValue(13), objDataReader.GetValue(14), objDataReader.GetValue(15), objDataReader.GetValue(16), objDataReader.GetValue(17), objDataReader.GetValue(18), objDataReader.GetValue(19));
                   
                    oListResult.Add(oClsIngresoPam);
                    oClsIngresoPam = null;
                }


            }

            catch (Exception ex)
            {
                //nTipoResultado = oclsErrores.nErrorConexionBaseDatos;
                //cTipoMensajeError = ex.Message.ToString() + " " + "PC_SP_VENTAS_GNV" + " " + ConfigurationManager.ConnectionStrings("cn").ConnectionString;
                //oLogErroresRutaLocal.CreateLogFiles();
                //oLogErroresRutaLocal.ErrorLog(cRutaLog, ex.Message.ToString() + " " + "PC_SP_VENTAS_GNV" + " " + ConfigurationManager.ConnectionStrings("cn").ConnectionString + " " + ex.StackTrace);
            }


            return oListResult;
        }
    }
}
