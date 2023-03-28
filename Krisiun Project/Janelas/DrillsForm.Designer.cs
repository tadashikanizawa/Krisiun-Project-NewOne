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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // drill_UserControl1
            // 
            this.drill_UserControl1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.drill_UserControl1.Location = new System.Drawing.Point(12, 27);
            this.drill_UserControl1.Name = "drill_UserControl1";
            this.drill_UserControl1.Size = new System.Drawing.Size(141, 186);
            this.drill_UserControl1.TabIndex = 0;
            // 
            // lado_UserControl1
            // 
            this.lado_UserControl1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lado_UserControl1.Location = new System.Drawing.Point(383, 27);
            this.lado_UserControl1.Mentori_F_Bool = false;
            this.lado_UserControl1.Name = "lado_UserControl1";
            this.lado_UserControl1.Size = new System.Drawing.Size(67, 150);
            this.lado_UserControl1.TabIndex = 2;
            this.lado_UserControl1.Load += new System.EventHandler(this.lado_UserControl1_Load);
            // 
            // mentori_Frente1
            // 
            this.mentori_Frente1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mentori_Frente1.Kei = "1";
            this.mentori_Frente1.Location = new System.Drawing.Point(15, 219);
            this.mentori_Frente1.Name = "mentori_Frente1";
            this.mentori_Frente1.Size = new System.Drawing.Size(138, 115);
            this.mentori_Frente1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y});
            this.dataGridView1.Location = new System.Drawing.Point(472, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(203, 150);
            this.dataGridView1.TabIndex = 4;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            // 
            // mentori_Tras1
            // 
            this.mentori_Tras1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mentori_Tras1.Kei = "3.3";
            this.mentori_Tras1.Location = new System.Drawing.Point(159, 219);
            this.mentori_Tras1.Name = "mentori_Tras1";
            this.mentori_Tras1.Size = new System.Drawing.Size(132, 116);
            this.mentori_Tras1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(439, 324);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 84);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DrillsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mentori_Tras1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.mentori_Frente1);
            this.Controls.Add(this.lado_UserControl1);
            this.Controls.Add(this.drill_UserControl1);
            this.Name = "DrillsForm";
            this.Text = "DrillsFOrm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControils.Drill_UserControl drill_UserControl1;
        private UserControils.Lado_UserControl lado_UserControl1;
        private UserControils.Mentori_Frente mentori_Frente1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private UserControils.Mentori_Tras mentori_Tras1;
        private System.Windows.Forms.Button button1;
    }
}