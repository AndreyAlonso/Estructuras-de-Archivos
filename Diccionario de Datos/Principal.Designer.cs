﻿namespace Diccionario_de_Datos
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.minimizar = new System.Windows.Forms.Button();
            this.Cerrar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cabecera = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DSIG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.nombreAtributo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DirA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DirSig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminaAtributo = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboIndice = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboTipo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.DR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertarRegistro = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.indicePrimario = new System.Windows.Forms.DataGridView();
            this.cve_busqueda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cve_dir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.Índice = new System.Windows.Forms.TabPage();
            this.cEntidadRegistro = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textoIndice = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indicePrimario)).BeginInit();
            this.Índice.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.minimizar);
            this.panel1.Controls.Add(this.Cerrar);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // minimizar
            // 
            resources.ApplyResources(this.minimizar, "minimizar");
            this.minimizar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.minimizar.ForeColor = System.Drawing.Color.White;
            this.minimizar.Name = "minimizar";
            this.minimizar.UseVisualStyleBackColor = false;
            this.minimizar.Click += new System.EventHandler(this.minimizate);
            // 
            // Cerrar
            // 
            resources.ApplyResources(this.Cerrar, "Cerrar");
            this.Cerrar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Cerrar.ForeColor = System.Drawing.Color.White;
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = false;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            this.Cerrar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Cierrate);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.Índice);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage1.Controls.Add(this.cabecera);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.button8);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // cabecera
            // 
            resources.ApplyResources(this.cabecera, "cabecera");
            this.cabecera.Name = "cabecera";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // button8
            // 
            resources.ApplyResources(this.button8, "button8");
            this.button8.BackColor = System.Drawing.Color.Green;
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Name = "button8";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.nuevoProyecto);
            // 
            // button7
            // 
            resources.ApplyResources(this.button7, "button7");
            this.button7.BackColor = System.Drawing.Color.Firebrick;
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Name = "button7";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.abreArchivo);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.eliminaEntidad);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.creaEntidad);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.DE,
            this.DA,
            this.DD,
            this.DSIG});
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            // 
            // Nombre
            // 
            resources.ApplyResources(this.Nombre, "Nombre");
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // DE
            // 
            resources.ApplyResources(this.DE, "DE");
            this.DE.Name = "DE";
            this.DE.ReadOnly = true;
            // 
            // DA
            // 
            resources.ApplyResources(this.DA, "DA");
            this.DA.Name = "DA";
            this.DA.ReadOnly = true;
            // 
            // DD
            // 
            resources.ApplyResources(this.DD, "DD");
            this.DD.Name = "DD";
            this.DD.ReadOnly = true;
            // 
            // DSIG
            // 
            resources.ApplyResources(this.DSIG, "DSIG");
            this.DSIG.Name = "DSIG";
            this.DSIG.ReadOnly = true;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.eliminaAtributo);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.label3);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreAtributo,
            this.tipo,
            this.longitud,
            this.DirA,
            this.TI,
            this.DI,
            this.DirSig});
            resources.ApplyResources(this.dataGridView2, "dataGridView2");
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            // 
            // nombreAtributo
            // 
            resources.ApplyResources(this.nombreAtributo, "nombreAtributo");
            this.nombreAtributo.Name = "nombreAtributo";
            this.nombreAtributo.ReadOnly = true;
            // 
            // tipo
            // 
            resources.ApplyResources(this.tipo, "tipo");
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            // 
            // longitud
            // 
            resources.ApplyResources(this.longitud, "longitud");
            this.longitud.Name = "longitud";
            this.longitud.ReadOnly = true;
            // 
            // DirA
            // 
            resources.ApplyResources(this.DirA, "DirA");
            this.DirA.Name = "DirA";
            this.DirA.ReadOnly = true;
            // 
            // TI
            // 
            resources.ApplyResources(this.TI, "TI");
            this.TI.Name = "TI";
            this.TI.ReadOnly = true;
            // 
            // DI
            // 
            resources.ApplyResources(this.DI, "DI");
            this.DI.Name = "DI";
            this.DI.ReadOnly = true;
            // 
            // DirSig
            // 
            resources.ApplyResources(this.DirSig, "DirSig");
            this.DirSig.Name = "DirSig";
            this.DirSig.ReadOnly = true;
            // 
            // eliminaAtributo
            // 
            resources.ApplyResources(this.eliminaAtributo, "eliminaAtributo");
            this.eliminaAtributo.BackColor = System.Drawing.SystemColors.HotTrack;
            this.eliminaAtributo.ForeColor = System.Drawing.Color.White;
            this.eliminaAtributo.Name = "eliminaAtributo";
            this.eliminaAtributo.UseVisualStyleBackColor = false;
            this.eliminaAtributo.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            resources.ApplyResources(this.button6, "button6");
            this.button6.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.creaAtributo);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboIndice);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboTipo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label4);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // comboIndice
            // 
            resources.ApplyResources(this.comboIndice, "comboIndice");
            this.comboIndice.FormattingEnabled = true;
            this.comboIndice.Items.AddRange(new object[] {
            resources.GetString("comboIndice.Items"),
            resources.GetString("comboIndice.Items1"),
            resources.GetString("comboIndice.Items2"),
            resources.GetString("comboIndice.Items3"),
            resources.GetString("comboIndice.Items4"),
            resources.GetString("comboIndice.Items5")});
            this.comboIndice.Name = "comboIndice";
            this.comboIndice.SelectedIndexChanged += new System.EventHandler(this.comboIndice_SelectedIndexChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // textBox3
            // 
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // comboTipo
            // 
            resources.ApplyResources(this.comboTipo, "comboTipo");
            this.comboTipo.FormattingEnabled = true;
            this.comboTipo.Items.AddRange(new object[] {
            resources.GetString("comboTipo.Items"),
            resources.GetString("comboTipo.Items1")});
            this.comboTipo.Name = "comboTipo";
            this.comboTipo.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            this.textBox2.TextChanged += new System.EventHandler(this.nombraAtributo);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // comboBox1
            // 
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.seleccionaEntidad);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.comboBox6);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.dataGridView4);
            this.tabPage3.Controls.Add(this.insertarRegistro);
            this.tabPage3.Controls.Add(this.dataGridView3);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // comboBox6
            // 
            resources.ApplyResources(this.comboBox6, "comboBox6");
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.SelectedIndexChanged += new System.EventHandler(this.comboBox6_SelectedIndexChanged);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DR});
            resources.ApplyResources(this.dataGridView4, "dataGridView4");
            this.dataGridView4.Name = "dataGridView4";
            // 
            // DR
            // 
            resources.ApplyResources(this.DR, "DR");
            this.DR.Name = "DR";
            // 
            // insertarRegistro
            // 
            this.insertarRegistro.BackColor = System.Drawing.SystemColors.HotTrack;
            resources.ApplyResources(this.insertarRegistro, "insertarRegistro");
            this.insertarRegistro.ForeColor = System.Drawing.Color.White;
            this.insertarRegistro.Name = "insertarRegistro";
            this.insertarRegistro.UseVisualStyleBackColor = false;
            this.insertarRegistro.Click += new System.EventHandler(this.insertarRegistro_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView3, "dataGridView3");
            this.dataGridView3.Name = "dataGridView3";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.indicePrimario);
            this.tabPage4.Controls.Add(this.label10);
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // indicePrimario
            // 
            this.indicePrimario.AllowUserToAddRows = false;
            this.indicePrimario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.indicePrimario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cve_busqueda,
            this.cve_dir});
            resources.ApplyResources(this.indicePrimario, "indicePrimario");
            this.indicePrimario.Name = "indicePrimario";
            this.indicePrimario.ReadOnly = true;
            // 
            // cve_busqueda
            // 
            resources.ApplyResources(this.cve_busqueda, "cve_busqueda");
            this.cve_busqueda.Name = "cve_busqueda";
            this.cve_busqueda.ReadOnly = true;
            // 
            // cve_dir
            // 
            resources.ApplyResources(this.cve_dir, "cve_dir");
            this.cve_dir.Name = "cve_dir";
            this.cve_dir.ReadOnly = true;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // Índice
            // 
            this.Índice.Controls.Add(this.cEntidadRegistro);
            this.Índice.Controls.Add(this.label12);
            this.Índice.Controls.Add(this.textoIndice);
            this.Índice.Controls.Add(this.label11);
            this.Índice.Controls.Add(this.comboBox5);
            this.Índice.Controls.Add(this.label13);
            resources.ApplyResources(this.Índice, "Índice");
            this.Índice.Name = "Índice";
            this.Índice.UseVisualStyleBackColor = true;
            // 
            // cEntidadRegistro
            // 
            resources.ApplyResources(this.cEntidadRegistro, "cEntidadRegistro");
            this.cEntidadRegistro.FormattingEnabled = true;
            this.cEntidadRegistro.Name = "cEntidadRegistro";
            this.cEntidadRegistro.SelectedIndexChanged += new System.EventHandler(this.cEntidadRegistro_SelectedIndexChanged);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // textoIndice
            // 
            resources.ApplyResources(this.textoIndice, "textoIndice");
            this.textoIndice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.textoIndice.Name = "textoIndice";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // comboBox5
            // 
            resources.ApplyResources(this.comboBox5, "comboBox5");
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Principal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Principal";
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indicePrimario)).EndInit();
            this.Índice.ResumeLayout(false);
            this.Índice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button minimizar;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn DE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DSIG;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboTipo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboIndice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button eliminaAtributo;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreAtributo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn longitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn DirA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TI;
        private System.Windows.Forms.DataGridViewTextBoxColumn DI;
        private System.Windows.Forms.DataGridViewTextBoxColumn DirSig;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox cabecera;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button insertarRegistro;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.DataGridViewTextBoxColumn DR;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView indicePrimario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cve_busqueda;
        private System.Windows.Forms.DataGridViewTextBoxColumn cve_dir;
        private System.Windows.Forms.TabPage Índice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label textoIndice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cEntidadRegistro;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label14;
    }
}

