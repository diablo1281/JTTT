namespace JTTT
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.buttonMake = new System.Windows.Forms.Button();
            this.panelFindPicture = new System.Windows.Forms.Panel();
            this.comboBoxIF = new System.Windows.Forms.ComboBox();
            this.comboBoxTHEN = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.panelSendMail = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelFindPicture.SuspendLayout();
            this.panelSendMail.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(187, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jeżeli";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(17, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "to:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(17, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "to wykonaj to:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(18, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "URL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(2, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tekst";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(3, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "e-mail";
            // 
            // textBoxURL
            // 
            this.textBoxURL.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxURL.Location = new System.Drawing.Point(65, 14);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(322, 20);
            this.textBoxURL.TabIndex = 7;
            // 
            // textBoxText
            // 
            this.textBoxText.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxText.Location = new System.Drawing.Point(65, 52);
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(322, 20);
            this.textBoxText.TabIndex = 8;
            // 
            // textBoxMail
            // 
            this.textBoxMail.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxMail.Location = new System.Drawing.Point(65, 10);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(322, 20);
            this.textBoxMail.TabIndex = 9;
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(132, 496);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(239, 23);
            this.buttonMake.TabIndex = 10;
            this.buttonMake.Text = "Wykonaj";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // panelFindPicture
            // 
            this.panelFindPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFindPicture.Controls.Add(this.textBoxURL);
            this.panelFindPicture.Controls.Add(this.label5);
            this.panelFindPicture.Controls.Add(this.label6);
            this.panelFindPicture.Controls.Add(this.textBoxText);
            this.panelFindPicture.Location = new System.Drawing.Point(20, 101);
            this.panelFindPicture.Name = "panelFindPicture";
            this.panelFindPicture.Size = new System.Drawing.Size(426, 89);
            this.panelFindPicture.TabIndex = 11;
            this.panelFindPicture.Visible = false;
            // 
            // comboBoxIF
            // 
            this.comboBoxIF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIF.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxIF.FormattingEnabled = true;
            this.comboBoxIF.Location = new System.Drawing.Point(55, 74);
            this.comboBoxIF.Name = "comboBoxIF";
            this.comboBoxIF.Size = new System.Drawing.Size(391, 21);
            this.comboBoxIF.TabIndex = 12;
            this.comboBoxIF.SelectedIndexChanged += new System.EventHandler(this.comboBoxIF_SelectedIndexChanged);
            // 
            // comboBoxTHEN
            // 
            this.comboBoxTHEN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTHEN.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxTHEN.FormattingEnabled = true;
            this.comboBoxTHEN.Location = new System.Drawing.Point(143, 271);
            this.comboBoxTHEN.Name = "comboBoxTHEN";
            this.comboBoxTHEN.Size = new System.Drawing.Size(303, 21);
            this.comboBoxTHEN.TabIndex = 13;
            this.comboBoxTHEN.SelectedIndexChanged += new System.EventHandler(this.comboBoxTHEN_SelectedIndexChanged);
            // 
            // panelSendMail
            // 
            this.panelSendMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSendMail.Controls.Add(this.label7);
            this.panelSendMail.Controls.Add(this.textBoxMail);
            this.panelSendMail.Location = new System.Drawing.Point(20, 298);
            this.panelSendMail.Name = "panelSendMail";
            this.panelSendMail.Size = new System.Drawing.Size(426, 100);
            this.panelSendMail.TabIndex = 14;
            this.panelSendMail.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.panelSendMail);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.comboBoxTHEN);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.comboBoxIF);
            this.panel3.Controls.Add(this.buttonMake);
            this.panel3.Controls.Add(this.panelFindPicture);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(493, 571);
            this.panel3.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 591);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelFindPicture.ResumeLayout(false);
            this.panelFindPicture.PerformLayout();
            this.panelSendMail.ResumeLayout(false);
            this.panelSendMail.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.Panel panelFindPicture;
        private System.Windows.Forms.ComboBox comboBoxIF;
        private System.Windows.Forms.ComboBox comboBoxTHEN;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Panel panelSendMail;
        private System.Windows.Forms.Panel panel3;
    }
}

