namespace Krisiun_Project.Janelas
{
    partial class DrillsForm
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
            this.drill_UserControl1 = new Krisiun_Project.UserControils.Drill_UserControl();
            this.lado_UserControl1 = new Krisiun_Project.UserControils.Lado_UserControl();
            this.mentori_Frente1 = new Krisiun_Project.UserControils.Mentori_Frente();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mentori_Tras1 = new Krisiun_Project.UserControils.Mentori_Tras();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.xy_panel = new System.Windows.Forms.Panel();
            this.pcd_panel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.colors_UserControl1 = new Krisiun_Project.UserControils.Colors_UserControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.xy_panel.SuspendLayout();
            this.pcd_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // drill_UserControl1
            // 
            this.drill_UserControl1.Atsumi = 0F;
            this.drill_UserControl1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.drill_UserControl1.DrillKakouAnnai = "";
            this.drill_UserControl1.DrillKei = "1";
            this.drill_UserControl1.DrillNumber = "01";
            this.drill_UserControl1.DrillTipo = null;
            this.drill_UserControl1.DrillZ = "0";
            this.drill_UserControl1.Location = new System.Drawing.Point(152, 22);
            this.drill_UserControl1.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.drill_UserControl1.Name = "drill_UserControl1";
            this.drill_UserControl1.Sentan = false;
            this.drill_UserControl1.Size = new System.Drawing.Size(235, 279);
            this.drill_UserControl1.TabIndex = 0;
            this.drill_UserControl1.Load += new System.EventHandler(this.drill_UserControl1_Load);
            // 
            // lado_UserControl1
            // 
            this.lado_UserControl1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lado_UserControl1.Bool_Frente = false;
            this.lado_UserControl1.Bool_Tras = false;
            this.lado_UserControl1.Location = new System.Drawing.Point(23, 22);
            this.lado_UserControl1.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.lado_UserControl1.Name = "lado_UserControl1";
            this.lado_UserControl1.Size = new System.Drawing.Size(112, 225);
            this.lado_UserControl1.TabIndex = 2;
            this.lado_UserControl1.Load += new System.EventHandler(this.lado_UserControl1_Load);
            // 
            // mentori_Frente1
            // 
            this.mentori_Frente1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mentori_Frente1.Kei = "1";
            this.mentori_Frente1.Location = new System.Drawing.Point(403, 40);
            this.mentori_Frente1.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.mentori_Frente1.Name = "mentori_Frente1";
            this.mentori_Frente1.Size = new System.Drawing.Size(230, 172);
            this.mentori_Frente1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y});
            this.dataGridView1.Location = new System.Drawing.Point(142, 18);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(233, 225);
            this.dataGridView1.TabIndex = 4;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.MinimumWidth = 8;
            this.X.Name = "X";
            this.X.Width = 70;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.MinimumWidth = 8;
            this.Y.Name = "Y";
            this.Y.Width = 70;
            // 
            // mentori_Tras1
            // 
            this.mentori_Tras1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mentori_Tras1.Kei = "3.3";
            this.mentori_Tras1.Location = new System.Drawing.Point(403, 246);
            this.mentori_Tras1.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.mentori_Tras1.Name = "mentori_Tras1";
            this.mentori_Tras1.Size = new System.Drawing.Size(220, 174);
            this.mentori_Tras1.TabIndex = 5;
            this.mentori_Tras1.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(980, 531);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(223, 126);
            this.button1.TabIndex = 6;
            this.button1.Text = "作成/セーブ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(707, 418);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(80, 22);
            this.radioButton2.TabIndex = 12;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "P.C.D.";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(707, 387);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(55, 22);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "XY";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // xy_panel
            // 
            this.xy_panel.Controls.Add(this.dataGridView1);
            this.xy_panel.Location = new System.Drawing.Point(803, 22);
            this.xy_panel.Name = "xy_panel";
            this.xy_panel.Size = new System.Drawing.Size(400, 434);
            this.xy_panel.TabIndex = 13;
            // 
            // pcd_panel
            // 
            this.pcd_panel.Controls.Add(this.label3);
            this.pcd_panel.Controls.Add(this.label2);
            this.pcd_panel.Controls.Add(this.label1);
            this.pcd_panel.Controls.Add(this.textBox3);
            this.pcd_panel.Controls.Add(this.textBox2);
            this.pcd_panel.Controls.Add(this.textBox1);
            this.pcd_panel.Controls.Add(this.dataGridView2);
            this.pcd_panel.Location = new System.Drawing.Point(803, 22);
            this.pcd_panel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pcd_panel.Name = "pcd_panel";
            this.pcd_panel.Size = new System.Drawing.Size(400, 434);
            this.pcd_panel.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "P.C.D.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 380);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 342);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "X";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(43, 375);
            this.textBox3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(71, 25);
            this.textBox3.TabIndex = 13;
            this.textBox3.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(43, 338);
            this.textBox2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(71, 25);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "0";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 66);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(109, 25);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "0";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dataGridView2.Location = new System.Drawing.Point(142, 27);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(148, 387);
            this.dataGridView2.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Ø";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(790, 590);
            this.button2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 68);
            this.button2.TabIndex = 14;
            this.button2.Text = "閉じる";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // colors_UserControl1
            // 
            this.colors_UserControl1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colors_UserControl1.Location = new System.Drawing.Point(32, 295);
            this.colors_UserControl1.Name = "colors_UserControl1";
            this.colors_UserControl1.Size = new System.Drawing.Size(194, 87);
            this.colors_UserControl1.TabIndex = 15;
            // 
            // DrillsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1232, 675);
            this.Controls.Add(this.colors_UserControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mentori_Tras1);
            this.Controls.Add(this.mentori_Frente1);
            this.Controls.Add(this.lado_UserControl1);
            this.Controls.Add(this.drill_UserControl1);
            this.Controls.Add(this.xy_panel);
            this.Controls.Add(this.pcd_panel);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "DrillsForm";
            this.Text = "DrillsFOrm";
            this.Load += new System.EventHandler(this.DrillsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.xy_panel.ResumeLayout(false);
            this.pcd_panel.ResumeLayout(false);
            this.pcd_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControils.Drill_UserControl drill_UserControl1;
        private UserControils.Lado_UserControl lado_UserControl1;
        private UserControils.Mentori_Frente mentori_Frente1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private UserControils.Mentori_Tras mentori_Tras1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Panel xy_panel;
        private System.Windows.Forms.Panel pcd_panel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.Button button2;
        private UserControils.Colors_UserControl colors_UserControl1;
    }
}