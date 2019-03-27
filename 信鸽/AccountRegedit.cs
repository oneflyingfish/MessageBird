using System;
using System.IO;
using System.Windows.Forms;
using MessageBirdCommon;
using ObjectExpandClass;

namespace MessageBird
{
    public partial class AccountRegedit : Form
    {
        public AccountRegedit(SignIn parent)
        {
            ParentProcess = parent;
            InitializeComponent();        
            this.Show();
            this.TopMost = true;
            this.Closed += AccountRegedit_Closed;
            timer = new Timer();
            timer.Tick += timer_Tick;
            timer.Interval = 1000;
            timer.Enabled = false;
        }

        /// <summary>
        /// 界面关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountRegedit_Closed(object sender, EventArgs e)
        {
            ParentProcess.Enabled = true;
        }

        /// <summary>
        /// 执行注册操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunButton_Click(object sender, EventArgs e)
        {
            //初步判断邮箱符合规则
            if (!this.EmailAccount.Text.Contains("@"))
            {
                MessageBox.Show("请输入合法的邮箱", "账户不符合规则");
                return;
            }

            //确认昵称符合规则
            if (this.NameTextBox.Text == ""||this.NameTextBox.Text.Contains(" ") || this.NameTextBox.Text.Contains("|") || this.NameTextBox.Text.Contains(@"\"))
            {
                MessageBox.Show(@"昵称不能为空，且不能含有空格、|、\", "信息不符合规则");
                return;
            }

            //确认密码符合规则
            if (this.Password1.Text != this.Password2.Text)
            {
                MessageBox.Show("您两次输入的密码不一致，请重试", "密码不符合规则");
                return;
            }

            if (!File.Exists(ImagePathTextBox.Text) || (!ImagePathTextBox.Text.EndsWith(".jpg") && !ImagePathTextBox.Text.EndsWith(".png")))
            {
                MessageBox.Show("请选择可用的图像，建议为正方形", "图像不符合规则");
                return;
            }
            //确认验证码
            if (this.ConfigString == "" || this.ConfigString!=this.ConfigTextBox.Text)
            {
                MessageBox.Show("验证码错误，请重新填写验证码", "系统消息");
                return;
            }
            //与服务器通信，修改参数
            //账户:EmailAccount.Text
            //昵称:NameTextBox.Text
            //密码:Password1.Text
            CallServer.AddSendNews(MessageProtocol.GetStartBytes(FunctionKind.RequestToRegeditAccount), EmailAccount.Text.ToTxtBytes(), NameTextBox.Text.ToTxtBytes(), Password1.Text.ToTxtBytes(), MessageProtocol.GetEndBytes());
            MessageBox.Show("修改成功", "系统消息");
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            ConfigString = "";
            for (int i = 0; i < 6; i++)
            {
                ConfigString += random.Next(10);
            }
            string msg = "亲爱的" + this.NameTextBox.Text + "!\r\n感谢您对信鸽的支持！\r\n您本次的验证码为:" + ConfigString + " 。如果不是您本人所为，请尽快联系我们\r\n祝您生活愉快!";
            if (!Email.SendEmail("信鸽验证码", msg, EmailAccount.Text))
            {
                return;
            }
            MessageBox.Show("验证码已经发送到您的邮箱，请注意查收");
            timer.Enabled = true;
            TimeLeft = 30;
            this.TimeLabel.Visible = true;
            this.ConfigButton.Enabled = false;
        }

        /// <summary>
        /// 三十秒倒计时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (TimeLeft <= 0)
            {
                this.timer.Enabled = false;
                this.TimeLabel.Visible = false;
                this.ConfigButton.Enabled = true;
            }
            else
            {
                TimeLeft--;
                this.TimeLabel.Text = TimeLeft + "s";
            }
        }

        string ConfigString = "";
        private SignIn ParentProcess = null;
        int TimeLeft = 0;
        Timer timer;

        /// <summary>
        /// 选取图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            fileDialog.Filter = "图片(*.png ;*.jpg)|*.png;*.jpg";
            fileDialog.Title = "选择图像（尽量选择正方形图片）";
            fileDialog.Multiselect = false;//不可选取多个文件
            if(fileDialog.ShowDialog()==DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(fileDialog.FileName);
                double length = Convert.ToDouble(fileInfo.Length);
                if (!fileInfo.FullName.ToLower().EndsWith(".png") || (fileInfo.Length > 31457280))
                {
                    MessageBox.Show("目前仅支持小于30KB的png图像");
                    return;
                }
                this.ImagePathTextBox.Text = fileDialog.FileName;
            }
        }
    }
}
