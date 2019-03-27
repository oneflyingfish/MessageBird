namespace ConnectTabForm
{
    partial class ConnectTabForm
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
            this.TabForm = new System.Windows.Forms.TabControl();
            this.FriendTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GroupTab = new System.Windows.Forms.TabPage();
            this.TabForm.SuspendLayout();
            this.FriendTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabForm
            // 
            this.TabForm.Controls.Add(this.FriendTab);
            this.TabForm.Controls.Add(this.GroupTab);
            this.TabForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabForm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TabForm.Location = new System.Drawing.Point(0, 0);
            this.TabForm.Margin = new System.Windows.Forms.Padding(0);
            this.TabForm.Name = "TabForm";
            this.TabForm.SelectedIndex = 0;
            this.TabForm.Size = new System.Drawing.Size(347, 512);
            this.TabForm.TabIndex = 0;
            // 
            // FriendTab
            // 
            this.FriendTab.AutoScroll = true;
            this.FriendTab.Controls.Add(this.panel1);
            this.FriendTab.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FriendTab.ForeColor = System.Drawing.Color.Black;
            this.FriendTab.Location = new System.Drawing.Point(4, 36);
            this.FriendTab.Margin = new System.Windows.Forms.Padding(0);
            this.FriendTab.Name = "FriendTab";
            this.FriendTab.Size = new System.Drawing.Size(339, 472);
            this.FriendTab.TabIndex = 0;
            this.FriendTab.Text = "好友";
            this.FriendTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 472);
            this.panel1.TabIndex = 0;
            // 
            // GroupTab
            // 
            this.GroupTab.AutoScroll = true;
            this.GroupTab.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GroupTab.Location = new System.Drawing.Point(4, 36);
            this.GroupTab.Name = "GroupTab";
            this.GroupTab.Size = new System.Drawing.Size(339, 472);
            this.GroupTab.TabIndex = 1;
            this.GroupTab.Text = "群聊";
            this.GroupTab.UseVisualStyleBackColor = true;
            // 
            // ConnectTabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.TabForm);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ConnectTabForm";
            this.Size = new System.Drawing.Size(347, 512);
            this.TabForm.ResumeLayout(false);
            this.FriendTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl TabForm;
        public System.Windows.Forms.TabPage FriendTab;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TabPage GroupTab;
    }
}
