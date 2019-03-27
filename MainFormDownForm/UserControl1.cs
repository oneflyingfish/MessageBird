using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GroupShowForm;

namespace MainFormDownForm
{
    public partial class MainFormDownForm : UserControl
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public MainFormDownForm()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        private void Init()
        {
            //MessageTimer = new Timer();
            //FriendTimer = new Timer();
            //MessageTimer.Interval = 500;
            //FriendTimer.Interval = 500;
            //MessageTimer.Enabled = false;
            //FriendTimer.Enabled = false;
            //MessageTimer.Tick += MessageTimer_Tick;
            //FriendTimer.Tick += FriendTimer_Tick;

            //初始化信息栏
            messageForm = new MessageForm.MessageForm();
            messageForm.RequestChat += MainFormDownForm_RequestChat;
            //初始化联系人
            connectTabForm = new ConnectTabForm.ConnectTabForm();
            connectTabForm.RequestChat += MainFormDownForm_RequestChat;
            //加入搜索界面
            showSearchForm = new ShowSearchForm.ShowSearchForm();
            showSearchForm.Dock = DockStyle.Fill;
            this.showSearchForm = new ShowSearchForm.ShowSearchForm();
            this.searchShowPanel = new Panel();
            searchShowPanel.Dock = DockStyle.Fill;
            this.searchShowPanel.AutoScroll = true;
            this.searchShowPanel.Controls.Add(this.showSearchForm);
            this.showSearchForm.RequestChatEvent+= MainFormDownForm_RequestChat;
        }

        /// <summary>
        /// 返回主界面
        /// </summary>
        private void ShowSearchForm_GiveUpSearchFormEvent()
        {
            this.ChangeToGroupForm();
        }

        /// <summary>
        /// 切换为搜索界面
        /// </summary>
        public void ChangeToSearchForm()
        {
            if(this.Controls.Contains(this.groupShowPanel))
            {
                this.Controls.Remove(this.groupShowPanel);
            }
            
            if(!this.Controls.Contains(this.searchShowPanel))
            {
                this.Controls.Add(this.searchShowPanel);
            }
        }

        /// <summary>
        /// 执行搜索功能
        /// </summary>
        public void RunSearch(string KeyWords)
        {
            this.showSearchForm.ClearControls();
            if (KeyWords == "" || KeyWords == "搜索")
            {
                return;
            }

            //this.showSearchForm.AddControlsToPanel(MessageBirdCommon.UserInformation.GetMessagesHasKeyWords(KeyWords), "消息列表");
            this.showSearchForm.AddControlsToPanel(MessageBirdCommon.UserInformation.GetGroupsHasKeyWords(KeyWords), "您加入的群");
            this.showSearchForm.AddControlsToPanel(MessageBirdCommon.UserInformation.GetFriendsHasKeyWords(KeyWords), "您的好友");
        }

        /// <summary>
        /// 切换回正常界面
        /// </summary>
        public void ChangeToGroupForm()
        {
            if (this.Controls.Contains(this.searchShowPanel))
            {
                this.Controls.Remove(this.searchShowPanel);
            }

            if (!this.Controls.Contains(this.groupShowPanel))
            {
                this.Controls.Add(this.groupShowPanel);
            }
        }

        /// <summary>
        /// 请求聊天
        /// </summary>
        /// <param name="o"></param>
        private void MainFormDownForm_RequestChat(object o)
        {
            RequestChat(o);
        }

        /// <summary>
        /// 鼠标滑过 消息/联系人 模块
        /// 变色效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupBox_MouseMove(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            button.ForeColor = Color.DodgerBlue;
        }

        /// <summary>
        /// 鼠标离开 消息/联系人 模块
        /// 变色效果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupBox_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.ForeColor = Color.Black;
        }

        /// <summary>
        /// 显示联系人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FriendGroupBox_Click(object sender, EventArgs e)
        {
            //控件已经存在
            if (DownPanel.Controls.Contains(connectTabForm))
            {
                return;
            }
            //删除原来的控件
            if (DownPanel.Controls.Contains(messageForm))
            {
                DownPanel.Controls.Remove(messageForm);
            }
            //添加新的控件
            DownPanel.Controls.Add(connectTabForm);
            connectTabForm.Dock = DockStyle.Fill;

        }

        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageGroupBox_Click(object sender, EventArgs e)
        {
            //控件已经存在
            if(DownPanel.Controls.Contains(messageForm))
            {
                return;
            }
            //删除原来的控件
            if(DownPanel.Controls.Contains(connectTabForm))
            {
                DownPanel.Controls.Remove(connectTabForm);
            }
            //添加新的控件
            DownPanel.Controls.Add(messageForm);
            messageForm.Dock = DockStyle.Fill;
        }

        //private Timer MessageTimer;
        //private Timer FriendTimer;
        //private bool havingMessage = false;
        //private bool havingNewFriend = false;
        public MessageForm.MessageForm messageForm=null;
        public ConnectTabForm.ConnectTabForm connectTabForm=null;
        public ShowSearchForm.ShowSearchForm showSearchForm = null;

        private System.Windows.Forms.Panel groupShowPanel=null;
        private Panel searchShowPanel = null;
        public event Action<object> RequestChat;




        ///// <summary>
        ///// 有新消息属性
        ///// </summary>
        //public bool HavingMessage
        //{
        //    get
        //    {
        //        return this.havingMessage;
        //    }
        //    set
        //    {
        //        if (value == true)
        //        {
        //            this.MessageGroupBox.ForeColor = Color.Red;
        //            MessageTimer.Enabled = true;
        //        }
        //        else
        //        {
        //            this.MessageGroupBox.ForeColor = Color.Black;
        //            MessageTimer.Enabled = false;
        //        }
        //    }
        //}

        ///// <summary>
        ///// 有新好友属性
        ///// </summary>
        //public bool HavingNewFriend
        //{
        //    get
        //    {
        //        return havingNewFriend;
        //    }
        //    set
        //    {
        //        if (value == true)
        //        {
        //            this.FriendGroupBox.ForeColor = Color.Red;
        //            FriendTimer.Enabled = true;
        //        }
        //        else
        //        {
        //            this.FriendGroupBox.ForeColor = Color.Black;
        //            FriendTimer.Enabled = false;
        //        }
        //    }
        //}

        ///// <summary>
        ///// 好友栏闪烁
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void FriendTimer_Tick(object sender, EventArgs e)
        //{
        //    if (this.FriendGroupBox.ForeColor == Color.Transparent)
        //    {
        //        this.FriendGroupBox.ForeColor = Color.Red;
        //    }
        //    else
        //    {
        //        this.FriendGroupBox.ForeColor = Color.Transparent;
        //    }
        //}

        ///// <summary>
        ///// 消息栏闪烁
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void MessageTimer_Tick(object sender, EventArgs e)
        //{
        //    if (this.MessageGroupBox.ForeColor == Color.Transparent)
        //    {
        //        this.MessageGroupBox.ForeColor = Color.Red;

        //    }
        //    else
        //    {
        //        this.MessageGroupBox.ForeColor = Color.Transparent;
        //    }
        //}
    }
}
