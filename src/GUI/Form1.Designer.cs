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
            this.RtbPantalla.Text = "";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(450, 900);
            this.Controls.Add(this.RtbPantalla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPrincipal";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox RtbPantalla;
    }
}

