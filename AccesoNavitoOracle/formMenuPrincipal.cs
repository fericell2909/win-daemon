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
using ComAcceso;
//using System.Configuration;

namespace AccesoNavitoOracle
{
    public partial class formMenuPrincipal : Form
    {
        private Boolean loading;
        private int production;
        private string lblambiente;
        public formMenuPrincipal()
        {
            InitializeComponent();
            this.loading = true;
            production  = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["production"]);

            if(production == 1){
                this.linklabel.Text = System.Configuration.ConfigurationManager.AppSettings["url_intranet_production"];
                this.lblModo.Text = "PRODUCCION";
                this.lblModo.ForeColor = System.Drawing.Color.Red;
                this.lblModoCaption.ForeColor = System.Drawing.Color.Red;
            } else
            {
                this.linklabel.Text = System.Configuration.ConfigurationManager.AppSettings["url_intranet_staging"];
                this.lblModo.Text = "STAGING";
                this.lblModo.ForeColor = System.Drawing.Color.Green;
                this.lblModoCaption.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void btConectar_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(Host=" +
                    txtServidorOracle.Text + ")(Port=" + txtPuerto.Text + ")))(CONNECT_DATA=(SERVICE_NAME=" +
                    txtNombreServicio.Text + "))); User Id=" + txtUsuario.Text + ";Password=" + txtContrasena.Text + "; ";
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

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            
            List<ComValue.IngresoPam> oListPam = new List<ComValue.IngresoPam>();
            ComAcceso.ProcesosAutomaticos oAcceso = new ComAcceso.ProcesosAutomaticos();

            oListPam = oAcceso.Ejecutar_IngresoPam();

            MessageBox.Show(oListPam.Count.ToString(), "MEnsajes xyz");

            */
            ComAcceso.ProcesosAutomaticos oAcceso = new ComAcceso.ProcesosAutomaticos();
            List<ComValue.GridProceso> oListGridProceso = new List<ComValue.GridProceso>();
            oListGridProceso = oAcceso.List_Procesos_Automaticos();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {


            this.txtServidorOracle.Text = "";
            this.txtPuerto.Text = "";
            this.txtNombreServicio.Text = "";
            this.txtUsuario.Text = "";
            this.txtContrasena.Text = "";
            this.txtLog.Text = "";

        }

        private void formMenuPrincipal_Load(object sender, EventArgs e)
        {
            if (this.loading) {

                this.dglistado.Visible = false;

                //string configvalue1 = ConfigurationManager.AppSettings["countoffiles"];
                /*
                    Obtener Listado para grilla
                 */
                //MessageBox.Show("Caption", configvalue1);

            } else
            {
                this.dglistado.Visible = true;
            }
        }

        private void lblcargando_Click(object sender, EventArgs e)
        {


        }
    }
}
