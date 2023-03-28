namespace Krisiun_Project.UserControils
{
    partial class Mentori_Frente
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
            this.men_frente_z_tb = new System.Windows.Forms.TextBox();
            this.men_frente_checkbox = new System.Windows.Forms.CheckBox();
            this.label35 = new System.Windows.Forms.Label();
            this.men_frente_tipo_combo = new System.Windows.Forms.ComboBox();
            this.men_frente_dan_tb = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.men_frente_tam_tb = new System.Windows.Forms.TextBox();
            this.men_frente_kei_tb = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // men_frente_z_tb
            // 
            this.men_frente_z_tb.Location = new System.Drawing.Point(31, 80);
            this.men_frente_z_tb.Name = "men_frente_z_tb";
            this.men_frente_z_tb.Size = new System.Drawing.Size(36, 19);
            this.men_frente_z_tb.TabIndex = 85;
            this.men_frente_z_tb.Text = "-1.5";
            this.men_frente_z_tb.TextChanged += new System.EventHandler(this.men_frente_z_tb_TextChanged);
            // 
            // men_frente_checkbox
            // 
            this.men_frente_checkbox.AutoSize = true;
            this.men_frente_checkbox.Location = new System.Drawing.Point(26, 12);
            this.men_frente_checkbox.Name = "men_frente_checkbox";
            this.men_frente_checkbox.Size = new System.Drawing.Size(76, 16);
            this.men_frente_checkbox.TabIndex = 77;
            this.men_frente_checkbox.Text = "面取り(表)";
            this.men_frente_checkbox.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(16, 82);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(12, 12);
            this.label35.TabIndex = 86;
            this.label35.Text = "Z";
            // 
            // men_frente_tipo_combo
            // 
            this.men_frente_tipo_combo.FormattingEnabled = true;
            this.men_frente_tipo_combo.Items.AddRange(new object[] {
            "VC-2C(φ10)"});
            this.men_frente_tipo_combo.Location = new System.Drawing.Point(23, 32);
            this.men_frente_tipo_combo.Name = "men_frente_tipo_combo";
            this.men_frente_tipo_combo.Size = new System.Drawing.Size(96, 20);
            this.men_frente_tipo_combo.TabIndex = 78;
            this.men_frente_tipo_combo.Text = "VC-2C(φ10)";
            this.men_frente_tipo_combo.SelectedIndexChanged += new System.EventHandler(this.men_frente_tipo_combo_SelectedIndexChanged);
            // 
            // men_frente_dan_tb
            // 
            this.men_frente_dan_tb.Location = new System.Drawing.Point(83, 80);
            this.men_frente_dan_tb.Name = "men_frente_dan_tb";
            this.men_frente_dan_tb.Size = new System.Drawing.Size(36, 19);
            this.men_frente_dan_tb.TabIndex = 83;
            this.men_frente_dan_tb.Text = "0";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(67, 82);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(18, 12);
            this.label32.TabIndex = 84;
            this.label32.Text = "Z+";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(13, 63);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(17, 12);
            this.label30.TabIndex = 80;
            this.label30.Text = "φ";
            // 
            // men_frente_tam_tb
            // 
            this.men_frente_tam_tb.Location = new System.Drawing.Point(83, 56);
            this.men_frente_tam_tb.Name = "men_frente_tam_tb";
            this.men_frente_tam_tb.Size = new System.Drawing.Size(36, 19);
            this.men_frente_tam_tb.TabIndex = 81;
            this.men_frente_tam_tb.Text = "0.3";
            // 
            // men_frente_kei_tb
            // 
            this.men_frente_kei_tb.Location = new System.Drawing.Point(31, 56);
            this.men_frente_kei_tb.Name = "men_frente_kei_tb";
            this.men_frente_kei_tb.Size = new System.Drawing.Size(36, 19);
            this.men_frente_kei_tb.TabIndex = 79;
            this.men_frente_kei_tb.Text = "1";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(67, 59);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(13, 12);
            this.label31.TabIndex = 82;
            this.label31.Text = "C";
            // 
            // Mentori_Frente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.men_frente_z_tb);
            this.Controls.Add(this.men_frente_checkbox);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.men_frente_tipo_combo);
            this.Controls.Add(this.men_frente_dan_tb);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.men_frente_tam_tb);
            this.Controls.Add(this.men_frente_kei_tb);
            this.Controls.Add(this.label31);
            this.Name = "Mentori_Frente";
            this.Size = new System.Drawing.Size(138, 115);
            this.Load += new System.EventHandler(this.Mentori_Frente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox men_frente_z_tb;
        public System.Windows.Forms.CheckBox men_frente_checkbox;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox men_frente_tipo_combo;
        private System.Windows.Forms.TextBox men_frente_dan_tb;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox men_frente_tam_tb;
        public System.Windows.Forms.TextBox men_frente_kei_tb;
        private System.Windows.Forms.Label label31;
    }
}
