namespace MessageBird
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.SoftwareConfigButton = new System.Windows.Forms.Button();
            this.DownForm = new MainFormDownForm.MainFormDownForm();
            this.BottomRightIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.UpForm = new MainFormUpForm.MainFormUpForm();
            this.DownFormPanel = new System.Windows.Forms.Panel();
            this.BottomPanel.SuspendLayout();
            this.DownFormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.White;
            this.BottomPanel.Controls.Add(this.SoftwareConfigButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 798);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.BottomPanel.Size = new System.Drawing.Size(348, 40);
            this.BottomPanel.TabIndex = 2;
            // 
            // SoftwareConfigButton
            // 
            this.SoftwareConfigButton.BackColor = System.Drawing.Color.Transparent;
            this.SoftwareConfigButton.BackgroundImage = global::信鸽.Properties.Resources.添加好友__1_1;
            this.SoftwareConfigButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SoftwareConfigButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.SoftwareConfigButton.FlatAppearance.BorderSize = 0;
            this.SoftwareConfigButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SoftwareConfigButton.Location = new System.Drawing.Point(10, 5);
            this.SoftwareConfigButton.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.SoftwareConfigButton.Name = "SoftwareConfigButton";
            this.SoftwareConfigButton.Size = new System.Drawing.Size(30, 30);
            this.SoftwareConfigButton.TabIndex = 0;
            this.SoftwareConfigButton.UseVisualStyleBackColor = false;
            this.SoftwareConfigButton.Click += new System.EventHandler(this.SoftwareConfigButton_Click);
            // 
            // DownForm
            // 
            this.DownForm.BackColor = System.Drawing.Color.Transparent;
            this.DownForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DownForm.Location = new System.Drawing.Point(0, 0);
            this.DownForm.Margin = new System.Windows.Forms.Padding(4);
            this.DownForm.Name = "DownForm";
            this.DownForm.Size = new System.Drawing.Size(348, 623);
            this.DownForm.TabIndex = 1;
            // 
            // BottomRightIcon
            // 
            this.BottomRightIcon.Text = "信鸽";
            // 
            // UpForm
            // 
            this.UpForm.BackColor = System.Drawing.Color.White;
            this.UpForm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UpForm.BackgroundImage")));
            this.UpForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UpForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.UpForm.Location = new System.Drawing.Point(0, 0);
            this.UpForm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UpForm.Name = "UpForm";
            this.UpForm.Size = new System.Drawing.Size(348, 175);
            this.UpForm.TabIndex = 0;
            // 
            // DownFormPanel
            // 
            this.DownFormPanel.BackColor = System.Drawing.Color.Transparent;
            this.DownFormPanel.Controls.Add(this.DownForm);
            this.DownFormPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DownFormPanel.Location = new System.Drawing.Point(0, 175);
            this.DownFormPanel.Margin = new System.Windows.Forms.Padding(0);
            this.DownFormPanel.Name = "DownFormPanel";
            this.DownFormPanel.Size = new System.Drawing.Size(348, 623);
            this.DownFormPanel.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(348, 838);
            this.Controls.Add(this.DownFormPanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.UpForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "信鸽";
            this.BottomPanel.ResumeLayout(false);
            this.DownFormPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        public MainFormUpForm.MainFormUpForm UpForm;
        public MainFormDownForm.MainFormDownForm DownForm;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button SoftwareConfigButton;
        private System.Windows.Forms.NotifyIcon BottomRightIcon;
        private System.Windows.Forms.Panel DownFormPanel;
    }
}

