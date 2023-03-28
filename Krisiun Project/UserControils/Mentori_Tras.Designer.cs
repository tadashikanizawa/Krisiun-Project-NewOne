namespace Krisiun_Project.UserControils
{
    partial class Mentori_Tras
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
            this.men_tras_z = new System.Windows.Forms.TextBox();
            this.men_tras_checkbox = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.men_tras_tipo_combo = new System.Windows.Forms.ComboBox();
            this.men_tras_dan = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.men_tras_tam = new System.Windows.Forms.TextBox();
            this.men_tras_kei = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // men_tras_z
            // 
            this.men_tras_z.Location = new System.Drawing.Point(29, 82);
            this.men_tras_z.Name = "men_tras_z";
            this.men_tras_z.Size = new System.Drawing.Size(36, 19);
            this.men_tras_z.TabIndex = 85;
            this.men_tras_z.Text = "-1.5";
            // 
            // men_tras_checkbox
            // 
            this.men_tras_checkbox.AutoSize = true;
            this.men_tras_checkbox.Location = new System.Drawing.Point(24, 14);
            this.men_tras_checkbox.Name = "men_tras_checkbox";
            this.men_tras_checkbox.Size = new System.Drawing.Size(76, 16);
            this.men_tras_checkbox.TabIndex = 77;
            this.men_tras_checkbox.Text = "面取り(裏)";
            this.men_tras_checkbox.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 84);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(12, 12);
            this.label16.TabIndex = 86;
            this.label16.Text = "Z";
            // 
            // men_tras_tipo_combo
            // 
            this.men_tras_tipo_combo.FormattingEnabled = true;
            this.men_tras_tipo_combo.Items.AddRange(new object[] {
            "VC-2C(φ10)"});
            this.men_tras_tipo_combo.Location = new System.Drawing.Point(21, 34);
            this.men_tras_tipo_combo.Name = "men_tras_tipo_combo";
            this.men_tras_tipo_combo.Size = new System.Drawing.Size(96, 20);
            this.men_tras_tipo_combo.TabIndex = 78;
            this.men_tras_tipo_combo.Text = "VC-2C(φ10)";
            this.men_tras_tipo_combo.SelectedIndexChanged += new System.EventHandler(this.men_tras_tipo_combo_SelectedIndexChanged);
            // 
            // men_tras_dan
            // 
            this.men_tras_dan.Location = new System.Drawing.Point(81, 82);
            this.men_tras_dan.Name = "men_tras_dan";
            this.men_tras_dan.Size = new System.Drawing.Size(36, 19);
            this.men_tras_dan.TabIndex = 83;
            this.men_tras_dan.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(65, 84);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(18, 12);
            this.label17.TabIndex = 84;
            this.label17.Text = "Z+";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 65);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 80;
            this.label18.Text = "φ";
            // 
            // men_tras_tam
            // 
            this.men_tras_tam.Location = new System.Drawing.Point(81, 58);
            this.men_tras_tam.Name = "men_tras_tam";
            this.men_tras_tam.Size = new System.Drawing.Size(36, 19);
            this.men_tras_tam.TabIndex = 81;
            this.men_tras_tam.Text = "0.3";
            // 
            // men_tras_kei
            // 
            this.men_tras_kei.Location = new System.Drawing.Point(29, 56);
            this.men_tras_kei.Name = "men_tras_kei";
            this.men_tras_kei.Size = new System.Drawing.Size(36, 19);
            this.men_tras_kei.TabIndex = 79;
            this.men_tras_kei.Text = "3.3";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(45, 60);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(13, 12);
            this.label19.TabIndex = 82;
            this.label19.Text = "C";
            // 
            // Mentori_Tras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.men_tras_z);
            this.Controls.Add(this.men_tras_checkbox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.men_tras_tipo_combo);
            this.Controls.Add(this.men_tras_dan);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.men_tras_tam);
            this.Controls.Add(this.men_tras_kei);
            this.Controls.Add(this.label19);
            this.Name = "Mentori_Tras";
            this.Size = new System.Drawing.Size(132, 116);
            this.Load += new System.EventHandler(this.Mentori_Tras_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox men_tras_z;
        public System.Windows.Forms.CheckBox men_tras_checkbox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox men_tras_tipo_combo;
        private System.Windows.Forms.TextBox men_tras_dan;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox men_tras_tam;
        public System.Windows.Forms.TextBox men_tras_kei;
        private System.Windows.Forms.Label label19;
    }
}
