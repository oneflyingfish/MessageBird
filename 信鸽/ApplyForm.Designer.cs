namespace MessageBird
{
    partial class ApplyForm
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
            this.accountLabel = new System.Windows.Forms.Label();
            this.accountTextbox = new System.Windows.Forms.TextBox();
            this.sendbutton = new System.Windows.Forms.Button();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.userNamelabel = new System.Windows.Forms.Label();
            this.functionComboBox = new System.Windows.Forms.ComboBox();
            this.functionLabel = new System.Windows.Forms.Label();
            this.showBusyLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // accountLabel
            // 
            this.accountLabel.AutoSize = true;
            this.accountLabel.Location = new System.Drawing.Point(18, 47);
            this.accountLabel.Name = "accountLabel";
            this.accountLabel.Size = new System.Drawing.Size(120, 15);
            this.accountLabel.TabIndex = 0;
            this.accountLabel.Text = "好友账号/群号：";
            // 
            // accountTextbox
            // 
            this.accountTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accountTextbox.BackColor = System.Drawing.Color.White;
            this.accountTextbox.Location = new System.Drawing.Point(150, 43);
            this.accountTextbox.Name = "accountTextbox";
            this.accountTextbox.Size = new System.Drawing.Size(236, 25);
            this.accountTextbox.TabIndex = 1;
            // 
            // sendbutton
            // 
            this.sendbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendbutton.BackColor = System.Drawing.Color.White;
            this.sendbutton.Location = new System.Drawing.Point(290, 186);
            this.sendbutton.Name = "sendbutton";
            this.sendbutton.Size = new System.Drawing.Size(95, 23);
            this.sendbutton.TabIndex = 2;
            this.sendbutton.Text = "发送请求";
            this.sendbutton.UseVisualStyleBackColor = false;
            this.sendbutton.Click += new System.EventHandler(this.sendbutton_Click);
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userNameTextBox.BackColor = System.Drawing.Color.White;
            this.userNameTextBox.Location = new System.Drawing.Point(150, 111);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.ReadOnly = true;
            this.userNameTextBox.Size = new System.Drawing.Size(236, 25);
            this.userNameTextBox.TabIndex = 5;
            // 
            // userNamelabel
            // 
            this.userNamelabel.AutoSize = true;
            this.userNamelabel.Location = new System.Drawing.Point(16, 118);
            this.userNamelabel.Name = "userNamelabel";
            this.userNamelabel.Size = new System.Drawing.Size(135, 15);
            this.userNamelabel.TabIndex = 4;
            this.userNamelabel.Text = "好友昵称/群昵称：";
            // 
            // functionComboBox
            // 
            this.functionComboBox.BackColor = System.Drawing.Color.White;
            this.functionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.functionComboBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.functionComboBox.FormattingEnabled = true;
            this.functionComboBox.Items.AddRange(new object[] {
            "加入群聊",
            "添加好友",
            "新建群聊"});
            this.functionComboBox.Location = new System.Drawing.Point(69, 188);
            this.functionComboBox.Name = "functionComboBox";
            this.functionComboBox.Size = new System.Drawing.Size(121, 28);
            this.functionComboBox.TabIndex = 6;
            // 
            // functionLabel
            // 
            this.functionLabel.AutoSize = true;
            this.functionLabel.Location = new System.Drawing.Point(11, 192);
            this.functionLabel.Name = "functionLabel";
            this.functionLabel.Size = new System.Drawing.Size(52, 15);
            this.functionLabel.TabIndex = 7;
            this.functionLabel.Text = "功能：";
            // 
            // showBusyLabel
            // 
            this.showBusyLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.showBusyLabel.AutoSize = true;
            this.showBusyLabel.BackColor = System.Drawing.Color.Transparent;
            this.showBusyLabel.ForeColor = System.Drawing.Color.Red;
            this.showBusyLabel.Location = new System.Drawing.Point(163, 233);
            this.showBusyLabel.Name = "showBusyLabel";
            this.showBusyLabel.Size = new System.Drawing.Size(97, 15);
            this.showBusyLabel.TabIndex = 8;
            this.showBusyLabel.Text = "等待输入账户";
            // 
            // ApplyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(401, 256);
            this.Controls.Add(this.showBusyLabel);
            this.Controls.Add(this.functionLabel);
            this.Controls.Add(this.functionComboBox);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.userNamelabel);
            this.Controls.Add(this.sendbutton);
            this.Controls.Add(this.accountTextbox);
            this.Controls.Add(this.accountLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ApplyForm";
            this.Text = "您所申请添加的好友/群信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label accountLabel;
        private System.Windows.Forms.TextBox accountTextbox;
        private System.Windows.Forms.Button sendbutton;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Label userNamelabel;
        private System.Windows.Forms.ComboBox functionComboBox;
        private System.Windows.Forms.Label functionLabel;
        private System.Windows.Forms.Label showBusyLabel;
    }
}