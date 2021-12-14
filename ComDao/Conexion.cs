using System;
using System.Configuration;
using System.Collections.Specialized;
using Oracle.ManagedDataAccess.Client;

namespace ComDao
{
    public class Conexion
    {

        private OracleConnection conexion;
        private string servidor;
        private int puerto;
        private string nombreservicio;
        private string user;
        private string password;
        public Conexion()
        {
            
            servidor = "rac1-scan.csm.cl";
            puerto = 1521;
            nombreservicio = "MEDISYN_CSM";
            user = "SGONZALEZ";
            password = "Amsm_0410";

       

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
