namespace Architecture_and_Organization_midterm_project
{
    partial class Number_System_Converter
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
            this.rbtnDecimal = new System.Windows.Forms.RadioButton();
            this.rbtnBinary = new System.Windows.Forms.RadioButton();
            this.rbtnHexa = new System.Windows.Forms.RadioButton();
            this.rbtnOctal = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.cbDecimal = new System.Windows.Forms.CheckBox();
            this.cbHexa = new System.Windows.Forms.CheckBox();
            this.cbOctal = new System.Windows.Forms.CheckBox();
            this.cbBinary = new System.Windows.Forms.CheckBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.txtOctal = new System.Windows.Forms.TextBox();
            this.txtHexa = new System.Windows.Forms.TextBox();
            this.txtBinary = new System.Windows.Forms.TextBox();
            this.txtDecimal = new System.Windows.Forms.TextBox();
            this.gbOperation = new System.Windows.Forms.GroupBox();
            this.cbSigned = new System.Windows.Forms.CheckBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtDecimalDup = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.gbOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtnDecimal
            // 
            this.rbtnDecimal.AutoSize = true;
            this.rbtnDecimal.Location = new System.Drawing.Point(17, 30);
            this.rbtnDecimal.Name = "rbtnDecimal";
            this.rbtnDecimal.Size = new System.Drawing.Size(91, 24);
            this.rbtnDecimal.TabIndex = 0;
            this.rbtnDecimal.TabStop = true;
            this.rbtnDecimal.Text = "Decimal";
            this.rbtnDecimal.UseVisualStyleBackColor = true;
            // 
            // rbtnBinary
            // 
            this.rbtnBinary.AutoSize = true;
            this.rbtnBinary.Location = new System.Drawing.Point(17, 60);
            this.rbtnBinary.Name = "rbtnBinary";
            this.rbtnBinary.Size = new System.Drawing.Size(78, 24);
            this.rbtnBinary.TabIndex = 1;
            this.rbtnBinary.TabStop = true;
            this.rbtnBinary.Text = "Binary";
            this.rbtnBinary.UseVisualStyleBackColor = true;
            // 
            // rbtnHexa
            // 
            this.rbtnHexa.AutoSize = true;
            this.rbtnHexa.Location = new System.Drawing.Point(17, 90);
            this.rbtnHexa.Name = "rbtnHexa";
            this.rbtnHexa.Size = new System.Drawing.Size(125, 24);
            this.rbtnHexa.TabIndex = 2;
            this.rbtnHexa.TabStop = true;
            this.rbtnHexa.Text = "Hexadeciaml";
            this.rbtnHexa.UseVisualStyleBackColor = true;
            // 
            // rbtnOctal
            // 
            this.rbtnOctal.AutoSize = true;
            this.rbtnOctal.Location = new System.Drawing.Point(17, 120);
            this.rbtnOctal.Name = "rbtnOctal";
            this.rbtnOctal.Size = new System.Drawing.Size(71, 24);
            this.rbtnOctal.TabIndex = 3;
            this.rbtnOctal.TabStop = true;
            this.rbtnOctal.Text = "Octal";
            this.rbtnOctal.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLaunch);
            this.groupBox1.Controls.Add(this.rbtnHexa);
            this.groupBox1.Controls.Add(this.rbtnOctal);
            this.groupBox1.Controls.Add(this.rbtnDecimal);
            this.groupBox1.Controls.Add(this.rbtnBinary);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 201);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose input mode:";
            // 
            // btnLaunch
            // 
            this.btnLaunch.Location = new System.Drawing.Point(44, 150);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(98, 36);
            this.btnLaunch.TabIndex = 12;
            this.btnLaunch.Text = "LAUNCH";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(241, 51);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(190, 26);
            this.txtInput.TabIndex = 1;
            this.txtInput.Text = "Input here:";
            this.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInput.Click += new System.EventHandler(this.txtInput_Click);
            // 
            // cbDecimal
            // 
            this.cbDecimal.AutoSize = true;
            this.cbDecimal.Location = new System.Drawing.Point(51, 153);
            this.cbDecimal.Name = "cbDecimal";
            this.cbDecimal.Size = new System.Drawing.Size(92, 24);
            this.cbDecimal.TabIndex = 2;
            this.cbDecimal.Text = "Decimal";
            this.cbDecimal.UseVisualStyleBackColor = true;
            // 
            // cbHexa
            // 
            this.cbHexa.AutoSize = true;
            this.cbHexa.Location = new System.Drawing.Point(51, 233);
            this.cbHexa.Name = "cbHexa";
            this.cbHexa.Size = new System.Drawing.Size(126, 24);
            this.cbHexa.TabIndex = 3;
            this.cbHexa.Text = "Hexadecimal";
            this.cbHexa.UseVisualStyleBackColor = true;
            // 
            // cbOctal
            // 
            this.cbOctal.AutoSize = true;
            this.cbOctal.Location = new System.Drawing.Point(51, 274);
            this.cbOctal.Name = "cbOctal";
            this.cbOctal.Size = new System.Drawing.Size(72, 24);
            this.cbOctal.TabIndex = 4;
            this.cbOctal.Text = "Octal";
            this.cbOctal.UseVisualStyleBackColor = true;
            // 
            // cbBinary
            // 
            this.cbBinary.AutoSize = true;
            this.cbBinary.Location = new System.Drawing.Point(51, 192);
            this.cbBinary.Name = "cbBinary";
            this.cbBinary.Size = new System.Drawing.Size(79, 24);
            this.cbBinary.TabIndex = 5;
            this.cbBinary.Text = "Binary";
            this.cbBinary.UseVisualStyleBackColor = true;
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(51, 51);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(87, 20);
            this.lblInput.TabIndex = 6;
            this.lblInput.Text = "Input value";
            // 
            // txtOctal
            // 
            this.txtOctal.Location = new System.Drawing.Point(241, 274);
            this.txtOctal.Name = "txtOctal";
            this.txtOctal.Size = new System.Drawing.Size(190, 26);
            this.txtOctal.TabIndex = 7;
            this.txtOctal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHexa
            // 
            this.txtHexa.Location = new System.Drawing.Point(241, 233);
            this.txtHexa.Name = "txtHexa";
            this.txtHexa.Size = new System.Drawing.Size(190, 26);
            this.txtHexa.TabIndex = 8;
            this.txtHexa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBinary
            // 
            this.txtBinary.Location = new System.Drawing.Point(241, 192);
            this.txtBinary.Name = "txtBinary";
            this.txtBinary.Size = new System.Drawing.Size(190, 26);
            this.txtBinary.TabIndex = 9;
            this.txtBinary.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDecimal
            // 
            this.txtDecimal.Location = new System.Drawing.Point(241, 153);
            this.txtDecimal.Name = "txtDecimal";
            this.txtDecimal.Size = new System.Drawing.Size(190, 26);
            this.txtDecimal.TabIndex = 10;
            this.txtDecimal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbOperation
            // 
            this.gbOperation.Controls.Add(this.txtDecimalDup);
            this.gbOperation.Controls.Add(this.cbSigned);
            this.gbOperation.Controls.Add(this.btnConvert);
            this.gbOperation.Controls.Add(this.txtHexa);
            this.gbOperation.Controls.Add(this.txtDecimal);
            this.gbOperation.Controls.Add(this.txtInput);
            this.gbOperation.Controls.Add(this.txtBinary);
            this.gbOperation.Controls.Add(this.cbDecimal);
            this.gbOperation.Controls.Add(this.cbHexa);
            this.gbOperation.Controls.Add(this.txtOctal);
            this.gbOperation.Controls.Add(this.cbOctal);
            this.gbOperation.Controls.Add(this.lblInput);
            this.gbOperation.Controls.Add(this.cbBinary);
            this.gbOperation.Location = new System.Drawing.Point(265, 72);
            this.gbOperation.Name = "gbOperation";
            this.gbOperation.Size = new System.Drawing.Size(463, 339);
            this.gbOperation.TabIndex = 0;
            this.gbOperation.TabStop = false;
            this.gbOperation.Text = "Operation";
            this.gbOperation.Visible = false;
            // 
            // cbSigned
            // 
            this.cbSigned.AutoSize = true;
            this.cbSigned.Location = new System.Drawing.Point(241, 21);
            this.cbSigned.Name = "cbSigned";
            this.cbSigned.Size = new System.Drawing.Size(95, 24);
            this.cbSigned.TabIndex = 12;
            this.cbSigned.Text = "negative";
            this.cbSigned.UseVisualStyleBackColor = true;
            this.cbSigned.Visible = false;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(282, 89);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(111, 36);
            this.btnConvert.TabIndex = 11;
            this.btnConvert.Text = "CONVERT";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // txtDecimalDup
            // 
            this.txtDecimalDup.Location = new System.Drawing.Point(241, 131);
            this.txtDecimalDup.Name = "txtDecimalDup";
            this.txtDecimalDup.Size = new System.Drawing.Size(190, 26);
            this.txtDecimalDup.TabIndex = 13;
            this.txtDecimalDup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDecimalDup.Visible = false;
            // 
            // Number_System_Converter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbOperation);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Number_System_Converter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Number System Converter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbOperation.ResumeLayout(false);
            this.gbOperation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnDecimal;
        private System.Windows.Forms.RadioButton rbtnBinary;
        private System.Windows.Forms.RadioButton rbtnHexa;
        private System.Windows.Forms.RadioButton rbtnOctal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.CheckBox cbDecimal;
        private System.Windows.Forms.CheckBox cbHexa;
        private System.Windows.Forms.CheckBox cbOctal;
        private System.Windows.Forms.CheckBox cbBinary;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox txtOctal;
        private System.Windows.Forms.TextBox txtHexa;
        private System.Windows.Forms.TextBox txtBinary;
        private System.Windows.Forms.TextBox txtDecimal;
        private System.Windows.Forms.GroupBox gbOperation;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.CheckBox cbSigned;
        private System.Windows.Forms.TextBox txtDecimalDup;
    }
}