﻿namespace Test1.UserForms
{
    partial class CreateStock
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Subbut = new System.Windows.Forms.Button();
            this.nament = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.stockent = new System.Windows.Forms.NumericUpDown();
            this.Pricent = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.stockent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pricent)).BeginInit();
            this.SuspendLayout();
            // 
            // Subbut
            // 
            this.Subbut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Subbut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Subbut.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Subbut.Location = new System.Drawing.Point(456, 295);
            this.Subbut.Name = "Subbut";
            this.Subbut.Size = new System.Drawing.Size(172, 68);
            this.Subbut.TabIndex = 28;
            this.Subbut.Text = "Submit!";
            this.Subbut.UseVisualStyleBackColor = false;
            this.Subbut.Click += new System.EventHandler(this.Subbut_Click);
            // 
            // nament
            // 
            this.nament.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nament.Location = new System.Drawing.Point(456, 91);
            this.nament.Name = "nament";
            this.nament.Size = new System.Drawing.Size(252, 22);
            this.nament.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(172, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(262, 23);
            this.label8.TabIndex = 24;
            this.label8.Text = "No. Of Units to stock";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(256, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 23);
            this.label5.TabIndex = 23;
            this.label5.Text = "Price per unit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(376, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 23);
            this.label4.TabIndex = 22;
            this.label4.Text = "Name";
            // 
            // stockent
            // 
            this.stockent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.stockent.Location = new System.Drawing.Point(456, 222);
            this.stockent.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.stockent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stockent.Name = "stockent";
            this.stockent.Size = new System.Drawing.Size(172, 22);
            this.stockent.TabIndex = 29;
            this.stockent.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Pricent
            // 
            this.Pricent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Pricent.Location = new System.Drawing.Point(456, 159);
            this.Pricent.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.Pricent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Pricent.Name = "Pricent";
            this.Pricent.Size = new System.Drawing.Size(172, 22);
            this.Pricent.TabIndex = 30;
            this.Pricent.ThousandsSeparator = true;
            this.Pricent.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CreateStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Pricent);
            this.Controls.Add(this.stockent);
            this.Controls.Add(this.Subbut);
            this.Controls.Add(this.nament);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "CreateStock";
            this.Size = new System.Drawing.Size(1042, 496);
            this.Load += new System.EventHandler(this.Create_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stockent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pricent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Subbut;
        private System.Windows.Forms.TextBox nament;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown stockent;
        private System.Windows.Forms.NumericUpDown Pricent;
    }
}
