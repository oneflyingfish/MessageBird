using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainFormUpForm
{
    public partial class MainFormUpForm: UserControl
    {
        public MainFormUpForm()
        { 
            InitializeComponent();
            CreateEvent();
            this.SearchTextBox.GotFocus += SearchTextBox_GotFocus;
            this.SearchTextBox.LostFocus += SearchTextBox_LostFocus;
            //this.SearchTextBox.TextChanged += SearchTextBox_TextChanged;
            this.SearchBoxIcon.Click += SearchBoxIcon_Click;
        }

        /// <summary>
        /// 自定义事件
        /// </summary>
        private void CreateEvent()
        {
            //定义MouseDownEvent
            CreateMouseDownEvent();
            //定义MouseMoveEvent
            CreateMouseMoveEvent();
            this.MouseDownEvent += (o, e) => { };
            this.MouseMoveEvent += (o, e) => { };
            this.RequestForSearchFormEvent += () => { };
            this.GiveUpSearchFormEvent += () => { };
            this.RequestForSearchEvent += (o) => { };
        }

        /// <summary>
        /// 搜索框获取焦点，开始搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBox_GotFocus(object sender, EventArgs e)
        {
            this.SearchTextBox.ForeColor = Color.Black;
            if(this.SearchTextBox.Text == "搜索")
            {
                this.SearchTextBox.Text = "";
            }
            //触发搜索事件
            this.exitButton.Visible = true;
            RequestForSearchFormEvent();
        }

        ///// <summary>
        ///// 触发搜索事件
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void SearchTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    RequestForSearchFormEvent(this.SearchTextBox.Text);
        //}


        /// <summary>
        /// 搜索框失去焦点，放弃搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBox_LostFocus(object sender, EventArgs e)
        {
            this.SearchTextBox.ForeColor = SystemColors.InactiveCaption;
            if (this.SearchTextBox.Text == "")
            {
                this.SearchTextBox.Text = "搜索";
            }
        }

        /// <summary>
        /// 退出搜索界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton_Click(object sender, EventArgs e)
        {
            GiveUpSearchFormEvent();
            this.exitButton.Visible = false;
        }

        /// <summary>
        /// 定义MouseMoveEvent事件
        /// </summary>
        private void CreateMouseMoveEvent()
        {
            this.MouseMove += MainFormUpForm_MouseMove;
            this.UpPanel.MouseMove += MainFormUpForm_MouseMove;
            this.UserNameLabel.MouseMove += MainFormUpForm_MouseMove;
            this.EmailLabel.MouseMove += MainFormUpForm_MouseMove;
            this.AppIconPictureBox.MouseMove+= MainFormUpForm_MouseMove;
        }

        /// <summary>
        /// 定义MouseDownEvent事件
        /// </summary>
        private void CreateMouseDownEvent()
        {
            this.MouseDown += MainFormUpForm_MouseDown;
            this.UpPanel.MouseDown += MainFormUpForm_MouseDown;
            this.UserNameLabel.MouseDown += MainFormUpForm_MouseDown;
            this.EmailLabel.MouseDown += MainFormUpForm_MouseDown;
            this.AppIconPictureBox.MouseDown += MainFormUpForm_MouseDown;
        }

        /// <summary>
        /// 窗体移动相关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFormUpForm_MouseDown(object sender,MouseEventArgs e)
        {
            MouseDownEvent(sender, e);
        }

        /// <summary>
        /// 窗体移动相关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFormUpForm_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMoveEvent(sender, e);
        }

        /// <summary>
        /// 开始搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBoxIcon_Click(object sender, EventArgs e)
        {
            RequestForSearchFormEvent();
            RequestForSearchEvent(this.SearchTextBox.Text);
        }

        /// <summary>
        /// 编辑框回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SearchBoxIcon.PerformClick();
            }
        }

        public event MouseEventHandler MouseDownEvent;
        public event MouseEventHandler MouseMoveEvent;
        public event Action RequestForSearchFormEvent;
        public event Action<string> RequestForSearchEvent;
        public event Action GiveUpSearchFormEvent;

        
    }
}
