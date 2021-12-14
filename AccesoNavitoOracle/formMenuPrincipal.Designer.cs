namespace AccesoNavitoOracle
{
    partial class formMenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btConectar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNombreServicio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServidorOracle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_listado_procesos = new System.Windows.Forms.TabPage();
            this.linklabel = new System.Windows.Forms.LinkLabel();
            this.lblModoCaption = new System.Windows.Forms.Label();
            this.lblAmbiente = new System.Windows.Forms.Label();
            this.lblcargando = new System.Windows.Forms.Label();
            this.dglistado = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ultimaeject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actualizadohasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rangodesde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rangohasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tab_configuracion = new System.Windows.Forms.TabPage();
            this.tab_probar_conexion = new System.Windows.Forms.TabPage();
            this.btnClean = new System.Windows.Forms.Button();
            this.lblModo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab_listado_procesos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglistado)).BeginInit();
            this.tab_probar_conexion.SuspendLayout();
            this.SuspendLayout();
            // 
            // btConectar
            // 
            this.btConectar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btConectar.Location = new System.Drawing.Point(6, 189);
            this.btConectar.Name = "btConectar";
            this.btConectar.Size = new System.Drawing.Size(133, 23);
            this.btConectar.TabIndex = 1;
            this.btConectar.Text = "Probar Conexion";
            this.btConectar.UseVisualStyleBackColor = true;
            this.btConectar.Click += new System.EventHandler(this.btConectar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtNombreServicio);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPuerto);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtContrasena);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtServidorOracle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(924, 167);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de conexión ";
            // 
            // txtNombreServicio
            // 
            this.txtNombreServicio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreServicio.Location = new System.Drawing.Point(105, 129);
            this.txtNombreServicio.Name = "txtNombreServicio";
            this.txtNombreServicio.Size = new System.Drawing.Size(785, 20);
            this.txtNombreServicio.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Nombre servicio";
            // 
            // txtPuerto
            // 
            this.txtPuerto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPuerto.Location = new System.Drawing.Point(105, 102);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(785, 20);
            this.txtPuerto.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Puerto";
            // 
            // txtContrasena
            // 
            this.txtContrasena.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContrasena.Location = new System.Drawing.Point(105, 75);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.Size = new System.Drawing.Size(785, 20);
            this.txtContrasena.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuario.Location = new System.Drawing.Point(105, 49);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(785, 20);
            this.txtUsuario.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Usuario";
            // 
            // txtServidorOracle
            // 
            this.txtServidorOracle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServidorOracle.Location = new System.Drawing.Point(104, 23);
            this.txtServidorOracle.Name = "txtServidorOracle";
            this.txtServidorOracle.Size = new System.Drawing.Size(785, 20);
            this.txtServidorOracle.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Servidor Oracle";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(6, 218);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(924, 225);
            this.txtLog.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Boton de Prueba - Ingreso PAM";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_listado_procesos);
            this.tabControl1.Controls.Add(this.tab_configuracion);
            this.tabControl1.Controls.Add(this.tab_probar_conexion);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(959, 475);
            this.tabControl1.TabIndex = 4;
            // 
            // tab_listado_procesos
            // 
            this.tab_listado_procesos.Controls.Add(this.lblModo);
            this.tab_listado_procesos.Controls.Add(this.linklabel);
            this.tab_listado_procesos.Controls.Add(this.lblModoCaption);
            this.tab_listado_procesos.Controls.Add(this.lblAmbiente);
            this.tab_listado_procesos.Controls.Add(this.lblcargando);
            this.tab_listado_procesos.Controls.Add(this.dglistado);
            this.tab_listado_procesos.Controls.Add(this.button1);
            this.tab_listado_procesos.Location = new System.Drawing.Point(4, 22);
            this.tab_listado_procesos.Name = "tab_listado_procesos";
            this.tab_listado_procesos.Padding = new System.Windows.Forms.Padding(3);
            this.tab_listado_procesos.Size = new System.Drawing.Size(951, 449);
            this.tab_listado_procesos.TabIndex = 0;
            this.tab_listado_procesos.Text = "Listado de Procesos";
            this.tab_listado_procesos.UseVisualStyleBackColor = true;
            // 
            // linklabel
            // 
            this.linklabel.AutoSize = true;
            this.linklabel.LinkColor = System.Drawing.SystemColors.MenuHighlight;
            this.linklabel.Location = new System.Drawing.Point(116, 8);
            this.linklabel.Name = "linklabel";
            this.linklabel.Size = new System.Drawing.Size(45, 13);
            this.linklabel.TabIndex = 8;
            this.linklabel.TabStop = true;
            this.linklabel.Text = "linklabel";
            // 
            // lblModoCaption
            // 
            this.lblModoCaption.AutoSize = true;
            this.lblModoCaption.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblModoCaption.Location = new System.Drawing.Point(22, 27);
            this.lblModoCaption.Name = "lblModoCaption";
            this.lblModoCaption.Size = new System.Drawing.Size(40, 13);
            this.lblModoCaption.TabIndex = 7;
            this.lblModoCaption.Text = "MODO";
            // 
            // lblAmbiente
            // 
            this.lblAmbiente.AutoSize = true;
            this.lblAmbiente.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblAmbiente.Location = new System.Drawing.Point(20, 8);
            this.lblAmbiente.Name = "lblAmbiente";
            this.lblAmbiente.Size = new System.Drawing.Size(90, 13);
            this.lblAmbiente.TabIndex = 6;
            this.lblAmbiente.Text = "URL AMBIENTE:";
            // 
            // lblcargando
            // 
            this.lblcargando.AutoSize = true;
            this.lblcargando.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcargando.Location = new System.Drawing.Point(373, 159);
            this.lblcargando.Name = "lblcargando";
            this.lblcargando.Size = new System.Drawing.Size(108, 20);
            this.lblcargando.TabIndex = 5;
            this.lblcargando.Text = "Cargando . . .";
            this.lblcargando.Click += new System.EventHandler(this.lblcargando_Click);
            // 
            // dglistado
            // 
            this.dglistado.AllowUserToAddRows = false;
            this.dglistado.AllowUserToDeleteRows = false;
            this.dglistado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dglistado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.ultimaeject,
            this.actualizadohasta,
            this.rangodesde,
            this.rangohasta,
            this.accion});
            this.dglistado.Location = new System.Drawing.Point(7, 44);
            this.dglistado.Name = "dglistado";
            this.dglistado.ReadOnly = true;
            this.dglistado.Size = new System.Drawing.Size(842, 213);
            this.dglistado.TabIndex = 4;
            // 
            // id
            // 
            this.id.Frozen = true;
            this.id.HeaderText = "#";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // ultimaeject
            // 
            this.ultimaeject.HeaderText = "Ultima Ejecucion";
            this.ultimaeject.Name = "ultimaeject";
            this.ultimaeject.ReadOnly = true;
            // 
            // actualizadohasta
            // 
            this.actualizadohasta.HeaderText = "Actualizado hasta";
            this.actualizadohasta.Name = "actualizadohasta";
            this.actualizadohasta.ReadOnly = true;
            // 
            // rangodesde
            // 
            this.rangodesde.HeaderText = "Rango Desde";
            this.rangodesde.Name = "rangodesde";
            this.rangodesde.ReadOnly = true;
            // 
            // rangohasta
            // 
            this.rangohasta.HeaderText = "Rango Hasta";
            this.rangohasta.Name = "rangohasta";
            this.rangohasta.ReadOnly = true;
            // 
            // accion
            // 
            this.accion.HeaderText = "Accion";
            this.accion.Name = "accion";
            this.accion.ReadOnly = true;
            // 
            // tab_configuracion
            // 
            this.tab_configuracion.Location = new System.Drawing.Point(4, 22);
            this.tab_configuracion.Name = "tab_configuracion";
            this.tab_configuracion.Padding = new System.Windows.Forms.Padding(3);
            this.tab_configuracion.Size = new System.Drawing.Size(951, 449);
            this.tab_configuracion.TabIndex = 1;
            this.tab_configuracion.Text = "Configuracion";
            this.tab_configuracion.UseVisualStyleBackColor = true;
            // 
            // tab_probar_conexion
            // 
            this.tab_probar_conexion.Controls.Add(this.btnClean);
            this.tab_probar_conexion.Controls.Add(this.groupBox1);
            this.tab_probar_conexion.Controls.Add(this.txtLog);
            this.tab_probar_conexion.Controls.Add(this.btConectar);
            this.tab_probar_conexion.Location = new System.Drawing.Point(4, 22);
            this.tab_probar_conexion.Name = "tab_probar_conexion";
            this.tab_probar_conexion.Padding = new System.Windows.Forms.Padding(3);
            this.tab_probar_conexion.Size = new System.Drawing.Size(951, 449);
            this.tab_probar_conexion.TabIndex = 2;
            this.tab_probar_conexion.Text = "Probar Conexion";
            this.tab_probar_conexion.UseVisualStyleBackColor = true;
            // 
            // btnClean
            // 
            this.btnClean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClean.Location = new System.Drawing.Point(797, 189);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(133, 23);
            this.btnClean.TabIndex = 3;
            this.btnClean.Text = "Limpiar";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // lblModo
            // 
            this.lblModo.AutoSize = true;
            this.lblModo.ForeColor = System.Drawing.Color.Firebrick;
            this.lblModo.Location = new System.Drawing.Point(116, 28);
            this.lblModo.Name = "lblModo";
            this.lblModo.Size = new System.Drawing.Size(44, 13);
            this.lblModo.TabIndex = 9;
            this.lblModo.Text = "lblModo";
            // 
            // formMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 497);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proceso Automaticos";
            this.Load += new System.EventHandler(this.formMenuPrincipal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tab_listado_procesos.ResumeLayout(false);
            this.tab_listado_procesos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dglistado)).EndInit();
            this.tab_probar_conexion.ResumeLayout(false);
            this.tab_probar_conexion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btConectar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtServidorOracle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtNombreServicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_listado_procesos;
        private System.Windows.Forms.TabPage tab_configuracion;
        private System.Windows.Forms.TabPage tab_probar_conexion;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Label lblcargando;
        private System.Windows.Forms.DataGridView dglistado;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ultimaeject;
        private System.Windows.Forms.DataGridViewTextBoxColumn actualizadohasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn rangodesde;
        private System.Windows.Forms.DataGridViewTextBoxColumn rangohasta;
        private System.Windows.Forms.DataGridViewButtonColumn accion;
        private System.Windows.Forms.Label lblModoCaption;
        private System.Windows.Forms.Label lblAmbiente;
        private System.Windows.Forms.LinkLabel linklabel;
        private System.Windows.Forms.Label lblModo;
    }
}

