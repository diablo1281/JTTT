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
            this.buttonMake = new System.Windows.Forms.Button();
            this.comboBoxIF = new System.Windows.Forms.ComboBox();
            this.comboBoxTHEN = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.wyslijMaila = new JTTT.WyslijMaila();
            this.znajdzNaStronie = new JTTT.ZnajdzNaStronie();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
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
            // panel3
            // 
            this.panel3.Controls.Add(this.wyslijMaila);
            this.panel3.Controls.Add(this.znajdzNaStronie);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.comboBoxTHEN);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.comboBoxIF);
            this.panel3.Controls.Add(this.buttonMake);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(493, 571);
            this.panel3.TabIndex = 15;
            // 
            // wyslijMaila
            // 
            this.wyslijMaila.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wyslijMaila.Location = new System.Drawing.Point(20, 298);
            this.wyslijMaila.Name = "wyslijMaila";
            this.wyslijMaila.Size = new System.Drawing.Size(441, 49);
            this.wyslijMaila.TabIndex = 15;
            this.wyslijMaila.Visible = false;
            // 
            // znajdzNaStronie
            // 
            this.znajdzNaStronie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.znajdzNaStronie.Location = new System.Drawing.Point(20, 112);
            this.znajdzNaStronie.Name = "znajdzNaStronie";
            this.znajdzNaStronie.Size = new System.Drawing.Size(437, 90);
            this.znajdzNaStronie.TabIndex = 14;
            this.znajdzNaStronie.Visible = false;
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
            this.Text = "JTTT (JS-BR)";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.ComboBox comboBoxIF;
        private System.Windows.Forms.ComboBox comboBoxTHEN;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Panel panel3;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private ZnajdzNaStronie znajdzNaStronie;
        private WyslijMaila wyslijMaila;
    }
}

