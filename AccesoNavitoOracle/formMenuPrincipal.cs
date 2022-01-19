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
using System.IO;
//using System.Configuration;


namespace AccesoNavitoOracle
{
    public partial class formMenuPrincipal : Form
    {
        private int production;
        private string cRutaLog = String.Empty;
        private int conteo;
        private Boolean InicioTimer;
        private ComValue.ManejadorLogs oLogErrores = new ComValue.ManejadorLogs();

        public formMenuPrincipal()
        {
            InitializeComponent();
            production  = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["production"]);

            if(production == 1){
                this.linklabel.Text = System.Configuration.ConfigurationManager.AppSettings["url_intranet_production"];
                this.lblModo.Text = ComValue.Enum.producion;
                this.lblModo.ForeColor = System.Drawing.Color.Red;
                this.lblModoCaption.ForeColor = System.Drawing.Color.Red;
                
            } else
            {
                this.linklabel.Text = System.Configuration.ConfigurationManager.AppSettings["url_intranet_staging"];
                this.lblModo.Text = ComValue.Enum.staging;
                this.lblModo.ForeColor = System.Drawing.Color.Green;
                this.lblModoCaption.ForeColor = System.Drawing.Color.Green;
            }

            this.lblrutacsv.Text = System.Configuration.ConfigurationManager.AppSettings["ruta_csv"];
            this.lblrutalog.Text = System.Configuration.ConfigurationManager.AppSettings["ruta_log"];

            this.dglistado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.Shown += new EventHandler(formMenuPrincipal_Shown);
            this.lblusuario.Text = Environment.UserName;
            cRutaLog = System.Configuration.ConfigurationManager.AppSettings["ruta_log"];

            this.lblvalidacion.Text = "Timer cada " + timerProcesoAutomatico.Interval.ToString() + " segundos.";
        }

        private void CargarGrilla()
        {


            this.lblcargando.Text = ComValue.Enum.mensaje_cargando_grilla;
            //this.lblcargando.Visible = true;
            this.dglistado.Visible = false;
            this.dglistado.Rows.Clear();
            
            ComAcceso.ProcesosAutomaticos oAcceso = new ComAcceso.ProcesosAutomaticos();
            List<ComValue.GridProceso> oListGridProceso = new List<ComValue.GridProceso>();
            oListGridProceso = oAcceso.List_Procesos_Automaticos();

            Button btn = new Button();
            btn.Text = ComValue.Enum.boton_ejecutar;

            Button btn2 = new Button();
            btn2.Text = ComValue.Enum.boton_generar_csv;

            foreach (ComValue.GridProceso ogrid in oListGridProceso)
            {
                dglistado.Rows.Add(ogrid.id, ogrid.nombre, ogrid.ultimaejecucion, ogrid.actualizadohasta, ogrid.rangodesde, ogrid.rangohasta, btn , btn2, ogrid.tiempo);
            
            }
            this.dglistado.Sort(this.dglistado.Columns["id"], ListSortDirection.Ascending);

            this.lblcargando.Text = "";
            lblcargando.Visible = false;
            this.dglistado.Visible = true;


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
            
            SetTimer();

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
                if (Convert.ToInt32(dglistado.CurrentRow.Index + 1) == 1)
                {
                    this.generate_csv_export(ComValue.Enum.ingreso_pam, ComValue.Enum.csv_ingreso_pam);
                }

                if (Convert.ToInt32(dglistado.CurrentRow.Index + 1) == 2)
                {
                    this.generate_csv_export(ComValue.Enum.recaudacion, ComValue.Enum.csv_recaudacion);
                
                }

                if (Convert.ToInt32(dglistado.CurrentRow.Index + 1) == 3)
                {
                    this.generate_csv_export(ComValue.Enum.envio_isapre, ComValue.Enum.csv_envio_isapre);

                }

                if (Convert.ToInt32(dglistado.CurrentRow.Index + 1) == 4)
                {
                    this.generate_csv_export(ComValue.Enum.anulacion_pam, ComValue.Enum.csv_anulacion_pam);

                }


            }
            // eject
            if (dglistado.CurrentCell.ColumnIndex.Equals(6))
            {

                if (Convert.ToInt32(dglistado.CurrentRow.Index + 1) == 1)
                {

                    this.eject_process(ComValue.Enum.ingreso_pam, ComValue.Enum.csv_ingreso_pam,1,1,0);
                }

                if (Convert.ToInt32(dglistado.CurrentRow.Index + 1) == 2)
                {

                    this.eject_process(ComValue.Enum.recaudacion, ComValue.Enum.csv_recaudacion, 1, 1, 0);

                }

                if (Convert.ToInt32(dglistado.CurrentRow.Index + 1) == 3)
                {

                    this.eject_process(ComValue.Enum.envio_isapre, ComValue.Enum.csv_envio_isapre, 1, 1, 0);

                }

                if (Convert.ToInt32(dglistado.CurrentRow.Index + 1) == 4)
                {

                    this.eject_process(ComValue.Enum.anulacion_pam, ComValue.Enum.csv_anulacion_pam, 1, 1, 0);

                }


            }


            }

        private void generate_csv_export(string tipo, string mensaje)
        {


            try //boque try con todas las operaciones
            {
                this.dglistado.Visible = false;
                this.lblcargando.Visible = true;
                this.lblcargando.Text = mensaje;
                string ruta_csv_generada = String.Empty;

                ///

                ComAcceso.CsvExport o = new ComAcceso.CsvExport(tipo,ref ruta_csv_generada);
                this.dglistado.Visible = true;
                this.lblcargando.Text = "";
                this.lblcargando.Visible = false;

                MessageBox.Show(ComValue.Enum.mensaje_csv_ok + " en la ruta " + ruta_csv_generada, ComValue.Enum.titulo_mensaje); 
                
            }
            catch (Exception ex) //bloque catch para captura de error
            {
                MessageBox.Show("Ha Ocurrido un Error " + ex.ToString(), ComValue.Enum.titulo_mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void eject_process(string tipo , string mensaje , int view_message = 0 , int reload_grilla = 1 , int second = 0)
        {
            object result = null;

            try //boque try con todas las operaciones
            {
                this.dglistado.Visible = false;
                this.lblcargando.Visible = true;
                this.lblcargando.Text = mensaje;

                ComAcceso.Eject o = new ComAcceso.Eject();
                oLogErrores.CreateLogFiles();
                oLogErrores.ErrorLog(cRutaLog, ComValue.Enum.log_inicio_eject + tipo);

                result = o.sendTointranet(tipo, second);

                if(reload_grilla == 1)
                {
                    this.CargarGrilla();
                }
                

                oLogErrores.CreateLogFiles();
                oLogErrores.ErrorLog(cRutaLog, ComValue.Enum.log_termino_eject + tipo);


                this.dglistado.Visible = true;
                this.lblcargando.Text = "";
                this.lblcargando.Visible = false;

                if(view_message == 1)
                {

                    MessageBox.Show(ComValue.Enum.mensaje_eject_ok, ComValue.Enum.titulo_mensaje);
                
                }
                
            }
            catch (Exception ex) //bloque catch para captura de error
            {
                if (view_message == 1)
                {
                 
                    MessageBox.Show("Ha Ocurrido un Error " + ex.ToString(), ComValue.Enum.titulo_mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);

                } 
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

        private  void SetTimer()
        {
            conteo = 0;
            InicioTimer = true;
            if(InicioTimer == false){
                this.cmdiniciar.Enabled = true;
                this.cmddetener.Enabled = false;
                this.lblfechainiciovalidacion.Text = "";
            } else
            {   
                this.lblhorainiciovalidacion.Text = DateTime.Now.ToString(ComValue.Enum.format_hora);
                this.lblfechainiciovalidacion.Text = DateTime.Now.ToString(ComValue.Enum.format_fecha);
                this.cmdiniciar.Enabled = false;
                this.cmddetener.Enabled = true;
            }
            this.lblConteo.Visible = false;
        }

        private void timerProcesoAutomatico_Tick(object sender, EventArgs e)
        {

            // EJecutar Logica de procesos automaticos
            int veces_ejecutar = 0;
            int veces_ejecutar_second = 0;

            if(DateTime.Now.DayOfWeek == DayOfWeek.Monday ||
               DateTime.Now.DayOfWeek == DayOfWeek.Tuesday ||
               DateTime.Now.DayOfWeek == DayOfWeek.Wednesday ||
               DateTime.Now.DayOfWeek == DayOfWeek.Thursday ||
               DateTime.Now.DayOfWeek == DayOfWeek.Friday
               )
            {

                if(DateTime.Now.Hour == ComValue.Enum.hora_proceso ||
                    DateTime.Now.Hour == ComValue.Enum.hora_second_time_proceso)
                {
                    // only execute one time
                    if(DateTime.Now.Hour == ComValue.Enum.hora_proceso)
                    {

                        if (veces_ejecutar == 0) {
                            this.eject_process(ComValue.Enum.ingreso_pam, ComValue.Enum.csv_ingreso_pam, 0, 0,0);
                            this.eject_process(ComValue.Enum.recaudacion, ComValue.Enum.csv_recaudacion, 0, 0,0);
                            this.eject_process(ComValue.Enum.envio_isapre, ComValue.Enum.csv_envio_isapre, 0, 0,0);

                            this.CargarGrilla();
                            veces_ejecutar = -1;
                        }

                        
                    }

                    if(DateTime.Now.Hour == ComValue.Enum.hora_second_time_proceso)
                    {
                            
                        if(veces_ejecutar_second == 0)
                        {

                            this.eject_process(ComValue.Enum.ingreso_pam, ComValue.Enum.csv_ingreso_pam, 0, 0,1);
                            this.CargarGrilla();
                            veces_ejecutar_second = -1;

                        }
                    }
                    

                } else
                {
                    // To other day set the next variables.
                    if(DateTime.Now.Hour ==  0)
                    {
                        veces_ejecutar = 0;
                        veces_ejecutar_second = 0;
                    }
                }
                

                    
            }


        }

        private void cmdiniciar_Click(object sender, EventArgs e)
        {
            timerProcesoAutomatico.Enabled = true;
            timerProcesoAutomatico.Interval = 1*60*1000;
            this.cmdiniciar.Enabled = false;
            this.cmddetener.Enabled = true;
            this.lblhorainiciovalidacion.Text = DateTime.Now.ToString(ComValue.Enum.format_hora);
            this.lblfechainiciovalidacion.Text = DateTime.Now.ToString(ComValue.Enum.format_fecha);

        }

        private void cmddetener_Click(object sender, EventArgs e)
        {

            timerProcesoAutomatico.Enabled = false;
            this.cmdiniciar.Enabled = true;
            this.cmddetener.Enabled = false;
            this.conteo = 0;
            this.lblConteo.Text = "";
            this.lblhorainiciovalidacion.Text = "";
            this.lblfechainiciovalidacion.Text = "";

        }

        private void formMenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerProcesoAutomatico.Enabled = false;
            timerHora.Enabled = false;
        }

        private void timerHora_Tick(object sender, EventArgs e)
        {
            this.lblhora.Text = DateTime.Now.ToString(ComValue.Enum.format_hora);
        }

        private void cmdlimpiarcsv_Click(object sender, EventArgs e)
        {
            this.cleanFiles(this.lblrutacsv.Text, "Borrado de Archivos de CSV exitoso.");
        }

        private void cleanFiles(string ruta,string mensaje)
        {

            try //boque try con todas las operaciones
            {
                DirectoryInfo di = new DirectoryInfo(@"" + ruta);
                FileInfo[] files = di.GetFiles();
                foreach (FileInfo file in files)
                {
                    file.Delete();
                }

                MessageBox.Show(mensaje, ComValue.Enum.titulo_mensaje, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex) //bloque catch para captura de error
            {
                MessageBox.Show("Ha Ocurrido un Error " + ex.ToString(), ComValue.Enum.titulo_mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           

        }

        private void cmdlimpiarlog_Click(object sender, EventArgs e)
        {
            this.cleanFiles(this.lblrutalog.Text, "Borrado de Archivos  de Logs exitoso.");
        }

        private void cmdrecargar_Click(object sender, EventArgs e)
        {
            this.CargarGrilla();
        }
    }
}
