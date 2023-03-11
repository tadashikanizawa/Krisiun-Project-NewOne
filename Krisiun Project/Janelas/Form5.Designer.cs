namespace Krisiun_Project.Janelas
{
    partial class Form5
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
            this.ura_radio = new System.Windows.Forms.RadioButton();
            this.omote_radio = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.zuban_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.himen_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ura_radio
            // 
            this.ura_radio.AutoSize = true;
            this.ura_radio.Location = new System.Drawing.Point(115, 131);
            this.ura_radio.Name = "ura_radio";
            this.ura_radio.Size = new System.Drawing.Size(47, 16);
            this.ura_radio.TabIndex = 0;
            this.ura_radio.TabStop = true;
            this.ura_radio.Text = "裏面";
            this.ura_radio.UseVisualStyleBackColor = true;
            this.ura_radio.CheckedChanged += new System.EventHandler(this.ura_radio_CheckedChanged);
            // 
            // omote_radio
            // 
            this.omote_radio.AutoSize = true;
            this.omote_radio.Location = new System.Drawing.Point(62, 131);
            this.omote_radio.Name = "omote_radio";
            this.omote_radio.Size = new System.Drawing.Size(47, 16);
            this.omote_radio.TabIndex = 1;
            this.omote_radio.TabStop = true;
            this.omote_radio.Text = "表面";
            this.omote_radio.UseVisualStyleBackColor = true;
            this.omote_radio.CheckedChanged += new System.EventHandler(this.omote_radio_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(62, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 54);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 37;
            this.label2.Text = "図番";
            // 
            // zuban_tb
            // 
            this.zuban_tb.Location = new System.Drawing.Point(14, 65);
            this.zuban_tb.Name = "zuban_tb";
            this.zuban_tb.Size = new System.Drawing.Size(206, 19);
            this.zuban_tb.TabIndex = 36;
            this.zuban_tb.TextChanged += new System.EventHandler(this.zuban_tb_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 35;
            this.label1.Text = "品名";
            // 
            // himen_tb
            // 
            this.himen_tb.Location = new System.Drawing.Point(14, 27);
            this.himen_tb.Name = "himen_tb";
            this.himen_tb.Size = new System.Drawing.Size(206, 19);
            this.himen_tb.TabIndex = 34;
            this.himen_tb.TextChanged += new System.EventHandler(this.himen_tb_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(14, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 16);
            this.label3.TabIndex = 38;
            this.label3.Text = "どちらから加工をするですか？";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(232, 235);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.zuban_tb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.himen_tb);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.omote_radio);
            this.Controls.Add(this.ura_radio);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton ura_radio;
        private System.Windows.Forms.RadioButton omote_radio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox zuban_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox himen_tb;
        private System.Windows.Forms.Label label3;
    }
}