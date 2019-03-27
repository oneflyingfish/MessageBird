namespace MessageBird
{
    partial class SignIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignIn));
            this.SignFormIconPictureBox = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.MixButton = new System.Windows.Forms.Button();
            this.SignInPicture = new System.Windows.Forms.PictureBox();
            this.PasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoSignInCheckBox = new System.Windows.Forms.CheckBox();
            this.ResetPasswordLabel = new System.Windows.Forms.Label();
            this.RegeditAccountLabel = new System.Windows.Forms.Label();
            this.SignalInButton = new CCWin.SkinControl.SkinButton();
            this.AccountTextLine = new CCWin.SkinControl.SkinAlphaWaterTextBox();
            this.PasswordTextLine = new CCWin.SkinControl.SkinAlphaWaterTextBox();
            this.AccountPictureBox = new System.Windows.Forms.PictureBox();
            this.PasswordPictureBox = new System.Windows.Forms.PictureBox();
            this.AccountPanel = new System.Windows.Forms.Panel();
            this.PasswordPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.SignFormIconPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SignInPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordPictureBox)).BeginInit();
            this.AccountPanel.SuspendLayout();
            this.PasswordPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SignFormIconPictureBox
            // 
            resources.ApplyResources(this.SignFormIconPictureBox, "SignFormIconPictureBox");
            this.SignFormIconPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.SignFormIconPictureBox.BackgroundImage = global::信鸽.Properties.Resources.AppIcon_white;
            this.SignFormIconPictureBox.Name = "SignFormIconPictureBox";
            this.SignFormIconPictureBox.TabStop = false;
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.CloseButton, "CloseButton");
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.CloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // MixButton
            // 
            this.MixButton.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.MixButton, "MixButton");
            this.MixButton.FlatAppearance.BorderSize = 0;
            this.MixButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.MixButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.MixButton.ForeColor = System.Drawing.Color.White;
            this.MixButton.Name = "MixButton";
            this.MixButton.UseVisualStyleBackColor = false;
            this.MixButton.Click += new System.EventHandler(this.MixButton_Click);
            // 
            // SignInPicture
            // 
            resources.ApplyResources(this.SignInPicture, "SignInPicture");
            this.SignInPicture.BackColor = System.Drawing.Color.Transparent;
            this.SignInPicture.Name = "SignInPicture";
            this.SignInPicture.TabStop = false;
            // 
            // PasswordCheckBox
            // 
            resources.ApplyResources(this.PasswordCheckBox, "PasswordCheckBox");
            this.PasswordCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.PasswordCheckBox.Name = "PasswordCheckBox";
            this.PasswordCheckBox.UseVisualStyleBackColor = false;
            // 
            // AutoSignInCheckBox
            // 
            resources.ApplyResources(this.AutoSignInCheckBox, "AutoSignInCheckBox");
            this.AutoSignInCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.AutoSignInCheckBox.Name = "AutoSignInCheckBox";
            this.AutoSignInCheckBox.UseVisualStyleBackColor = false;
            // 
            // ResetPasswordLabel
            // 
            resources.ApplyResources(this.ResetPasswordLabel, "ResetPasswordLabel");
            this.ResetPasswordLabel.BackColor = System.Drawing.Color.Transparent;
            this.ResetPasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ResetPasswordLabel.Name = "ResetPasswordLabel";
            this.ResetPasswordLabel.Click += new System.EventHandler(this.ResetPasswordLabel_Click);
            // 
            // RegeditAccountLabel
            // 
            resources.ApplyResources(this.RegeditAccountLabel, "RegeditAccountLabel");
            this.RegeditAccountLabel.BackColor = System.Drawing.Color.Transparent;
            this.RegeditAccountLabel.ForeColor = System.Drawing.Color.White;
            this.RegeditAccountLabel.Name = "RegeditAccountLabel";
            this.RegeditAccountLabel.Click += new System.EventHandler(this.RegeditAccountLabel_Click);
            // 
            // SignalInButton
            // 
            resources.ApplyResources(this.SignalInButton, "SignalInButton");
            this.SignalInButton.BackColor = System.Drawing.Color.Transparent;
            this.SignalInButton.BaseColor = System.Drawing.Color.DodgerBlue;
            this.SignalInButton.BorderColor = System.Drawing.Color.Transparent;
            this.SignalInButton.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.SignalInButton.DownBack = null;
            this.SignalInButton.DownBaseColor = System.Drawing.Color.DodgerBlue;
            this.SignalInButton.ForeColor = System.Drawing.Color.White;
            this.SignalInButton.GlowColor = System.Drawing.Color.DodgerBlue;
            this.SignalInButton.InnerBorderColor = System.Drawing.Color.Aquamarine;
            this.SignalInButton.MouseBack = null;
            this.SignalInButton.MouseBaseColor = System.Drawing.Color.DodgerBlue;
            this.SignalInButton.Name = "SignalInButton";
            this.SignalInButton.NormlBack = null;
            this.SignalInButton.UseVisualStyleBackColor = false;
            // 
            // AccountTextLine
            // 
            resources.ApplyResources(this.AccountTextLine, "AccountTextLine");
            this.AccountTextLine.BackAlpha = 0;
            this.AccountTextLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AccountTextLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AccountTextLine.ForeColor = System.Drawing.Color.Black;
            this.AccountTextLine.Name = "AccountTextLine";
            this.AccountTextLine.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.AccountTextLine.WaterFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AccountTextLine.WaterText = "登录邮箱账户";
            // 
            // PasswordTextLine
            // 
            resources.ApplyResources(this.PasswordTextLine, "PasswordTextLine");
            this.PasswordTextLine.BackAlpha = 0;
            this.PasswordTextLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.PasswordTextLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordTextLine.Cursor = System.Windows.Forms.Cursors.Default;
            this.PasswordTextLine.ForeColor = System.Drawing.Color.Black;
            this.PasswordTextLine.Name = "PasswordTextLine";
            this.PasswordTextLine.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.PasswordTextLine.WaterFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PasswordTextLine.WaterText = "密码";
            this.PasswordTextLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordTextLine_Click);
            // 
            // AccountPictureBox
            // 
            this.AccountPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.AccountPictureBox.BackgroundImage = global::信鸽.Properties.Resources.Account;
            resources.ApplyResources(this.AccountPictureBox, "AccountPictureBox");
            this.AccountPictureBox.Name = "AccountPictureBox";
            this.AccountPictureBox.TabStop = false;
            // 
            // PasswordPictureBox
            // 
            this.PasswordPictureBox.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.PasswordPictureBox, "PasswordPictureBox");
            this.PasswordPictureBox.Name = "PasswordPictureBox";
            this.PasswordPictureBox.TabStop = false;
            // 
            // AccountPanel
            // 
            resources.ApplyResources(this.AccountPanel, "AccountPanel");
            this.AccountPanel.BackColor = System.Drawing.Color.Transparent;
            this.AccountPanel.Controls.Add(this.AccountTextLine);
            this.AccountPanel.Controls.Add(this.AccountPictureBox);
            this.AccountPanel.Name = "AccountPanel";
            // 
            // PasswordPanel
            // 
            resources.ApplyResources(this.PasswordPanel, "PasswordPanel");
            this.PasswordPanel.BackColor = System.Drawing.Color.Transparent;
            this.PasswordPanel.Controls.Add(this.PasswordTextLine);
            this.PasswordPanel.Controls.Add(this.PasswordPictureBox);
            this.PasswordPanel.Name = "PasswordPanel";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.MixButton);
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Name = "panel1";
            // 
            // SignIn
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.SignFormIconPictureBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PasswordPanel);
            this.Controls.Add(this.AccountPanel);
            this.Controls.Add(this.SignalInButton);
            this.Controls.Add(this.RegeditAccountLabel);
            this.Controls.Add(this.ResetPasswordLabel);
            this.Controls.Add(this.AutoSignInCheckBox);
            this.Controls.Add(this.PasswordCheckBox);
            this.Controls.Add(this.SignInPicture);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SignIn";
            ((System.ComponentModel.ISupportInitialize)(this.SignFormIconPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SignInPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordPictureBox)).EndInit();
            this.AccountPanel.ResumeLayout(false);
            this.AccountPanel.PerformLayout();
            this.PasswordPanel.ResumeLayout(false);
            this.PasswordPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox SignFormIconPictureBox;
        public System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button MixButton;
        private System.Windows.Forms.PictureBox SignInPicture;
        //private TransparentTextBox AccountTextLine;
        //private TransparentTextBox PasswordTextLine;
        private System.Windows.Forms.CheckBox PasswordCheckBox;
        private System.Windows.Forms.CheckBox AutoSignInCheckBox;
        private System.Windows.Forms.Label ResetPasswordLabel;
        private System.Windows.Forms.Label RegeditAccountLabel;
        private CCWin.SkinControl.SkinButton SignalInButton;
        private System.Windows.Forms.PictureBox AccountPictureBox;
        private System.Windows.Forms.PictureBox PasswordPictureBox;
        private System.Windows.Forms.Panel AccountPanel;
        private System.Windows.Forms.Panel PasswordPanel;
        public CCWin.SkinControl.SkinAlphaWaterTextBox AccountTextLine;
        public CCWin.SkinControl.SkinAlphaWaterTextBox PasswordTextLine;
        private System.Windows.Forms.Panel panel1;
    }
}