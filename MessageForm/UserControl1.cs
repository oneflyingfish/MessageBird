using System;
using System.Drawing;
using System.Windows.Forms;
using GroupShowForm;
using MessageBirdCommon;

namespace MessageForm
{
    public partial class MessageForm: UserControl
    {
        /// <summary>
        /// 消息界面默认构造函数
        /// </summary>
        public MessageForm()
        {
            InitializeComponent();
            this.Paint += MessageForm_Paint;
        }

        /// <summary>
        /// 绘制暗白色线条，仅为了美观
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Gainsboro), 0, 0, Width, 0);
        }

        /// <summary>
        /// 添加消息控件,并且绑定相关事件
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="name"></param>
        /// <param name="account"></param>
        /// <param name="message"></param>
        /// <param name="time"></param>
        /// <param name="imagePath"></param>
        public void AddControl(int kind , string name, string account, string message, string time,Bitmap userImage,bool isOnline)
        {
            GroupShowForm.GroupShowForm groupShowForm=null;
            if (kind!=3)
            {
                MessageBox.Show("消息分组错误");
                return;
            }
            for(int i=0;i<this.Controls.Count;i++)
            {
                groupShowForm = this.Controls[i] as GroupShowForm.GroupShowForm;
                if(groupShowForm.Account==account)
                {
                    this.Controls.Remove(groupShowForm);
                    break;
                }
                groupShowForm = null;
            }
            if(groupShowForm==null)
            {
                groupShowForm = new GroupShowForm.GroupShowForm();
                groupShowForm.ToUpEvent += GroupShowForm_ToUpEvent;
                groupShowForm.DeleteEvent += GroupShowForm_DeleteEvent;
                groupShowForm.Dock = DockStyle.Top;
                groupShowForm.RequestChatEvent += GroupShowForm_RequestChatEvent;
            }

            //全局注册
            UserInformation.MessageInformation.Add(groupShowForm);

            //更新显示内容
            groupShowForm.SetInformation(3, name, account, message,time, userImage,isOnline);
            //此账户消息数目加一
            groupShowForm.Number++;
            this.Controls.Add(groupShowForm);
        }

        /// <summary>
        /// 触发内部消息控件触发聊天事件(事件上抛）
        /// </summary>
        /// <param name="o"></param>
        private void GroupShowForm_RequestChatEvent(object o)
        {
            RequestChat(o);
        }

        /// <summary>
        /// 执行删除
        /// </summary>
        /// <param name="o"></param>
        private void GroupShowForm_DeleteEvent(object o)
        {
            GroupShowForm.GroupShowForm groupShowForm = o as GroupShowForm.GroupShowForm;
            this.Controls.Remove(groupShowForm);

            UserInformation.RemoveMessageInformation(groupShowForm.Account);
        }

        /// <summary>
        /// 执行消息置顶
        /// </summary>
        /// <param name="o"></param>
        private void GroupShowForm_ToUpEvent(object o)
        {
            GroupShowForm.GroupShowForm groupShowForm = o as GroupShowForm.GroupShowForm;
            this.Controls.Remove(groupShowForm);
            this.Controls.Add(groupShowForm);
            groupShowForm.Dock = DockStyle.Top;
        }

        public event Action<object> RequestChat;
    }
}
