namespace Krisiun_Project.janela_principal
{
    partial class Form2
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
            this.frente_checkbox = new System.Windows.Forms.CheckBox();
            this.tras_checkbox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // frente_checkbox
            // 
            this.frente_checkbox.AutoSize = true;
            this.frente_checkbox.Location = new System.Drawing.Point(29, 38);
            this.frente_checkbox.Name = "frente_checkbox";
            this.frente_checkbox.Size = new System.Drawing.Size(36, 16);
            this.frente_checkbox.TabIndex = 0;
            this.frente_checkbox.Text = "表";
            this.frente_checkbox.UseVisualStyleBackColor = true;
            this.frente_checkbox.CheckedChanged += new System.EventHandler(this.frente_checkbox_CheckedChanged);
            // 
            // tras_checkbox
            // 
            this.tras_checkbox.AutoSize = true;
            this.tras_checkbox.Location = new System.Drawing.Point(71, 38);
            this.tras_checkbox.Name = "tras_checkbox";
            this.tras_checkbox.Size = new System.Drawing.Size(36, 16);
            this.tras_checkbox.TabIndex = 1;
            this.tras_checkbox.Text = "裏";
            this.tras_checkbox.UseVisualStyleBackColor = true;
            this.tras_checkbox.CheckedChanged += new System.EventHandler(this.tras_checkbox_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 5;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(176, 237);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tras_checkbox);
            this.Controls.Add(this.frente_checkbox);
            this.Name = "Form2";
            this.Text = "Add";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox frente_checkbox;
        private System.Windows.Forms.CheckBox tras_checkbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}