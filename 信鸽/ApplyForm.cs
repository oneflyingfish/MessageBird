using System;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjectExpandClass;
using MessageBirdCommon;

namespace MessageBird
{
    public partial class ApplyForm : Form
    {
        public enum FunctionChoice { AddToGroup, AddFriend, CreateGroup };

        public ApplyForm()
        {
            InitializeComponent();
            this.functionComboBox.SelectedValueChanged += FunctionComboBox_SelectedValueChanged;
            this.userNameTextBox.TextChanged += InformationChanged;
            this.accountTextbox.TextChanged+= InformationChanged;
            this.functionComboBox.SelectedValueChanged+= InformationChanged;
            InitUi();
        }

        /// <summary>
        /// 信息被更改时，请求中断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InformationChanged(object sender, EventArgs e)
        {
            if(sender is TextBox)
            {
                TextBox textBox = sender as TextBox;
                textBox.Text = textBox.Text.Replace(" ", "");
            }
            this.sendbutton.Text = "发送请求";
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        private void InitUi()
        {
            this.functionComboBox.SelectedIndex = 0;
        }


        /// <summary>
        /// 下拉框值改变时，修改编辑框设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FunctionComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((FunctionChoice)this.functionComboBox.SelectedIndex == FunctionChoice.AddToGroup)
            {
                this.currentFunction = FunctionChoice.AddToGroup;
                this.accountTextbox.ReadOnly = false;
                this.accountTextbox.BackColor = System.Drawing.Color.White;
                this.userNameTextBox.ReadOnly = true;
                this.userNameTextBox.Text = "";
                this.userNameTextBox.BackColor = System.Drawing.SystemColors.Control;
                this.showBusyLabel.Text = "等待输入群号";
            }
            else if ((FunctionChoice)this.functionComboBox.SelectedIndex == FunctionChoice.AddFriend)
            {
                this.currentFunction = FunctionChoice.AddFriend;
                this.accountTextbox.ReadOnly = false;
                this.accountTextbox.BackColor = System.Drawing.Color.White;
                this.userNameTextBox.ReadOnly = true;
                this.userNameTextBox.Text = "";
                this.userNameTextBox.BackColor = System.Drawing.SystemColors.Control;
                this.showBusyLabel.Text = "等待输入账户";
            }
            else if ((FunctionChoice)this.functionComboBox.SelectedIndex== FunctionChoice.CreateGroup)
            {
                this.currentFunction = FunctionChoice.CreateGroup;
                this.accountTextbox.ReadOnly = true;
                this.accountTextbox.Text = "";
                this.accountTextbox.BackColor = System.Drawing.SystemColors.Control;
                this.userNameTextBox.ReadOnly = false;
                this.userNameTextBox.BackColor = System.Drawing.Color.White;
                this.showBusyLabel.Text = "等待输入昵称";
            }
        }

        /// <summary>
        /// 发送请求
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendbutton_Click(object sender, EventArgs e)
        {
            if (this.sendbutton.Text == "发送请求")
            {
                switch (currentFunction)
                {
                    case FunctionChoice.AddFriend:
                        if (!this.accountTextbox.Text.EndsWith(".com") || this.accountTextbox.Text == "")
                        {
                            MessageBox.Show("请输入正确的好友邮箱");
                            return;
                        }

                        //云验证账户，并请求昵称？？？
                        FunctionWords functionWordsForFriendUserName = this.SendNewsAndReceiveAnswer(FunctionKind.SeekForUserName, this.accountTextbox.Text, "", null);
                        if(functionWordsForFriendUserName!=null &&functionWordsForFriendUserName.stringList.Count>0)
                        {
                            this.userNameTextBox.Text = functionWordsForFriendUserName.stringList[0];
                            this.showBusyLabel.Text = "已返回昵称，请确认";
                            break;
                        }
                        this.showBusyLabel.Text = "账户不存在";
                        return;
                    case FunctionChoice.AddToGroup:
                        if (this.accountTextbox.Text.EndsWith(".com") || this.accountTextbox.Text == "")
                        {
                            MessageBox.Show("请输入正确的群号");
                            return;
                        }

                        //云验证账户，并请求昵称？？？
                        FunctionWords functionWordsForGroupUserName = this.SendNewsAndReceiveAnswer(FunctionKind.SeekForUserName, this.accountTextbox.Text, "", null);
                        if (functionWordsForGroupUserName != null && functionWordsForGroupUserName.stringList.Count > 0)
                        {
                            this.userNameTextBox.Text = functionWordsForGroupUserName.stringList[0];
                            this.showBusyLabel.Text = "已返回昵称，请确认";
                            break;
                        }
                        this.showBusyLabel.Text = "账户不存在";
                        return;
                    case FunctionChoice.CreateGroup:
                        if (this.userNameTextBox.Text == "")
                        {
                            MessageBox.Show("请输入正确的昵称");
                            return;
                        }

                        //云请求群号，返回群号？？？
                        FunctionWords functionWordsForCreateGroup= this.SendNewsAndReceiveAnswer(FunctionKind.SeekForNewGroupAccount,"","", null);
                        if (functionWordsForCreateGroup != null && functionWordsForCreateGroup.stringList.Count > 0)
                        {
                            this.accountTextbox.Text = functionWordsForCreateGroup.stringList[0];
                            this.showBusyLabel.Text = "已返回群号，请确认";
                            break;
                        }
                        this.showBusyLabel.Text = "服务器异常，请稍后重试";
                        return;
                    default:
                        return;
                }
                this.sendbutton.Text = "确认";
            }
            else if (this.sendbutton.Text == "确认")
            {
                if(this.userNameTextBox.Text=="" || this.accountTextbox.Text=="")
                {
                    MessageBox.Show("错误: 似乎存在信息不完整，请重试");
                    this.sendbutton.Text = "发送请求";
                    return;
                }

                switch (currentFunction)
                {
                    case FunctionChoice.AddFriend:
                        //发送请求???
                        CallServer.AddSendNews(MessageProtocol.GetStartBytes(FunctionKind.ApplyToAddFriend), MessageBirdCommon.UserInformation.Account.ToTxtBytes(), MessageBirdCommon.UserInformation.UserName.ToTxtBytes(), this.accountTextbox.Text.ToTxtBytes(), MessageProtocol.GetEndBytes());
                        break;
                    case FunctionChoice.AddToGroup:
                        //发送请求???
                        CallServer.AddSendNews(MessageProtocol.GetStartBytes(FunctionKind.ApplyToAddGroup), MessageBirdCommon.UserInformation.Account.ToTxtBytes(), MessageBirdCommon.UserInformation.UserName.ToTxtBytes(), this.accountTextbox.Text.ToTxtBytes(), MessageProtocol.GetEndBytes());
                        break;
                    case FunctionChoice.CreateGroup:
                        //发送请求???
                        MessageBox.Show("请选择小于30KB的png图片");
                        OpenFileDialog fileDialog = new OpenFileDialog();
                        DialogResult result = fileDialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            FileInfo fileInfo = new FileInfo(fileDialog.FileName);
                            double length = Convert.ToDouble(fileInfo.Length);
                            if(!fileInfo.FullName.ToLower().EndsWith(".png") || (fileInfo.Length> 31457280))
                            {
                                MessageBox.Show("目前仅支持小于30KB的png图像");
                                return;
                            }
                            Bitmap image= new Bitmap(Image.FromFile(fileDialog.FileName));
                            CallServer.AddSendNews(MessageProtocol.GetStartBytes(FunctionKind.RequestToRegeditGroup), MessageBirdCommon.UserInformation.Account.ToTxtBytes(), MessageBirdCommon.UserInformation.UserName.ToTxtBytes(), this.accountTextbox.Text.ToTxtBytes(),image.ToImageBytes(), MessageProtocol.GetEndBytes());
                        }
                        else
                        {
                            return;
                        }
                        break;
                    default:
                        return;
                }
                MessageBox.Show("申请信息已发出");
                this.sendbutton.Text = "发送请求";
            }
        }

        private FunctionChoice currentFunction = FunctionChoice.AddToGroup;
    }
}
