namespace ShowNews
{
    partial class ShowNewsOfYou
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
            this.spacePanel = new System.Windows.Forms.Panel();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.userImagePictureBox = new System.Windows.Forms.PictureBox();
            this.newsPanel = new System.Windows.Forms.Panel();
            this.newsLabel = new System.Windows.Forms.Label();
            this.dateTimePanel = new System.Windows.Forms.Panel();
            this.datetimeLabel = new System.Windows.Forms.Label();
            this.middlePanel = new System.Windows.Forms.Panel();
            this.downPanel = new System.Windows.Forms.Panel();
            this.picturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userImagePictureBox)).BeginInit();
            this.newsPanel.SuspendLayout();
            this.dateTimePanel.SuspendLayout();
            this.middlePanel.SuspendLayout();
            this.downPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // spacePanel
            // 
            this.spacePanel.AutoSize = true;
            this.spacePanel.BackColor = System.Drawing.Color.Transparent;
            this.spacePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spacePanel.Location = new System.Drawing.Point(97, 0);
            this.spacePanel.Name = "spacePanel";
            this.spacePanel.Size = new System.Drawing.Size(477, 55);
            this.spacePanel.TabIndex = 0;
            // 
            // picturePanel
            // 
            this.picturePanel.AutoSize = true;
            this.picturePanel.BackColor = System.Drawing.Color.Transparent;
            this.picturePanel.Controls.Add(this.userImagePictureBox);
            this.picturePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.picturePanel.Location = new System.Drawing.Point(0, 0);
            this.picturePanel.MinimumSize = new System.Drawing.Size(77, 50);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Padding = new System.Windows.Forms.Padding(19, 0, 19, 0);
            this.picturePanel.Size = new System.Drawing.Size(77, 55);
            this.picturePanel.TabIndex = 8;
            // 
            // userImagePictureBox
            // 
            this.userImagePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.userImagePictureBox.BackgroundImage = global::ShowNews.Properties.Resources.image;
            this.userImagePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.userImagePictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.userImagePictureBox.Location = new System.Drawing.Point(19, 0);
            this.userImagePictureBox.Name = "userImagePictureBox";
            this.userImagePictureBox.Size = new System.Drawing.Size(39, 41);
            this.userImagePictureBox.TabIndex = 0;
            this.userImagePictureBox.TabStop = false;
            // 
            // newsPanel
            // 
            this.newsPanel.AutoSize = true;
            this.newsPanel.BackColor = System.Drawing.Color.Transparent;
            this.newsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.newsPanel.Controls.Add(this.newsLabel);
            this.newsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newsPanel.Location = new System.Drawing.Point(0, 0);
            this.newsPanel.MaximumSize = new System.Drawing.Size(525, 0);
            this.newsPanel.Name = "newsPanel";
            this.newsPanel.Padding = new System.Windows.Forms.Padding(10, 12, 10, 10);
            this.newsPanel.Size = new System.Drawing.Size(20, 55);
            this.newsPanel.TabIndex = 3;
            // 
            // newsLabel
            // 
            this.newsLabel.AutoSize = true;
            this.newsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newsLabel.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newsLabel.ForeColor = System.Drawing.Color.White;
            this.newsLabel.Location = new System.Drawing.Point(10, 12);
            this.newsLabel.MaximumSize = new System.Drawing.Size(400, 0);
            this.newsLabel.Name = "newsLabel";
            this.newsLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.newsLabel.Size = new System.Drawing.Size(0, 25);
            this.newsLabel.TabIndex = 0;
            // 
            // dateTimePanel
            // 
            this.dateTimePanel.BackColor = System.Drawing.Color.Transparent;
            this.dateTimePanel.Controls.Add(this.datetimeLabel);
            this.dateTimePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.dateTimePanel.Location = new System.Drawing.Point(0, 0);
            this.dateTimePanel.Name = "dateTimePanel";
            this.dateTimePanel.Size = new System.Drawing.Size(574, 28);
            this.dateTimePanel.TabIndex = 7;
            // 
            // datetimeLabel
            // 
            this.datetimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.datetimeLabel.AutoSize = true;
            this.datetimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.datetimeLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.datetimeLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.datetimeLabel.Location = new System.Drawing.Point(212, 1);
            this.datetimeLabel.Name = "datetimeLabel";
            this.datetimeLabel.Size = new System.Drawing.Size(159, 20);
            this.datetimeLabel.TabIndex = 0;
            this.datetimeLabel.Text = "2018-05-03 18:06:52";
            // 
            // middlePanel
            // 
            this.middlePanel.AutoSize = true;
            this.middlePanel.Controls.Add(this.newsPanel);
            this.middlePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.middlePanel.Location = new System.Drawing.Point(77, 0);
            this.middlePanel.Name = "middlePanel";
            this.middlePanel.Size = new System.Drawing.Size(20, 55);
            this.middlePanel.TabIndex = 10;
            // 
            // downPanel
            // 
            this.downPanel.Controls.Add(this.spacePanel);
            this.downPanel.Controls.Add(this.middlePanel);
            this.downPanel.Controls.Add(this.picturePanel);
            this.downPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downPanel.Location = new System.Drawing.Point(0, 28);
            this.downPanel.Name = "downPanel";
            this.downPanel.Size = new System.Drawing.Size(574, 55);
            this.downPanel.TabIndex = 0;
            // 
            // ShowNewsOfYou
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.downPanel);
            this.Controls.Add(this.dateTimePanel);
            this.MinimumSize = new System.Drawing.Size(0, 75);
            this.Name = "ShowNewsOfYou";
            this.Size = new System.Drawing.Size(574, 83);
            this.picturePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userImagePictureBox)).EndInit();
            this.newsPanel.ResumeLayout(false);
            this.newsPanel.PerformLayout();
            this.dateTimePanel.ResumeLayout(false);
            this.dateTimePanel.PerformLayout();
            this.middlePanel.ResumeLayout(false);
            this.middlePanel.PerformLayout();
            this.downPanel.ResumeLayout(false);
            this.downPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel spacePanel;
        private System.Windows.Forms.Panel picturePanel;
        private System.Windows.Forms.PictureBox userImagePictureBox;
        private System.Windows.Forms.Panel newsPanel;
        private System.Windows.Forms.Label newsLabel;
        private System.Windows.Forms.Panel dateTimePanel;
        private System.Windows.Forms.Label datetimeLabel;
        private System.Windows.Forms.Panel middlePanel;
        private System.Windows.Forms.Panel downPanel;
    }
}
