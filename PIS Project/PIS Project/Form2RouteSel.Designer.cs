namespace PIS_Project
{
    partial class Form2RouteSel
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.PunetoMum_R = new System.Windows.Forms.CheckBox();
            this.PunetoSur_R = new System.Windows.Forms.CheckBox();
            this.PunetoKop_R = new System.Windows.Forms.CheckBox();
            this.PunetoBsl_R = new System.Windows.Forms.CheckBox();
            this.NagpurtoBsl_R = new System.Windows.Forms.CheckBox();
            this.Back_B = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.Back_B);
            this.groupBox1.Controls.Add(this.NagpurtoBsl_R);
            this.groupBox1.Controls.Add(this.PunetoBsl_R);
            this.groupBox1.Controls.Add(this.PunetoKop_R);
            this.groupBox1.Controls.Add(this.PunetoSur_R);
            this.groupBox1.Controls.Add(this.PunetoMum_R);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.vScrollBar1);
            this.groupBox1.Location = new System.Drawing.Point(18, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 482);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Route Selection";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(416, 19);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(23, 342);
            this.vScrollBar1.TabIndex = 9;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "ROUTES :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PunetoMum_R
            // 
            this.PunetoMum_R.AutoSize = true;
            this.PunetoMum_R.Location = new System.Drawing.Point(18, 49);
            this.PunetoMum_R.Name = "PunetoMum_R";
            this.PunetoMum_R.Size = new System.Drawing.Size(107, 17);
            this.PunetoMum_R.TabIndex = 12;
            this.PunetoMum_R.Text = "PUNE TO CSTM";
            this.PunetoMum_R.UseVisualStyleBackColor = true;
            // 
            // PunetoSur_R
            // 
            this.PunetoSur_R.AutoSize = true;
            this.PunetoSur_R.Location = new System.Drawing.Point(17, 109);
            this.PunetoSur_R.Name = "PunetoSur_R";
            this.PunetoSur_R.Size = new System.Drawing.Size(100, 17);
            this.PunetoSur_R.TabIndex = 13;
            this.PunetoSur_R.Text = "PUNE TO SUR";
            this.PunetoSur_R.UseVisualStyleBackColor = true;
            // 
            // PunetoKop_R
            // 
            this.PunetoKop_R.AutoSize = true;
            this.PunetoKop_R.Location = new System.Drawing.Point(18, 176);
            this.PunetoKop_R.Name = "PunetoKop_R";
            this.PunetoKop_R.Size = new System.Drawing.Size(99, 17);
            this.PunetoKop_R.TabIndex = 14;
            this.PunetoKop_R.Text = "PUNE TO KOP";
            this.PunetoKop_R.UseVisualStyleBackColor = true;
            // 
            // PunetoBsl_R
            // 
            this.PunetoBsl_R.AutoSize = true;
            this.PunetoBsl_R.Location = new System.Drawing.Point(18, 241);
            this.PunetoBsl_R.Name = "PunetoBsl_R";
            this.PunetoBsl_R.Size = new System.Drawing.Size(97, 17);
            this.PunetoBsl_R.TabIndex = 15;
            this.PunetoBsl_R.Text = "PUNE TO BSL";
            this.PunetoBsl_R.UseVisualStyleBackColor = true;
            // 
            // NagpurtoBsl_R
            // 
            this.NagpurtoBsl_R.AutoSize = true;
            this.NagpurtoBsl_R.Location = new System.Drawing.Point(18, 306);
            this.NagpurtoBsl_R.Name = "NagpurtoBsl_R";
            this.NagpurtoBsl_R.Size = new System.Drawing.Size(90, 17);
            this.NagpurtoBsl_R.TabIndex = 16;
            this.NagpurtoBsl_R.Text = "NGP TO BSL";
            this.NagpurtoBsl_R.UseVisualStyleBackColor = true;
            // 
            // Back_B
            // 
            this.Back_B.Location = new System.Drawing.Point(83, 433);
            this.Back_B.Name = "Back_B";
            this.Back_B.Size = new System.Drawing.Size(90, 23);
            this.Back_B.TabIndex = 17;
            this.Back_B.Text = "BACK";
            this.Back_B.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(243, 433);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "SEND";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(181, 367);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(241, 43);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "SELECT HERE  IF YOU WANT TO SEND \r\nCOORDINATES FOR SELECTED STATION \r\nFROM LIST";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(183, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(230, 342);
            this.listView1.TabIndex = 20;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Form2RouteSel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 510);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2RouteSel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PASSENGER INFORMATION SYSTEM DEMO";
            this.Load += new System.EventHandler(this.Form2RouteSel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Back_B;
        private System.Windows.Forms.CheckBox NagpurtoBsl_R;
        private System.Windows.Forms.CheckBox PunetoBsl_R;
        private System.Windows.Forms.CheckBox PunetoKop_R;
        private System.Windows.Forms.CheckBox PunetoSur_R;
        private System.Windows.Forms.CheckBox PunetoMum_R;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;

    }
}