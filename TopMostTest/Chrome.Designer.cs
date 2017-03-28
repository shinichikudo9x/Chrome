namespace TopMostTest
{
    partial class Chrome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chrome));
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.txtSupport = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnLanguage = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtQuestion
            // 
            this.txtQuestion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuestion.Location = new System.Drawing.Point(0, 0);
            this.txtQuestion.Margin = new System.Windows.Forms.Padding(0);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(522, 30);
            this.txtQuestion.TabIndex = 0;
            this.txtQuestion.TextChanged += new System.EventHandler(this.txtQuestion_TextChanged);
            this.txtQuestion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtQuestion_MouseDown);
            this.txtQuestion.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtQuestion_MouseUp);
            // 
            // txtSupport
            // 
            this.txtSupport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSupport.Location = new System.Drawing.Point(0, 45);
            this.txtSupport.Margin = new System.Windows.Forms.Padding(0);
            this.txtSupport.Multiline = true;
            this.txtSupport.Name = "txtSupport";
            this.txtSupport.ReadOnly = true;
            this.txtSupport.Size = new System.Drawing.Size(522, 30);
            this.txtSupport.TabIndex = 1;
            this.txtSupport.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSupport_MouseClick);
            // 
            // txtResult
            // 
            this.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResult.Location = new System.Drawing.Point(0, 30);
            this.txtResult.Margin = new System.Windows.Forms.Padding(0);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(522, 15);
            this.txtResult.TabIndex = 2;
            this.txtResult.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtResult_MouseClick);
            // 
            // btnLanguage
            // 
            this.btnLanguage.BackColor = System.Drawing.Color.Transparent;
            this.btnLanguage.FlatAppearance.BorderSize = 0;
            this.btnLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLanguage.ForeColor = System.Drawing.Color.Transparent;
            this.btnLanguage.Location = new System.Drawing.Point(522, 55);
            this.btnLanguage.Margin = new System.Windows.Forms.Padding(0);
            this.btnLanguage.Name = "btnLanguage";
            this.btnLanguage.Size = new System.Drawing.Size(20, 20);
            this.btnLanguage.TabIndex = 5;
            this.btnLanguage.Text = "E";
            this.btnLanguage.UseVisualStyleBackColor = false;
            this.btnLanguage.Click += new System.EventHandler(this.btnLanguage_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(522, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 6;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMode
            // 
            this.btnMode.BackColor = System.Drawing.Color.Transparent;
            this.btnMode.FlatAppearance.BorderSize = 0;
            this.btnMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMode.ForeColor = System.Drawing.Color.Transparent;
            this.btnMode.Location = new System.Drawing.Point(522, 25);
            this.btnMode.Name = "btnMode";
            this.btnMode.Size = new System.Drawing.Size(20, 20);
            this.btnMode.TabIndex = 7;
            this.btnMode.Text = "M";
            this.btnMode.UseVisualStyleBackColor = false;
            this.btnMode.Click += new System.EventHandler(this.button2_Click);
            // 
            // Chrome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 75);
            this.ControlBox = false;
            this.Controls.Add(this.btnMode);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLanguage);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtSupport);
            this.Controls.Add(this.txtQuestion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Chrome";
            this.Text = "Facebook - Google Chrome";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.TextBox txtSupport;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnLanguage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMode;
    }
}

