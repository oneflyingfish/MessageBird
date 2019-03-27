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
using MessageBirdCommon;

namespace ConnectTabForm
{
    public partial class ConnectTabForm : UserControl
    {
        public ConnectTabForm()
        {
            InitializeComponent();
            this.Paint += ConnectTabForm_Paint;
        }

        /// <summary>
        /// 绘制暗白色的线条，仅起到美观作用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectTabForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Gainsboro), 0, 0, Width, 0);
        }

        /// <summary>
        /// 增加显示好友/群组
        /// kind默认值为0, kind=1表示好友，kind=2表示群组
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="Name"></param>
        /// <param name="Number"></param>
        /// <param name="ImagePath"></param>
        public void AddControl(int kind, string name, string account , Bitmap userImage,bool isOnline)
        {
            TabPage tabForm = null;
            GroupShowForm.GroupShowForm groupShowForm = new GroupShowForm.GroupShowForm();
            groupShowForm.SetInformation(kind, name, account, userImage, isOnline);
            groupShowForm.RequestChatEvent += GroupShowForm_RequestChatEvent;
            //判断父控件   
            if (kind == 1)
            {
                tabForm = this.FriendTab;
                groupShowForm.ToUpEvent += new Action<object>(GroupShowForm_FriendToUpEvent);
                groupShowForm.DeleteEvent += new Action<object>(GroupShowForm_FriendDeleteEvent);
                UserInformation.FriendsInformation.Add(groupShowForm);

            }
            else if (kind == 2)
            {
                tabForm = this.GroupTab;
                groupShowForm.ToUpEvent += new Action<object>(GroupShowForm_GroupToUpEvent);
                groupShowForm.DeleteEvent += new Action<object>(GroupShowForm_GroupDeleteEvent);
                UserInformation.GroupsInformation.Add(groupShowForm);
            }
            else
            {
                MessageBox.Show("群组错误");
                return;
            }
            //添加控件
            tabForm.Controls.Add(groupShowForm);
            groupShowForm.Dock = DockStyle.Top;
        }

        /// <summary>
        /// 请求聊天事件（事件上抛)
        /// </summary>
        /// <param name="o"></param>
        private void GroupShowForm_RequestChatEvent(object o)
        {
            RequestChat(o);
        }

        /// <summary>
        /// 好友置顶
        /// </summary>
        /// <param name="o"></param>
        private void GroupShowForm_FriendToUpEvent(object o)
        {
            GroupShowForm.GroupShowForm groupShowForm = o as GroupShowForm.GroupShowForm;
            this.FriendTab.Controls.Remove(groupShowForm);
            this.FriendTab.Controls.Add(groupShowForm);
            groupShowForm.Dock = DockStyle.Top;
        }

        /// <summary>
        /// 删除好友
        /// </summary>
        /// <param name="o"></param>
        private void GroupShowForm_FriendDeleteEvent(object o)
        {
            GroupShowForm.GroupShowForm groupShowForm = o as GroupShowForm.GroupShowForm;
            this.FriendTab.Controls.Remove(groupShowForm);

            //删除全局记录
            MessageBirdCommon.UserInformation.RemoveFriendsInformation(groupShowForm.Account);

        }

        /// <summary>
        /// 群置顶
        /// </summary>
        /// <param name="o"></param>
        private void GroupShowForm_GroupToUpEvent(object o)
        {
            GroupShowForm.GroupShowForm groupShowForm = o as GroupShowForm.GroupShowForm;
            this.GroupTab.Controls.Remove(groupShowForm);
            this.GroupTab.Controls.Add(groupShowForm);
            groupShowForm.Dock = DockStyle.Top;
        }

        /// <summary>
        /// 退群
        /// </summary>
        /// <param name="o"></param>
        private void GroupShowForm_GroupDeleteEvent(object o)
        {
            GroupShowForm.GroupShowForm groupShowForm = o as GroupShowForm.GroupShowForm;
            this.GroupTab.Controls.Remove(groupShowForm);
            //删除全局记录
            MessageBirdCommon.UserInformation.RemoveGroupsInformation(groupShowForm.Account);
        }

        public event Action<object> RequestChat;
    } 
}
