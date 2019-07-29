namespace Final_Project
{
    partial class Form1
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
            this.InputPicture = new System.Windows.Forms.PictureBox();
            this.OutputPicture = new System.Windows.Forms.PictureBox();
            this.SelectBT = new System.Windows.Forms.Button();
            this.RotateBT = new System.Windows.Forms.Button();
            this.SobelBT = new System.Windows.Forms.Button();
            this.MSSVLB = new System.Windows.Forms.Label();
            this.SegmenImage = new System.Windows.Forms.PictureBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.InputPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SegmenImage)).BeginInit();
            this.SuspendLayout();
            // 
            // InputPicture
            // 
            this.InputPicture.Location = new System.Drawing.Point(480, 12);
            this.InputPicture.Name = "InputPicture";
            this.InputPicture.Size = new System.Drawing.Size(441, 401);
            this.InputPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.InputPicture.TabIndex = 9;
            this.InputPicture.TabStop = false;
            this.InputPicture.Click += new System.EventHandler(this.InputPicture_Click);
            // 
            // OutputPicture
            // 
            this.OutputPicture.Location = new System.Drawing.Point(480, 441);
            this.OutputPicture.Name = "OutputPicture";
            this.OutputPicture.Size = new System.Drawing.Size(441, 401);
            this.OutputPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OutputPicture.TabIndex = 10;
            this.OutputPicture.TabStop = false;
            // 
            // SelectBT
            // 
            this.SelectBT.Location = new System.Drawing.Point(52, 142);
            this.SelectBT.Name = "SelectBT";
            this.SelectBT.Size = new System.Drawing.Size(169, 23);
            this.SelectBT.TabIndex = 12;
            this.SelectBT.Text = "Select image";
            this.SelectBT.UseVisualStyleBackColor = true;
            this.SelectBT.Click += new System.EventHandler(this.SelectBT_Click);
            // 
            // RotateBT
            // 
            this.RotateBT.Location = new System.Drawing.Point(284, 142);
            this.RotateBT.Name = "RotateBT";
            this.RotateBT.Size = new System.Drawing.Size(129, 23);
            this.RotateBT.TabIndex = 13;
            this.RotateBT.Text = "Rotate Image";
            this.RotateBT.UseVisualStyleBackColor = true;
            this.RotateBT.Click += new System.EventHandler(this.RotateBT_Click);
            // 
            // SobelBT
            // 
            this.SobelBT.Location = new System.Drawing.Point(146, 206);
            this.SobelBT.Name = "SobelBT";
            this.SobelBT.Size = new System.Drawing.Size(194, 56);
            this.SobelBT.TabIndex = 15;
            this.SobelBT.Text = "Find";
            this.SobelBT.UseVisualStyleBackColor = true;
            this.SobelBT.Click += new System.EventHandler(this.SobelBT_Click);
            // 
            // MSSVLB
            // 
            this.MSSVLB.AutoSize = true;
            this.MSSVLB.Location = new System.Drawing.Point(122, 441);
            this.MSSVLB.Name = "MSSVLB";
            this.MSSVLB.Size = new System.Drawing.Size(54, 17);
            this.MSSVLB.TabIndex = 16;
            this.MSSVLB.Text = "MSSV :";
            // 
            // SegmenImage
            // 
            this.SegmenImage.Location = new System.Drawing.Point(157, 354);
            this.SegmenImage.Name = "SegmenImage";
            this.SegmenImage.Size = new System.Drawing.Size(173, 59);
            this.SegmenImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SegmenImage.TabIndex = 20;
            this.SegmenImage.TabStop = false;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(198, 441);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(155, 22);
            this.txtResult.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(148, 793);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 35);
            this.button1.TabIndex = 26;
            this.button1.Text = "Kết thúc mô phỏng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 883);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.SegmenImage);
            this.Controls.Add(this.MSSVLB);
            this.Controls.Add(this.SobelBT);
            this.Controls.Add(this.RotateBT);
            this.Controls.Add(this.SelectBT);
            this.Controls.Add(this.OutputPicture);
            this.Controls.Add(this.InputPicture);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.InputPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SegmenImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox InputPicture;
        private System.Windows.Forms.PictureBox OutputPicture;
        private System.Windows.Forms.Button SelectBT;
        private System.Windows.Forms.Button RotateBT;
        private System.Windows.Forms.Button SobelBT;
        private System.Windows.Forms.Label MSSVLB;
        private System.Windows.Forms.PictureBox SegmenImage;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button button1;
    }
}

