namespace MokaCom
{
    partial class SelectServerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.mokaDatabases = new MokaCom.MokaDatabases();
            this.serversBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.serversListBox = new System.Windows.Forms.ListBox();
            this.databasesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.databasesListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.mokaDatabases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serversBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databasesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select database";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(42, 258);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.OK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(135, 258);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // mokaDatabases
            // 
            this.mokaDatabases.DataSetName = "MokaDatabases";
            this.mokaDatabases.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // serversBindingSource
            // 
            this.serversBindingSource.DataMember = "Servers";
            this.serversBindingSource.DataSource = this.mokaDatabases;
            // 
            // serversListBox
            // 
            this.serversListBox.DataSource = this.serversBindingSource;
            this.serversListBox.FormattingEnabled = true;
            this.serversListBox.Location = new System.Drawing.Point(12, 23);
            this.serversListBox.Name = "serversListBox";
            this.serversListBox.Size = new System.Drawing.Size(300, 69);
            this.serversListBox.TabIndex = 6;
            this.serversListBox.ValueMember = "Name";
            // 
            // databasesBindingSource
            // 
            this.databasesBindingSource.DataMember = "FK_Servers_Databases";
            this.databasesBindingSource.DataSource = this.serversBindingSource;
            // 
            // databasesListBox
            // 
            this.databasesListBox.DataSource = this.databasesBindingSource;
            this.databasesListBox.DisplayMember = "Name";
            this.databasesListBox.FormattingEnabled = true;
            this.databasesListBox.Location = new System.Drawing.Point(12, 118);
            this.databasesListBox.Name = "databasesListBox";
            this.databasesListBox.Size = new System.Drawing.Size(300, 121);
            this.databasesListBox.TabIndex = 6;
            this.databasesListBox.ValueMember = "Name";
            // 
            // SelectServerForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(338, 302);
            this.Controls.Add(this.databasesListBox);
            this.Controls.Add(this.serversListBox);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SelectServerForm";
            this.Text = "Select Moka database ";
            this.Load += new System.EventHandler(this.SelectServerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mokaDatabases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serversBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databasesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private MokaDatabases mokaDatabases;
        private System.Windows.Forms.BindingSource serversBindingSource;
        private System.Windows.Forms.ListBox serversListBox;
        private System.Windows.Forms.BindingSource databasesBindingSource;
        private System.Windows.Forms.ListBox databasesListBox;
    }
}