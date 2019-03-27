using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowNews
{
    public partial class ShowNewsOfYou: UserControl
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="news"></param>
        /// <param name="userImage"></param>
        /// <param name="userName"></param>
        public ShowNewsOfYou(string news = "", Bitmap userImage = null,string dateTime="", string userName = "")
        {
            InitializeComponent();
            this.newsLabel.SizeChanged += NewsLabel_SizeChanged;
            this.newsPanel.Paint += NewsPanel_Paint;
            SetInformation(news, userImage,dateTime,userName);
            times = (times + 1) % 6;//打印次数加一 
        }

        /// <summary>
        /// 绘制消息边框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewsPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            SolidBrush brush = new SolidBrush(System.Drawing.Color.SkyBlue);
            int radius = 5;
            int height = this.newsPanel.Height - 1;
            int width = this.newsPanel.Width - 1;
            graphics.FillEllipse(brush, 0, 0, radius * 2, radius * 2);                                              //左上角圆弧
            graphics.FillEllipse(brush, 0, height - radius * 2 - 1, radius * 2, radius * 2);                        //左下角圆弧
            graphics.FillEllipse(brush, width - radius * 2 - 1, 0, radius * 2, radius * 2);                         //右上角圆弧
            graphics.FillEllipse(brush, width - radius * 2 - 1, height - radius * 2 - 1, radius * 2, radius * 2);   //右下角圆弧
            graphics.FillRectangle(brush, radius, 0, width - radius * 2, height);                                   //竖的矩形
            graphics.FillRectangle(brush, 0, radius, width, height - radius * 2);                                   //横的矩形 
        }

        /// <summary>
        /// 设置界面信息
        /// </summary>
        /// <param name="news"></param>
        /// <param name="userImage"></param>
        /// <param name="account"></param>
        public void SetInformation(string news = "", Bitmap userImage = null,string dateTime="",string userName = "")
        {
            //至多30秒显示一次时间
            if (!((DateTime.Now - ShowNewsOfYou.timebefore).TotalSeconds > 30.0 || ShowNewsOfYou.times == 0))
            {
                dateTime = "";
            }
            ShowNewsOfYou.timebefore = DateTime.Now;

            this.datetimeLabel.Text = dateTime;
            //设置昵称
            if (userName != "")
            {
                nameLabel = new Label();
                nameLabel.Text = userName;
                nameLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                nameLabel.Dock = DockStyle.Top;
                nameLabel.ForeColor = System.Drawing.Color.Silver;
                nameLabel.BackColor = System.Drawing.Color.Transparent;
                nameLabel.AutoSize = false; //防止昵称换行
                this.middlePanel.Controls.Add(nameLabel);
            }

            //设置消息内容
            this.newsLabel.Text = news;

            //设置图像
            if (userImage != null)
            {
                this.userImagePictureBox.BackgroundImage = userImage;
            }
        }

        /// <summary>
        /// 窗体自适应大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewsLabel_SizeChanged(object sender, EventArgs e)
        {
            //设置高度
            int heigh = 0;
            if (nameLabel == null)
            {
                heigh = this.newsLabel.Height + 55;
            }
            else
            {
                heigh = this.newsLabel.Height + 55+ this.nameLabel.Height;
            }

            if (heigh < 80)
            {

                this.Height = 80;
            }
            else
            {
                this.Height = heigh;
            }
        }

        /// <summary>
        /// 显示昵称
        /// </summary>
        private Label nameLabel=null;
        //使得事件不频繁出现
        private static int times = 0;                                                       //已经打印日期的次数
        private static DateTime timebefore = DateTime.Parse("2017 - 7 - 20 20:36:12");      //上次打印日期的时间,初始值较小确保第一次收到消息打印时间
    }
}
