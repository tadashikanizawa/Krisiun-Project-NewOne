namespace Krisiun_Project.UserControils
{
    partial class Lado_UserControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tras_checkBox = new System.Windows.Forms.CheckBox();
            this.frente_checkBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(13, 107);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(42, 16);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "横2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 80);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(42, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "横1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // tras_checkBox
            // 
            this.tras_checkBox.AutoSize = true;
            this.tras_checkBox.Location = new System.Drawing.Point(13, 53);
            this.tras_checkBox.Name = "tras_checkBox";
            this.tras_checkBox.Size = new System.Drawing.Size(36, 16);
            this.tras_checkBox.TabIndex = 1;
            this.tras_checkBox.Text = "裏";
            this.tras_checkBox.UseVisualStyleBackColor = true;
            // 
            // frente_checkBox
            // 
            this.frente_checkBox.AutoSize = true;
            this.frente_checkBox.Location = new System.Drawing.Point(13, 26);
            this.frente_checkBox.Name = "frente_checkBox";
            this.frente_checkBox.Size = new System.Drawing.Size(36, 16);
            this.frente_checkBox.TabIndex = 0;
            this.frente_checkBox.Text = "表";
            this.frente_checkBox.UseVisualStyleBackColor = true;
            this.frente_checkBox.CheckedChanged += new System.EventHandler(this.frente_checkBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "面";
            // 
            // Lado_UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.frente_checkBox);
            this.Controls.Add(this.tras_checkBox);
            this.Controls.Add(this.label3);
            this.Name = "Lado_UserControl";
            this.Size = new System.Drawing.Size(67, 140);
            this.Load += new System.EventHandler(this.Lado_UserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox tras_checkBox;
        private System.Windows.Forms.CheckBox frente_checkBox;
        private System.Windows.Forms.Label label3;
    }
}
