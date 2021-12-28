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
        private int production;
        public formMenuPrincipal()
        {
            InitializeComponent();
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

            this.lblrutacsv.Text = System.Configuration.ConfigurationManager.AppSettings["ruta_csv"];

            this.dglistado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.Shown += new EventHandler(formMenuPrincipal_Shown);

        }

        private void CargarGrilla()
        {

            ComAcceso.ProcesosAutomaticos oAcceso = new ComAcceso.ProcesosAutomaticos();
            List<ComValue.GridProceso> oListGridProceso = new List<ComValue.GridProceso>();
            oListGridProceso = oAcceso.List_Procesos_Automaticos();

            Button btn = new Button();
            btn.Text = "Ejecutar";

            foreach (ComValue.GridProceso ogrid in oListGridProceso)
            {
                dglistado.Rows.Add(ogrid.id, ogrid.nombre, ogrid.ultimaejecucion, ogrid.actualizadohasta, ogrid.rangodesde, ogrid.rangohasta, btn);
            
            }

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

            this.VisibleGrilla(false);

        }

        private void formMenuPrincipal_Shown(Object sender, EventArgs e)
        {
             this.CargarGrilla();

            this.VisibleGrilla(true);

        }

        private void VisibleGrilla(Boolean bvalue)
        {
            this.dglistado.Visible = bvalue;
            this.lblcargando.Visible = !bvalue;
        }

        private void dglistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dglistado.CurrentCell.ColumnIndex.Equals(7))
            {
     
                   // MessageBox.Show(dglistado.CurrentCell.Value.ToString());
                    this.dglistado.Visible = false;
                    this.lblcargando.Visible = true;
                    this.lblcargando.Text = "Generando CSV - Ingreso Flujo PAM . . .";
                    
                    ComAcceso.CsvExport o = new ComAcceso.CsvExport("ingreso_pam");
                    this.dglistado.Visible = true;
                    this.lblcargando.Text = "";
                    this.lblcargando.Visible = false;

                    MessageBox.Show("CSV Generado Correctamente", "Atencion, Aviso Importante");

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
    }
}
