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
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSerialize = new System.Windows.Forms.Button();
            this.buttonDeSerialize = new System.Windows.Forms.Button();
            this.buttonCleanList = new System.Windows.Forms.Button();
            this.buttonMakeList = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.sprawdzPogode1 = new JTTT.sprawdzPogode();
            this.wyslijMaila = new JTTT.WyslijMaila();
            this.znajdzNaStronie = new JTTT.ZnajdzNaStronie();
            this.buttonWeather = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.buttonMake.Text = "Dodaj do listy";
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
            this.panel3.Controls.Add(this.buttonWeather);
            this.panel3.Controls.Add(this.sprawdzPogode1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.textBoxName);
            this.panel3.Controls.Add(this.groupBox1);
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
            this.panel3.Size = new System.Drawing.Size(963, 571);
            this.panel3.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(42, 470);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "Nazwa ";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(104, 470);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(353, 20);
            this.textBoxName.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSerialize);
            this.groupBox1.Controls.Add(this.buttonDeSerialize);
            this.groupBox1.Controls.Add(this.buttonCleanList);
            this.groupBox1.Controls.Add(this.buttonMakeList);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(476, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 311);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // buttonSerialize
            // 
            this.buttonSerialize.Location = new System.Drawing.Point(313, 211);
            this.buttonSerialize.Name = "buttonSerialize";
            this.buttonSerialize.Size = new System.Drawing.Size(153, 34);
            this.buttonSerialize.TabIndex = 20;
            this.buttonSerialize.Text = "Serlialize";
            this.buttonSerialize.UseVisualStyleBackColor = true;
            this.buttonSerialize.Click += new System.EventHandler(this.buttonSerialize_Click);
            // 
            // buttonDeSerialize
            // 
            this.buttonDeSerialize.Location = new System.Drawing.Point(313, 248);
            this.buttonDeSerialize.Name = "buttonDeSerialize";
            this.buttonDeSerialize.Size = new System.Drawing.Size(153, 38);
            this.buttonDeSerialize.TabIndex = 19;
            this.buttonDeSerialize.Text = "DeSerialize";
            this.buttonDeSerialize.UseVisualStyleBackColor = true;
            this.buttonDeSerialize.Click += new System.EventHandler(this.buttonDeSerialize_Click);
            // 
            // buttonCleanList
            // 
            this.buttonCleanList.Location = new System.Drawing.Point(169, 211);
            this.buttonCleanList.Name = "buttonCleanList";
            this.buttonCleanList.Size = new System.Drawing.Size(138, 75);
            this.buttonCleanList.TabIndex = 18;
            this.buttonCleanList.Text = "Wyczyść listę";
            this.buttonCleanList.UseVisualStyleBackColor = true;
            this.buttonCleanList.Click += new System.EventHandler(this.buttonCleanList_Click);
            // 
            // buttonMakeList
            // 
            this.buttonMakeList.Location = new System.Drawing.Point(15, 211);
            this.buttonMakeList.Name = "buttonMakeList";
            this.buttonMakeList.Size = new System.Drawing.Size(148, 75);
            this.buttonMakeList.TabIndex = 17;
            this.buttonMakeList.Text = "Wykonaj";
            this.buttonMakeList.UseVisualStyleBackColor = true;
            this.buttonMakeList.Click += new System.EventHandler(this.buttonMakeList_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(15, 17);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(451, 173);
            this.listBox1.TabIndex = 16;
            // 
            // sprawdzPogode1
            // 
            this.sprawdzPogode1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sprawdzPogode1.City = "";
            this.sprawdzPogode1.Location = new System.Drawing.Point(20, 112);
            this.sprawdzPogode1.Name = "sprawdzPogode1";
            this.sprawdzPogode1.Size = new System.Drawing.Size(437, 90);
            this.sprawdzPogode1.TabIndex = 20;
            this.sprawdzPogode1.Temp = 0;
            this.sprawdzPogode1.Visible = false;
            // 
            // wyslijMaila
            // 
            this.wyslijMaila.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wyslijMaila.Location = new System.Drawing.Point(20, 298);
            this.wyslijMaila.Name = "wyslijMaila";
            this.wyslijMaila.Size = new System.Drawing.Size(441, 84);
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
            // buttonWeather
            // 
            this.buttonWeather.Location = new System.Drawing.Point(800, 532);
            this.buttonWeather.Name = "buttonWeather";
            this.buttonWeather.Size = new System.Drawing.Size(142, 23);
            this.buttonWeather.TabIndex = 21;
            this.buttonWeather.Text = "Pogoda milordzie!";
            this.buttonWeather.UseVisualStyleBackColor = true;
            this.buttonWeather.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonWeather_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 591);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "JTTT (JS-BR)";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSerialize;
        private System.Windows.Forms.Button buttonDeSerialize;
        private System.Windows.Forms.Button buttonCleanList;
        private System.Windows.Forms.Button buttonMakeList;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxName;
        private sprawdzPogode sprawdzPogode1;
        private System.Windows.Forms.Button buttonWeather;
    }
}

