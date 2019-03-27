using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using MessageBirdCommonClass;
using System.IO;


namespace GroupShowForm
{
    ///// <summary>
    ///// 列表状态改变,已经被替代
    ///// </summary>
    ///// <param name="o"></param>
    //public delegate void GroupFormStatusChange(object o);

    /// <summary>
    /// 显示好友或者群的列表块
    /// kind为1~3：好友、群聊、消息模块 ----MainDownForm内部信息控件
    /// kind为4~5：好友、群聊、消息模块 ----Mainform.ChatForm左部控件
    /// </summary>
    public partial class GroupShowForm: UserControl
    {
        /// <summary>
        /// 不能成功使用含有参数的构造函数，故调用SetInformation函数初始化
        /// </summary>
        public GroupShowForm()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            CreateEvent();
            this.ToUpItem.Click += ToUp_Click;
            //this.DeleteItem.Click += DeleteItem_Click;
            this.Open.Click += Open_Click;
            this.MouseEnterEvent += GroupShowForm_MouseEnterEvent;
            this.MouseLeaveEvent += GroupShowForm_MouseLeaveEvent;
            this.DoubleClickEvent += GroupShowForm_DoubleClickEvent;

            //绑定数据改变事件
            this.AccountChangeEvent += GroupShowForm_AccountChangeEvent;
            this.UserNameChangeEvent += GroupShowForm_UserNameChangeEvent;
            this.TimeChangeEvent += GroupShowForm_TimeChangeEvent;
            //this.ImageChangeEvent += GroupShowForm_ImageChangeEvent;
            this.NumberChangeEvent += GroupShowForm_NumberChangeEvent;
            this.MessageChangeEvent += GroupShowForm_MessageChangeEvent;

            this.NumberPanel.Paint += NumberPanel_Paint;
            this.ClickEvent += (o,e)=> { };
            this.DoubleClick += (o, e) => { };
            this.RequestChatEvent += (o) => { };
        }

        /// <summary>
        /// 打开聊天框
        /// </summary>
        /// <param name="o"></param>
        private void GroupShowForm_DoubleClickEvent(object sender, EventArgs e)
        {
            if (Kind == 1)
            {
                //打开好友聊天
                RequestChatEvent(this);
            }
            else if (Kind == 2)
            {
                //打开群聊
                RequestChatEvent(this);
            }
            else if (Kind == 3)
            {
                //打开新消息
                this.Number = 0;
                this.GroupNumberLabel.Text = "";
                //回复消息
                RequestChatEvent(this);
            }
            else
            {
                //不执行操作；
            }
        }

        /// <summary>
        /// 设置在线状态显示
        /// </summary>
        /// <param name="status"></param>
        public void ShowOnlineStatus(bool status)
        {
            if(status==true)
            {
                this.GroupNameLabel.ForeColor = Color.Black;
            }
            else
            {
                this.GroupNameLabel.ForeColor = Color.Salmon;
            }
        }

        /// <summary>
        /// 绘制新消息数目特效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberPanel_Paint(object sender, PaintEventArgs e)
        {
            if(this.Kind!=3 || this.GroupNumberLabel.Text == "")
            {
                return;
            }
            int numberWidth = this.NumberPanel.Width;
            int numberHeight = this.NumberPanel.Height;
            SolidBrush bursh = new SolidBrush(Color.Red);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //e.Graphics.DrawEllipse(new Pen(bursh), 0, 0, numberWidth-1,numberHeight-1);
            e.Graphics.FillEllipse(bursh, 0, 0, numberWidth - 1, numberHeight - 1);

        }

        /// <summary>
        /// 返回类中信息是否含有关键字
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public bool HasKeywords(string keyWord)
        {
            return this.information.HasKeywords(keyWord);
        }

        /// <summary>
        /// 加入显示信息事件
        /// </summary>
        /// <param name="o"></param>
        private void GroupShowForm_MessageChangeEvent(object o)
        {
            if(Kind==3)
            {
                this.GroupAccountLabel.Text = Message;
            }
            else
            {
                this.GroupAccountLabel.Text = Account;
            }
        }

        /// <summary>
        /// 加入显示图像事件
        /// </summary>
        /// <param name="o"></param>
        private void GroupShowForm_ImageChangeEvent(object o)
        {
            this.GroupImagePictureBox.BackgroundImage = UserImage;
        }

        /// <summary>
        /// 加入显示日期事件事件
        /// </summary>
        /// <param name="o"></param>
        private void GroupShowForm_TimeChangeEvent(object o)
        {
            this.GroupTimeLabel.Text = Time;
        }

        /// <summary>
        /// 加入显示昵称时间
        /// </summary>
        /// <param name="o"></param>
        private void GroupShowForm_UserNameChangeEvent(object o)
        {
            this.GroupNameLabel.Text = UserName;
        }

        /// <summary>
        /// 加入显示账户事件
        /// </summary>
        /// <param name="o"></param>
        private void GroupShowForm_AccountChangeEvent(object o)
        {
            if (Kind == 3)
            {
                this.GroupAccountLabel.Text = Message;
            }
            else if(information.Kind ==4 || information.Kind == 5 || information.Kind == 6)
            {
                this.GroupAccountLabel.ForeColor = Color.White;
                if(information.Account.Length > 8)
                {
                    this.GroupAccountLabel.Text = Account.Substring(0, 8) + "..";
                }
                else
                {
                    this.GroupAccountLabel.Text = Account;
                }
            }
            else
            {
                this.GroupAccountLabel.Text = Account;
            }
        }

        /// <summary>
        /// 显示消息数目
        /// </summary>
        /// <param name="o"></param>
        private void GroupShowForm_NumberChangeEvent(object o)
        {
            if(this.Number<1)
            {
                this.GroupNumberLabel.Text = "";
            }
            else if(this.Number>=1 &&this.Number<100)
            {
                this.GroupNumberLabel.Text = this.Number.ToString();
            }
            else
            {
                this.GroupNumberLabel.Text = "**";
            }
            this.NumberPanel.Refresh();
        }

        /// <summary>
        /// 控件颜色变白
        /// </summary>
        /// <param name="o"></param>
        private void GroupShowForm_MouseLeaveEvent(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        /// <summary>
        /// 控件颜色变暗，并获取焦点
        /// </summary>
        /// <param name="o"></param>
        private void GroupShowForm_MouseEnterEvent(object sender, EventArgs e)
        {
            if(this.Kind>=4)
            {
                this.BackColor = Color.FromArgb(114, 145, 210);
                
            }
            else
            {
                this.BackColor = SystemColors.Control;
            }
            this.Focus();
        }

        /// <summary>
        /// 自定义事件
        /// </summary>
        private void CreateEvent()
        {
            //自定义鼠标进入事件
            CreateMouseEnterEvent();
            //自定义鼠标离开事件
            CreaterMouseLeaveEvent();
            //自定义鼠标双击事件
            CreateDoubleClickEvent();
            //定义鼠标点击事件
            CreateClickEvent();
        }

        /// <summary>
        /// MouseEnterEvent事件模块
        /// </summary>
        private void CreateMouseEnterEvent()
        {
            this.MouseEnter += GroupShowForm_MouseEnter;
            this.RightPanel.MouseEnter += GroupShowForm_MouseEnter;
            this.GroupImagePictureBox.MouseEnter += GroupShowForm_MouseEnter;
            this.GroupNameLabel.MouseEnter += GroupShowForm_MouseEnter;
            this.GroupAccountLabel.MouseEnter += GroupShowForm_MouseEnter;
            this.LeftPanel.MouseEnter += GroupShowForm_MouseEnter;
            this.GroupImagePictureBox.MouseEnter += GroupShowForm_MouseEnter;
            this.GroupTimeLabel.MouseEnter += GroupShowForm_MouseEnter;
            this.GroupNumberLabel.MouseEnter += GroupShowForm_MouseEnter;
            this.NumberPanel.MouseEnter+= GroupShowForm_MouseEnter;
        }

        /// <summary>
        /// MouseLeaveEvent事件模块
        /// </summary>
        private void CreaterMouseLeaveEvent()
        {
            this.MouseLeave += GroupShowForm_MouseLeave;
            this.RightPanel.MouseLeave += GroupShowForm_MouseLeave;
            this.GroupImagePictureBox.MouseLeave += GroupShowForm_MouseLeave;
            this.GroupNameLabel.MouseLeave += GroupShowForm_MouseLeave;
            this.GroupAccountLabel.MouseLeave += GroupShowForm_MouseLeave;
            this.LeftPanel.MouseLeave += GroupShowForm_MouseLeave;
            this.GroupImagePictureBox.MouseLeave += GroupShowForm_MouseLeave;
            this.GroupTimeLabel.MouseLeave += GroupShowForm_MouseLeave;
            this.GroupNumberLabel.MouseLeave += GroupShowForm_MouseLeave;
            this.NumberPanel.MouseMove+= GroupShowForm_MouseLeave;
        }

        /// <summary>
        /// DoubleClickEvent事件模块
        /// </summary>
        private void CreateDoubleClickEvent()
        {
            this.DoubleClick += GroupShowForm_DoubleClick;
            this.RightPanel.DoubleClick += GroupShowForm_DoubleClick;
            this.GroupImagePictureBox.DoubleClick += GroupShowForm_DoubleClick;
            this.GroupNameLabel.DoubleClick += GroupShowForm_DoubleClick;
            this.GroupAccountLabel.DoubleClick += GroupShowForm_DoubleClick;
            this.LeftPanel.DoubleClick += GroupShowForm_DoubleClick;
            this.GroupImagePictureBox.DoubleClick += GroupShowForm_DoubleClick;
            this.GroupTimeLabel.DoubleClick += GroupShowForm_DoubleClick;
            this.GroupNumberLabel.DoubleClick += GroupShowForm_DoubleClick;
            this.NumberPanel.DoubleClick += GroupShowForm_DoubleClick;
        }

        /// <summary>
        /// ClickEvent事件模块
        /// </summary>
        private void CreateClickEvent()
        {
            this.Click += GroupShowForm_Click;
            this.RightPanel.Click += GroupShowForm_Click;
            this.GroupImagePictureBox.Click += GroupShowForm_Click;
            this.GroupNameLabel.Click += GroupShowForm_Click;
            this.GroupAccountLabel.Click += GroupShowForm_Click;
            this.LeftPanel.Click += GroupShowForm_Click;
            this.GroupImagePictureBox.Click += GroupShowForm_Click;
            this.GroupTimeLabel.Click += GroupShowForm_Click;
            this.GroupNumberLabel.Click += GroupShowForm_Click;
            this.NumberPanel.Click += GroupShowForm_Click;
        }

        /// <summary>
        /// 初始化块类别、信息等,此函数适用于：好友/群组显示
        /// kind=1/4表示好友，kind=2/5表示群组, kind=3/6表示消息
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="Name"></param>
        /// <param name="Account"></param>
        /// <param name="ImagePath"></param>
        public void SetInformation(int kind,string name, string account, Bitmap userImage,bool isOnline=true)
        {
            this.Kind = kind;
            this.Account = account;
            this.UserName = name;
            if(userImage!=null)
            {
                this.UserImage =userImage;
            }
            else
            {
                this.UserImage = null;
            }
            //在全局注册
            //RequestRegistEvent(this);
            this.IsOnline = isOnline;
        }

        /// <summary>
        /// 初始化块类别、信息等,此函数适用于：消息显示
        /// kind=1/4表示好友，kind=2/5表示群组, kind=3/6表示消息
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="Name"></param>
        /// <param name="Account"></param>
        /// <param name="ImagePath"></param>
        public void SetInformation(int kind, string name, string account,string message,string time, Bitmap userImage,bool isOnline=true)
        {
            this.Kind = kind;
            this.Account = account;
            this.UserName = name;
            this.Message = message;
            this.Time = time;
            this.UserImage = userImage;
            //在全局注册
            //RequestRegistEvent(this);
            this.IsOnline = isOnline;
        }

        /// <summary>
        /// 鼠标进入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupShowForm_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterEvent(this,e);
        }

        /// <summary>
        /// 鼠标离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupShowForm_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent(this,e);
        }

        /// <summary>
        /// 双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupShowForm_DoubleClick(object sender, EventArgs e)
        {
            DoubleClickEvent(this,e);
        }

        /// <summary>
        /// 点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupShowForm_Click(object sender, EventArgs e)
        {
            ClickEvent(this, e);
        }

        /// <summary>
        /// 右键打开会话
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open_Click(object sender, EventArgs e)
        {
            if(information.Kind <=3)
            {
                DoubleClickEvent(this, e);
            }
            else
            {
                ClickEvent(this, e);
            }
        }


        /// <summary>
        /// 主动触发单击事件
        /// </summary>
        public void OnClick()
        {
            ClickEvent(this, new EventArgs());
        }


        /// <summary>
        /// 右键删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteItem_Click(object sender, EventArgs e)
        {
            DeleteEvent(this);
        }

        /// <summary>
        /// 右键置顶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToUp_Click(object sender, EventArgs e)
        {
            ToUpEvent(this);
        }

        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupShowForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyData==Keys.O)
            {
                this.OnDoubleClick(e);
            }
            else if(e.KeyData==Keys.Delete)
            {
                DeleteEvent(this);
            }
            else if(e.Alt && e.KeyData==Keys.Up)
            {
                ToUpEvent(this);
            }
        }

        /// <summary>
        /// 消息数目属性封装，触发改变事件
        /// </summary>
        public int Number
        {
            get => number;
            set
            {
                number = value;
                NumberChangeEvent(this);
            }
        }

        /// <summary>
        /// 控件种类，1：好友 2：群组 3：消息
        /// </summary>
        public int Kind{get => information.Kind;set => information.Kind = value;}

        /// <summary>
        /// 邮箱,触发AccountChangeEvent事件
        /// </summary>
        public string Account
        {
            get => information.Account;
            set { information.Account = value; AccountChangeEvent(this); }
        }

        /// <summary>
        /// 昵称,触发UserNameChangeEvent事件
        /// </summary>
        public string UserName
        {
            get => information.UserName;
            set { information.UserName = value; UserNameChangeEvent(this); }
        }

        /// <summary>
        /// 消息内容,触发MessageChangeEvent事件
        /// </summary>
        public string Message
        {
            get => information.Message;
            set { information.Message = value; MessageChangeEvent(this); }
        }

        /// <summary>
        /// 接收消息的时间（通常针对消息控件),触发TimeChangeEvent事件
        /// </summary>
        public string Time
        {
            get => information.Time;
            set { information.Time = value; TimeChangeEvent(this); }
        }

        /// <summary>
        /// 封装用户图像
        /// </summary>
        public Bitmap UserImage
        {
            get => information.UserImage;
            set
            {
                information.UserImage = value;
                this.GroupImagePictureBox.BackgroundImage = information.UserImage;
            }
        }

        /// <summary>
        /// 在线状态封装,会主动显示控件颜色变化
        /// </summary>
        public bool IsOnline
        {
            get => information.IsOnline;
            set
            {
                information.IsOnline = value;
                //触发状态改变事件
                ShowOnlineStatus(value);
            }
        }

        /// <summary>
        /// 修改在线状态，不会主动显示控件颜色变化
        /// </summary>
        public bool IsOnlineUnsafe
        {
            get => information.IsOnline;
            set => information.IsOnline = value;
        }

        /// <summary>
        /// 置顶事件
        /// </summary>
        public event Action<object> ToUpEvent;
        /// <summary>
        /// 删除事件
        /// </summary>
        public event Action<object> DeleteEvent;
        /// <summary>
        /// 消息数目改变事件
        /// </summary>
        public event Action<object> NumberChangeEvent;
        /// <summary>
        /// 账户邮箱改变事件
        /// </summary>
        public event Action<object> AccountChangeEvent;
        /// <summary>
        /// 昵称改变事件
        /// </summary>
        public event Action<object> UserNameChangeEvent;
        ///// <summary>
        ///// 请求注册事件
        ///// </summary>
        //public event Action<object> RequestRegistEvent;
        /// <summary>
        /// 消息改变事件
        /// </summary>
        public event Action<object> MessageChangeEvent;
        /// <summary>
        /// 消息改变事件
        /// </summary>
        public event Action<object> TimeChangeEvent;
        /// <summary>
        /// 加入聊天事件
        /// </summary>
        public event Action<object> RequestChatEvent;
        ///// <summary>
        ///// 在线状态改变事件
        ///// </summary>
        //public event GroupFormStatusChange OnlineStatusChangeEvent;

        /// <summary>
        /// 双击事件
        /// </summary>
        public event EventHandler DoubleClickEvent;
        /// <summary>
        /// 点击事件
        /// </summary>
        public event EventHandler ClickEvent;
        /// <summary>
        /// 鼠标进入事件
        /// </summary>
        public event EventHandler MouseEnterEvent;
        /// <summary>
        /// 鼠标离开事件
        /// </summary>
        public event EventHandler MouseLeaveEvent;

        public MessageInformation information = new MessageInformation();
        private int number = 0;
        private Panel newsPanel =new Panel();

    }
}
