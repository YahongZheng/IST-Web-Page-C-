namespace P3starter
{
    partial class People_Box
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
            this.gb_peo = new System.Windows.Forms.GroupBox();
            this.pictureBox_peo = new System.Windows.Forms.PictureBox();
            this.rtb_peo = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_peo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_peo)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_peo
            // 
            this.gb_peo.Controls.Add(this.pictureBox_peo);
            this.gb_peo.Controls.Add(this.rtb_peo);
            this.gb_peo.Location = new System.Drawing.Point(49, 43);
            this.gb_peo.Name = "gb_peo";
            this.gb_peo.Size = new System.Drawing.Size(430, 205);
            this.gb_peo.TabIndex = 0;
            this.gb_peo.TabStop = false;
            this.gb_peo.Text = "Our People";
            // 
            // pictureBox_peo
            // 
            this.pictureBox_peo.Location = new System.Drawing.Point(16, 20);
            this.pictureBox_peo.Name = "pictureBox_peo";
            this.pictureBox_peo.Size = new System.Drawing.Size(161, 153);
            this.pictureBox_peo.TabIndex = 1;
            this.pictureBox_peo.TabStop = false;
            // 
            // rtb_peo
            // 
            this.rtb_peo.Location = new System.Drawing.Point(246, 20);
            this.rtb_peo.Name = "rtb_peo";
            this.rtb_peo.Size = new System.Drawing.Size(161, 153);
            this.rtb_peo.TabIndex = 0;
            this.rtb_peo.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(201, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Our People";
            // 
            // People_Box
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 293);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gb_peo);
            this.Name = "People_Box";
            this.Text = "People_Box";
            this.gb_peo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_peo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_peo;
        private System.Windows.Forms.PictureBox pictureBox_peo;
        private System.Windows.Forms.RichTextBox rtb_peo;
        private System.Windows.Forms.Label label1;
    }
}