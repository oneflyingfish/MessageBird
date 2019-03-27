using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using MessageBirdCommonClass;
using GroupShowForm;

namespace MessageBirdCommon
{
    public static class UserInformation
    {
        public static List<Object> GroupsInformation = new List<Object>();
        public static List<Object> FriendsInformation = new List<Object>();
        public static List<Object> MessageInformation = new List<Object>();

        /// <summary>
        /// 设置在线/离线
        /// </summary>
        /// <param name="account"></param>
        /// <param name="status"></param>
        public static void SetOnlineStatus(string account,bool status)
        {
            GroupShowForm.GroupShowForm friendForm = GetFriendObject(account) as GroupShowForm.GroupShowForm;
            GroupShowForm.GroupShowForm groupForm = GetGroupObject(account) as GroupShowForm.GroupShowForm;
            GroupShowForm.GroupShowForm messageForm = GetMessageObejct(account) as GroupShowForm.GroupShowForm;

            //好友栏中设置
            if(friendForm!=null)
            {
                friendForm.IsOnlineUnsafe = status;//修改内部记录
                friendForm.ShowOnlineStatus(status);//设置显示
            }

            //群组栏中设置
            if (groupForm != null)
            {
                groupForm.IsOnlineUnsafe = status;//修改内部记录
                groupForm.ShowOnlineStatus(status);//设置显示
            }

            //消息栏中设置
            if (messageForm != null)
            {
                messageForm.IsOnlineUnsafe = status;//修改内部记录
                messageForm.ShowOnlineStatus(status);//设置显示
            }

        }

        /// <summary>
        /// 返回含有关键字的群组引用列表
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        public static List<GroupShowForm.GroupShowForm> GetGroupsObjectHasKeyWords(string keyWords)
        {
            if (GroupsInformation.Count <= 0)
            {
                return null;
            }

            List<GroupShowForm.GroupShowForm> GroupsObjectHasKeyWords = new List<GroupShowForm.GroupShowForm>();
            GroupShowForm.GroupShowForm groupShowForm = null;
            for (int i = 0; i < GroupsInformation.Count; i++)
            {
                groupShowForm = GroupsInformation[i] as GroupShowForm.GroupShowForm;
                if (groupShowForm.HasKeywords(keyWords))
                {

                    GroupsObjectHasKeyWords.Add(groupShowForm);
                }
            }
            return GroupsObjectHasKeyWords;
        }

        /// <summary>
        /// 返回含有关键字的群组列表
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        public static List<BaseInformation> GetGroupsHasKeyWords(string keyWords)
        {
            
            if (GroupsInformation.Count<=0)
            {
                return null;
            }

            List<BaseInformation> GroupsHasKeyWords = new List<BaseInformation>();
            GroupShowForm.GroupShowForm groupShowForm = null;
            BaseInformation baseInformation = null;
            for (int i=0;i<GroupsInformation.Count;i++)
            {
                groupShowForm = GroupsInformation[i] as GroupShowForm.GroupShowForm;
                if(groupShowForm.HasKeywords(keyWords))
                {
                    baseInformation = new BaseInformation();
                    baseInformation.SetInformation(groupShowForm.Kind, groupShowForm.Account, groupShowForm.UserName, groupShowForm.UserImage, groupShowForm.IsOnline);
                    GroupsHasKeyWords.Add(baseInformation);
                }
            }
            return GroupsHasKeyWords;
        }

        /// <summary>
        /// 返回含有关键字的好友引用列表
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        public static List<GroupShowForm.GroupShowForm> GetFriendsObjectHasKeyWords(string keyWords)
        {
            if (FriendsInformation.Count <= 0)
            {
                return null;
            }

            List<GroupShowForm.GroupShowForm> FriendsObjectHasKeyWords = new List<GroupShowForm.GroupShowForm>();
            GroupShowForm.GroupShowForm groupShowForm = null;
            for (int i = 0; i < FriendsInformation.Count; i++)
            {
                groupShowForm = FriendsInformation[i] as GroupShowForm.GroupShowForm;
                if (groupShowForm.HasKeywords(keyWords))
                {
                    FriendsObjectHasKeyWords.Add(groupShowForm);
                }
            }
            return FriendsObjectHasKeyWords;
        }

        /// <summary>
        /// 返回含有关键字的好友列表
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        public static List<BaseInformation> GetFriendsHasKeyWords(string keyWords)
        {
            if (FriendsInformation.Count <= 0)
            {
                return null;
            }

            List<BaseInformation> FriendsHasKeyWords = new List<BaseInformation>();
            GroupShowForm.GroupShowForm groupShowForm = null;
            BaseInformation baseInformation = null;
            for (int i = 0; i < FriendsInformation.Count; i++)
            {
                groupShowForm = FriendsInformation[i] as GroupShowForm.GroupShowForm;
                if (groupShowForm.HasKeywords(keyWords))
                {
                    baseInformation = new BaseInformation();
                    baseInformation.SetInformation(groupShowForm.Kind, groupShowForm.Account, groupShowForm.UserName, groupShowForm.UserImage, groupShowForm.IsOnline);
                    FriendsHasKeyWords.Add(baseInformation);
                }
            }
            return FriendsHasKeyWords;
        }

        /// <summary>
        /// 返回含有关键字的消息引用列表
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        public static List<GroupShowForm.GroupShowForm> GetMessagesObjectHasKeyWords(string keyWords)
        {

            if (MessageInformation.Count <= 0)
            {
                return null;
            }

            List<GroupShowForm.GroupShowForm> MessagesObjectHasKeyWords = new List<GroupShowForm.GroupShowForm>();
            GroupShowForm.GroupShowForm groupShowForm = null;
            for (int i = 0; i < MessageInformation.Count; i++)
            {
                groupShowForm = MessageInformation[i] as GroupShowForm.GroupShowForm;
                if (groupShowForm.HasKeywords(keyWords))
                {
                    MessagesObjectHasKeyWords.Add(groupShowForm);
                }
            }
            return MessagesObjectHasKeyWords;
        }

        /// <summary>
        /// 返回含有关键字的消息列表
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        public static List<BaseInformation> GetMessagesHasKeyWords(string keyWords)
        {

            if (MessageInformation.Count <= 0)
            {
                return null;
            }

            List<BaseInformation> MessagesHasKeyWords = new List<BaseInformation>();
            GroupShowForm.GroupShowForm groupShowForm = null;
            BaseInformation baseInformation = null;
            for (int i = 0; i < MessageInformation.Count; i++)
            {
                groupShowForm = MessageInformation[i] as GroupShowForm.GroupShowForm;
                if (groupShowForm.HasKeywords(keyWords))
                {
                    baseInformation = new BaseInformation();
                    baseInformation.SetInformation(groupShowForm.Kind, groupShowForm.Account, groupShowForm.UserName, groupShowForm.UserImage, groupShowForm.IsOnline);
                    MessagesHasKeyWords.Add(baseInformation);
                }
            }
            return MessagesHasKeyWords;
        }

        /// <summary>
        /// 获取主界中群组的对象
        /// 返回值为null表示对象不存在
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static Object GetGroupObject(string account)
        {
            if(GroupsInformation.Count<=0)
            {
                return null;
            }

            GroupShowForm.GroupShowForm obj = null;
            for(int i=0;i<GroupsInformation.Count;i++)
            {
                obj = GroupsInformation[i] as GroupShowForm.GroupShowForm;
                if (obj.Account==account)
                {
                    return obj;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取主界中好友的对象
        /// 返回值为null表示对象不存在
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static Object GetFriendObject(string account)
        {
            if (FriendsInformation.Count <= 0)
            {
                return null;
            }

            GroupShowForm.GroupShowForm obj = null;
            for (int i = 0; i < FriendsInformation.Count; i++)
            {
                obj = FriendsInformation[i] as GroupShowForm.GroupShowForm;
                if (obj.Account == account)
                {
                    return obj;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取主界面中消息对象
        /// 返回值为null表示对象不存在
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static Object GetMessageObejct(string account)
        {
            if(MessageInformation.Count<=0)
            {
                return null;
            }

            GroupShowForm.GroupShowForm obj = null;
            //倒序查询，消息列表中一个账户可以有多个对象，界面只显示了最后一个
            for (int i= MessageInformation.Count-1;i>=0;i--)
            {
                obj = MessageInformation[i] as GroupShowForm.GroupShowForm;
                if(obj.Account==account)
                {
                    return obj;
                }
            }
            return null;
        }

        /// <summary>
        /// 删除群组信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static void RemoveGroupsInformation(string account)
        {
            if(GroupsInformation.Count<=0)
            {
                return;
            }

            List<Object> infoList = new List<Object>();//结果列表
            GroupShowForm.GroupShowForm groupShowForm = null;
            for (int i=0;i<GroupsInformation.Count;i++)
            {
                groupShowForm = GroupsInformation[i] as GroupShowForm.GroupShowForm;
                if(groupShowForm.Account!=account)
                {
                    infoList.Add(groupShowForm);
                }
            }
            GroupsInformation = infoList;
        }

        /// <summary>
        /// 删除好友信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static void RemoveFriendsInformation(string account)
        {
            if (FriendsInformation.Count <= 0)
            {
                return;
            }

            List<Object> infoList = new List<Object>();//结果列表
            GroupShowForm.GroupShowForm groupShowForm = null;
            for (int i = 0; i < FriendsInformation.Count; i++)
            {
                groupShowForm = FriendsInformation[i] as GroupShowForm.GroupShowForm;
                if (groupShowForm.Account != account)
                {
                    infoList.Add(groupShowForm);
                }
            }
            FriendsInformation = infoList;
        }

        /// <summary>
        /// 删除消息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static void RemoveMessageInformation(string account)
        {
            if (MessageInformation.Count <= 0)
            {
                return;
            }

            List<Object> infoList = new List<Object>();//结果列表
            GroupShowForm.GroupShowForm groupShowForm = null;
            for (int i = 0; i < MessageInformation.Count; i++)
            {
                groupShowForm = MessageInformation[i] as GroupShowForm.GroupShowForm;
                if (groupShowForm.Account != account)
                {
                    infoList.Add(groupShowForm);
                }
            }
            MessageInformation = infoList;
        }

        //当前登录账户的基础信息以及其属性封装
        public static string Account { get => information.Account; set => information.Account = value; }
        public static string UserName { get => information.UserName; set => information.UserName = value; }
        public static Bitmap Image { get => information.UserImage; set => information.UserImage = value; }
        public static BaseInformation information = new BaseInformation();
    }
}
