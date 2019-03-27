using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MessageBirdCommon;
using ObjectExpandClass;

namespace MessageBird
{
    /// <summary>
    /// 定义登录的委托
    /// </summary>
    /// <param name="o"></param>
    public delegate void RunParentForm(Object o,string account);

    /// <summary>
    /// 登录界面类
    /// </summary>
    public partial class SignIn : Form
    {
        /// <summary>
        /// 定义登录事件 
        /// </summary>
        public event RunParentForm FinishSignIn;

        /// <summary>
        /// 默认构造函数,绑定相关事件
        /// </summary>
        public SignIn()
        {
            InitializeComponent();
            //实现阴影立体效果
            FormShadow.SetShadow(this);
            //显示登录窗体，设置焦点
            this.Show();
            this.SignalInButton.Focus();
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.AccountPanel.Paint += AccountPanel_Paint;
            this.PasswordPanel.Paint += PasswordPanel_Paint;

            //绑定窗口移动事件
            this.MouseDown += SignIn_MouseDown;
            this.MouseMove += SignIn_MouseMove;
            this.SignInPicture.MouseMove+= SignIn_MouseMove;
            this.SignInPicture.MouseDown+= SignIn_MouseDown;
            this.panel1.MouseMove += SignIn_MouseMove;
            this.panel1.MouseDown += SignIn_MouseDown;

            //登录相关事件绑定
            this.SignalInButton.Click += SignalInButton_Click;
            this.AccountTextLine.Leave += AccountTextLine_Leave;

            //勾选自动登录->记住密码
            this.AutoSignInCheckBox.CheckedChanged += AutoSignInCheckBox_CheckedChanged;

            //取消记住密码->取消自动登录
            this.PasswordCheckBox.CheckedChanged += PasswordCheckBox_CheckedChanged;
        }

        private void PasswordPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Blue), 0, PasswordPanel.Height-1, PasswordPanel.Width-1, PasswordPanel.Height-1);
        }

        private void AccountPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Blue), 0, AccountPanel.Height-1, AccountPanel.Width-1, AccountPanel.Height-1);
        }

        /// <summary>
        /// 取消记住密码-->取消自动登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(this.PasswordCheckBox.CheckState==CheckState.Unchecked)
            {
                this.AutoSignInCheckBox.CheckState = CheckState.Unchecked;
            }
        }

        /// <summary>
        /// 自动登录-->记住密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoSignInCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(this.AutoSignInCheckBox.CheckState==CheckState.Checked)
            {
                this.PasswordCheckBox.CheckState = CheckState.Checked;
            }
        }

        /// <summary>
        /// 账户输入完毕，请求图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountTextLine_Leave(object sender, EventArgs e)
        {
            //向服务器请求登录图片，并且置换到init.png
            //此处未写完!!!!!!!!!!!!
            FunctionWords functionWords =this.SendNewsAndReceiveAnswer(FunctionKind.SeekForImage, this.Account, "", null);
            if(functionWords!=null && functionWords.bitmapList.Count>0)
            {
                UserImage = functionWords.bitmapList[0];
                this.SignInPicture.BackgroundImage = UserImage;
            }
            else
            {
                UserImage = new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png");
                this.SignInPicture.BackgroundImage = UserImage;
            }
            
        }

        /// <summary>
        /// 初始化界面，是否为记住密码，是否需要自动登录
        /// </summary>
        public void init()
        {
            if(File.Exists(System.Environment.CurrentDirectory + "\\init"))
            {
                this.PasswordCheckBox.Checked = true;
                //读取历史账户、密码
                FileStream file = new FileStream(System.Environment.CurrentDirectory + "\\init", FileMode.Open);
                StreamReader reader = new StreamReader(file);
                string ifAutoSignIn = reader.ReadLine();
                Account= reader.ReadLine();
                Password = reader.ReadLine();
                reader.Close();

                //记住密码时自动获取图标
                //UserImage = new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png");
                FunctionWords functionWords = this.SendNewsAndReceiveAnswer(FunctionKind.SeekForImage, this.Account, "", null);
                if (functionWords != null && functionWords.bitmapList.Count > 0)
                {
                    UserImage = functionWords.bitmapList[0];
                }
                this.SignInPicture.BackgroundImage = UserImage;
               
                if(ifAutoSignIn=="true") //自动登录
                {
                    this.AutoSignInCheckBox.Checked = true; //自动登录勾选
                    this.SignalInButton.PerformClick();//执行登录操作
                }
            }
        }

        /// <summary>
        /// 界面拖动实现模块
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignIn_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                this.Left += (e.Location.X - FormX);
                this.Top += (e.Location.Y - FormY);
                return;
            }
        }

        /// <summary>
        /// 界面拖动实现模块
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignIn_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                this.FormX = e.X;
                this.FormY = e.Y;
                return;
            }
        }

        /// <summary>
        /// 最小化界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MixButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 关闭界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 账户注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegeditAccountLabel_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AccountRegedit child=new AccountRegedit(this);
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetPasswordLabel_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AccountRegedit child = new AccountRegedit(this);
        }

        /// <summary>
        /// 点击登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignalInButton_Click(object sender, EventArgs e)
        {
            this.SignalInButton.Text = "正 在 登 录...";
            //配置登录信息
            AutoSignInConfig();
            //密码是否正确
            bool AccountFitPassword = false;

            //云服务器请求决断
            FunctionWords functionWords = this.SendNewsAndReceiveAnswer(FunctionKind.VerifyAccount, this.Account, this.Password, null);
            if(functionWords!=null && functionWords.stringList.Count>0)
            {
                if(functionWords.stringList[0]=="true")
                {
                    AccountFitPassword = true;
                }
            }

            //账户密码正确
            if (AccountFitPassword)
            {
                //触发登录事件
                FinishSignIn(this,Account);
            }
            else
            {
                this.SignalInButton.Text = "登 录";
            }

        }

        /// <summary>
        /// 记录自动登录相关的配置信息（已知存在安全问题，后期改进）当不记住密码时，init文件不存在
        /// 第一行:是否自动登录
        /// 第二行:账户
        /// 第三行:密码
        /// </summary>
        private void AutoSignInConfig()
        {
            if (this.PasswordCheckBox.Checked == true)
            {
                FileStream file = new FileStream(System.Environment.CurrentDirectory + "\\init", FileMode.Create);
                StreamWriter writer = new StreamWriter(file);
                if (this.AutoSignInCheckBox.Checked == true) //是否自动登录
                {
                    writer.WriteLine("true"); //自动登录
                }
                else
                {
                    writer.WriteLine("false");
                }
                //记录账户
                writer.WriteLine(Account);
                //记录密码
                writer.WriteLine(Password);
                writer.Close();
            }
            else
            {
                //不自动登录时，直接删除配置文件
                File.Delete(System.Environment.CurrentDirectory + "\\init");
            }
        }

        public string Account{ get { return this.AccountTextLine.Text; } set { this.AccountTextLine.Text = value; } }
        public string Password { get { return this.PasswordTextLine.Text; } set { this.PasswordTextLine.Text = value; } }
        public Bitmap UserImage { get => image; set => image = value; }

        private Bitmap image = global::信鸽.Properties.Resources.image;

        private int FormX = 0;
        private int FormY = 0;

        private void PasswordTextLine_Click(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                this.SignalInButton.PerformClick();
            }    
        }
    }
};