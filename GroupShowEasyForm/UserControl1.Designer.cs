namespace GroupShowEasyForm
{
    partial class GroupShowEasyForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.ImagePictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UserNameLabel.AutoEllipsis = true;
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.UserNameLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserNameLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserNameLabel.Location = new System.Drawing.Point(57, 19);
            this.UserNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(0, 27);
            this.UserNameLabel.TabIndex = 1;
            this.UserNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ImagePictureBox
            // 
            this.ImagePictureBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ImagePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.ImagePictureBox.BackgroundImage = global::GroupShowEasyForm.Properties.Resources.image;
            this.ImagePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImagePictureBox.Location = new System.Drawing.Point(10, 13);
            this.ImagePictureBox.Name = "ImagePictureBox";
            this.ImagePictureBox.Size = new System.Drawing.Size(40, 40);
            this.ImagePictureBox.TabIndex = 0;
            this.ImagePictureBox.TabStop = false;
            // 
            // GroupShowEasyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.ImagePictureBox);
            this.Name = "GroupShowEasyForm";
            this.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.Size = new System.Drawing.Size(263, 67);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ImagePictureBox;
        private System.Windows.Forms.Label UserNameLabel;
    }
}
