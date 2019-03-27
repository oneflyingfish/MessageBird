using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace MessageBirdCommonClass
{
    /// <summary>
    /// 用来描述一个讯息的类
    /// </summary>
    public class MessageInformation : BaseInformation
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public MessageInformation() : base()
        {
            //无操作
        }

        /// <summary>
        /// 0：kind.ToString()
        /// 1：userName
        /// 2：account
        /// 3：time
        /// 4：message
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public override string this[string index]
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
                    case 3:
                        return this.time;
                    case 4:
                        return this.message;
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
                    case 3:
                        this.time = value;
                        break;
                    case 4:
                        this.message = value;
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
        public override bool HasKeywords(string Keywords)
        {
            if(this.account.Contains(Keywords) || this.userName.Contains(Keywords) ||this.message.Contains(Keywords) ||this.time.Contains(Keywords))
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
        /// <param name="time"></param>
        /// <param name="message"></param>
        /// <param name="image"></param>
        public void SetInformation(int kind,string account,string userName,string time,string message,Bitmap image,bool isOnline)
        {
            this.Kind = kind;
            this.Account = account;
            this.UserName = userName;
            this.Time = time;
            this.Message = message;
            this.UserImage = image;
            this.IsOnline = isOnline;
        }


        public string Time
        {
            get => time;
            set
            {
                if(value.Length>=6)
                {
                    time = value.Substring(5);
                    return;
                }
                time = value;
                return;
            }
        }
        public string Message { get => message; set => message = value; }

        private string time="";
        private string message="";
        private new const int count = 5;//索引器索引个数,覆盖基类
    }
}
