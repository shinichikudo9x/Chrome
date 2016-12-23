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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chrome));
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.txtSupport = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnKey = new System.Windows.Forms.Button();
            this.btnAns = new System.Windows.Forms.Button();
            this.btnLanguage = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtQuestion
            // 
            this.txtQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuestion.Location = new System.Drawing.Point(-1, 0);
            this.txtQuestion.Multiline = true;
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(584, 48);
            this.txtQuestion.TabIndex = 0;
            this.txtQuestion.TextChanged += new System.EventHandler(this.txtQuestion_TextChanged);
            this.txtQuestion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtQuestion_MouseDown);
            this.txtQuestion.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtQuestion_MouseUp);
            // 
            // txtSupport
            // 
            this.txtSupport.Location = new System.Drawing.Point(-1, 70);
            this.txtSupport.Multiline = true;
            this.txtSupport.Name = "txtSupport";
            this.txtSupport.Size = new System.Drawing.Size(509, 48);
            this.txtSupport.TabIndex = 1;
            this.txtSupport.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtSupport_MouseClick);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(-1, 45);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(584, 19);
            this.txtResult.TabIndex = 2;
            this.txtResult.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtResult_MouseClick);
            // 
            // btnKey
            // 
            this.btnKey.Location = new System.Drawing.Point(511, 67);
            this.btnKey.Margin = new System.Windows.Forms.Padding(0);
            this.btnKey.Name = "btnKey";
            this.btnKey.Size = new System.Drawing.Size(35, 25);
            this.btnKey.TabIndex = 3;
            this.btnKey.Text = "Key";
            this.btnKey.UseVisualStyleBackColor = true;
            this.btnKey.Click += new System.EventHandler(this.btnKey_Click);
            // 
            // btnAns
            // 
            this.btnAns.Location = new System.Drawing.Point(546, 67);
            this.btnAns.Margin = new System.Windows.Forms.Padding(0);
            this.btnAns.Name = "btnAns";
            this.btnAns.Size = new System.Drawing.Size(35, 25);
            this.btnAns.TabIndex = 4;
            this.btnAns.Text = "Ans";
            this.btnAns.UseVisualStyleBackColor = true;
            this.btnAns.Click += new System.EventHandler(this.btnAns_Click);
            // 
            // btnLanguage
            // 
            this.btnLanguage.Location = new System.Drawing.Point(511, 92);
            this.btnLanguage.Margin = new System.Windows.Forms.Padding(0);
            this.btnLanguage.Name = "btnLanguage";
            this.btnLanguage.Size = new System.Drawing.Size(70, 25);
            this.btnLanguage.TabIndex = 5;
            this.btnLanguage.Text = "ENG";
            this.btnLanguage.UseVisualStyleBackColor = true;
            this.btnLanguage.Click += new System.EventHandler(this.btnLanguage_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Chrome";
            this.notifyIcon1.Visible = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(559, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Chrome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 118);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLanguage);
            this.Controls.Add(this.btnAns);
            this.Controls.Add(this.btnKey);
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
        private System.Windows.Forms.Button btnKey;
        private System.Windows.Forms.Button btnAns;
        private System.Windows.Forms.Button btnLanguage;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button1;
    }
}

