using System;
using System.Configuration;
using System.Collections.Specialized;
using Oracle.ManagedDataAccess.Client;

namespace ComAcceso
{
    class Conexion
    {

        private OracleConnection conexion;
        private string servidor;
        private int puerto;
        private string nombreservicio;
        private string user;
        private string password;
        public Conexion()
        {
            
            // servidor = "rac1-scan.csm.cl";
            servidor = System.Configuration.ConfigurationManager.AppSettings["servidor"];
            puerto = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["puerto"]);
            nombreservicio = System.Configuration.ConfigurationManager.AppSettings["nombreservicio"];
            user = System.Configuration.ConfigurationManager.AppSettings["user"];
            password = System.Configuration.ConfigurationManager.AppSettings["password"];

        }
        public OracleConnection conectar()
        {
            string constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(Host=" +
                    servidor + ")(Port=" + puerto + ")))(CONNECT_DATA=(SERVICE_NAME=" +
                    nombreservicio + "))); User Id=" + user + ";Password=" + password + "; ";

            conexion = new OracleConnection(constr);
            return conexion;
        }

    }
}
