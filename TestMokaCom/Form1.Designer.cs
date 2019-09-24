namespace TestMokaCom
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
            this.OGMDisplay = new System.Windows.Forms.TextBox();
            this.OGM = new System.Windows.Forms.TextBox();
            this.useSepa = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Company = new System.Windows.Forms.TextBox();
            this.btnMaakOGM = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.FactuurNR = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBtwNr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSelectServer = new System.Windows.Forms.Button();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lstPrinters = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // OGMDisplay
            // 
            this.OGMDisplay.Location = new System.Drawing.Point(141, 84);
            this.OGMDisplay.Name = "OGMDisplay";
            this.OGMDisplay.Size = new System.Drawing.Size(159, 20);
            this.OGMDisplay.TabIndex = 23;
            // 
            // OGM
            // 
            this.OGM.Location = new System.Drawing.Point(141, 58);
            this.OGM.Name = "OGM";
            this.OGM.Size = new System.Drawing.Size(159, 20);
            this.OGM.TabIndex = 22;
            // 
            // useSepa
            // 
            this.useSepa.AutoSize = true;
            this.useSepa.Location = new System.Drawing.Point(269, 35);
            this.useSepa.Name = "useSepa";
            this.useSepa.Size = new System.Drawing.Size(54, 17);
            this.useSepa.TabIndex = 21;
            this.useSepa.Text = "SEPA";
            this.useSepa.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Factuur NR";
            // 
            // Company
            // 
            this.Company.Location = new System.Drawing.Point(89, 33);
            this.Company.Name = "Company";
            this.Company.Size = new System.Drawing.Size(46, 20);
            this.Company.TabIndex = 19;
            // 
            // btnMaakOGM
            // 
            this.btnMaakOGM.Location = new System.Drawing.Point(330, 31);
            this.btnMaakOGM.Name = "btnMaakOGM";
            this.btnMaakOGM.Size = new System.Drawing.Size(81, 20);
            this.btnMaakOGM.TabIndex = 18;
            this.btnMaakOGM.Text = "Maak OGM";
            this.btnMaakOGM.UseVisualStyleBackColor = true;
            this.btnMaakOGM.Click += new System.EventHandler(this.btnMaakOGM_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Company";
            // 
            // FactuurNR
            // 
            this.FactuurNR.Location = new System.Drawing.Point(209, 32);
            this.FactuurNR.Name = "FactuurNR";
            this.FactuurNR.Size = new System.Drawing.Size(54, 20);
            this.FactuurNR.TabIndex = 16;
            this.FactuurNR.Text = "16/9999";
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(89, 7);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(46, 20);
            this.txtCountry.TabIndex = 15;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(330, 6);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(81, 20);
            this.btnCheck.TabIndex = 14;
            this.btnCheck.Text = "Check BTW";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "BTW nummer";
            // 
            // txtBtwNr
            // 
            this.txtBtwNr.Location = new System.Drawing.Point(141, 6);
            this.txtBtwNr.Name = "txtBtwNr";
            this.txtBtwNr.Size = new System.Drawing.Size(182, 20);
            this.txtBtwNr.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Electronic Version";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Formatted Version";
            // 
            // btnSelectServer
            // 
            this.btnSelectServer.Location = new System.Drawing.Point(12, 115);
            this.btnSelectServer.Name = "btnSelectServer";
            this.btnSelectServer.Size = new System.Drawing.Size(81, 20);
            this.btnSelectServer.TabIndex = 26;
            this.btnSelectServer.Text = "Select server";
            this.btnSelectServer.UseVisualStyleBackColor = true;
            this.btnSelectServer.Click += new System.EventHandler(this.btnSelectServer_Click);
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(103, 116);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(197, 20);
            this.txtServer.TabIndex = 27;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(103, 142);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(197, 20);
            this.txtDatabase.TabIndex = 28;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(12, 166);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(81, 20);
            this.btnPrint.TabIndex = 29;
            this.btnPrint.Text = "Show Printers";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lstPrinters
            // 
            this.lstPrinters.FormattingEnabled = true;
            this.lstPrinters.Location = new System.Drawing.Point(103, 168);
            this.lstPrinters.Name = "lstPrinters";
            this.lstPrinters.Size = new System.Drawing.Size(197, 56);
            this.lstPrinters.TabIndex = 30;
            this.lstPrinters.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstPrinters_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 249);
            this.Controls.Add(this.lstPrinters);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.btnSelectServer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.OGMDisplay);
            this.Controls.Add(this.OGM);
            this.Controls.Add(this.useSepa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Company);
            this.Controls.Add(this.btnMaakOGM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FactuurNR);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBtwNr);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OGMDisplay;
        private System.Windows.Forms.TextBox OGM;
        private System.Windows.Forms.CheckBox useSepa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Company;
        private System.Windows.Forms.Button btnMaakOGM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FactuurNR;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBtwNr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSelectServer;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ListBox lstPrinters;
    }
}

