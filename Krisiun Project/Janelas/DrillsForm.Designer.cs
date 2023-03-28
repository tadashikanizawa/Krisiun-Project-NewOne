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
            this.mentori_Frente1 = new Krisiun_Project.UserControils.Mentori_Frente();
            this.lado_UserControl1 = new Krisiun_Project.UserControils.Lado_UserControl();
            this.mentori_Tras1 = new Krisiun_Project.UserControils.Mentori_Tras();
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
            // mentori_Frente1
            // 
            this.mentori_Frente1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mentori_Frente1.Kei = "1";
            this.mentori_Frente1.Location = new System.Drawing.Point(183, 38);
            this.mentori_Frente1.Name = "mentori_Frente1";
            this.mentori_Frente1.Size = new System.Drawing.Size(138, 115);
            this.mentori_Frente1.TabIndex = 1;
            // 
            // lado_UserControl1
            // 
            this.lado_UserControl1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lado_UserControl1.Location = new System.Drawing.Point(349, 73);
            this.lado_UserControl1.Name = "lado_UserControl1";
            this.lado_UserControl1.Size = new System.Drawing.Size(67, 150);
            this.lado_UserControl1.TabIndex = 2;
            this.lado_UserControl1.Load += new System.EventHandler(this.lado_UserControl1_Load);
            // 
            // mentori_Tras1
            // 
            this.mentori_Tras1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mentori_Tras1.Kei = "3.3";
            this.mentori_Tras1.Location = new System.Drawing.Point(189, 159);
            this.mentori_Tras1.Name = "mentori_Tras1";
            this.mentori_Tras1.Size = new System.Drawing.Size(132, 116);
            this.mentori_Tras1.TabIndex = 3;
            // 
            // DrillsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mentori_Tras1);
            this.Controls.Add(this.lado_UserControl1);
            this.Controls.Add(this.mentori_Frente1);
            this.Controls.Add(this.drill_UserControl1);
            this.Name = "DrillsForm";
            this.Text = "DrillsFOrm";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControils.Drill_UserControl drill_UserControl1;
        private UserControils.Mentori_Frente mentori_Frente1;
        private UserControils.Lado_UserControl lado_UserControl1;
        private UserControils.Mentori_Tras mentori_Tras1;
    }
}