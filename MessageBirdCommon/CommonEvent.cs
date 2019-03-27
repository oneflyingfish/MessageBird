using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Drawing.Imaging;
using ObjectExpandClass;


namespace MessageBirdCommon
{
    /// <summary>
    /// 定义一些非 “阻塞” 问答式消息收发事件（部分可宏观处理的事件，在CommonEventPartHandle类中实现）
    /// 问答式（允许阻塞）的事件直接由下层程序自主建立临时通信
    /// </summary>
    public static class CommonEvent
    {
        //请求个别图像、昵称、账户等等信息不再此类中触发，直接在所在线程调用,定义为拓展方法，详见ObjectExpandClass.ExpandForSocket

        //关闭程序
        //接收信息事件
        /// <summary>
        /// 关闭程序事件
        /// </summary>
        public static event Action CloseProgramEvent;
        /// <summary>
        /// 关闭程序事件
        /// </summary>
        public static void EmitCloseProgramEvent()
        {
            CloseProgramEvent();
        }

        //添加好友
        /// <summary>
        /// 添加新好友事件
        /// 昵称
        /// 账户
        /// 图像
        /// 是否在线
        /// </summary>
        public static event Action<string, string,Bitmap,bool> AddNewFriendEvent;
        /// <summary>
        /// 触发添加新好友事件
        /// </summary>
        /// <param name="userName">昵称</param>
        /// <param name="account">账户</param>
        /// <param name="userImage">图像</param>
        /// <param name="isOnline">是否在线</param>
        public static void EmitAddNewFriendEvent(string userName, string account, Bitmap userImage, bool isOnline)
        {
            AddNewFriendEvent(userName,account,userImage,isOnline);
        }

        //添加群聊
        /// <summary>
        /// 添加新群聊事件
        /// 昵称
        /// 账户
        /// 图像
        /// </summary>
        public static event Action<string, string, Bitmap> AddNewGroupEvent;
        /// <summary>
        /// 触发添加新群聊事件
        /// 昵称
        /// 图像
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="account"></param>
        /// <param name="userImage"></param>
        public static void EmitAddNewGroupEvent(string userName, string account, Bitmap userImage)
        {
            AddNewGroupEvent(userName, account, userImage);
        }

        //消息到达
        /// <summary>
        /// 接收消息事件
        /// 发送方昵称
        /// 发送方账户
        /// 消息
        /// 时间"2018-10-08 21:50:21"
        /// 发送方图像
        /// 群号/好友账户
        /// 是否在线
        /// </summary>
        public static event Action<string, string,string,string, Bitmap,string,bool> AddNewMessageEvent;
        /// <summary>
        /// 触发接收群消息事件
        /// </summary>
        /// <param name="userName">发送方昵称</param>
        /// <param name="userAccount">发送方账户</param>
        /// <param name="message">消息</param>
        /// <param name="time">发送时间</param>
        /// <param name="userImage">发送方图像</param>
        /// <param name="ID">群聊</param>
        public static void EmitAddNewGroupMessageEvent(string userName, string userAccount, string message, string time, Bitmap userImage, string ID)
        {
            AddNewMessageEvent(userName, userAccount, message, time, userImage, ID, true);
        }
        /// <summary>
        /// 触发接收好友消息事件
        /// </summary>
        /// <param name="userName">发送方昵称</param>
        /// <param name="userAccount">发送方账户</param>
        /// <param name="message">消息</param>
        /// <param name="time">发送时间</param>
        /// <param name="userImage">发送方图像</param>
        /// <param name="ID">群聊/账户</param>
        /// <param name="isOneline">是否在线</param>
        public static void EmitAddNewFriendMessageEvent(string userAccount, string message, string time)
        {
            string userName;
            Bitmap userImage;
            bool isOnline;
            GroupShowForm.GroupShowForm groupShowForm = UserInformation.GetFriendObject(userAccount) as GroupShowForm.GroupShowForm;
            if (groupShowForm!=null)
            {
                userName = groupShowForm.UserName;
                userImage = groupShowForm.UserImage;
                isOnline = groupShowForm.IsOnline;
            }
            else
            {
                userName = "陌生人";
                userImage = new Bitmap(System.Environment.CurrentDirectory + "\\initImage.png");
                isOnline = true;
            }
            
            AddNewMessageEvent(userName, userAccount, message, time, userImage, userAccount, isOnline);
        }

        //在线状态改变
        /// <summary>
        /// 好友在线状态改变
        /// 账户,状态
        /// </summary>
        public static event Action<string, bool> OnlineChangeEvent;
        /// <summary>
        /// 触发好友在线状态改变
        /// </summary>
        public static void EmitOnlineChangeEvent(string userAccount,bool isOnline)
        {
            OnlineChangeEvent(userAccount, isOnline);
        }

        //好友申请处理回复
        //申请好友处理完毕事件
        /// <summary>
        /// 回复好友申请
        /// 账户
        /// 昵称
        /// "true"/"false"
        /// </summary>
        public static event Action<string,string,bool> AnswerApplyToAddFriendEvent;
        /// <summary>
        /// 触发申请好友处理完毕事件
        /// </summary>
        /// <param name="account">对方账户</param>
        /// <param name="userName">对方昵称</param>
        /// <param name="yesOrRight">结果</param>
        public static void EmitAnswerApplyToAddFriendEvent(string account,string userName,bool yesOrNo)
        {
            AnswerApplyToAddFriendEvent(account, userName, yesOrNo);
        }

        //群聊申请处理回复
        /// <summary>
        /// 申请群聊处理完毕事件
        /// 群号
        /// 昵称
        /// "true"/"false"
        /// </summary>
        public static event Action<string,string,bool> AnswerApplyToAddGroupEvent;
        /// <summary>
        /// 触发申请群聊处理完毕事件
        /// </summary>
        /// <param name="account">对方账户</param>
        /// <param name="userName">对方昵称</param>
        /// <param name="yesOrRight">结果</param>
        public static void EmitAnswerApplyToAddGroupEvent(string groupAccount, string groupName, bool yesOrRight)
        {
            AnswerApplyToAddGroupEvent(groupAccount, groupName, yesOrRight);
        }
    }
}
