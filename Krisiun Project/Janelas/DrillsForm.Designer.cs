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
            this.mentori_Frente2 = new Krisiun_Project.UserControils.Mentori_Frente();
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
            this.drill_UserControl1.Location = new System.Drawing.Point(91, 15);
            this.drill_UserControl1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.drill_UserControl1.Name = "drill_UserControl1";
            this.drill_UserControl1.Sentan = false;
            this.drill_UserControl1.Size = new System.Drawing.Size(141, 186);
            this.drill_UserControl1.TabIndex = 0;
            this.drill_UserControl1.Load += new System.EventHandler(this.drill_UserControl1_Load);
            // 
            // lado_UserControl1
            // 
            this.lado_UserControl1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lado_UserControl1.Bool_Frente = false;
            this.lado_UserControl1.Bool_Tras = false;
            this.lado_UserControl1.Location = new System.Drawing.Point(14, 15);
            this.lado_UserControl1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.lado_UserControl1.Name = "lado_UserControl1";
            this.lado_UserControl1.Size = new System.Drawing.Size(67, 150);
            this.lado_UserControl1.TabIndex = 2;
            this.lado_UserControl1.Load += new System.EventHandler(this.lado_UserControl1_Load);
            // 
            // mentori_Frente1
            // 
            this.mentori_Frente1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mentori_Frente1.Kei = "1";
            this.mentori_Frente1.Location = new System.Drawing.Point(242, 27);
            this.mentori_Frente1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.mentori_Frente1.Name = "mentori_Frente1";
            this.mentori_Frente1.Size = new System.Drawing.Size(138, 115);
            this.mentori_Frente1.TabIndex = 3;
            this.mentori_Frente1.Load += new System.EventHandler(this.mentori_Frente1_Load);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y});
            this.dataGridView1.Location = new System.Drawing.Point(85, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(140, 150);
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
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(588, 354);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 84);
            this.button1.TabIndex = 6;
            this.button1.Text = "作成/セーブ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(424, 279);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(52, 16);
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
            this.radioButton1.Location = new System.Drawing.Point(424, 258);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(37, 16);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "XY";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // xy_panel
            // 
            this.xy_panel.Controls.Add(this.dataGridView1);
            this.xy_panel.Location = new System.Drawing.Point(482, 15);
            this.xy_panel.Margin = new System.Windows.Forms.Padding(2);
            this.xy_panel.Name = "xy_panel";
            this.xy_panel.Size = new System.Drawing.Size(240, 289);
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
            this.pcd_panel.Location = new System.Drawing.Point(482, 15);
            this.pcd_panel.Name = "pcd_panel";
            this.pcd_panel.Size = new System.Drawing.Size(240, 289);
            this.pcd_panel.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "P.C.D.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "X";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(26, 250);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(44, 19);
            this.textBox3.TabIndex = 13;
            this.textBox3.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(26, 225);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(44, 19);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "0";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(67, 19);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "0";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dataGridView2.Location = new System.Drawing.Point(85, 18);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(89, 258);
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
            this.button2.Location = new System.Drawing.Point(474, 393);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 45);
            this.button2.TabIndex = 14;
            this.button2.Text = "閉じる";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // colors_UserControl1
            // 
            this.colors_UserControl1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.colors_UserControl1.Location = new System.Drawing.Point(19, 197);
            this.colors_UserControl1.Margin = new System.Windows.Forms.Padding(1);
            this.colors_UserControl1.Name = "colors_UserControl1";
            this.colors_UserControl1.Size = new System.Drawing.Size(116, 58);
            this.colors_UserControl1.TabIndex = 15;
            // 
            // mentori_Frente2
            // 
            this.mentori_Frente2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mentori_Frente2.Kei = "1";
            this.mentori_Frente2.Location = new System.Drawing.Point(242, 159);
            this.mentori_Frente2.Name = "mentori_Frente2";
            this.mentori_Frente2.Size = new System.Drawing.Size(138, 115);
            this.mentori_Frente2.TabIndex = 16;
            // 
            // DrillsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(739, 450);
            this.Controls.Add(this.mentori_Frente2);
            this.Controls.Add(this.colors_UserControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mentori_Frente1);
            this.Controls.Add(this.lado_UserControl1);
            this.Controls.Add(this.drill_UserControl1);
            this.Controls.Add(this.xy_panel);
            this.Controls.Add(this.pcd_panel);
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
        private UserControils.Mentori_Frente mentori_Frente2;
    }
}