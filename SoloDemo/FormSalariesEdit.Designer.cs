namespace SoloDemo
{
    partial class FormSalariesEdit
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
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxEmp = new System.Windows.Forms.ComboBox();
            this.labelID = new System.Windows.Forms.Label();
            this.monthCalendarFrom = new System.Windows.Forms.MonthCalendar();
            this.numericUpDownAm = new System.Windows.Forms.NumericUpDown();
            this.monthCalendarUntil = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAm)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(115, 335);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(462, 37);
            this.buttonSubmit.TabIndex = 16;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Employee";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Valid from";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Valid to";
            // 
            // comboBoxEmp
            // 
            this.comboBoxEmp.FormattingEnabled = true;
            this.comboBoxEmp.Location = new System.Drawing.Point(115, 47);
            this.comboBoxEmp.Name = "comboBoxEmp";
            this.comboBoxEmp.Size = new System.Drawing.Size(192, 24);
            this.comboBoxEmp.TabIndex = 15;
            this.comboBoxEmp.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.ComboBoxFormat);
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(10, 16);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(132, 17);
            this.labelID.TabIndex = 11;
            this.labelID.Text = "ID of salary record: ";
            // 
            // monthCalendarFrom
            // 
            this.monthCalendarFrom.Location = new System.Drawing.Point(115, 116);
            this.monthCalendarFrom.Name = "monthCalendarFrom";
            this.monthCalendarFrom.TabIndex = 21;
            // 
            // numericUpDownAm
            // 
            this.numericUpDownAm.DecimalPlaces = 2;
            this.numericUpDownAm.Location = new System.Drawing.Point(115, 82);
            this.numericUpDownAm.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownAm.Name = "numericUpDownAm";
            this.numericUpDownAm.Size = new System.Drawing.Size(192, 22);
            this.numericUpDownAm.TabIndex = 22;
            // 
            // monthCalendarUntil
            // 
            this.monthCalendarUntil.Location = new System.Drawing.Point(385, 117);
            this.monthCalendarUntil.Name = "monthCalendarUntil";
            this.monthCalendarUntil.TabIndex = 23;
            // 
            // FormSalariesEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 383);
            this.Controls.Add(this.monthCalendarUntil);
            this.Controls.Add(this.numericUpDownAm);
            this.Controls.Add(this.monthCalendarFrom);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxEmp);
            this.Controls.Add(this.labelID);
            this.Name = "FormSalariesEdit";
            this.Text = "Salaries (edit or add)";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxEmp;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.MonthCalendar monthCalendarFrom;
        private System.Windows.Forms.NumericUpDown numericUpDownAm;
        private System.Windows.Forms.MonthCalendar monthCalendarUntil;
    }
}