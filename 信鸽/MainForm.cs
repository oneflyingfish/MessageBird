using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Text;
using System.Runtime.InteropServices;
using MessageBirdCommon;
using ObjectExpandClass;

namespace MessageBird
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            //绑定顶层关闭程序事件处理
            CommonEvent.CloseProgramEvent += CommonEvent_CloseProgramEvent;
            //实现阴影立体效果
            FormShadow.SetShadow(this);

            this.TopMost = true;//设置为顶级窗口
            this.BottomPanel.Paint += BottomPanel_Paint;
            //设置右下角图标
            this.BottomRightIcon.Icon = GrayIcon;
            this.BottomRightIcon.Click += BottomRightIcon_Click;
            this.BottomRightIcon.Visible = true;

            //连接远程通信服务器
            if (!CallServer.InitCallServer())
            {
                System.Environment.Exit(1);
            }

            //初始化聊天界面
            this.chatForm = new ChatForm();
            this.chatForm.Visible = false;
            chatForm.FormClosed += ChatForm_FormClosed;
            //绑定双击打开聊天记录事件
            this.DownForm.RequestChat += DownForm_RequestChat;

            //实例化闹钟,用来显示消息
            ShowNewsTimer = new System.Windows.Forms.Timer();
            ShowNewsTimer.Interval = 500;
            ShowNewsTimer.Enabled = false;

            //实例化登录界面
            signInForm = new SignIn();
            signInForm.Show();
            signInForm.ShowInTaskbar = false;
            //显示托盘图标，放在这里，通过默认图标为不显示，防止图标重复出现
            this.BottomRightIcon.Visible = true;

            //绑定相关事件
            ConnectEvent();
            //初始化登录界面
            signInForm.init();
        }

        /// <summary>
        /// 登录事件
        /// </summary>
        /// <param name="o"></param>
        private void SignInForm_FinishSignIn(object o, string account)
        {
            //初始界面为消息界面
            this.DownForm.MessageGroupBox.PerformClick();
            //初始化主界面
            this.UpForm.EmailLabel.Text = account;
            UserInformation.Account = account;

            //初始化昵称？？？云请求
            FunctionWords functionWordsForUserName = this.SendNewsAndReceiveAnswer(FunctionKind.SeekForUserName, account, "", null);
            if (functionWordsForUserName != null && functionWordsForUserName.stringList.Count>0)
            {
                this.UpForm.UserNameLabel.Text = functionWordsForUserName.stringList[0];
                UserInformation.UserName = functionWordsForUserName.stringList[0];
            }

            //初始化图像？？？云请求
            FunctionWords functionWordsForImage = this.SendNewsAndReceiveAnswer(FunctionKind.SeekForImage, account, "", null);
            if (functionWordsForImage != null && functionWordsForImage.bitmapList.Count > 0)
            {
                this.UpForm.UserImagePictureBox.BackgroundImage= functionWordsForImage.bitmapList[0];
                UserInformation.Image = functionWordsForImage.bitmapList[0];
            }

            //初始化主窗体
            init();

            CommonEvent.AddNewFriendEvent += CommonEvent_AddNewFriendEvent;
            CommonEvent.AddNewGroupEvent += CommonEvent_AddNewGroupEvent;
            CommonEvent.AddNewMessageEvent += CommonEvent_AddNewMessageEvent;
            CommonEvent.OnlineChangeEvent += CommonEvent_OnlineChangeEvent;
            CommonEvent.AnswerApplyToAddFriendEvent += CommonEvent_AnswerApplyToAddFriendEvent;
            CommonEvent.AnswerApplyToAddGroupEvent += CommonEvent_AnswerApplyToAddGroupEvent;

            //向服务器声明自己
            CallServer.AddSendNews(MessageProtocol.GetStartBytes(FunctionKind.DeclareConnect), MessageBirdCommon.UserInformation.Account.ToTxtBytes(), MessageProtocol.GetEndBytes());

            //模拟好友/群聊消息接收
            RunVirtualMessage();
        }

        /// <summary>
        /// 回复添加群聊处理完毕事件
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        private void CommonEvent_AnswerApplyToAddGroupEvent(string arg1, string arg2, bool arg3)
        {
            if(arg3)
            {
                MessageBox.Show("你对群号为:" + arg1 + "群名为:" + arg2 + "的加群申请已被同意");
            }
            else
            {
                MessageBox.Show("你对群号为:" + arg1 + "群名为:" + arg2 + "的加群申请被拒绝");
            }
        }

        /// <summary>
        ///  回复添加好友处理完毕事件
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        private void CommonEvent_AnswerApplyToAddFriendEvent(string arg1, string arg2, bool arg3)
        {
            if (arg3)
            {
                MessageBox.Show("你对账号为:" + arg1 + "昵称为:" + arg2 + "的好友申请已被同意");
            }
            else
            {
                MessageBox.Show("你对账号为:" + arg1 + "昵称为:" + arg2 + "的好友申请被拒绝");
            }
        }

        /// <summary>
        /// 顶层触发在线状态改变事件
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void CommonEvent_OnlineChangeEvent(string arg1, bool arg2)
        {
            UserInformation.SetOnlineStatus(arg1, arg2);
        }

        /// <summary>
        /// 顶层触发添加新消息
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="arg5"></param>
        /// <param name="arg6"></param>
        /// <param name="arg7"></param>
        private void CommonEvent_AddNewMessageEvent(string arg1, string arg2, string arg3, string arg4, Bitmap arg5, string arg6, bool arg7)
        {
            this.AddControl(3, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        /// <summary>
        /// 顶层触发添加新群聊
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        private void CommonEvent_AddNewGroupEvent(string arg1, string arg2, Bitmap arg3)
        {
            this.AddControl(2, arg1, arg2, arg3);
        }

        /// <summary>
        /// 顶层触发添加新好友
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        private void CommonEvent_AddNewFriendEvent(string arg1, string arg2, Bitmap arg3, bool arg4)
        {
            this.AddControl(1, arg1, arg2, arg3, arg4);
        }

        /// <summary>
        /// 顶层触发关闭事件
        /// </summary>
        private void CommonEvent_CloseProgramEvent()
        {
            this.Close();
            System.Environment.Exit(0);
        }


        /// <summary>
        /// 主界面初始化
        /// </summary>
        private void init()
        {
            //关闭登录界面
            this.signInForm.Close();
            this.Opacity = 100;
            this.SetDesktopLocation(Screen.PrimaryScreen.WorkingArea.Size.Width - 600, 55);
            this.Show();

            //右下角弹出通知
            this.BottomRightIcon.BalloonTipIcon = ToolTipIcon.Info;
            this.BottomRightIcon.BalloonTipTitle = "登录提示";
            this.BottomRightIcon.BalloonTipText = String.Format("亲爱的{0},你好,欢迎回来！您本次登录账户为：{1}\n\n祝您生活愉快！", UserInformation.UserName, UserInformation.Account);
            this.BottomRightIcon.ShowBalloonTip(300);

            this.BottomRightIcon.Text = "信鸽账户:" + UserInformation.Account + "\n用户名:" + UserInformation.UserName + "\n声音：默认开启\n会话消息:任务栏头像闪动";
            this.BottomRightIcon.Icon = BlueIcon;
            this.AcceptNews = true;
            this.DownForm.MessageGroupBox.PerformClick();
        }

        /// <summary>
        /// 打开聊天事件
        /// </summary>
        /// <param name="o"></param>
        private void DownForm_RequestChat(object o)
        {
            GroupShowForm.GroupShowForm groupShowForm = o as GroupShowForm.GroupShowForm;

            if(chatForm==null)
            {
                MessageBox.Show("错误:内部聊天对象被意外释放");
                chatForm = new ChatForm();
                chatForm.Show();
                chatForm.FormClosed += ChatForm_FormClosed;    
            }
            this.chatForm.Visible = true;

            //显示界面
            if (chatForm.WindowState == FormWindowState.Minimized)
            {
                chatForm.WindowState = FormWindowState.Normal;
            }

            //为了使得聊天界面左部信息控件可以区分类别，又使其不响应双击打开聊天事件，kind+3
            chatForm.AddControlsToLeft(groupShowForm.Kind + 3, groupShowForm.Account, groupShowForm.UserName, groupShowForm.UserImage);
        }

        /// <summary>
        ///聊天界面关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.chatForm = new ChatForm();
            this.chatForm.Visible = false;
            chatForm.FormClosed += ChatForm_FormClosed;
        }

        /// <summary>
        /// 播放新消息声音
        /// </summary>
        private void PlayNewsSound()
        {
            //聊天框已经实例化
            if(chatForm.Visible==true)
            {
                if(chatForm.ContainsFocus==true ||AcceptNews==false)
                {
                    return;
                }
            }
            if(this.ContainsFocus==true ||this.UpForm.ContainsFocus==true ||this.DownForm.ContainsFocus==true)
            {
                return;
            }
            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.SoundLocation=System.Environment.CurrentDirectory + "\\Music\\NewsSound.wav";
            soundPlayer.Load();
            soundPlayer.Play();
        }

        /// <summary>
        /// 来电消息提醒
        /// </summary>
        private void ShowNews()
        {
            if(AcceptNews==false)
            {
                return;
            }
            this.ShowNewsTimer.Enabled = true;
            PlayNewsSound();
        }

        /// <summary>
        /// 绘制底部虚线条，仅为了美观
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BottomPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Gainsboro), 0, 0, this.BottomPanel.Width - 1, 0);
        }

        /// <summary>
        /// 初始化好友、群组、消息列表
        /// kind=1: 好友
        /// kind=2：群组
        /// kind=3：消息
        /// </summary>
        private void RunVirtualMessage()
        {
            
            CommonEvent.EmitAddNewFriendEvent("好友1", "45378353@qq.com", new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png" ),true);
            CommonEvent.EmitAddNewFriendEvent("好友2", "7317227@qq.com", new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png"), true);
            CommonEvent.EmitAddNewFriendEvent("好友3", "2870538@qq.com", new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png"), true);
            CommonEvent.EmitAddNewFriendEvent("好友4", "381727@qq.com", new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png"), true);
            CommonEvent.EmitAddNewFriendEvent("好友5", "9507079@qq.com", new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png"), true);
            CommonEvent.EmitAddNewFriendEvent("好友6", "9972799@qq.com", new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png"), true);
            CommonEvent.EmitAddNewFriendEvent("好友7", "99973789@qq.com", new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png"), true);
            CommonEvent.EmitAddNewFriendEvent("好友8", "887783@qq.com", new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png"), true);
            CommonEvent.EmitAddNewFriendEvent("好友9", "99987379@qq.com", new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png"), true);

            CommonEvent.EmitAddNewGroupEvent("群聊1", "215204", new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png"));
            CommonEvent.EmitAddNewGroupEvent("群聊2", "537783", new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png"));
            CommonEvent.EmitAddNewGroupEvent("群聊3", "5664563", new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png"));
            CommonEvent.EmitAddNewGroupEvent("群聊4", "2456556", new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png"));
            CommonEvent.EmitAddNewGroupEvent("群聊5", "21525647", new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png"));
            CommonEvent.EmitAddNewGroupEvent("群聊6", "21525383", new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png"));
            CommonEvent.EmitAddNewGroupEvent("群聊7", "215335613", new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png"));
            CommonEvent.EmitAddNewGroupEvent("群聊8", "215368813", new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png"));
            CommonEvent.EmitAddNewGroupEvent("群聊9", "215863563", new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png"));
            CommonEvent.EmitAddNewGroupEvent("群聊10", "21553855", new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png"));


            CommonEvent.EmitAddNewFriendMessageEvent("7317227@qq.com", "你好1", "2018-10-08 21:50:22");
            CommonEvent.EmitAddNewFriendMessageEvent("7317227@qq.com", "你好2", "2018-10-08 21:50:23");
            CommonEvent.EmitAddNewGroupMessageEvent("好友1", "7317227@qq.com", "你好1", "2018-10-08 21:50:21", new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png"), "215204");
            CommonEvent.EmitAddNewGroupMessageEvent("好友2", "7317227@qq.com", "你好2", "2018-10-08 21:50:22", new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png"), "215204");

            //好友2不在线
            CommonEvent.EmitOnlineChangeEvent("7317227@qq.com", false);
            //好友3不在线
            CommonEvent.EmitOnlineChangeEvent("2870538@qq.com", false);
        }

        /// <summary>
        /// 添加好友/群组控件
        /// kind:类型识别符
        /// name:昵称
        /// account:账户
        /// imagePath:图像
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="name"></param>
        /// <param name="account"></param>
        /// <param name="imagePath"></param>
        private void AddControl(int kind, string name, string account,string imagePath= "initImage.png",bool isOnline=true)
        {
            if(kind!=1&&kind!=2)
            {
                MessageBox.Show("接收到的\"添加好友 / 群组控件\"消息格式不正确");
                return;
            }
            Bitmap userImage = new Bitmap(System.Environment.CurrentDirectory + "\\" + imagePath);
            AddControl(kind, name, account, userImage, isOnline);
        }

        /// <summary>
        /// 添加好友/群组控件
        /// kind:类型识别符
        /// name:昵称
        /// account:账户
        /// image:图像
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="name"></param>
        /// <param name="account"></param>
        /// <param name="image"></param>
        private void AddControl(int kind, string name, string account, Bitmap userImage, bool isOnline = true)
        {
            if (kind != 1 && kind != 2)
            {
                MessageBox.Show("接收到的\"添加好友 / 群组控件\"消息格式不正确");
                return;
            }
            //加入好友或者群信息
            DownForm.connectTabForm.AddControl(kind, name, account, userImage, isOnline);
        }

        /// <summary>
        /// 添加消息控件
        /// </summary>
        /// <param name="kind">类型识别符</param>
        /// <param name="name">好友/群聊昵称</param>
        /// <param name="account">好友账户</param>
        /// <param name="message">消息内容</param>
        /// <param name="time">发送时间</param>
        /// <param name="imagePath">好友图像</param>
        /// <param name="ID">当表示群消息的时候为群号，表示好友消息的时候与发送账号同号,此时可用空串表示</param>
        /// <param name="isOnline">是否在线</param>
        private void AddControl(int kind, string name, string account, string message, string time, string imagePath= "initImage.png",string ID="",bool isOnline=true)
        {
            if (kind != 3)
            {
                MessageBox.Show("接收到的\"添加消息\"消息格式不正确");
                return;
            }
            if(imagePath=="")
            {
                imagePath = "initImage.png";
            }

            if (ID == "")
            {
                ID = account;
            }

            Bitmap userImage = new Bitmap(System.Environment.CurrentDirectory + "\\" + imagePath);
            AddControl(kind, name, account, message, time, new Bitmap(imagePath), ID,isOnline);
        }

        /// <summary>
        /// 添加消息控件,提供调用
        /// </summary>
        /// <param name="kind">类型识别符</param>
        /// <param name="name">好友昵称</param>
        /// <param name="account">好友账户</param>
        /// <param name="message">消息内容</param>
        /// <param name="time">发送时间</param>
        /// <param name="userImage">好友图像</param>
        /// <param name="ID">当表示群消息的时候为群号，表示好友消息的时候与发送账号同号</param>
        /// <param name="isOnline">是否在线</param>
        private void AddControl(int kind, string name,string account, string message, string time, Bitmap userImage, string ID="", bool isOnline=true)
        {
            if (kind != 3)
            {
                MessageBox.Show("接收到的\"添加消息\"消息格式不正确");
                return;
            }

            if (ID == "")
            {
                ID = account;
            }

            string idName = "";
            if(ID.EndsWith(".com"))
            {
                idName = name;
            }
            else
            {
                idName = (MessageBirdCommon.UserInformation.GetGroupObject(ID) as GroupShowForm.GroupShowForm).UserName;
            }

            //加入消息
            DownForm.messageForm.AddControl(kind,idName , ID, message, time, userImage,isOnline);
            this.chatForm.EmitReceiveNewsEvent(account, userImage,ID, message, name,time);
            ////新消息提醒
            ShowNews();
        }

        /// <summary>
        /// 绑定主界面和登录界面的事件
        /// </summary>
        private void ConnectEvent()
        {
            //实现拖动
            this.UpForm.MouseMoveEvent += MainForm_MouseMove;
            this.UpForm.MouseDownEvent += MainForm_MouseDown;
            this.UpForm.RequestForSearchEvent += UpForm_RequestForSearch;
            this.UpForm.RequestForSearchFormEvent += UpForm_RequestForSearchFormEvent;
            this.UpForm.GiveUpSearchFormEvent += UpForm_GiveUpSearchFormEvent;
            //初始化时隐藏界面
            this.Load += MainForm_Load;
            //实现关闭和最小化功能
            this.UpForm.CloseButton.Click += CloseButton_Click;
            this.UpForm.MixButton.Click += MixButton_Click;
            //登录窗口联带关闭主窗体
            signInForm.CloseButton.Click += CloseButton_Click;
            //实现登录窗体切换
            signInForm.FinishSignIn += SignInForm_FinishSignIn;
            ShowNewsTimer.Tick += ShowNewsTimer_Tick;
        }

        private void UpForm_RequestForSearchFormEvent()
        {
            this.DownForm.ChangeToSearchForm();
        }

        private void UpForm_GiveUpSearchFormEvent()
        {
            this.DownForm.ChangeToGroupForm();
        }

        /// <summary>
        /// 触发搜索界面
        /// </summary>
        /// <param name="obj"></param>
        private void UpForm_RequestForSearch(string obj)
        {
            this.DownForm.RunSearch(obj);
        }

        /// <summary>
        /// 程序右下角图标闪烁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowNewsTimer_Tick(object sender, EventArgs e)
        {
            //尚未登录，不接受消息
            if(this.BottomRightIcon.Icon == GrayIcon)
            {
                return;
            }

            //用户已经打开应用，停止闪烁
            if (this.WindowState != FormWindowState.Minimized)
            {
                ShowNewsTimer.Enabled = false;
                this.BottomRightIcon.Icon = BlueIcon;
            }
            else if (this.BottomRightIcon.Icon== BlueIcon)
            {
                this.BottomRightIcon.Icon = SpaceIcon;
            }
            else
            {
                this.BottomRightIcon.Icon = BlueIcon;
            }
            
        }

        /// <summary>
        /// 添加好友/群聊、新建群聊
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SoftwareConfigButton_Click(object sender, EventArgs e)
        {
            if(applyForm==null)
            {
                applyForm = new ApplyForm();
                applyForm.FormClosed += ApplyForm_FormClosed;
                applyForm.Visible = true;
            }
        }

        /// <summary>
        /// 好友/群聊申请界面关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            applyForm = null;
        }

        /// <summary>
        /// 添加群/好友
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFriendButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 最小化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MixButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 关闭主窗体事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>    
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.BottomRightIcon.Dispose();
            this.Close();
            System.Environment.Exit(0);
        }

        /// <summary>
        /// 主界面登录准备，包含主界面隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            this.ShowInTaskbar = false;
        }

        /// <summary>
        /// 主界面拖动实现模块
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += (e.Location.X - FormX);
                this.Top += (e.Location.Y - FormY);
                return;
            }
        }

        /// <summary>
        /// 主界面拖动实现模块
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.FormX = e.X;
                this.FormY = e.Y;
                return;
            }
        }

        /// <summary>
        /// 点击气泡图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BottomRightIcon_Click(object sender, EventArgs e)
        {
            if (this.BottomRightIcon.Icon != GrayIcon)
            {
                this.BottomRightIcon.Icon = BlueIcon;
                this.WindowState = FormWindowState.Normal;
                this.Show();
                this.ShowNewsTimer.Enabled = false;
            }
        }

        private int FormX = 0;
        private int FormY = 0;
        private System.Windows.Forms.Timer ShowNewsTimer = null;
        private Icon GrayIcon = new Icon(System.Environment.CurrentDirectory + "\\Pictures\\Icons\\App3.ico");
        private Icon BlueIcon=new Icon(System.Environment.CurrentDirectory + "\\Pictures\\Icons\\App1.ico");
        private Icon SpaceIcon = new Icon(System.Environment.CurrentDirectory + "\\Pictures\\Icons\\space.ico");
        private SignIn signInForm=null;
        private ChatForm chatForm = null;
        bool AcceptNews = false;
        ApplyForm applyForm=null;
        
    }
}
