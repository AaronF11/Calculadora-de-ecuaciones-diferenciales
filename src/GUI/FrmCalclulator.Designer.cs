namespace Calculadora_de_ecuaciones_diferenciales
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.RtbPantalla = new System.Windows.Forms.RichTextBox();
            this.BtnLog = new System.Windows.Forms.Button();
            this.BtnDel = new System.Windows.Forms.Button();
            this.BtnClc = new System.Windows.Forms.Button();
            this.BtnCalcular = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RtbPantalla
            // 
            this.RtbPantalla.BackColor = System.Drawing.Color.White;
            this.RtbPantalla.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RtbPantalla.Dock = System.Windows.Forms.DockStyle.Top;
            this.RtbPantalla.Location = new System.Drawing.Point(20, 20);
            this.RtbPantalla.Name = "RtbPantalla";
            this.RtbPantalla.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RtbPantalla.Size = new System.Drawing.Size(410, 136);
            this.RtbPantalla.TabIndex = 0;
            this.RtbPantalla.Text = "x^2+5x+3=1\n x^2+5x+3=1";
            this.RtbPantalla.ZoomFactor = 2F;
            // 
            // BtnLog
            // 
            this.BtnLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(202)))), ((int)(((byte)(249)))));
            this.BtnLog.FlatAppearance.BorderSize = 0;
            this.BtnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLog.ForeColor = System.Drawing.Color.White;
            this.BtnLog.Location = new System.Drawing.Point(20, 180);
            this.BtnLog.Name = "BtnLog";
            this.BtnLog.Size = new System.Drawing.Size(55, 57);
            this.BtnLog.TabIndex = 1;
            this.BtnLog.Text = "log";
            this.BtnLog.UseVisualStyleBackColor = false;
            // 
            // BtnDel
            // 
            this.BtnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.BtnDel.FlatAppearance.BorderSize = 0;
            this.BtnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDel.ForeColor = System.Drawing.Color.White;
            this.BtnDel.Location = new System.Drawing.Point(166, 180);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(55, 57);
            this.BtnDel.TabIndex = 2;
            this.BtnDel.Text = "del";
            this.BtnDel.UseVisualStyleBackColor = false;
            // 
            // BtnClc
            // 
            this.BtnClc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.BtnClc.FlatAppearance.BorderSize = 0;
            this.BtnClc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClc.ForeColor = System.Drawing.Color.White;
            this.BtnClc.Location = new System.Drawing.Point(93, 180);
            this.BtnClc.Name = "BtnClc";
            this.BtnClc.Size = new System.Drawing.Size(55, 57);
            this.BtnClc.TabIndex = 3;
            this.BtnClc.Text = "clc";
            this.BtnClc.UseVisualStyleBackColor = false;
            // 
            // BtnCalcular
            // 
            this.BtnCalcular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(201)))));
            this.BtnCalcular.FlatAppearance.BorderSize = 0;
            this.BtnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCalcular.ForeColor = System.Drawing.Color.White;
            this.BtnCalcular.Location = new System.Drawing.Point(243, 180);
            this.BtnCalcular.Name = "BtnCalcular";
            this.BtnCalcular.Size = new System.Drawing.Size(184, 57);
            this.BtnCalcular.TabIndex = 4;
            this.BtnCalcular.Text = "Calcular";
            this.BtnCalcular.UseVisualStyleBackColor = false;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(450, 900);
            this.Controls.Add(this.BtnCalcular);
            this.Controls.Add(this.BtnClc);
            this.Controls.Add(this.BtnDel);
            this.Controls.Add(this.BtnLog);
            this.Controls.Add(this.RtbPantalla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPrincipal";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox RtbPantalla;
        private System.Windows.Forms.Button BtnLog;
        private System.Windows.Forms.Button BtnDel;
        private System.Windows.Forms.Button BtnClc;
        private System.Windows.Forms.Button BtnCalcular;
    }
}

