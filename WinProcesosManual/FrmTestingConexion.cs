using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WinProcesosManual
{
    public partial class FrmTestingConexion : Form
    {
        public FrmTestingConexion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string servidor = "rac1-scan.csm.cl";
                string puerto = "1521";
                string nombreservicio = "MEDISYN_CSM";
                string user = "SGONZALEZ";
                string password = "Amsm_0410";

            string constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(Host=" +
                        servidor + ")(Port=" + puerto + ")))(CONNECT_DATA=(SERVICE_NAME=" +
                        nombreservicio + "))); User Id=" + user + ";Password=" + password + "; ";

                //Datos de conexión a Oracle - Si se usa fichero
                //tnsnames.ora (indicado en variable de entorno ORACLE_HOME)
                /*
                 string constr = "user id=" + txtUsuario.Text + ";password=" + 
                    txtContrasena.Text + ";data source=" + txtNombreServicio.Text;
                */

                //Datos de conexión para no usar tnsnames.ora
               
                OracleConnection con = new OracleConnection(constr);
                con.Open();
                if (txtLog.Text != "")
                {
                    txtLog.AppendText(Environment.NewLine);
                }
                txtLog.AppendText("Conectado a servidor Oracle, versión: " + con.ServerVersion);
                con.Dispose();
            }
            catch (Exception ex)
            {
                if (txtLog.Text != "")
                {
                    txtLog.AppendText(Environment.NewLine);
                }
                txtLog.AppendText("Error al conectar a Oracle: " + ex);
            }
        }
    }
}
