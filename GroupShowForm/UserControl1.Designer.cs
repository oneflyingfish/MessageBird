namespace GroupShowForm
{
    partial class GroupShowForm
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
            this.components = new System.ComponentModel.Container();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.MouseRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToUpItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupImagePictureBox = new System.Windows.Forms.PictureBox();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.NumberPanel = new System.Windows.Forms.Panel();
            this.GroupNumberLabel = new System.Windows.Forms.Label();
            this.GroupTimeLabel = new System.Windows.Forms.Label();
            this.GroupAccountLabel = new System.Windows.Forms.Label();
            this.GroupNameLabel = new System.Windows.Forms.Label();
            this.LeftPanel.SuspendLayout();
            this.MouseRightClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupImagePictureBox)).BeginInit();
            this.RightPanel.SuspendLayout();
            this.NumberPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.Color.Transparent;
            this.LeftPanel.ContextMenuStrip = this.MouseRightClick;
            this.LeftPanel.Controls.Add(this.GroupImagePictureBox);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Padding = new System.Windows.Forms.Padding(15);
            this.LeftPanel.Size = new System.Drawing.Size(83, 83);
            this.LeftPanel.TabIndex = 2;
            // 
            // MouseRightClick
            // 
            this.MouseRightClick.BackColor = System.Drawing.Color.Transparent;
            this.MouseRightClick.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MouseRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open,
            this.toolStripSeparator1,
            this.ToUpItem});
            this.MouseRightClick.Name = "MouseRightClick";
            this.MouseRightClick.Size = new System.Drawing.Size(197, 58);
            // 
            // Open
            // 
            this.Open.Name = "Open";
            this.Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.Open.Size = new System.Drawing.Size(196, 24);
            this.Open.Text = "打开会话";
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // ToUpItem
            // 
            this.ToUpItem.Name = "ToUpItem";
            this.ToUpItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Up)));
            this.ToUpItem.Size = new System.Drawing.Size(196, 24);
            this.ToUpItem.Text = "置顶";
            // 
            // GroupImagePictureBox
            // 
            this.GroupImagePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.GroupImagePictureBox.BackgroundImage = global::GroupShowForm.Properties.Resources.image1;
            this.GroupImagePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GroupImagePictureBox.ContextMenuStrip = this.MouseRightClick;
            this.GroupImagePictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.GroupImagePictureBox.Location = new System.Drawing.Point(15, 15);
            this.GroupImagePictureBox.Name = "GroupImagePictureBox";
            this.GroupImagePictureBox.Size = new System.Drawing.Size(53, 53);
            this.GroupImagePictureBox.TabIndex = 0;
            this.GroupImagePictureBox.TabStop = false;
            // 
            // RightPanel
            // 
            this.RightPanel.AutoSize = true;
            this.RightPanel.BackColor = System.Drawing.Color.Transparent;
            this.RightPanel.ContextMenuStrip = this.MouseRightClick;
            this.RightPanel.Controls.Add(this.NumberPanel);
            this.RightPanel.Controls.Add(this.GroupTimeLabel);
            this.RightPanel.Controls.Add(this.GroupAccountLabel);
            this.RightPanel.Controls.Add(this.GroupNameLabel);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPanel.Location = new System.Drawing.Point(83, 0);
            this.RightPanel.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Padding = new System.Windows.Forms.Padding(5, 10, 10, 10);
            this.RightPanel.Size = new System.Drawing.Size(331, 83);
            this.RightPanel.TabIndex = 4;
            // 
            // NumberPanel
            // 
            this.NumberPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NumberPanel.Controls.Add(this.GroupNumberLabel);
            this.NumberPanel.Location = new System.Drawing.Point(289, 35);
            this.NumberPanel.Name = "NumberPanel";
            this.NumberPanel.Padding = new System.Windows.Forms.Padding(1);
            this.NumberPanel.Size = new System.Drawing.Size(29, 22);
            this.NumberPanel.TabIndex = 4;
            // 
            // GroupNumberLabel
            // 
            this.GroupNumberLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupNumberLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GroupNumberLabel.ForeColor = System.Drawing.Color.White;
            this.GroupNumberLabel.Location = new System.Drawing.Point(1, 1);
            this.GroupNumberLabel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.GroupNumberLabel.Name = "GroupNumberLabel";
            this.GroupNumberLabel.Size = new System.Drawing.Size(27, 20);
            this.GroupNumberLabel.TabIndex = 3;
            this.GroupNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupTimeLabel
            // 
            this.GroupTimeLabel.AutoSize = true;
            this.GroupTimeLabel.ContextMenuStrip = this.MouseRightClick;
            this.GroupTimeLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.GroupTimeLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GroupTimeLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.GroupTimeLabel.Location = new System.Drawing.Point(321, 10);
            this.GroupTimeLabel.Name = "GroupTimeLabel";
            this.GroupTimeLabel.Size = new System.Drawing.Size(0, 20);
            this.GroupTimeLabel.TabIndex = 2;
            // 
            // GroupAccountLabel
            // 
            this.GroupAccountLabel.BackColor = System.Drawing.Color.Transparent;
            this.GroupAccountLabel.ContextMenuStrip = this.MouseRightClick;
            this.GroupAccountLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GroupAccountLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GroupAccountLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.GroupAccountLabel.Location = new System.Drawing.Point(5, 53);
            this.GroupAccountLabel.Name = "GroupAccountLabel";
            this.GroupAccountLabel.Size = new System.Drawing.Size(316, 20);
            this.GroupAccountLabel.TabIndex = 1;
            this.GroupAccountLabel.Text = "账户尚未加载出来";
            // 
            // GroupNameLabel
            // 
            this.GroupNameLabel.AutoSize = true;
            this.GroupNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.GroupNameLabel.ContextMenuStrip = this.MouseRightClick;
            this.GroupNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupNameLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GroupNameLabel.ForeColor = System.Drawing.Color.Salmon;
            this.GroupNameLabel.Location = new System.Drawing.Point(5, 10);
            this.GroupNameLabel.Name = "GroupNameLabel";
            this.GroupNameLabel.Size = new System.Drawing.Size(161, 27);
            this.GroupNameLabel.TabIndex = 0;
            this.GroupNameLabel.Text = "这是一个好友/群";
            // 
            // GroupShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ContextMenuStrip = this.MouseRightClick;
            this.Controls.Add(this.RightPanel);
            this.Controls.Add(this.LeftPanel);
            this.Name = "GroupShowForm";
            this.Size = new System.Drawing.Size(414, 83);
            this.DoubleClick += new System.EventHandler(this.GroupShowForm_DoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GroupShowForm_KeyDown);
            this.MouseEnter += new System.EventHandler(this.GroupShowForm_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.GroupShowForm_MouseLeave);
            this.LeftPanel.ResumeLayout(false);
            this.MouseRightClick.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupImagePictureBox)).EndInit();
            this.RightPanel.ResumeLayout(false);
            this.RightPanel.PerformLayout();
            this.NumberPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel LeftPanel;
        public System.Windows.Forms.PictureBox GroupImagePictureBox;
        public System.Windows.Forms.Panel RightPanel;
        public System.Windows.Forms.Label GroupAccountLabel;
        public System.Windows.Forms.Label GroupNameLabel;
        public System.Windows.Forms.Label GroupTimeLabel;
        public System.Windows.Forms.Label GroupNumberLabel;
        public System.Windows.Forms.ToolStripMenuItem ToUpItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripMenuItem Open;
        private System.Windows.Forms.Panel NumberPanel;
        public System.Windows.Forms.ContextMenuStrip MouseRightClick;
    }
}
