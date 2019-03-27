using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessageBirdCommonClass;

namespace GroupShowEasyForm
{
    public partial class GroupShowEasyForm: UserControl
    {
        public GroupShowEasyForm(string userName,Bitmap userImage=null)
        {
            
            InitializeComponent();
            DefineEvent();

            //定义滑过变色
            this.MouseEnterEvent += GroupShowEasyForm_MouseEnterEvent;
            this.MouseLeaveEvent += GroupShowEasyForm_MouseLeaveEvent;
            this.UserNameLabel.Text = userName;
            if(userImage==null)
            {
                userImage= new Bitmap(System.Environment.CurrentDirectory + "//initImage.png");
            }
            this.ImagePictureBox.BackgroundImage = userImage;
        }

        /// <summary>
        /// 鼠标滑过变色实现模块
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupShowEasyForm_MouseLeaveEvent(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        /// <summary>
        /// 鼠标滑过变色实现模块
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupShowEasyForm_MouseEnterEvent(object sender, EventArgs e)
        {
             this.BackColor = SystemColors.Control;
        }

        /// <summary>
        /// 自定义事件
        /// </summary>
        private void DefineEvent()
        {
            //定义鼠标离开事件
            CreateMouseLeaveEvent();
            //定义鼠标进入事件
            CreateMouseEnterEvent();
        }

        /// <summary>
        /// 定义鼠标离开事件
        /// </summary>
        private void CreateMouseLeaveEvent()
        {
            this.MouseLeave += GroupShowEasyForm_MouseLeave;
            this.ImagePictureBox.MouseLeave+= GroupShowEasyForm_MouseLeave;
            this.UserNameLabel.MouseLeave += GroupShowEasyForm_MouseLeave;
        }

        /// <summary>
        /// 定义鼠标进入事件
        /// </summary>
        private void CreateMouseEnterEvent()
        {
            this.MouseEnter += GroupShowEasyForm_MouseEnter;
            this.ImagePictureBox.MouseEnter += GroupShowEasyForm_MouseEnter;
            this.UserNameLabel.MouseEnter += GroupShowEasyForm_MouseEnter;
        }

        /// <summary>
        /// 触发鼠标进入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupShowEasyForm_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterEvent(this, e);
        }

        /// <summary>
        /// 触发鼠标离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupShowEasyForm_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent(this, e);
        }

        /// <summary>
        /// 鼠标进入事件
        /// </summary>
        public event EventHandler MouseEnterEvent;

        /// <summary>
        /// 鼠标离开事件
        /// </summary>
        public event EventHandler MouseLeaveEvent;
    }
}
