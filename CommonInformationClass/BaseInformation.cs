using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBirdCommonClass
{
    /// <summary>
    /// 用来描述一个用户/群信息的类
    /// </summary>
    public class BaseInformation
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public BaseInformation()
        {
            //无操作
        }

        /// <summary>
        /// 0：kind.ToString()
        /// 1：userName
        /// 2：account
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public virtual string this[string index]
        {
            get
            {
                int i = -1;
                if (!int.TryParse(index, out i))
                {
                    return "";
                }
                switch (i)
                {
                    case 0:
                        return this.Kind.ToString();
                    case 1:
                        return this.userName;
                    case 2:
                        return this.account;
                    default:
                        return "";
                }
            }
            set
            {
                int i = -1;
                if (!int.TryParse(index, out i))
                {
                    //不执行操作
                }
                switch (i)
                {
                    case 0:
                        this.Kind = int.Parse(value);
                        break;
                    case 1:
                        this.userName = value;
                        break;
                    case 2:
                        this.account = value;
                        break;
                    default:
                        break;
                }
            }

        }

        /// <summary>
        /// 判断内部信息是否包含关键字
        /// </summary>
        /// <param name="Keywords"></param>
        /// <returns></returns>
        public virtual bool HasKeywords(string Keywords)
        {
            if (this.account.Contains(Keywords) || this.userName.Contains(Keywords))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 重置信息
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="account"></param>
        /// <param name="userName"></param>
        /// <param name="userImage"></param>
        public virtual void SetInformation(int kind, string account, string userName,Bitmap userImage,bool isOnline)
        {
            this.Kind = kind;
            this.Account = account;
            this.UserName = userName;
            this.UserImage = userImage;
            this.IsOnline = isOnline;
        }

        public virtual int Kind { get => kind; set => kind = value; }
        public virtual string Account { get => account; set => account = value; }
        public virtual string UserName { get => userName; set => userName = value; }
        public virtual Bitmap UserImage { get => image; set => image = value; }
        public virtual int Count { get => count; }
        public bool IsOnline { get => isOnline; set => isOnline = value; }

        protected int kind = 0;
        protected string account = "xin@xinge.com";
        protected string userName = "用户";
        protected System.Drawing.Bitmap image = null;
        protected const int count = 3;//索引器索引个数
        protected bool isOnline = true;
    }
}
