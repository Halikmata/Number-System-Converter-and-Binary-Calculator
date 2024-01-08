namespace Architecture_and_Organization_midterm_project
{
    partial class Binary_Calculator
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
            this.txtInput2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtn2s = new System.Windows.Forms.RadioButton();
            this.btnCompute = new System.Windows.Forms.Button();
            this.rbtnPow = new System.Windows.Forms.RadioButton();
            this.rbtnDiv = new System.Windows.Forms.RadioButton();
            this.rbtnMult = new System.Windows.Forms.RadioButton();
            this.rbtnSub = new System.Windows.Forms.RadioButton();
            this.rbtnAdd = new System.Windows.Forms.RadioButton();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtInput1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSign1 = new System.Windows.Forms.CheckBox();
            this.cbSign2 = new System.Windows.Forms.CheckBox();
            this.lblSign = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInput2
            // 
            this.txtInput2.Location = new System.Drawing.Point(570, 114);
            this.txtInput2.Name = "txtInput2";
            this.txtInput2.Size = new System.Drawing.Size(156, 26);
            this.txtInput2.TabIndex = 1;
            this.txtInput2.TextChanged += new System.EventHandler(this.txtInput2_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtn2s);
            this.groupBox1.Controls.Add(this.btnCompute);
            this.groupBox1.Controls.Add(this.rbtnPow);
            this.groupBox1.Controls.Add(this.rbtnDiv);
            this.groupBox1.Controls.Add(this.rbtnMult);
            this.groupBox1.Controls.Add(this.rbtnSub);
            this.groupBox1.Controls.Add(this.rbtnAdd);
            this.groupBox1.Location = new System.Drawing.Point(317, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 162);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OPERATION";
            // 
            // rbtn2s
            // 
            this.rbtn2s.AutoSize = true;
            this.rbtn2s.Location = new System.Drawing.Point(124, 53);
            this.rbtn2s.Name = "rbtn2s";
            this.rbtn2s.Size = new System.Drawing.Size(54, 24);
            this.rbtn2s.TabIndex = 6;
            this.rbtn2s.TabStop = true;
            this.rbtn2s.Text = "2\'s";
            this.rbtn2s.UseVisualStyleBackColor = true;
            // 
            // btnCompute
            // 
            this.btnCompute.Location = new System.Drawing.Point(38, 111);
            this.btnCompute.Name = "btnCompute";
            this.btnCompute.Size = new System.Drawing.Size(105, 34);
            this.btnCompute.TabIndex = 5;
            this.btnCompute.Text = "Compute";
            this.btnCompute.UseVisualStyleBackColor = true;
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // rbtnPow
            // 
            this.rbtnPow.AutoSize = true;
            this.rbtnPow.Location = new System.Drawing.Point(22, 53);
            this.rbtnPow.Name = "rbtnPow";
            this.rbtnPow.Size = new System.Drawing.Size(41, 24);
            this.rbtnPow.TabIndex = 4;
            this.rbtnPow.TabStop = true;
            this.rbtnPow.Text = "^";
            this.rbtnPow.UseVisualStyleBackColor = true;
            // 
            // rbtnDiv
            // 
            this.rbtnDiv.AutoSize = true;
            this.rbtnDiv.Location = new System.Drawing.Point(124, 81);
            this.rbtnDiv.Name = "rbtnDiv";
            this.rbtnDiv.Size = new System.Drawing.Size(38, 24);
            this.rbtnDiv.TabIndex = 3;
            this.rbtnDiv.TabStop = true;
            this.rbtnDiv.Text = "/";
            this.rbtnDiv.UseVisualStyleBackColor = true;
            // 
            // rbtnMult
            // 
            this.rbtnMult.AutoSize = true;
            this.rbtnMult.Location = new System.Drawing.Point(124, 25);
            this.rbtnMult.Name = "rbtnMult";
            this.rbtnMult.Size = new System.Drawing.Size(41, 24);
            this.rbtnMult.TabIndex = 2;
            this.rbtnMult.TabStop = true;
            this.rbtnMult.Text = "x";
            this.rbtnMult.UseVisualStyleBackColor = true;
            // 
            // rbtnSub
            // 
            this.rbtnSub.AutoSize = true;
            this.rbtnSub.Location = new System.Drawing.Point(22, 81);
            this.rbtnSub.Name = "rbtnSub";
            this.rbtnSub.Size = new System.Drawing.Size(39, 24);
            this.rbtnSub.TabIndex = 1;
            this.rbtnSub.TabStop = true;
            this.rbtnSub.Text = "-";
            this.rbtnSub.UseVisualStyleBackColor = true;
            // 
            // rbtnAdd
            // 
            this.rbtnAdd.AutoSize = true;
            this.rbtnAdd.Location = new System.Drawing.Point(22, 25);
            this.rbtnAdd.Name = "rbtnAdd";
            this.rbtnAdd.Size = new System.Drawing.Size(43, 24);
            this.rbtnAdd.TabIndex = 0;
            this.rbtnAdd.TabStop = true;
            this.rbtnAdd.Text = "+";
            this.rbtnAdd.UseVisualStyleBackColor = true;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(250, 275);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(319, 26);
            this.txtOutput.TabIndex = 3;
            this.txtOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOutput.Click += new System.EventHandler(this.txtOutput_Click);
            // 
            // txtInput1
            // 
            this.txtInput1.Location = new System.Drawing.Point(109, 114);
            this.txtInput1.Name = "txtInput1";
            this.txtInput1.Size = new System.Drawing.Size(156, 26);
            this.txtInput1.TabIndex = 4;
            this.txtInput1.TextChanged += new System.EventHandler(this.txtInput1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(323, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 36);
            this.label1.TabIndex = 5;
            this.label1.Text = "ANSWER IS";
            // 
            // cbSign1
            // 
            this.cbSign1.AutoSize = true;
            this.cbSign1.Location = new System.Drawing.Point(109, 147);
            this.cbSign1.Name = "cbSign1";
            this.cbSign1.Size = new System.Drawing.Size(85, 24);
            this.cbSign1.TabIndex = 6;
            this.cbSign1.Text = "Signed";
            this.cbSign1.UseVisualStyleBackColor = true;
            // 
            // cbSign2
            // 
            this.cbSign2.AutoSize = true;
            this.cbSign2.Location = new System.Drawing.Point(570, 147);
            this.cbSign2.Name = "cbSign2";
            this.cbSign2.Size = new System.Drawing.Size(85, 24);
            this.cbSign2.TabIndex = 7;
            this.cbSign2.Text = "Signed";
            this.cbSign2.UseVisualStyleBackColor = true;
            // 
            // lblSign
            // 
            this.lblSign.AutoSize = true;
            this.lblSign.Location = new System.Drawing.Point(283, 304);
            this.lblSign.Name = "lblSign";
            this.lblSign.Size = new System.Drawing.Size(249, 20);
            this.lblSign.TabIndex = 8;
            this.lblSign.Text = "in 2\'s Complement form (negative)";
            this.lblSign.Visible = false;
            // 
            // Binary_Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSalmon;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSign);
            this.Controls.Add(this.cbSign2);
            this.Controls.Add(this.cbSign1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInput1);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtInput2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Binary_Calculator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Binary Calculator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtn2s;
        private System.Windows.Forms.Button btnCompute;
        private System.Windows.Forms.RadioButton rbtnPow;
        private System.Windows.Forms.RadioButton rbtnDiv;
        private System.Windows.Forms.RadioButton rbtnMult;
        private System.Windows.Forms.RadioButton rbtnSub;
        private System.Windows.Forms.RadioButton rbtnAdd;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtInput1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbSign1;
        private System.Windows.Forms.CheckBox cbSign2;
        private System.Windows.Forms.Label lblSign;
    }
}