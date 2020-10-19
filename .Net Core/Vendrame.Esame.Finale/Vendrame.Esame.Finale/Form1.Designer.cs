namespace Vendrame.Esame.Finale
{
    partial class Form1
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
            this.btnMacelleria = new System.Windows.Forms.Button();
            this.btnFrutta = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMacelleria
            // 
            this.btnMacelleria.Location = new System.Drawing.Point(12, 12);
            this.btnMacelleria.Name = "btnMacelleria";
            this.btnMacelleria.Size = new System.Drawing.Size(122, 38);
            this.btnMacelleria.TabIndex = 0;
            this.btnMacelleria.Text = "Macelleria";
            this.btnMacelleria.UseVisualStyleBackColor = true;
            this.btnMacelleria.Click += new System.EventHandler(this.btnMacelleria_Click);
            // 
            // btnFrutta
            // 
            this.btnFrutta.Location = new System.Drawing.Point(150, 12);
            this.btnFrutta.Name = "btnFrutta";
            this.btnFrutta.Size = new System.Drawing.Size(122, 38);
            this.btnFrutta.TabIndex = 1;
            this.btnFrutta.Text = "Frutta e Verdura";
            this.btnFrutta.UseVisualStyleBackColor = true;
            this.btnFrutta.Click += new System.EventHandler(this.btnFrutta_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(291, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 38);
            this.button3.TabIndex = 2;
            this.button3.Text = "Pesce";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 66);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnFrutta);
            this.Controls.Add(this.btnMacelleria);
            this.Name = "Form1";
            this.Text = "Interfaccia utente";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMacelleria;
        private System.Windows.Forms.Button btnFrutta;
        private System.Windows.Forms.Button button3;
    }
}

