namespace MainFormDownForm
{
    partial class MainFormDownForm
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
            this.UpTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.FriendGroupBox = new System.Windows.Forms.Button();
            this.MessageGroupBox = new System.Windows.Forms.Button();
            this.DownPanel = new System.Windows.Forms.Panel();
            this.groupShowPanel = new System.Windows.Forms.Panel();
            this.UpTableLayout.SuspendLayout();
            this.groupShowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UpTableLayout
            // 
            this.UpTableLayout.BackColor = System.Drawing.Color.Transparent;
            this.UpTableLayout.ColumnCount = 2;
            this.UpTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.UpTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.UpTableLayout.Controls.Add(this.FriendGroupBox, 1, 0);
            this.UpTableLayout.Controls.Add(this.MessageGroupBox, 0, 0);
            this.UpTableLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.UpTableLayout.Location = new System.Drawing.Point(0, 0);
            this.UpTableLayout.Margin = new System.Windows.Forms.Padding(4);
            this.UpTableLayout.Name = "UpTableLayout";
            this.UpTableLayout.RowCount = 1;
            this.UpTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.UpTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.UpTableLayout.Size = new System.Drawing.Size(344, 50);
            this.UpTableLayout.TabIndex = 0;
            // 
            // FriendGroupBox
            // 
            this.FriendGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.FriendGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FriendGroupBox.FlatAppearance.BorderSize = 0;
            this.FriendGroupBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.FriendGroupBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.FriendGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FriendGroupBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FriendGroupBox.Location = new System.Drawing.Point(172, 0);
            this.FriendGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.FriendGroupBox.Name = "FriendGroupBox";
            this.FriendGroupBox.Size = new System.Drawing.Size(172, 50);
            this.FriendGroupBox.TabIndex = 1;
            this.FriendGroupBox.Text = "联系人";
            this.FriendGroupBox.UseVisualStyleBackColor = false;
            this.FriendGroupBox.Click += new System.EventHandler(this.FriendGroupBox_Click);
            this.FriendGroupBox.MouseLeave += new System.EventHandler(this.GroupBox_MouseLeave);
            this.FriendGroupBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GroupBox_MouseMove);
            // 
            // MessageGroupBox
            // 
            this.MessageGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.MessageGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageGroupBox.FlatAppearance.BorderSize = 0;
            this.MessageGroupBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.MessageGroupBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.MessageGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MessageGroupBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MessageGroupBox.Location = new System.Drawing.Point(0, 0);
            this.MessageGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.MessageGroupBox.Name = "MessageGroupBox";
            this.MessageGroupBox.Size = new System.Drawing.Size(172, 50);
            this.MessageGroupBox.TabIndex = 0;
            this.MessageGroupBox.Text = "消息";
            this.MessageGroupBox.UseVisualStyleBackColor = false;
            this.MessageGroupBox.Click += new System.EventHandler(this.MessageGroupBox_Click);
            this.MessageGroupBox.MouseLeave += new System.EventHandler(this.GroupBox_MouseLeave);
            this.MessageGroupBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GroupBox_MouseMove);
            // 
            // DownPanel
            // 
            this.DownPanel.AutoScroll = true;
            this.DownPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DownPanel.Location = new System.Drawing.Point(0, 50);
            this.DownPanel.Margin = new System.Windows.Forms.Padding(0);
            this.DownPanel.Name = "DownPanel";
            this.DownPanel.Size = new System.Drawing.Size(344, 471);
            this.DownPanel.TabIndex = 1;
            // 
            // groupShowPanel
            // 
            this.groupShowPanel.BackColor = System.Drawing.Color.Transparent;
            this.groupShowPanel.Controls.Add(this.DownPanel);
            this.groupShowPanel.Controls.Add(this.UpTableLayout);
            this.groupShowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupShowPanel.Location = new System.Drawing.Point(0, 0);
            this.groupShowPanel.Name = "groupShowPanel";
            this.groupShowPanel.Size = new System.Drawing.Size(344, 521);
            this.groupShowPanel.TabIndex = 0;
            // 
            // MainFormDownForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupShowPanel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainFormDownForm";
            this.Size = new System.Drawing.Size(344, 521);
            this.UpTableLayout.ResumeLayout(false);
            this.groupShowPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel UpTableLayout;
        public System.Windows.Forms.Button FriendGroupBox;
        public System.Windows.Forms.Button MessageGroupBox;
        public System.Windows.Forms.Panel DownPanel;
    }
}
