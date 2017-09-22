namespace SoloDemo
{
    partial class FormHome
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
            this.buttonEmployees = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDBcatalog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDBpass = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDBuserID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDBDataSource = new System.Windows.Forms.TextBox();
            this.buttonDepartements = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonEmployees
            // 
            this.buttonEmployees.Location = new System.Drawing.Point(12, 42);
            this.buttonEmployees.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEmployees.Name = "buttonEmployees";
            this.buttonEmployees.Size = new System.Drawing.Size(220, 30);
            this.buttonEmployees.TabIndex = 0;
            this.buttonEmployees.Text = "Employees";
            this.buttonEmployees.UseVisualStyleBackColor = true;
            this.buttonEmployees.Click += new System.EventHandler(this.buttonEmployees_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxDBcatalog);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxDBpass);
            this.groupBox1.Controls.Add(this.buttonConnect);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxDBuserID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxDBDataSource);
            this.groupBox1.Location = new System.Drawing.Point(12, 121);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(453, 169);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection details";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 108);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Databaze:";
            // 
            // textBoxDBcatalog
            // 
            this.textBoxDBcatalog.Location = new System.Drawing.Point(112, 105);
            this.textBoxDBcatalog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDBcatalog.Name = "textBoxDBcatalog";
            this.textBoxDBcatalog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxDBcatalog.Size = new System.Drawing.Size(335, 22);
            this.textBoxDBcatalog.TabIndex = 7;
            this.textBoxDBcatalog.Text = "SOLODEMO_emplo1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 80);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password:";
            // 
            // textBoxDBpass
            // 
            this.textBoxDBpass.Location = new System.Drawing.Point(112, 78);
            this.textBoxDBpass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDBpass.Name = "textBoxDBpass";
            this.textBoxDBpass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxDBpass.Size = new System.Drawing.Size(335, 22);
            this.textBoxDBpass.TabIndex = 5;
            this.textBoxDBpass.UseSystemPasswordChar = true;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(307, 133);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(141, 30);
            this.buttonConnect.TabIndex = 4;
            this.buttonConnect.Text = "Test connection";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 53);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "User name:";
            // 
            // textBoxDBuserID
            // 
            this.textBoxDBuserID.Location = new System.Drawing.Point(112, 49);
            this.textBoxDBuserID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDBuserID.Name = "textBoxDBuserID";
            this.textBoxDBuserID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxDBuserID.Size = new System.Drawing.Size(335, 22);
            this.textBoxDBuserID.TabIndex = 2;
            this.textBoxDBuserID.Text = "soldemo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 25);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Databaze URI:";
            // 
            // textBoxDBDataSource
            // 
            this.textBoxDBDataSource.Location = new System.Drawing.Point(112, 21);
            this.textBoxDBDataSource.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDBDataSource.Name = "textBoxDBDataSource";
            this.textBoxDBDataSource.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxDBDataSource.Size = new System.Drawing.Size(335, 22);
            this.textBoxDBDataSource.TabIndex = 0;
            this.textBoxDBDataSource.Text = "solodemo.database.windows.net";
            // 
            // buttonDepartements
            // 
            this.buttonDepartements.Location = new System.Drawing.Point(245, 42);
            this.buttonDepartements.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDepartements.Name = "buttonDepartements";
            this.buttonDepartements.Size = new System.Drawing.Size(220, 30);
            this.buttonDepartements.TabIndex = 2;
            this.buttonDepartements.Text = "Departements";
            this.buttonDepartements.UseVisualStyleBackColor = true;
            this.buttonDepartements.Click += new System.EventHandler(this.buttonDepartements_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "config";
            this.saveFileDialog1.FileName = "ConnectionString";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(296, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Welcome! Select object of management ativity";
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 302);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonDepartements);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonEmployees);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormHome";
            this.Text = "SoloDemo™";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEmployees;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDBuserID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDBDataSource;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDBcatalog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDBpass;
        private System.Windows.Forms.Button buttonDepartements;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label5;
    }
}

