using System;

namespace MessageBird
{
    partial class ChatForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.NewsEditRichTextBox = new System.Windows.Forms.RichTextBox();
            this.BottomButtonPanel = new System.Windows.Forms.Panel();
            this.BottomCloseButton = new System.Windows.Forms.Button();
            this.BottomSendButton = new System.Windows.Forms.Button();
            this.ButtonFunctionPanel = new System.Windows.Forms.Panel();
            this.historyDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.historyButton = new System.Windows.Forms.Button();
            this.TransportFileButton = new System.Windows.Forms.Button();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.RightBottomPanel = new System.Windows.Forms.Panel();
            this.groupMemberPanel = new System.Windows.Forms.Panel();
            this.groupShowMemberPanel = new System.Windows.Forms.Panel();
            this.viewGroupMemberButton = new System.Windows.Forms.Button();
            this.groupShowMemberLabel = new System.Windows.Forms.Label();
            this.fileTransportPanel = new System.Windows.Forms.Panel();
            this.RightTopForm = new GroupOppositeEasyInformation.GroupOppositeEasyInformation();
            this.MiddlePanel = new System.Windows.Forms.Panel();
            this.middleShowPanel = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.TopPanel = new System.Windows.Forms.Panel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.TopRightPanel = new System.Windows.Forms.Panel();
            this.MixButton = new System.Windows.Forms.Button();
            this.MaxButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.TopLeftPanel = new System.Windows.Forms.Panel();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.BottomPanel.SuspendLayout();
            this.BottomButtonPanel.SuspendLayout();
            this.ButtonFunctionPanel.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.RightBottomPanel.SuspendLayout();
            this.groupShowMemberPanel.SuspendLayout();
            this.MiddlePanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.TopRightPanel.SuspendLayout();
            this.TopLeftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftPanel
            // 
            this.LeftPanel.AutoScroll = true;
            this.LeftPanel.AutoScrollMargin = new System.Drawing.Size(2, 0);
            this.LeftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(173)))), ((int)(((byte)(243)))));
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 49);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.LeftPanel.Size = new System.Drawing.Size(199, 566);
            this.LeftPanel.TabIndex = 1;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.NewsEditRichTextBox);
            this.BottomPanel.Controls.Add(this.BottomButtonPanel);
            this.BottomPanel.Controls.Add(this.ButtonFunctionPanel);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(199, 455);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.BottomPanel.Size = new System.Drawing.Size(621, 160);
            this.BottomPanel.TabIndex = 3;
            // 
            // NewsEditRichTextBox
            // 
            this.NewsEditRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NewsEditRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewsEditRichTextBox.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NewsEditRichTextBox.Location = new System.Drawing.Point(0, 40);
            this.NewsEditRichTextBox.Name = "NewsEditRichTextBox";
            this.NewsEditRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.NewsEditRichTextBox.ShowSelectionMargin = true;
            this.NewsEditRichTextBox.Size = new System.Drawing.Size(621, 70);
            this.NewsEditRichTextBox.TabIndex = 1;
            this.NewsEditRichTextBox.Text = "";
            // 
            // BottomButtonPanel
            // 
            this.BottomButtonPanel.Controls.Add(this.BottomCloseButton);
            this.BottomButtonPanel.Controls.Add(this.BottomSendButton);
            this.BottomButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomButtonPanel.Location = new System.Drawing.Point(0, 110);
            this.BottomButtonPanel.Name = "BottomButtonPanel";
            this.BottomButtonPanel.Padding = new System.Windows.Forms.Padding(0, 1, 15, 1);
            this.BottomButtonPanel.Size = new System.Drawing.Size(621, 35);
            this.BottomButtonPanel.TabIndex = 1;
            // 
            // BottomCloseButton
            // 
            this.BottomCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BottomCloseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BottomCloseButton.BackColor = System.Drawing.Color.White;
            this.BottomCloseButton.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.BottomCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BottomCloseButton.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BottomCloseButton.Location = new System.Drawing.Point(400, 1);
            this.BottomCloseButton.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.BottomCloseButton.Name = "BottomCloseButton";
            this.BottomCloseButton.Size = new System.Drawing.Size(95, 33);
            this.BottomCloseButton.TabIndex = 1;
            this.BottomCloseButton.Text = "关闭";
            this.BottomCloseButton.UseVisualStyleBackColor = false;
            this.BottomCloseButton.Click += new System.EventHandler(this.BottomCloseButton_Click);
            // 
            // BottomSendButton
            // 
            this.BottomSendButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BottomSendButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BottomSendButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.BottomSendButton.FlatAppearance.BorderSize = 0;
            this.BottomSendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BottomSendButton.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BottomSendButton.Location = new System.Drawing.Point(511, 1);
            this.BottomSendButton.Name = "BottomSendButton";
            this.BottomSendButton.Size = new System.Drawing.Size(95, 33);
            this.BottomSendButton.TabIndex = 0;
            this.BottomSendButton.Text = "发送";
            this.BottomSendButton.UseVisualStyleBackColor = false;
            this.BottomSendButton.Click += new System.EventHandler(this.BottomSendButton_Click);
            // 
            // ButtonFunctionPanel
            // 
            this.ButtonFunctionPanel.Controls.Add(this.historyDateTimePicker);
            this.ButtonFunctionPanel.Controls.Add(this.historyButton);
            this.ButtonFunctionPanel.Controls.Add(this.TransportFileButton);
            this.ButtonFunctionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonFunctionPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonFunctionPanel.Name = "ButtonFunctionPanel";
            this.ButtonFunctionPanel.Padding = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.ButtonFunctionPanel.Size = new System.Drawing.Size(621, 40);
            this.ButtonFunctionPanel.TabIndex = 0;
            // 
            // historyDateTimePicker
            // 
            this.historyDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.historyDateTimePicker.CalendarFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.historyDateTimePicker.CalendarForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.historyDateTimePicker.Location = new System.Drawing.Point(386, 6);
            this.historyDateTimePicker.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.historyDateTimePicker.Name = "historyDateTimePicker";
            this.historyDateTimePicker.Size = new System.Drawing.Size(200, 25);
            this.historyDateTimePicker.TabIndex = 0;
            this.toolTip.SetToolTip(this.historyDateTimePicker, "选好最早日期以后，回车开始加载");
            this.historyDateTimePicker.Visible = false;
            this.historyDateTimePicker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.historyDateTimePicker_KeyDown);
            // 
            // historyButton
            // 
            this.historyButton.BackColor = System.Drawing.Color.Transparent;
            this.historyButton.BackgroundImage = global::信鸽.Properties.Resources.历史;
            this.historyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.historyButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.historyButton.FlatAppearance.BorderSize = 0;
            this.historyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.historyButton.Location = new System.Drawing.Point(591, 5);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(25, 25);
            this.historyButton.TabIndex = 1;
            this.toolTip.SetToolTip(this.historyButton, "查看更多历史记录");
            this.historyButton.UseVisualStyleBackColor = false;
            this.historyButton.Click += new System.EventHandler(this.historyButton_Click);
            // 
            // TransportFileButton
            // 
            this.TransportFileButton.BackColor = System.Drawing.Color.Transparent;
            this.TransportFileButton.BackgroundImage = global::信鸽.Properties.Resources.文件__1_;
            this.TransportFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TransportFileButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.TransportFileButton.FlatAppearance.BorderSize = 0;
            this.TransportFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TransportFileButton.Location = new System.Drawing.Point(5, 5);
            this.TransportFileButton.Name = "TransportFileButton";
            this.TransportFileButton.Size = new System.Drawing.Size(25, 25);
            this.TransportFileButton.TabIndex = 0;
            this.TransportFileButton.UseVisualStyleBackColor = false;
            // 
            // RightPanel
            // 
            this.RightPanel.BackColor = System.Drawing.Color.Transparent;
            this.RightPanel.Controls.Add(this.RightBottomPanel);
            this.RightPanel.Controls.Add(this.RightTopForm);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightPanel.Location = new System.Drawing.Point(820, 49);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(251, 566);
            this.RightPanel.TabIndex = 0;
            // 
            // RightBottomPanel
            // 
            this.RightBottomPanel.AutoScroll = true;
            this.RightBottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.RightBottomPanel.Controls.Add(this.groupMemberPanel);
            this.RightBottomPanel.Controls.Add(this.groupShowMemberPanel);
            this.RightBottomPanel.Controls.Add(this.fileTransportPanel);
            this.RightBottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightBottomPanel.Location = new System.Drawing.Point(0, 162);
            this.RightBottomPanel.Name = "RightBottomPanel";
            this.RightBottomPanel.Size = new System.Drawing.Size(251, 404);
            this.RightBottomPanel.TabIndex = 1;
            // 
            // groupMemberPanel
            // 
            this.groupMemberPanel.AutoScroll = true;
            this.groupMemberPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupMemberPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupMemberPanel.Location = new System.Drawing.Point(0, 121);
            this.groupMemberPanel.Name = "groupMemberPanel";
            this.groupMemberPanel.Size = new System.Drawing.Size(251, 283);
            this.groupMemberPanel.TabIndex = 3;
            // 
            // groupShowMemberPanel
            // 
            this.groupShowMemberPanel.Controls.Add(this.viewGroupMemberButton);
            this.groupShowMemberPanel.Controls.Add(this.groupShowMemberLabel);
            this.groupShowMemberPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupShowMemberPanel.Location = new System.Drawing.Point(0, 86);
            this.groupShowMemberPanel.Name = "groupShowMemberPanel";
            this.groupShowMemberPanel.Size = new System.Drawing.Size(251, 35);
            this.groupShowMemberPanel.TabIndex = 2;
            // 
            // viewGroupMemberButton
            // 
            this.viewGroupMemberButton.BackgroundImage = global::信鸽.Properties.Resources.望远镜;
            this.viewGroupMemberButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.viewGroupMemberButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.viewGroupMemberButton.FlatAppearance.BorderSize = 0;
            this.viewGroupMemberButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewGroupMemberButton.Location = new System.Drawing.Point(0, 0);
            this.viewGroupMemberButton.Name = "viewGroupMemberButton";
            this.viewGroupMemberButton.Size = new System.Drawing.Size(35, 35);
            this.viewGroupMemberButton.TabIndex = 2;
            this.toolTip.SetToolTip(this.viewGroupMemberButton, "点击显示群成员");
            this.viewGroupMemberButton.UseVisualStyleBackColor = true;
            this.viewGroupMemberButton.Visible = false;
            this.viewGroupMemberButton.Click += new System.EventHandler(this.viewGroupMemberButton_Click);
            // 
            // groupShowMemberLabel
            // 
            this.groupShowMemberLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.groupShowMemberLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupShowMemberLabel.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupShowMemberLabel.Location = new System.Drawing.Point(0, 0);
            this.groupShowMemberLabel.Name = "groupShowMemberLabel";
            this.groupShowMemberLabel.Size = new System.Drawing.Size(251, 35);
            this.groupShowMemberLabel.TabIndex = 1;
            this.groupShowMemberLabel.Text = "群成员";
            this.groupShowMemberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.groupShowMemberLabel.Visible = false;
            // 
            // fileTransportPanel
            // 
            this.fileTransportPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.fileTransportPanel.Location = new System.Drawing.Point(0, 0);
            this.fileTransportPanel.Name = "fileTransportPanel";
            this.fileTransportPanel.Size = new System.Drawing.Size(251, 86);
            this.fileTransportPanel.TabIndex = 0;
            // 
            // RightTopForm
            // 
            this.RightTopForm.BackColor = System.Drawing.Color.Transparent;
            this.RightTopForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.RightTopForm.Location = new System.Drawing.Point(0, 0);
            this.RightTopForm.Name = "RightTopForm";
            this.RightTopForm.Size = new System.Drawing.Size(251, 162);
            this.RightTopForm.TabIndex = 0;
            // 
            // MiddlePanel
            // 
            this.MiddlePanel.AutoScroll = true;
            this.MiddlePanel.AutoSize = true;
            this.MiddlePanel.BackColor = System.Drawing.Color.Transparent;
            this.MiddlePanel.Controls.Add(this.middleShowPanel);
            this.MiddlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MiddlePanel.Location = new System.Drawing.Point(199, 49);
            this.MiddlePanel.Name = "MiddlePanel";
            this.MiddlePanel.Size = new System.Drawing.Size(621, 406);
            this.MiddlePanel.TabIndex = 0;
            // 
            // middleShowPanel
            // 
            this.middleShowPanel.AutoSize = true;
            this.middleShowPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.middleShowPanel.Location = new System.Drawing.Point(0, 0);
            this.middleShowPanel.Name = "middleShowPanel";
            this.middleShowPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.middleShowPanel.Size = new System.Drawing.Size(621, 20);
            this.middleShowPanel.TabIndex = 0;
            // 
            // TopPanel
            // 
            this.TopPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TopPanel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.TopPanel.BackgroundImage = global::信鸽.Properties.Resources.TopBackGround;
            this.TopPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TopPanel.Controls.Add(this.TitleLabel);
            this.TopPanel.Controls.Add(this.TopRightPanel);
            this.TopPanel.Controls.Add(this.TopLeftPanel);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Padding = new System.Windows.Forms.Padding(10, 6, 0, 6);
            this.TopPanel.Size = new System.Drawing.Size(1071, 49);
            this.TopPanel.TabIndex = 0;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.TitleLabel.Font = new System.Drawing.Font("微软雅黑", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleLabel.Location = new System.Drawing.Point(472, 12);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(136, 31);
            this.TitleLabel.TabIndex = 2;
            this.TitleLabel.Text = "1618028班";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TopRightPanel
            // 
            this.TopRightPanel.AutoSize = true;
            this.TopRightPanel.BackColor = System.Drawing.Color.Transparent;
            this.TopRightPanel.Controls.Add(this.MixButton);
            this.TopRightPanel.Controls.Add(this.MaxButton);
            this.TopRightPanel.Controls.Add(this.CloseButton);
            this.TopRightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.TopRightPanel.Location = new System.Drawing.Point(941, 6);
            this.TopRightPanel.Name = "TopRightPanel";
            this.TopRightPanel.Padding = new System.Windows.Forms.Padding(0, 11, 8, 11);
            this.TopRightPanel.Size = new System.Drawing.Size(130, 37);
            this.TopRightPanel.TabIndex = 1;
            // 
            // MixButton
            // 
            this.MixButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MixButton.AutoSize = true;
            this.MixButton.BackColor = System.Drawing.Color.Transparent;
            this.MixButton.BackgroundImage = global::信鸽.Properties.Resources.最小化;
            this.MixButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MixButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(145)))), ((int)(((byte)(210)))));
            this.MixButton.FlatAppearance.BorderSize = 0;
            this.MixButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.MixButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.MixButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MixButton.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MixButton.Location = new System.Drawing.Point(15, 11);
            this.MixButton.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.MixButton.Name = "MixButton";
            this.MixButton.Size = new System.Drawing.Size(15, 15);
            this.MixButton.TabIndex = 1;
            this.MixButton.UseVisualStyleBackColor = false;
            this.MixButton.Click += new System.EventHandler(this.MixButton_Click);
            // 
            // MaxButton
            // 
            this.MaxButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MaxButton.BackColor = System.Drawing.Color.Transparent;
            this.MaxButton.BackgroundImage = global::信鸽.Properties.Resources.最大化;
            this.MaxButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MaxButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(145)))), ((int)(((byte)(210)))));
            this.MaxButton.FlatAppearance.BorderSize = 0;
            this.MaxButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.MaxButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.MaxButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaxButton.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaxButton.ForeColor = System.Drawing.Color.Black;
            this.MaxButton.Location = new System.Drawing.Point(56, 11);
            this.MaxButton.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.MaxButton.Name = "MaxButton";
            this.MaxButton.Padding = new System.Windows.Forms.Padding(30);
            this.MaxButton.Size = new System.Drawing.Size(15, 15);
            this.MaxButton.TabIndex = 1;
            this.MaxButton.UseVisualStyleBackColor = false;
            this.MaxButton.Click += new System.EventHandler(this.MaxButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.AutoSize = true;
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.BackgroundImage = global::信鸽.Properties.Resources.关闭;
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(145)))), ((int)(((byte)(210)))));
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CloseButton.Location = new System.Drawing.Point(94, 11);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(15, 15);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // TopLeftPanel
            // 
            this.TopLeftPanel.AutoSize = true;
            this.TopLeftPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TopLeftPanel.BackColor = System.Drawing.Color.Transparent;
            this.TopLeftPanel.Controls.Add(this.SearchTextBox);
            this.TopLeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.TopLeftPanel.Location = new System.Drawing.Point(10, 6);
            this.TopLeftPanel.Name = "TopLeftPanel";
            this.TopLeftPanel.Padding = new System.Windows.Forms.Padding(15, 5, 15, 5);
            this.TopLeftPanel.Size = new System.Drawing.Size(185, 37);
            this.TopLeftPanel.TabIndex = 0;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.SearchTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.SearchTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(161)))), ((int)(((byte)(235)))));
            this.SearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SearchTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.SearchTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SearchTextBox.ForeColor = System.Drawing.Color.LightGray;
            this.SearchTextBox.Location = new System.Drawing.Point(15, 5);
            this.SearchTextBox.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.SearchTextBox.Multiline = true;
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(155, 27);
            this.SearchTextBox.TabIndex = 0;
            this.SearchTextBox.Text = "搜索";
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1071, 615);
            this.Controls.Add(this.MiddlePanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.RightPanel);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChatForm";
            this.Text = "ChatForm";
            this.BottomPanel.ResumeLayout(false);
            this.BottomButtonPanel.ResumeLayout(false);
            this.ButtonFunctionPanel.ResumeLayout(false);
            this.RightPanel.ResumeLayout(false);
            this.RightBottomPanel.ResumeLayout(false);
            this.groupShowMemberPanel.ResumeLayout(false);
            this.MiddlePanel.ResumeLayout(false);
            this.MiddlePanel.PerformLayout();
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.TopRightPanel.ResumeLayout(false);
            this.TopRightPanel.PerformLayout();
            this.TopLeftPanel.ResumeLayout(false);
            this.TopLeftPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Panel TopLeftPanel;
        private System.Windows.Forms.Panel TopRightPanel;
        private System.Windows.Forms.Button MixButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Panel BottomButtonPanel;
        private System.Windows.Forms.Button BottomCloseButton;
        private System.Windows.Forms.Button BottomSendButton;
        private System.Windows.Forms.Panel ButtonFunctionPanel;
        private System.Windows.Forms.RichTextBox NewsEditRichTextBox;
        private System.Windows.Forms.Button MaxButton;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.Button TransportFileButton;
        private System.Windows.Forms.Panel RightBottomPanel;
        private GroupOppositeEasyInformation.GroupOppositeEasyInformation RightTopForm;
        private System.Windows.Forms.Panel MiddlePanel;
        private System.Windows.Forms.Panel middleShowPanel;
        private System.Windows.Forms.Button historyButton;
        private System.Windows.Forms.DateTimePicker historyDateTimePicker;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel groupMemberPanel;
        private System.Windows.Forms.Panel groupShowMemberPanel;
        private System.Windows.Forms.Label groupShowMemberLabel;
        private System.Windows.Forms.Panel fileTransportPanel;
        private System.Windows.Forms.Button viewGroupMemberButton;
    }
}