namespace Trabalho_3___Servidor
{
    partial class Servidor
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
            this.label1 = new System.Windows.Forms.Label();
            this.BT_Ligar = new System.Windows.Forms.Button();
            this.CB_Padrao = new System.Windows.Forms.CheckBox();
            this.TB_Porta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_IP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Log = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servidor - Definições";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BT_Ligar
            // 
            this.BT_Ligar.Location = new System.Drawing.Point(191, 120);
            this.BT_Ligar.Name = "BT_Ligar";
            this.BT_Ligar.Size = new System.Drawing.Size(75, 23);
            this.BT_Ligar.TabIndex = 14;
            this.BT_Ligar.Text = "Ligar";
            this.BT_Ligar.UseVisualStyleBackColor = true;
            this.BT_Ligar.Click += new System.EventHandler(this.BT_Ligar_Click);
            // 
            // CB_Padrao
            // 
            this.CB_Padrao.AutoSize = true;
            this.CB_Padrao.Location = new System.Drawing.Point(15, 120);
            this.CB_Padrao.Name = "CB_Padrao";
            this.CB_Padrao.Size = new System.Drawing.Size(102, 17);
            this.CB_Padrao.TabIndex = 13;
            this.CB_Padrao.Text = "IP/Porta padrão";
            this.CB_Padrao.UseVisualStyleBackColor = true;
            this.CB_Padrao.CheckedChanged += new System.EventHandler(this.CB_Padrao_CheckedChanged);
            // 
            // TB_Porta
            // 
            this.TB_Porta.Location = new System.Drawing.Point(15, 93);
            this.TB_Porta.Name = "TB_Porta";
            this.TB_Porta.Size = new System.Drawing.Size(252, 20);
            this.TB_Porta.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Porta:";
            // 
            // TB_IP
            // 
            this.TB_IP.Location = new System.Drawing.Point(15, 53);
            this.TB_IP.Name = "TB_IP";
            this.TB_IP.Size = new System.Drawing.Size(252, 20);
            this.TB_IP.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "IP:";
            // 
            // TB_Log
            // 
            this.TB_Log.Enabled = false;
            this.TB_Log.Location = new System.Drawing.Point(12, 149);
            this.TB_Log.Multiline = true;
            this.TB_Log.Name = "TB_Log";
            this.TB_Log.Size = new System.Drawing.Size(259, 132);
            this.TB_Log.TabIndex = 15;
            // 
            // Servidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 292);
            this.Controls.Add(this.TB_Log);
            this.Controls.Add(this.BT_Ligar);
            this.Controls.Add(this.CB_Padrao);
            this.Controls.Add(this.TB_Porta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_IP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Servidor";
            this.Text = "Servidor";
            this.Load += new System.EventHandler(this.Servidor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_Ligar;
        private System.Windows.Forms.CheckBox CB_Padrao;
        private System.Windows.Forms.TextBox TB_Porta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_IP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Log;
    }
}

