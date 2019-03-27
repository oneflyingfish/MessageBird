using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MessageBirdCommon;
using System.IO;
using System.Data;
using System.Data.SQLite;
using ObjectExpandClass;

namespace MessageBird
{
    public partial class ChatForm : Form
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public ChatForm()
        {
            InitializeComponent();
            //实现阴影立体效果
            FormShadow.SetShadow(this);

            DefineEvent();
            this.ShowInTaskbar = true;
            //绘制圆角函数
            //this.SetWindowRegion(5);

            //绑定事件
            this.MouseMoveEvent += ChatForm_MouseMove;
            this.MouseDownEvent += ChatForm_MouseDown;
            this.SizeChanged += ChatForm_SizeChanged;
            this.TopPanel.DoubleClick += TopPanel_DoubleClick;
            this.SearchTextBox.LostFocus += SearchTextBox_LostFocus;
            this.SearchTextBox.Click += SearchTextBox_Click;
            this.SearchTextBox.TextChanged += SearchTextBox_TextChanged;
            this.AccountOppositeChange += ChatForm_AccountOppositeChange;
            this.NewsEditRichTextBox.KeyDown += NewsEditRichTextBox_KeyDown;
            this.ReceiveNewsEvent += ChatForm_ReceiveNewsEvent;

            //绘制虚线条事件,美化
            this.TopLeftPanel.Paint += TopLeftPanel_Paint;
            this.RightPanel.Paint += RightPanel_Paint;
            this.ButtonFunctionPanel.Paint += ButtonFunctionPanel_Paint;
            this.RightBottomPanel.Paint += RightBottomPanel_Paint;
        }

        /// <summary>
        /// 增多历史消息显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void historyDateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                DateTime dateTime = this.historyDateTimePicker.Value;
                this.ShowHistorNews(this.Type, AccountOpposite, dateTime);
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// 主动触发消息分发事件
        /// </summary>
        /// <param name="senderAccount">发消息者账户，如果是自己，用"@@me"表示</param>
        /// <param name="image">图像</param>
        /// <param name="chatId">好友账号 / 群号</param>
        /// <param name="news"></param>
        /// <param name="userName">用户昵称</param>
        /// <param name="time">消息时间</param>
        public void EmitReceiveNewsEvent(string senderAccount, Bitmap image, string chatId, string news, string userName,string time)
        {
            //触发事件
            ReceiveNewsEvent(senderAccount, image, chatId, news, userName,time);
        }

        /// <summary>
        /// 分发消息
        /// </summary>
        /// <param name="senderAccount">发消息者账户，如果是自己，用"@@me"表示</param>
        /// <param name="image">图像</param>
        /// <param name="chatId">好友账号 / 群号</param>
        /// <param name="news"></param>
        /// <param name="userName">用户昵称</param>
        /// <param name="time">消息时间</param>
        private void ChatForm_ReceiveNewsEvent(string senderAccount, Bitmap image,string chatId, string news,string userName,string time)
        {
            int type = 0;   //1：单聊  2：群聊
            int flag = 0;   //1：自己发送的 2：其他人发送的
            if(chatId.EndsWith(".com"))
            {
                type = 1;   //单聊
            }
            else
            {
                type = 2;   //群聊--界面附加昵称
            }

            if(senderAccount=="@@me")
            {
                flag= 1;
                userName = "我自己";
            }
            else
            {
                flag = 2;
            }
                
            if(this.AccountOpposite==chatId) //此界面正在显示中
            {
                if (type == 1)
                {
                    //显示消息
                    this.AddNewsToPanel(flag, news, image, time.Replace("/", "-"));
                }
                else if (type == 2)
                {
                    //显示消息
                    this.AddNewsToPanel(flag, news, image, time.Replace("/", "-"),userName);
                } 
            }

            //记录消息
            RecordNews(senderAccount,userName,chatId,news,time);
        }

        /// <summary>
        /// 在磁盘中记下聊天记录
        /// </summary>
        /// <param name="account">成员账号</param>
        /// <param name="ID">群号</param>
        /// <param name="news">消息</param>
        public void RecordNews(string account,string userName,string ID,string news,string time)
        {
            if (news == "")
            {
                return;
            }

            string databasePath = System.Environment.CurrentDirectory + "\\files\\records.db";
            //打开数据库，不存在则创建
            if (!File.Exists(databasePath))
            {
                try
                {
                    SQLiteConnection.CreateFile(databasePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            SQLiteConnection databaseWriter = null;
            try
            {
                databaseWriter = new SQLiteConnection("Data Source=" + databasePath + "; Version=3;UseUTF16Encoding=True;");
                databaseWriter.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            //打开表，不存在则创建
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = databaseWriter;
            cmd.CommandText = "select * from sqlite_master  where type=\"table\" and name=\"TABLENAME\";".Replace("TABLENAME",ID);
            SQLiteDataReader resultTable = null;
            try
            {
                resultTable = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                databaseWriter.Close();
                return;
            }

            bool tableIsExist = false;  //存储聊天数据的表是否已经存在
            if (resultTable.Read())     //一行数据有效则返回true
            {
                tableIsExist = true;
            }
            resultTable.Close();

            try
            {
                if (!tableIsExist) //表不存在
                {
                    //以账户为表名创建新表
                    cmd.CommandText = @"CREATE TABLE 'TABLENAME'
                                    (
	                                    'DateTime'	TEXT NOT NULL,
	                                    'Account'	TEXT NOT NULL,
	                                    'News'	    TEXT NOT NULL,
                                        'UserName'	TEXT NOT NULL
                                    );".Replace("TABLENAME", ID);        //创建表的SQL语句
                    cmd.ExecuteNonQuery();
                }

                cmd.CommandText = "insert into \"TABLENAME\" values(\"DATATIME\",\"ACCOUNT\",\"NEWS\",\"USERNAME\");".Replace("TABLENAME", ID).Replace("DATATIME",Convert.ToDateTime(time).ToString("yyyy-MM-dd  hh:mm:ss")).Replace("ACCOUNT", account).Replace("NEWS", news).Replace("USERNAME", userName); ;
                cmd.ExecuteNonQuery();
                databaseWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                databaseWriter.Close();
            }
        }

        /// <summary>
        /// 点击发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BottomSendButton_Click(object sender, EventArgs e)
        {
            string news = this.NewsEditRichTextBox.Text;
            this.NewsEditRichTextBox.Text = "";
            Bitmap image = MessageBirdCommon.UserInformation.Image;

            if(news=="")
            {
                return;
            }

            if (this.Type==1)       //发送单人消息
            {
                //本地显示
                this.ReceiveNewsEvent("@@me", MessageBirdCommon.UserInformation.Image, this.accountOpposite, news, "",DateTime.Now.ToString());

                //云服务器发送，待完成？？
            }
            else if(this.Type==2)   //发送群消息
            {
                //本地显示
                this.ReceiveNewsEvent("@@me", MessageBirdCommon.UserInformation.Image, this.accountOpposite, news, "我自己", DateTime.Now.ToString());

                //云服务器发送，待完成？？

            }
        }

        /// <summary>
        /// 设置输入框快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewsEditRichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.Enter)
            {
                this.NewsEditRichTextBox.AppendText("\n");
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.BottomSendButton.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// 清空消息
        /// </summary>
        private void Clearnews()
        {
            this.MiddlePanel.Controls.Remove(this.middleShowPanel);
            this.middleShowPanel = new Panel();
            this.middleShowPanel.Dock = DockStyle.Top;
            this.middleShowPanel.AutoSize = true;
            this.middleShowPanel.Padding= new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.MiddlePanel.Controls.Add(this.middleShowPanel);
            
        }

        /// <summary>
        /// 向聊天框添加消息
        /// </summary>
        /// <param name="flag">1：右图像，2:左图像 </param>
        /// <param name="news">消息内容</param>
        /// <param name="image">图像</param>
        /// <param name="dataTime">时间</param>
        /// <param name="userName">昵称</param>
        private void AddNewsToPanel(int flag=0,string news="",Bitmap image=null,string dateTime="",string userName="")
        {
            //添加控件
            if (flag == 1)
            {
                ShowNews.ShowNewsOfMe youNews = new ShowNews.ShowNewsOfMe(news, image, dateTime,userName);
                youNews.Dock = DockStyle.Bottom;
                youNews.AutoSize = false;
                this.middleShowPanel.Controls.Add(youNews);
            }
            else if (flag == 2)
            {
                ShowNews.ShowNewsOfYou youNews = new ShowNews.ShowNewsOfYou(news, image, dateTime,userName);
                youNews.Dock = DockStyle.Bottom;
                youNews.AutoSize = false;
                this.middleShowPanel.Controls.Add(youNews);
            }
            this.MiddlePanel.VerticalScroll.Value = this.MiddlePanel.VerticalScroll.Maximum;
        }

        /// <summary>
        /// 默认回放四条历史消息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="ID"></param>
        private void ChatForm_AccountOppositeChange(int type, string ID)
        {
            ShowHistorNews(type, ID);
        }

        /// <summary>
        /// 回放历史消息
        /// </summary>
        /// <param name="type">好友还是群聊</param>
        /// <param name="accountOpposite">账户</param>
        /// <param name="count">回放条数</param>
        private void ShowHistorNews(int type, string ID,int count=4)
        {
            //清空消息界面
            this.Clearnews();
            //打开数据库，不存在则创建
            string databasePath = System.Environment.CurrentDirectory + "\\files\\records.db";
            if (!File.Exists(databasePath))
            {
                try
                {
                    SQLiteConnection.CreateFile(databasePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            SQLiteConnection databaseReader = null;
            try
            {
                databaseReader = new SQLiteConnection("Data Source=" + databasePath + "; Version=3;UseUTF16Encoding=True;");
                databaseReader.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            //打开表，不存在则创建
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = databaseReader;
            cmd.CommandText = "select * from sqlite_master  where type=\"table\" and name=\"TABLENAME\";".Replace("TABLENAME", ID);
            SQLiteDataReader resultTable = null;
            try
            {
                resultTable = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                databaseReader.Close();
                return;
            }

            bool tableIsExist = false;  //存储聊天数据的表是否已经存在
            if (resultTable.Read())     //一行数据有效则返回true
            {
                tableIsExist = true;
            }
            resultTable.Close();

            try
            {
                if (!tableIsExist) //表不存在
                {
                    //以账户为表名创建新表
                    cmd.CommandText = @"CREATE TABLE 'TABLENAME'
                                    (
	                                    'DateTime'	TEXT NOT NULL,
	                                    'Account'	TEXT NOT NULL,
	                                    'News'	TEXT NOT NULL,
                                        'UserName'	TEXT NOT NULL
                                    );".Replace("TABLENAME", ID);        //创建表的SQL语句
                    cmd.ExecuteNonQuery();
                    resultTable.Close();
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                cmd.CommandText = "select * from (select * from \"TABLENAME\" order by DateTime DESC limit 0,COUNT) order by DateTime ASC;".Replace("TABLENAME", ID).Replace("COUNT", count.ToString());
                SQLiteDataReader newsReader = cmd.ExecuteReader();

                if (type == 1) //好友
                {
                    while (newsReader.Read())
                    {
                        Bitmap image = null;    //图像
                        string dateTime = "";   //日期
                        string news = "";       //消息
                        int flag = 0;           //1表示自己，2表示对方

                        dateTime = (newsReader[0] as string).Replace("/", "-");
                        if ((newsReader[1] as string) == "@@me")
                        {
                            image = MessageBirdCommon.UserInformation.Image;
                            flag = 1;
                        }
                        else
                        {
                            image = this.ImageOpposite;
                            flag = 2;
                        }
                        news = newsReader[2] as string;
                        if(image==null)
                        {
                            image= new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png");
                        }
                        

                        //添加控件
                        AddNewsToPanel(flag, news, image, dateTime);
                    }
                }
                else if (type == 2)
                {
                    while (newsReader.Read())
                    {
                        string dateTime = "";
                        string news = "";
                        string account = "";
                        int flag = 0;           //1表示自己，2表示对方

                        dateTime = (newsReader[0] as string).Replace("/", "-");
                        account = newsReader[1] as string;
                        news = newsReader[2] as string;

                        //查询图像和昵称
                        Bitmap image = null;
                        string userName = "";
                        if (account == "@@me")
                        {
                            image = MessageBirdCommon.UserInformation.Image;
                            flag = 1;
                            userName = "我自己";
                        }
                        else
                        {
                            flag = 2;
                            GroupShowForm.GroupShowForm groupShowForm = MessageBirdCommon.UserInformation.GetFriendObject(account) as GroupShowForm.GroupShowForm;
                            if (groupShowForm != null)
                            {
                                image = groupShowForm.UserImage;
                            }
                            userName = newsReader[3] as string;
                        }

                        if (image == null)
                        {
                            image = new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png");
                        }
                        //添加控件
                        AddNewsToPanel(flag, news, image, dateTime, userName);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                databaseReader.Close();
            }
        }

        /// <summary>
        /// 回放历史消息
        /// </summary>
        /// <param name="type">好友还是群聊</param>
        /// <param name="accountOpposite">账户</param>
        /// <param name="count">回放条数</param>
        private void ShowHistorNews(int type, string ID, DateTime minDateTime)
        {
            //清空消息界面
            this.Clearnews();
            //打开数据库，不存在则创建
            string databasePath = System.Environment.CurrentDirectory + "\\files\\records.db";
            if (!File.Exists(databasePath))
            {
                try
                {
                    SQLiteConnection.CreateFile(databasePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            SQLiteConnection databaseReader = null;
            try
            {
                databaseReader = new SQLiteConnection("Data Source=" + databasePath + "; Version=3;UseUTF16Encoding=True;");
                databaseReader.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            //打开表，不存在则创建
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = databaseReader;
            cmd.CommandText = "select * from sqlite_master  where type=\"table\" and name=\"TABLENAME\";".Replace("TABLENAME", ID);
            SQLiteDataReader resultTable = null;
            try
            {
                resultTable = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                databaseReader.Close();
                return;
            }

            bool tableIsExist = false;  //存储聊天数据的表是否已经存在
            if (resultTable.Read())     //一行数据有效则返回true
            {
                tableIsExist = true;
            }
            resultTable.Close();

            try
            {
                if (!tableIsExist) //表不存在
                {
                    //以账户为表名创建新表
                    cmd.CommandText = @"CREATE TABLE 'TABLENAME'
                                    (
	                                    'DateTime'	TEXT NOT NULL,
	                                    'Account'	TEXT NOT NULL,
	                                    'News'	TEXT NOT NULL,
                                        'UserName'	TEXT NOT NULL
                                    );".Replace("TABLENAME", ID);        //创建表的SQL语句
                    cmd.ExecuteNonQuery();
                    resultTable.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                cmd.CommandText = "select * from (select * from \"TABLENAME\" where DateTime >= \"OLDDATE\" order by DateTime DESC) order by DateTime ASC;".Replace("TABLENAME", ID).Replace("OLDDATE", minDateTime.ToString("yyyy-MM-dd  hh:mm:ss"));
                SQLiteDataReader newsReader = cmd.ExecuteReader();

                if (type == 1) //好友
                {
                    while (newsReader.Read())
                    {
                        Bitmap image = null;    //图像
                        string dateTime = "";   //日期
                        string news = "";       //消息
                        int flag = 0;           //1表示自己，2表示对方

                        dateTime = (newsReader[0] as string).Replace("/", "-");
                        if ((newsReader[1] as string) == "@@me")
                        {
                            image = MessageBirdCommon.UserInformation.Image;
                            flag = 1;
                        }
                        else
                        {
                            image = this.ImageOpposite;
                            flag = 2;
                        }
                        news = newsReader[2] as string;

                        //添加控件
                        AddNewsToPanel(flag, news, image, dateTime);
                    }
                }
                else if (type == 2) //群聊
                {
                    while (newsReader.Read())
                    {
                        string dateTime = "";
                        string news = "";
                        string account = "";
                        int flag = 0;           //1表示自己，2表示对方

                        dateTime = (newsReader[0] as string).Replace("/", "-");
                        account = newsReader[1] as string;
                        news = newsReader[2] as string;

                        //查询图像和昵称
                        Bitmap image = null;
                        string userName = "";
                        if (account == "@@me")
                        {
                            image = MessageBirdCommon.UserInformation.Image;
                            flag = 1;
                            userName = "我自己";
                        }
                        else
                        {
                            flag = 2;
                            GroupShowForm.GroupShowForm groupShowForm = MessageBirdCommon.UserInformation.GetFriendObject(account) as GroupShowForm.GroupShowForm;
                            if (groupShowForm != null)
                            {
                                image = groupShowForm.UserImage;
                            }
                            userName = newsReader[3] as string;
                        }

                        if (image == null)
                        {
                            image = new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png");
                        }

                        //添加控件
                        AddNewsToPanel(flag, news, image, dateTime, userName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                databaseReader.Close();
            }
        }

        /// <summary>
        /// 查看历史记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void historyButton_Click(object sender, EventArgs e)
        {
            if(this.historyDateTimePicker.Visible == true)
            {
                this.historyDateTimePicker.Visible = false;
                this.toolTip.SetToolTip(this.historyButton, "查看更多历史记录");
            }
            else
            {
                this.historyDateTimePicker.Visible = true;
                this.historyDateTimePicker.Value = DateTime.Now;
                this.toolTip.SetToolTip(this.historyButton, "再点一下隐藏日期选择框");
            }
        }

        /// <summary>
        /// 搜索文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if(this.LeftPanel.Controls.Count<1)
            {
                return;
            }
            for(int i=0;i< this.LeftPanel.Controls.Count;i++)
            {
                GroupShowForm.GroupShowForm groupShowForm = this.LeftPanel.Controls[i] as GroupShowForm.GroupShowForm;
                if (groupShowForm.information.HasKeywords(this.SearchTextBox.Text))
                {
                    GroupShowForm_ToUpEvent(groupShowForm);
                }
            }
        }

        private void RightBottomPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Gainsboro), 0, 0, this.RightBottomPanel.Width - 1, 0);
        }

        /// <summary>
        /// 添加群成员或者共同好友
        /// </summary>
        /// <param name="InsertForm"></param>
        public void AddControlsToRight(int kind, string account, string userName, Bitmap userImage)
        {
           
        }

        /// <summary>
        /// 添加聊天好友/群
        /// </summary>
        /// <param name="InsertForm"></param>
        public void AddControlsToLeft(int kind, string account, string userName,Bitmap userImage)
        {
            GroupShowForm.GroupShowForm groupShowForm = null;
            //尝试找到已有控件置顶
            for (int i = 0; i < LeftPanel.Controls.Count; i++)
            {
                groupShowForm = LeftPanel.Controls[i] as GroupShowForm.GroupShowForm;
                if (groupShowForm.Account == account)
                {
                    this.LeftPanel.Controls.Remove(groupShowForm);
                    break;
                }
                groupShowForm = null;
            }

            //没有找到控件，生成新控件
            if (groupShowForm == null)
            {
                groupShowForm = new GroupShowForm.GroupShowForm();
                groupShowForm.ToUpEvent += GroupShowForm_ToUpEvent;
                groupShowForm.DeleteEvent += GroupShowForm_DeleteEvent;
                groupShowForm.ClickEvent += GroupShowForm_Click;
                groupShowForm.Dock = DockStyle.Top;
            }
            //设置信息
            groupShowForm.SetInformation(kind, userName, account, userImage);
            groupShowForm.OnClick();    //触发
            //控件放入panel
            this.LeftPanel.Controls.Add(groupShowForm);
        }

        /// <summary>
        /// 控件点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupShowForm_Click(object sender, EventArgs e)
        {
            GroupShowForm.GroupShowForm groupShowForm = sender as GroupShowForm.GroupShowForm;
            this.Kind = groupShowForm.Kind - 3;//为了区分群组，原类型值之前有加3处理
            this.AccountOpposite = groupShowForm.Account;
            this.UserNameOpposite = groupShowForm.UserName;
            this.ImageOpposite = groupShowForm.UserImage;
            this.RightTopForm.SetInformation(this.accountOpposite, this.userNameOpposite, groupShowForm.UserImage);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="o"></param>
        private void GroupShowForm_DeleteEvent(object o)
        {
            GroupShowForm.GroupShowForm groupShowForm = o as GroupShowForm.GroupShowForm;
            string account = groupShowForm.Account;
            this.LeftPanel.Controls.Remove(groupShowForm);

            if(account!=AccountOpposite)    //删除的并不是正在聊天的对象
            {
                return;
            }

            //当前对象被删除，开启一个新的对象
            if(this.LeftPanel.Controls.Count<1)
            {
                this.CloseButton.PerformClick();
            }
            else
            {
                GroupShowForm.GroupShowForm groupShowFormNew = this.LeftPanel.Controls[0] as GroupShowForm.GroupShowForm;
                groupShowFormNew.OnClick();
            }
        }

        /// <summary>
        /// 置顶
        /// </summary>
        /// <param name="o"></param>
        private void GroupShowForm_ToUpEvent(object o)
        {
            GroupShowForm.GroupShowForm groupShowForm = o as GroupShowForm.GroupShowForm;
            this.LeftPanel.Controls.Remove(groupShowForm);
            this.LeftPanel.Controls.Add(groupShowForm);
            groupShowForm.Dock = DockStyle.Top;
        }

        /// <summary>
        /// 去掉圆角
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChatForm_SizeChanged(object sender, EventArgs e)
        {
            this.SetWindowRegion(0);
        }

        /// <summary>
        /// 绘制边框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RightPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Gainsboro), 0, 0, 0, this.RightPanel.Height - 1);
        }

        /// <summary>
        /// 绘制边框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonFunctionPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Gainsboro), 0, 0, this.ButtonFunctionPanel.Width - 1, 0);
        }

        /// <summary>
        /// 搜索框边框绘制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopLeftPanel_Paint(object sender, PaintEventArgs e)
        {
            int width = this.TopLeftPanel.Width;
            int height = this.TopLeftPanel.Height;
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen pen = new Pen(Color.RoyalBlue);
            g.DrawLine(pen, (height - 1) / 2, 0, width + 1 - height / 2, 0);
            g.DrawLine(pen, (height - 1) / 2, height - 1, width + 1 - height / 2, height - 1);
            g.DrawArc(pen, 0, 0, height - 1, height - 1, 89, 182);
            g.DrawArc(pen, width - height, 0, height - 1, height - 1, 90, -180);
        }

        /// <summary>
        /// 实现关闭功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;//不能关闭。否则无法接收并分发消息
        }

        /// <summary>
        /// 实现放缩按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaxButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.MaxButton.BackgroundImage = global::信鸽.Properties.Resources.最大化;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.MaxButton.BackgroundImage = global::信鸽.Properties.Resources.最大化还原;
                this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                this.WindowState = FormWindowState.Maximized;
            }
        }

        /// <summary>
        /// 点击聊天框中的关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BottomCloseButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.LeftPanel.Controls.Count; i++)
            {
                GroupShowForm.GroupShowForm groupShowForm = this.LeftPanel.Controls[i] as GroupShowForm.GroupShowForm;
                if (groupShowForm.Account == AccountOpposite)
                {
                    this.GroupShowForm_DeleteEvent(groupShowForm);
                    return;
                }
            }
        }

        /// <summary>
        /// 双击顶部放大全屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopPanel_DoubleClick(object sender, EventArgs e)
        {
            this.MaxButton.PerformClick();
        }

        /// <summary>
        /// 实现最小化功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MixButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 界面拖动实现模块
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChatForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //实现拖动缩小窗体
                if (this.WindowState == FormWindowState.Maximized)
                {
                    int oldWidth = this.Width;
                    int oldHeight = this.Height;
                    this.WindowState = FormWindowState.Normal;
                    this.MaxButton.BackgroundImage = global::信鸽.Properties.Resources.最大化;
                    //this.Location = new Point(e.Location.X-100, e.Location.Y-10);
                    this.FormX = this.Width * e.Location.X / oldWidth;
                    this.FormY = this.Height * e.Location.Y / oldHeight;
                    return;
                }
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
        private void ChatForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.FormX = e.X;
                this.FormY = e.Y;
                return;
            }
        }

        /// <summary>
        /// 自定义事件
        /// </summary>
        private void DefineEvent()
        {
            //定义鼠标移动事件
            this.MouseMove += DefineMouseMoveEvent;
            this.TopPanel.MouseMove += DefineMouseMoveEvent;
            this.TopLeftPanel.MouseMove += DefineMouseMoveEvent;
            this.TopRightPanel.MouseMove += DefineMouseMoveEvent;
            this.SearchTextBox.MouseMove += DefineMouseMoveEvent;
            this.TitleLabel.MouseMove += DefineMouseMoveEvent;
            this.LeftPanel.MouseMove += DefineMouseMoveEvent;

            //定义鼠标按下事件
            this.MouseDown += DefineMouseDownEvent;
            this.TopPanel.MouseDown += DefineMouseDownEvent;
            this.TopLeftPanel.MouseDown += DefineMouseDownEvent;
            this.TopRightPanel.MouseDown += DefineMouseDownEvent;
            this.SearchTextBox.MouseDown += DefineMouseDownEvent;
            this.TitleLabel.MouseDown += DefineMouseDownEvent;
            this.LeftPanel.MouseDown += DefineMouseDownEvent;
        }

        /// <summary>
        /// 搜索框点击获得焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBox_Click(object sender, EventArgs e)
        {
            if (this.SearchTextBox.Text == "搜索")
            {
                this.SearchTextBox.Text = "";
            }
        }

        /// <summary>
        /// 搜索框失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBox_LostFocus(object sender, EventArgs e)
        {
            if (this.SearchTextBox.Text == "")
            {
                this.SearchTextBox.Text = "搜索";
            }
        }

        /// <summary>
        /// 触发MouseMove事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DefineMouseMoveEvent(object sender, MouseEventArgs e)
        {
            MouseMoveEvent(this, e);
        }

        /// <summary>
        /// 触发MouseDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DefineMouseDownEvent(object sender, MouseEventArgs e)
        {
            MouseDownEvent(this, e);
        }

        /// <summary>
        /// 主窗体绘制圆角模块
        /// </summary>
        private void SetWindowRegion(int distance)
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath;
            FormPath = new System.Drawing.Drawing2D.GraphicsPath();
            Rectangle rect = new Rectangle(0, distance, this.Width - distance, this.Height - distance);
            FormPath = GetRoundedRectPath(rect, 1);
            this.Region = new Region(FormPath);
        }

        /// <summary>
        /// 主窗体绘制圆角模块
        /// radius为半径
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            //   左上角   
            path.AddArc(arcRect, 180, 90);
            //   右上角   
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            //   右下角   
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);
            //   左下角   
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// 点击显示群成员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewGroupMemberButton_Click(object sender, EventArgs e)
        {
            //显示群成员
            //？？？？云请求群聊好友
            FunctionWords functionWords = this.SendNewsAndReceiveAnswer(FunctionKind.QueryMemberOfGroup, this.AccountOpposite, "", null);
            if(functionWords!=null && functionWords.stringList.Count>1 &&functionWords.bitmapList.Count== functionWords.stringList.Count)
            {
                //显示群成员便签
                this.viewGroupMemberButton.Visible = false;
                this.groupShowMemberLabel.Visible = true;
                for (int i=0;i< functionWords.stringList.Count;i++)
                {
                    GroupShowEasyForm.GroupShowEasyForm groupShowEasyForm = new GroupShowEasyForm.GroupShowEasyForm(functionWords.stringList[i], functionWords.bitmapList[i]);
                    groupShowEasyForm.Dock = DockStyle.Top;
                    this.groupMemberPanel.Controls.Add(groupShowEasyForm);
                }
            }
            else
            {
                MessageBox.Show("信息存在异常，请重试");
            }
        }

        public string UserNameOpposite
        {
            get => userNameOpposite;
            set
            {
                userNameOpposite = value;
                this.TitleLabel.Text = userNameOpposite;
            }
        }
        /// <summary>
        /// 触发来源--好友、群聊、消息
        /// </summary>
        public int Kind { get => kind; set => kind = value; }
        /// <summary>
        /// 好友还是群聊,1：好友，2：群聊
        /// </summary>
        public int Type
        {
            get => type;
            set
            {
                type = value;
                if(type==2) //群聊
                {
                    this.groupShowMemberLabel.Visible = false;
                    this.viewGroupMemberButton.Visible = true;  //显示群成员按钮
                }
                else
                {
                    this.groupShowMemberLabel.Visible = false;
                    this.viewGroupMemberButton.Visible = false; //隐藏群成员按钮
                }
                this.ClearGroupMemberPanel();
            }
        }
        public Bitmap ImageOpposite { get => imageOpposite; set => imageOpposite = value; }
        public string AccountOpposite
        {
            get => accountOpposite;
            set
            {
                this.accountOpposite = value;
                if (this.accountOpposite.EndsWith(".com"))
                {
                    this.Type = 1;
                }
                else
                {
                    this.Type = 2;
                }
                AccountOppositeChange(this.type, accountOpposite);
            }
        }

        /// <summary>
        /// 删除群成员
        /// </summary>
        private void ClearGroupMemberPanel()
        {
            while(this.groupMemberPanel.Controls.Count>0)
            {
                this.groupMemberPanel.Controls.RemoveAt(0);
            }
        }

        private string accountOpposite = "";
        private string userNameOpposite = "";
        private Bitmap imageOpposite = null;
        private int kind = 0;
        private int type = 0;
        private int FormX = 0;
        private int FormY = 0;

        public event MouseEventHandler MouseDownEvent;
        public event MouseEventHandler MouseMoveEvent;
        public event Action<int, string> AccountOppositeChange;
        /// <summary>
        /// 消息分发事件，可以由自己发送消息引发
        /// 发消息者账户
        /// 图像
        /// 好友账号群号
        /// 消息
        /// 用户昵称
        /// 时间
        /// </summary>
        public event Action<string, Bitmap, string, string, string,string> ReceiveNewsEvent;
    }
}