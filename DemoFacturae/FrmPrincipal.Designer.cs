﻿namespace DemoFacturae
{
    partial class FrmPrincipal
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
      this.btnGenerar = new System.Windows.Forms.Button();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.Console = new System.Windows.Forms.RichTextBox();
      this.SuspendLayout();
      // 
      // btnGenerar
      // 
      this.btnGenerar.Location = new System.Drawing.Point(99, 12);
      this.btnGenerar.Name = "btnGenerar";
      this.btnGenerar.Size = new System.Drawing.Size(138, 23);
      this.btnGenerar.TabIndex = 0;
      this.btnGenerar.Text = "Generar fichero";
      this.btnGenerar.UseVisualStyleBackColor = true;
      this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
      // 
      // Console
      // 
      this.Console.BackColor = System.Drawing.SystemColors.Desktop;
      this.Console.ForeColor = System.Drawing.Color.LawnGreen;
      this.Console.Location = new System.Drawing.Point(12, 41);
      this.Console.Name = "Console";
      this.Console.Size = new System.Drawing.Size(313, 144);
      this.Console.TabIndex = 1;
      this.Console.Text = "";
      // 
      // FrmPrincipal
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(337, 197);
      this.Controls.Add(this.Console);
      this.Controls.Add(this.btnGenerar);
      this.Name = "FrmPrincipal";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Demo Factura-e";
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.RichTextBox Console;
  }
}

