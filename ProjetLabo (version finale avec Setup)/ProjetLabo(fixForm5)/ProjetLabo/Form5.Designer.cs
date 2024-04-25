namespace ProjetLabo
{
    partial class Form5
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
        /// 


        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxProbleme = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonPageSuivante = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Controls.Add(this.comboBox3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(272, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 226);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Avancement des incidents";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(178, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Valider";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(112, 113);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(205, 95);
            this.listBox1.TabIndex = 2;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(196, 36);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Suivi de :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxId);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxProbleme);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(272, 344);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 214);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Envoyer une demande d\'intervention";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(209, 58);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(121, 20);
            this.textBoxId.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(168, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "ID:";
            // 
            // textBoxProbleme
            // 
            this.textBoxProbleme.Location = new System.Drawing.Point(209, 114);
            this.textBoxProbleme.Name = "textBoxProbleme";
            this.textBoxProbleme.Size = new System.Drawing.Size(121, 20);
            this.textBoxProbleme.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(178, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Envoyer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(209, 87);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Problème rencontré :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Poste concerné :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(75, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Interface utilisateurs";
            // 
            // buttonPageSuivante
            // 
            this.buttonPageSuivante.Location = new System.Drawing.Point(832, 555);
            this.buttonPageSuivante.Name = "buttonPageSuivante";
            this.buttonPageSuivante.Size = new System.Drawing.Size(91, 23);
            this.buttonPageSuivante.TabIndex = 5;
            this.buttonPageSuivante.Text = "Page suivante";
            this.buttonPageSuivante.UseVisualStyleBackColor = true;
            this.buttonPageSuivante.Click += new System.EventHandler(this.buttonPageSuivante_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 626);
            this.Controls.Add(this.buttonPageSuivante);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form5";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonPageSuivante;
        private System.Windows.Forms.TextBox textBoxProbleme;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label6;














        //    private void InitializeComponent()
        //    {
        //        this.label1 = new System.Windows.Forms.Label();
        //        this.groupBox1 = new System.Windows.Forms.GroupBox();
        //        this.groupBox2 = new System.Windows.Forms.GroupBox();
        //        this.textBox1 = new System.Windows.Forms.TextBox();
        //        this.groupBox1.SuspendLayout();
        //        this.SuspendLayout();
        //        // 
        //        // label1
        //        // 
        //        this.label1.AutoSize = true;
        //        this.label1.Location = new System.Drawing.Point(31, 40);
        //        this.label1.Name = "label1";
        //        this.label1.Size = new System.Drawing.Size(35, 13);
        //        this.label1.TabIndex = 0;
        //        this.label1.Text = "label1";
        //        // 
        //        // groupBox1
        //        // 
        //        this.groupBox1.Controls.Add(this.textBox1);
        //        this.groupBox1.Controls.Add(this.label1);
        //        this.groupBox1.Location = new System.Drawing.Point(238, 41);
        //        this.groupBox1.Name = "groupBox1";
        //        this.groupBox1.Size = new System.Drawing.Size(268, 158);
        //        this.groupBox1.TabIndex = 1;
        //        this.groupBox1.TabStop = false;
        //        this.groupBox1.Text = "Déclarer un incident";
        //        // 
        //        // groupBox2
        //        // 
        //        this.groupBox2.Location = new System.Drawing.Point(238, 221);
        //        this.groupBox2.Name = "groupBox2";
        //        this.groupBox2.Size = new System.Drawing.Size(268, 182);
        //        this.groupBox2.TabIndex = 2;
        //        this.groupBox2.TabStop = false;
        //        // 
        //        // textBox1
        //        // 
        //        this.textBox1.Location = new System.Drawing.Point(81, 40);
        //        this.textBox1.Name = "textBox1";
        //        this.textBox1.Size = new System.Drawing.Size(100, 20);
        //        this.textBox1.TabIndex = 1;
        //        // 
        //        // Form5
        //        // 
        //        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        //        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //        this.ClientSize = new System.Drawing.Size(860, 473);
        //        this.Controls.Add(this.groupBox2);
        //        this.Controls.Add(this.groupBox1);
        //        this.Name = "Form5";
        //        this.Text = "Form5";
        //        this.groupBox1.ResumeLayout(false);
        //        this.groupBox1.PerformLayout();
        //        this.ResumeLayout(false);

        //    }

        //    #endregion

        //    private System.Windows.Forms.Label label1;
        //    private System.Windows.Forms.GroupBox groupBox1;
        //    private System.Windows.Forms.GroupBox groupBox2;
        //    private System.Windows.Forms.TextBox textBox1;
    }
}