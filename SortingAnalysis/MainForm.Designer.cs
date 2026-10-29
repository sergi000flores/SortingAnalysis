#nullable disable
namespace SortingAnalysis
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleRight = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.nudSemilla = new System.Windows.Forms.NumericUpDown();
            this.lblSemilla = new System.Windows.Forms.Label();
            this.txtTamanos = new System.Windows.Forms.TextBox();
            this.lblTamanos = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabResultados = new System.Windows.Forms.TabPage();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.colN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBubbleMs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBubbleComp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBubbleMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBubbleMem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMergeMs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMergeComp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMergeMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMergeMem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpeedup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtConclusion = new System.Windows.Forms.TextBox();
            this.tabGrafica = new System.Windows.Forms.TabPage();
            this.graphPanel = new SortingAnalysis.GraphPanel();
            this.pnlGraficaOpciones = new System.Windows.Forms.Panel();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.cmbMetrica = new System.Windows.Forms.ComboBox();
            this.lblMetrica = new System.Windows.Forms.Label();
            this.tabAnalisis = new System.Windows.Forms.TabPage();
            this.txtAnalisis = new System.Windows.Forms.TextBox();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSemilla)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.tabGrafica.SuspendLayout();
            this.pnlGraficaOpciones.SuspendLayout();
            this.tabAnalisis.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblEstado);
            this.pnlTop.Controls.Add(this.progressBar);
            this.pnlTop.Controls.Add(this.btnLimpiar);
            this.pnlTop.Controls.Add(this.btnEjecutar);
            this.pnlTop.Controls.Add(this.nudSemilla);
            this.pnlTop.Controls.Add(this.lblSemilla);
            this.pnlTop.Controls.Add(this.txtTamanos);
            this.pnlTop.Controls.Add(this.lblTamanos);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1100, 76);
            this.pnlTop.TabIndex = 1;
            // 
            // lblTamanos
            // 
            this.lblTamanos.AutoSize = true;
            this.lblTamanos.Location = new System.Drawing.Point(12, 12);
            this.lblTamanos.Name = "lblTamanos";
            this.lblTamanos.Size = new System.Drawing.Size(190, 15);
            this.lblTamanos.Text = "Tamaños n (separados por comas):";
            // 
            // txtTamanos
            // 
            this.txtTamanos.Location = new System.Drawing.Point(12, 32);
            this.txtTamanos.Name = "txtTamanos";
            this.txtTamanos.Size = new System.Drawing.Size(330, 23);
            this.txtTamanos.TabIndex = 0;
            this.txtTamanos.Text = "100, 500, 1000, 2000, 5000, 10000";
            // 
            // lblSemilla
            // 
            this.lblSemilla.AutoSize = true;
            this.lblSemilla.Location = new System.Drawing.Point(360, 12);
            this.lblSemilla.Name = "lblSemilla";
            this.lblSemilla.Size = new System.Drawing.Size(98, 15);
            this.lblSemilla.Text = "Semilla aleatoria:";
            // 
            // nudSemilla
            // 
            this.nudSemilla.Location = new System.Drawing.Point(360, 32);
            this.nudSemilla.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudSemilla.Name = "nudSemilla";
            this.nudSemilla.Size = new System.Drawing.Size(100, 23);
            this.nudSemilla.TabIndex = 1;
            this.nudSemilla.Value = new decimal(new int[] { 42, 0, 0, 0 });
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Location = new System.Drawing.Point(480, 28);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(120, 30);
            this.btnEjecutar.TabIndex = 2;
            this.btnEjecutar.Text = "▶ Ejecutar análisis";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(610, 28);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(90, 30);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(720, 36);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(240, 22);
            this.progressBar.TabIndex = 4;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(720, 14);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(32, 15);
            this.lblEstado.Text = "Listo";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabResultados);
            this.tabMain.Controls.Add(this.tabGrafica);
            this.tabMain.Controls.Add(this.tabAnalisis);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 76);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1100, 604);
            this.tabMain.TabIndex = 0;
            // 
            // tabResultados
            // 
            this.tabResultados.Controls.Add(this.dgvResultados);
            this.tabResultados.Controls.Add(this.txtConclusion);
            this.tabResultados.Location = new System.Drawing.Point(4, 24);
            this.tabResultados.Name = "tabResultados";
            this.tabResultados.Padding = new System.Windows.Forms.Padding(3);
            this.tabResultados.Size = new System.Drawing.Size(1092, 576);
            this.tabResultados.TabIndex = 0;
            this.tabResultados.Text = "Resultados (empírico)";
            this.tabResultados.UseVisualStyleBackColor = true;
            // 
            // dgvResultados
            // 
            this.dgvResultados.AllowUserToAddRows = false;
            this.dgvResultados.AllowUserToDeleteRows = false;
            this.dgvResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResultados.ColumnHeadersHeight = 52;
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvResultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colN,
            this.colBubbleMs,
            this.colBubbleComp,
            this.colBubbleMov,
            this.colBubbleMem,
            this.colMergeMs,
            this.colMergeComp,
            this.colMergeMov,
            this.colMergeMem,
            this.colSpeedup});
            this.dgvResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResultados.Location = new System.Drawing.Point(3, 3);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.ReadOnly = true;
            this.dgvResultados.RowHeadersVisible = false;
            this.dgvResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResultados.Size = new System.Drawing.Size(1086, 450);
            this.dgvResultados.TabIndex = 0;
            dataGridViewCellStyleRight.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvResultados.DefaultCellStyle = dataGridViewCellStyleRight;
            // 
            // colN
            // 
            this.colN.HeaderText = "n";
            this.colN.Name = "colN";
            this.colN.ReadOnly = true;
            // 
            // colBubbleMs
            // 
            this.colBubbleMs.HeaderText = "Bubble: tiempo (ms)";
            this.colBubbleMs.Name = "colBubbleMs";
            this.colBubbleMs.ReadOnly = true;
            // 
            // colBubbleComp
            // 
            this.colBubbleComp.HeaderText = "Bubble: comparaciones";
            this.colBubbleComp.Name = "colBubbleComp";
            this.colBubbleComp.ReadOnly = true;
            // 
            // colBubbleMov
            // 
            this.colBubbleMov.HeaderText = "Bubble: movimientos";
            this.colBubbleMov.Name = "colBubbleMov";
            this.colBubbleMov.ReadOnly = true;
            // 
            // colBubbleMem
            // 
            this.colBubbleMem.HeaderText = "Bubble: memoria extra (B)";
            this.colBubbleMem.Name = "colBubbleMem";
            this.colBubbleMem.ReadOnly = true;
            // 
            // colMergeMs
            // 
            this.colMergeMs.HeaderText = "Merge: tiempo (ms)";
            this.colMergeMs.Name = "colMergeMs";
            this.colMergeMs.ReadOnly = true;
            // 
            // colMergeComp
            // 
            this.colMergeComp.HeaderText = "Merge: comparaciones";
            this.colMergeComp.Name = "colMergeComp";
            this.colMergeComp.ReadOnly = true;
            // 
            // colMergeMov
            // 
            this.colMergeMov.HeaderText = "Merge: movimientos";
            this.colMergeMov.Name = "colMergeMov";
            this.colMergeMov.ReadOnly = true;
            // 
            // colMergeMem
            // 
            this.colMergeMem.HeaderText = "Merge: memoria extra (B)";
            this.colMergeMem.Name = "colMergeMem";
            this.colMergeMem.ReadOnly = true;
            // 
            // colSpeedup
            // 
            this.colSpeedup.HeaderText = "Aceleración Merge vs Bubble";
            this.colSpeedup.Name = "colSpeedup";
            this.colSpeedup.ReadOnly = true;
            // 
            // txtConclusion
            // 
            this.txtConclusion.BackColor = System.Drawing.SystemColors.Window;
            this.txtConclusion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtConclusion.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.txtConclusion.Location = new System.Drawing.Point(3, 453);
            this.txtConclusion.Multiline = true;
            this.txtConclusion.Name = "txtConclusion";
            this.txtConclusion.ReadOnly = true;
            this.txtConclusion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConclusion.Size = new System.Drawing.Size(1086, 120);
            this.txtConclusion.TabIndex = 1;
            // 
            // tabGrafica
            // 
            this.tabGrafica.Controls.Add(this.graphPanel);
            this.tabGrafica.Controls.Add(this.pnlGraficaOpciones);
            this.tabGrafica.Location = new System.Drawing.Point(4, 24);
            this.tabGrafica.Name = "tabGrafica";
            this.tabGrafica.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrafica.Size = new System.Drawing.Size(1092, 576);
            this.tabGrafica.TabIndex = 1;
            this.tabGrafica.Text = "Gráfica";
            this.tabGrafica.UseVisualStyleBackColor = true;
            // 
            // graphPanel
            // 
            this.graphPanel.BackColor = System.Drawing.Color.White;
            this.graphPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphPanel.Location = new System.Drawing.Point(3, 43);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(1086, 530);
            this.graphPanel.TabIndex = 0;
            // 
            // pnlGraficaOpciones
            // 
            this.pnlGraficaOpciones.Controls.Add(this.chkLog);
            this.pnlGraficaOpciones.Controls.Add(this.cmbMetrica);
            this.pnlGraficaOpciones.Controls.Add(this.lblMetrica);
            this.pnlGraficaOpciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGraficaOpciones.Location = new System.Drawing.Point(3, 3);
            this.pnlGraficaOpciones.Name = "pnlGraficaOpciones";
            this.pnlGraficaOpciones.Size = new System.Drawing.Size(1086, 40);
            this.pnlGraficaOpciones.TabIndex = 1;
            // 
            // lblMetrica
            // 
            this.lblMetrica.AutoSize = true;
            this.lblMetrica.Location = new System.Drawing.Point(8, 12);
            this.lblMetrica.Name = "lblMetrica";
            this.lblMetrica.Size = new System.Drawing.Size(47, 15);
            this.lblMetrica.Text = "Métrica:";
            // 
            // cmbMetrica
            // 
            this.cmbMetrica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetrica.Items.AddRange(new object[] {
            "Tiempo (ms)",
            "Comparaciones",
            "Memoria extra (bytes)"});
            this.cmbMetrica.Location = new System.Drawing.Point(64, 8);
            this.cmbMetrica.Name = "cmbMetrica";
            this.cmbMetrica.Size = new System.Drawing.Size(200, 23);
            this.cmbMetrica.TabIndex = 0;
            this.cmbMetrica.SelectedIndexChanged += new System.EventHandler(this.Grafica_OpcionCambiada);
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Location = new System.Drawing.Point(280, 10);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(130, 19);
            this.chkLog.TabIndex = 1;
            this.chkLog.Text = "Escala logarítmica";
            this.chkLog.UseVisualStyleBackColor = true;
            this.chkLog.CheckedChanged += new System.EventHandler(this.Grafica_OpcionCambiada);
            // 
            // tabAnalisis
            // 
            this.tabAnalisis.Controls.Add(this.txtAnalisis);
            this.tabAnalisis.Location = new System.Drawing.Point(4, 24);
            this.tabAnalisis.Name = "tabAnalisis";
            this.tabAnalisis.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnalisis.Size = new System.Drawing.Size(1092, 576);
            this.tabAnalisis.TabIndex = 2;
            this.tabAnalisis.Text = "Análisis teórico O(n)";
            this.tabAnalisis.UseVisualStyleBackColor = true;
            // 
            // txtAnalisis
            // 
            this.txtAnalisis.BackColor = System.Drawing.SystemColors.Window;
            this.txtAnalisis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAnalisis.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtAnalisis.Location = new System.Drawing.Point(3, 3);
            this.txtAnalisis.Multiline = true;
            this.txtAnalisis.Name = "txtAnalisis";
            this.txtAnalisis.ReadOnly = true;
            this.txtAnalisis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAnalisis.Size = new System.Drawing.Size(1086, 570);
            this.txtAnalisis.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.pnlTop);
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eficiencia de algoritmos: Bubble Sort vs Merge Sort";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSemilla)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabResultados.ResumeLayout(false);
            this.tabResultados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.tabGrafica.ResumeLayout(false);
            this.pnlGraficaOpciones.ResumeLayout(false);
            this.pnlGraficaOpciones.PerformLayout();
            this.tabAnalisis.ResumeLayout(false);
            this.tabAnalisis.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.NumericUpDown nudSemilla;
        private System.Windows.Forms.Label lblSemilla;
        private System.Windows.Forms.TextBox txtTamanos;
        private System.Windows.Forms.Label lblTamanos;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabResultados;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.DataGridViewTextBoxColumn colN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBubbleMs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBubbleComp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBubbleMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBubbleMem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMergeMs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMergeComp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMergeMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMergeMem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpeedup;
        private System.Windows.Forms.TextBox txtConclusion;
        private System.Windows.Forms.TabPage tabGrafica;
        private SortingAnalysis.GraphPanel graphPanel;
        private System.Windows.Forms.Panel pnlGraficaOpciones;
        private System.Windows.Forms.CheckBox chkLog;
        private System.Windows.Forms.ComboBox cmbMetrica;
        private System.Windows.Forms.Label lblMetrica;
        private System.Windows.Forms.TabPage tabAnalisis;
        private System.Windows.Forms.TextBox txtAnalisis;
    }
}
