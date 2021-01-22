namespace AnimatedAvatar
{
    partial class MainForm
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
            this.AnimationPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.AnimationPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AnimationPictureBox
            // 
            this.AnimationPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.AnimationPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnimationPictureBox.Location = new System.Drawing.Point(0, 0);
            this.AnimationPictureBox.Name = "AnimationPictureBox";
            this.AnimationPictureBox.Size = new System.Drawing.Size(512, 512);
            this.AnimationPictureBox.TabIndex = 0;
            this.AnimationPictureBox.TabStop = false;
            this.AnimationPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.AnimationPictureBox_Paint);
            this.AnimationPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AnimationPictureBox_MouseDown);
            this.AnimationPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AnimationPictureBox_MouseMove);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 512);
            this.Controls.Add(this.AnimationPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.AnimationPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox AnimationPictureBox;
    }
}