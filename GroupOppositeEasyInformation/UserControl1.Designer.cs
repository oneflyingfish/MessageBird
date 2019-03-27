namespace GroupOppositeEasyInformation
{
    partial class GroupOppositeEasyInformation
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
            this.ImagePictureBox = new System.Windows.Forms.PictureBox();
            this.AccountLabel = new System.Windows.Forms.Label();
            this.UserNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ImagePictureBox
            // 
            this.ImagePictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ImagePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.ImagePictureBox.BackgroundImage = global::GroupOppositeEasyInformation.Properties.Resources.image;
            this.ImagePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImagePictureBox.Location = new System.Drawing.Point(65, 15);
            this.ImagePictureBox.Name = "ImagePictureBox";
            this.ImagePictureBox.Size = new System.Drawing.Size(70, 70);
            this.ImagePictureBox.TabIndex = 0;
            this.ImagePictureBox.TabStop = false;
            // 
            // AccountLabel
            // 
            this.AccountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AccountLabel.AutoSize = true;
            this.AccountLabel.BackColor = System.Drawing.Color.Transparent;
            this.AccountLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AccountLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AccountLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.AccountLabel.Location = new System.Drawing.Point(21, 129);
            this.AccountLabel.Name = "AccountLabel";
            this.AccountLabel.Size = new System.Drawing.Size(28, 20);
            this.AccountLabel.TabIndex = 1;
            this.AccountLabel.Text = "ID:";
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.UserNameLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserNameLabel.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserNameLabel.Location = new System.Drawing.Point(21, 95);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(69, 25);
            this.UserNameLabel.TabIndex = 2;
            this.UserNameLabel.Text = "昵称：";
            // 
            // GroupOppositeEasyInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.AccountLabel);
            this.Controls.Add(this.ImagePictureBox);
            this.Name = "GroupOppositeEasyInformation";
            this.Size = new System.Drawing.Size(200, 162);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ImagePictureBox;
        private System.Windows.Forms.Label AccountLabel;
        private System.Windows.Forms.Label UserNameLabel;
    }
}
