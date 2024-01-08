namespace Architecture_and_Organization_midterm_project
{
    partial class MainMenu
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
            this.btnNymSysConv = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBinaryCalc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNymSysConv
            // 
            this.btnNymSysConv.BackColor = System.Drawing.Color.Coral;
            this.btnNymSysConv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNymSysConv.Font = new System.Drawing.Font("Kristen ITC", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNymSysConv.ForeColor = System.Drawing.Color.Black;
            this.btnNymSysConv.Location = new System.Drawing.Point(310, 156);
            this.btnNymSysConv.Name = "btnNymSysConv";
            this.btnNymSysConv.Size = new System.Drawing.Size(222, 83);
            this.btnNymSysConv.TabIndex = 0;
            this.btnNymSysConv.Text = "NUMBER SYSTEM CONVERTER";
            this.btnNymSysConv.UseVisualStyleBackColor = false;
            this.btnNymSysConv.Click += new System.EventHandler(this.btnNymSysConv_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("NSimSun", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(316, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "MAIN MENU";
            // 
            // btnBinaryCalc
            // 
            this.btnBinaryCalc.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnBinaryCalc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBinaryCalc.Font = new System.Drawing.Font("Kristen ITC", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBinaryCalc.ForeColor = System.Drawing.Color.Black;
            this.btnBinaryCalc.Location = new System.Drawing.Point(310, 274);
            this.btnBinaryCalc.Name = "btnBinaryCalc";
            this.btnBinaryCalc.Size = new System.Drawing.Size(222, 65);
            this.btnBinaryCalc.TabIndex = 3;
            this.btnBinaryCalc.Text = "BINARY CALCULATOR";
            this.btnBinaryCalc.UseVisualStyleBackColor = false;
            this.btnBinaryCalc.Click += new System.EventHandler(this.btnBinaryCalc_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tomato;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBinaryCalc);
            this.Controls.Add(this.btnNymSysConv);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMenu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNymSysConv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBinaryCalc;
    }
}

