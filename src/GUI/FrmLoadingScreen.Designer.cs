﻿namespace Calculadora_de_ecuaciones_diferenciales
{
    partial class FrmLoadingScreen
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
            this.components = new System.ComponentModel.Container();
            this.PbxLoadingScreenGIF = new System.Windows.Forms.PictureBox();
            this.LblLoadingStatus = new System.Windows.Forms.Label();
            this.PbLoading = new System.Windows.Forms.ProgressBar();
            this.TmrLoadingScreen = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PbxLoadingScreenGIF)).BeginInit();
            this.SuspendLayout();
            // 
            // PbxLoadingScreenGIF
            // 
            this.PbxLoadingScreenGIF.Image = global::Calculadora_de_ecuaciones_diferenciales.Properties.Resources.LoadingScreen_GIF;
            this.PbxLoadingScreenGIF.Location = new System.Drawing.Point(135, 250);
            this.PbxLoadingScreenGIF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PbxLoadingScreenGIF.Name = "PbxLoadingScreenGIF";
            this.PbxLoadingScreenGIF.Size = new System.Drawing.Size(150, 150);
            this.PbxLoadingScreenGIF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbxLoadingScreenGIF.TabIndex = 1;
            this.PbxLoadingScreenGIF.TabStop = false;
            // 
            // LblLoadingStatus
            // 
            this.LblLoadingStatus.AutoSize = true;
            this.LblLoadingStatus.BackColor = System.Drawing.Color.Transparent;
            this.LblLoadingStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLoadingStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.LblLoadingStatus.Location = new System.Drawing.Point(90, 616);
            this.LblLoadingStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblLoadingStatus.Name = "LblLoadingStatus";
            this.LblLoadingStatus.Size = new System.Drawing.Size(242, 25);
            this.LblLoadingStatus.TabIndex = 5;
            this.LblLoadingStatus.Text = "Cargando calculadora...";
            this.LblLoadingStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PbLoading
            // 
            this.PbLoading.Location = new System.Drawing.Point(21, 648);
            this.PbLoading.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PbLoading.Name = "PbLoading";
            this.PbLoading.Size = new System.Drawing.Size(376, 28);
            this.PbLoading.TabIndex = 6;
            this.PbLoading.Visible = false;
            // 
            // TmrLoadingScreen
            // 
            this.TmrLoadingScreen.Enabled = true;
            this.TmrLoadingScreen.Interval = 90;
            this.TmrLoadingScreen.Tick += new System.EventHandler(this.TmrLoadingScreen_Tick);
            // 
            // FrmLoadingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(425, 686);
            this.Controls.Add(this.PbLoading);
            this.Controls.Add(this.LblLoadingStatus);
            this.Controls.Add(this.PbxLoadingScreenGIF);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmLoadingScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLoadingScreen";
            ((System.ComponentModel.ISupportInitialize)(this.PbxLoadingScreenGIF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbxLoadingScreenGIF;
        private System.Windows.Forms.Label LblLoadingStatus;
        private System.Windows.Forms.ProgressBar PbLoading;
        private System.Windows.Forms.Timer TmrLoadingScreen;
    }
}