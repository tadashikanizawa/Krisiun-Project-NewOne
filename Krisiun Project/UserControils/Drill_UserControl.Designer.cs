namespace Krisiun_Project.UserControils
{
    partial class Drill_UserControl
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
            this.label29 = new System.Windows.Forms.Label();
            this.Resfri_Combobox = new System.Windows.Forms.ComboBox();
            this.drill_combobox = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.Num_pro_textbox = new System.Windows.Forms.TextBox();
            this.drill_z_tb = new System.Windows.Forms.TextBox();
            this.sentan_cb = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.drill_kei_tb = new System.Windows.Forms.TextBox();
            this.tool_tb = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(57, 12);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(29, 12);
            this.label29.TabIndex = 65;
            this.label29.Text = "種類";
            // 
            // Resfri_Combobox
            // 
            this.Resfri_Combobox.FormattingEnabled = true;
            this.Resfri_Combobox.Items.AddRange(new object[] {
            "M08",
            "M12",
            "M51",
            "M339"});
            this.Resfri_Combobox.Location = new System.Drawing.Point(68, 97);
            this.Resfri_Combobox.Name = "Resfri_Combobox";
            this.Resfri_Combobox.Size = new System.Drawing.Size(60, 20);
            this.Resfri_Combobox.TabIndex = 88;
            // 
            // drill_combobox
            // 
            this.drill_combobox.FormattingEnabled = true;
            this.drill_combobox.Items.AddRange(new object[] {
            "ソリッドドリル",
            "カムドリル",
            "アクアフラット",
            "イスカルドリル",
            "NK",
            "ドリル",
            "センタードリル"});
            this.drill_combobox.Location = new System.Drawing.Point(15, 25);
            this.drill_combobox.Margin = new System.Windows.Forms.Padding(2);
            this.drill_combobox.Name = "drill_combobox";
            this.drill_combobox.Size = new System.Drawing.Size(113, 20);
            this.drill_combobox.TabIndex = 25;
            this.drill_combobox.SelectedIndexChanged += new System.EventHandler(this.drill_combobox_SelectedIndexChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(77, 54);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(12, 12);
            this.label25.TabIndex = 84;
            this.label25.Text = "Z";
            // 
            // Num_pro_textbox
            // 
            this.Num_pro_textbox.Location = new System.Drawing.Point(15, 144);
            this.Num_pro_textbox.Name = "Num_pro_textbox";
            this.Num_pro_textbox.Size = new System.Drawing.Size(112, 19);
            this.Num_pro_textbox.TabIndex = 2;
            // 
            // drill_z_tb
            // 
            this.drill_z_tb.Location = new System.Drawing.Point(88, 50);
            this.drill_z_tb.Name = "drill_z_tb";
            this.drill_z_tb.Size = new System.Drawing.Size(36, 19);
            this.drill_z_tb.TabIndex = 83;
            this.drill_z_tb.Text = "0";
            this.drill_z_tb.TextChanged += new System.EventHandler(this.drill_z_tb_TextChanged);
            // 
            // sentan_cb
            // 
            this.sentan_cb.AutoSize = true;
            this.sentan_cb.Location = new System.Drawing.Point(50, 75);
            this.sentan_cb.Name = "sentan_cb";
            this.sentan_cb.Size = new System.Drawing.Size(62, 16);
            this.sentan_cb.TabIndex = 87;
            this.sentan_cb.Text = "(+)先端";
            this.sentan_cb.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(14, 53);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(17, 12);
            this.label24.TabIndex = 82;
            this.label24.Text = "φ";
            // 
            // drill_kei_tb
            // 
            this.drill_kei_tb.Location = new System.Drawing.Point(33, 50);
            this.drill_kei_tb.Name = "drill_kei_tb";
            this.drill_kei_tb.Size = new System.Drawing.Size(36, 19);
            this.drill_kei_tb.TabIndex = 81;
            this.drill_kei_tb.Text = "1";
            this.drill_kei_tb.TextChanged += new System.EventHandler(this.drill_kei_tb_TextChanged);
            // 
            // tool_tb
            // 
            this.tool_tb.Location = new System.Drawing.Point(26, 98);
            this.tool_tb.Name = "tool_tb";
            this.tool_tb.Size = new System.Drawing.Size(36, 19);
            this.tool_tb.TabIndex = 85;
            this.tool_tb.Text = "01";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(12, 100);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(12, 12);
            this.label26.TabIndex = 86;
            this.label26.Text = "T";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 89;
            this.label1.Text = "加工案内";
            // 
            // Drill_UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.Resfri_Combobox);
            this.Controls.Add(this.drill_combobox);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.tool_tb);
            this.Controls.Add(this.Num_pro_textbox);
            this.Controls.Add(this.drill_kei_tb);
            this.Controls.Add(this.drill_z_tb);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.sentan_cb);
            this.Name = "Drill_UserControl";
            this.Size = new System.Drawing.Size(141, 186);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox Resfri_Combobox;
        private System.Windows.Forms.ComboBox drill_combobox;
        private System.Windows.Forms.Label label25;
        public System.Windows.Forms.TextBox Num_pro_textbox;
        public System.Windows.Forms.TextBox drill_z_tb;
        private System.Windows.Forms.CheckBox sentan_cb;
        private System.Windows.Forms.Label label24;
        public System.Windows.Forms.TextBox drill_kei_tb;
        private System.Windows.Forms.TextBox tool_tb;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label1;
    }
}
