using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectExpandClass
{
    public static class MessageProtocol
    {
        /// <summary>
        /// 转化为可传输的开始字节流
        /// </summary>
        /// <param name="functionKind"></param>
        /// <returns></returns>
        public static Byte[] GetStartBytes(FunctionKind functionKind)
        {
            int numberHeader = ((int)functionKind)*10 + (int)BlockKind.Start;
            return BitConverter.GetBytes(numberHeader);
        }

        /// <summary>
        /// 转化为可传输的开始字节流
        /// 拓展方法
        /// </summary>
        /// <param name="functionKind"></param>
        /// <returns></returns>
        public static Byte[] ToStartBytes(this FunctionKind functionKind)
        {
            return GetStartBytes(functionKind);
        }

        /// <summary>
        /// 转化为可传输的文字字节流
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Byte[] GetTxtBytes(string text)
        {
            Byte[] txtBytes = text.ToBytes();
            int numberHeader = txtBytes.Length * 10 + (int)BlockKind.Txt;
            return AddBytes(BitConverter.GetBytes(numberHeader), txtBytes);
        }

        /// <summary>
        /// 转化为可传输的文字字节流
        /// 拓展方法
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Byte[] ToTxtBytes(this string text)
        {
            return GetTxtBytes(text);
        }

        /// <summary>
        /// 转化为可传输的图片字节流
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static Byte[] GetImageBytes(Bitmap bitmap)
        {
            Byte[] bitmapBytes = bitmap.ToBytes();
            int numberHeader = bitmapBytes.Length * 10 + (int)BlockKind.Image;
            return AddBytes(BitConverter.GetBytes(numberHeader),bitmapBytes);
        }

        /// <summary>
        /// 转化为可传输的图片字节流
        /// 拓展方法
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static Byte[] ToImageBytes(this Bitmap bitmap)
        {
            return GetImageBytes(bitmap);
        }

        /// <summary>
        /// 转化为可传输的文件字节流，功能尚未实现！！
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static Byte[] GetFilesBytes(FileStream file)
        {
            return null;
        }

        /// <summary>
        /// 转化为可传输的文件字节流，功能尚未实现！！
        /// 拓展类
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static Byte[] ToFilesBytes(this FileStream file)
        {
            return GetFilesBytes(file);
        }

        /// <summary>
        /// 转化为可传输的结束字节流
        /// </summary>
        /// <returns></returns>
        public static Byte[] GetEndBytes()
        {
            return BitConverter.GetBytes((int)BlockKind.End);
        }

        /// <summary>
        /// 从数组的指定索引，读取一个块的说明书
        /// </summary>
        /// <param name="array"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static BlockInformation GetBlockInformation(Byte[] array,int startIndex=0)
        {
            int number = BitConverter.ToInt32(array, startIndex);
            BlockInformation blockInformation = new BlockInformation();
            blockInformation.blockKind = (BlockKind)(number % 10);
            if(blockInformation.blockKind==BlockKind.Start)
            {
                blockInformation.LengthOfValue = 0;
                blockInformation.functionKind = (FunctionKind)(number / 10);
            }
            else
            {
                blockInformation.LengthOfValue = number/10;
            }
            return blockInformation;
        }

        /// <summary>
        /// 从数组的指定索引，读取一个块的说明书
        /// </summary>
        /// <param name="array"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static BlockInformation ReadBlockInformation(this Byte[] array, int startIndex = 0)
        {
            int number = BitConverter.ToInt32(array, startIndex);
            BlockInformation blockInformation = new BlockInformation();
            blockInformation.blockKind = (BlockKind)(number % 10);
            if (blockInformation.blockKind == BlockKind.Start)
            {
                blockInformation.LengthOfValue = 0;
                blockInformation.functionKind = (FunctionKind)(number / 10);
            }
            else
            {
                blockInformation.LengthOfValue = number / 10;
            }
            return blockInformation;
        }

        /// <summary>
        /// 拼接两个字节数组
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Byte[] AddBytes(Byte[] a, Byte[] b)
        {
            if(a==null)
            {
                if(b==null)
                {
                    return null;
                }
                else
                {
                    return b;
                }
            }
            else
            {
                if(b==null)
                {
                    return a;
                }
            }
            Byte[] result = new Byte[a.Length + b.Length];
            System.Buffer.BlockCopy(a, 0, result, 0, a.Length);
            System.Buffer.BlockCopy(b, 0, result, a.Length, b.Length);
            return result;
        }

        /// <summary>
        /// 拼接三个字节数组
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Byte[] AddBytes(Byte[] a, Byte[] b, Byte[] c)
        {
            Byte[] result = new Byte[a.Length + b.Length + c.Length];
            System.Buffer.BlockCopy(a, 0, result, 0, a.Length);
            System.Buffer.BlockCopy(b, 0, result, a.Length, b.Length);
            System.Buffer.BlockCopy(c, 0, result, a.Length + b.Length, c.Length);
            return result;
        }

        /// <summary>
        /// 拼接四个字节数组
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Byte[] AddBytes(Byte[] a, Byte[] b, Byte[] c, Byte[] d)
        {
            Byte[] result = new Byte[a.Length + b.Length + c.Length + d.Length];
            System.Buffer.BlockCopy(a, 0, result, 0, a.Length);
            System.Buffer.BlockCopy(b, 0, result, a.Length, b.Length);
            System.Buffer.BlockCopy(c, 0, result, a.Length + b.Length, c.Length);
            System.Buffer.BlockCopy(d, 0, result, a.Length + b.Length+ c.Length,d.Length);
            return result;
        }

        /// <summary>
        /// 拼接五个字节数组
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Byte[] AddBytes(Byte[] a, Byte[] b, Byte[] c, Byte[] d,Byte[] e)
        {
            Byte[] result = new Byte[a.Length + b.Length + c.Length + d.Length+e.Length];
            System.Buffer.BlockCopy(a, 0, result, 0, a.Length);
            System.Buffer.BlockCopy(b, 0, result, a.Length, b.Length);
            System.Buffer.BlockCopy(c, 0, result, a.Length + b.Length, c.Length);
            System.Buffer.BlockCopy(d, 0, result, a.Length + b.Length + c.Length, d.Length);
            System.Buffer.BlockCopy(e, 0, result, a.Length + b.Length + c.Length + d.Length, e.Length);
            return result;
        }

        /// <summary>
        /// 图片转化为字节数组
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static Byte[] ToBytes(this Bitmap bitmap)
        {
            MemoryStream memoryStream = new MemoryStream();
            byte[] result = null;
            bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            result = memoryStream.GetBuffer();
            return result;
        }

        /// <summary>
        /// 字符串转化为字节数组
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static Byte[] ToBytes(this string txt)
        {
            return System.Text.Encoding.UTF8.GetBytes(txt);
        }

        /// <summary>
        /// 从字节数组中读取图片
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static Bitmap ToBitmap(this Byte[] bytes, int startIndex, int length)
        {
            MemoryStream memoryStream = new MemoryStream(bytes.Skip(startIndex).Take(length).ToArray());
            Bitmap bitmap = new Bitmap(Bitmap.FromStream(memoryStream));
            return bitmap;
        }

        /// <summary>
        /// 从字节数组中读取字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ToTxt(this Byte[] bytes, int startIndex, int length)
        {
            return System.Text.Encoding.UTF8.GetString(bytes, startIndex, length);
        }
    }

    /// <summary>
    /// 一个语句块功能枚举
    /// 共18种有效
    /// </summary>
    public enum FunctionKind
    {
        none=0,
        //立即请求：五种
        SeekForImage=1,                 //输入完账户立即请求图像
        VerifyAccount=2,                //登录时立即请求验证账户
        SeekForUserName=3,              //登录时和请求添加好友/群聊时立即请求昵称,为空串表示账户不存在
        SeekForNewGroupAccount=4,       //请求服务器产生新的群号
        QueryMemberOfGroup=5,           //立即查询一个群的所有成员

        //随机请求：十三种
        //RequestForFriendsList,          //请求好友列表
        //RequestForGroupList,            //请求群组列表
        //发送至服务器
        DeclareConnect,                 //刚连接服务器时声明一个连接，收到信息时服务器自动返回好友列表和群组列表
        ClientAllReadyToReceiveNews,    //客户端准备就绪，通知服务器可以开始转送新消息
        RequestToRegeditAccount,        //客户端请求服务器注册账户/修改信息，账户+密码+昵称+图像
        RequestToRegeditGroup,          //客户端请求注册群聊/修改群聊名称，账户+群号+群号昵称
        ApplyToAddFriend,               //客户端请求添加好友，服务器将转发给指定用户 我的账户+我的昵称+目标账户，或者是服务器通知用户别的用户发起请求
        ApplyToAddGroup,                //客户端请求添加群聊，不加以认证，直接注册 账户+群号
        //从服务器接收
        AnswerApplyToAddFriendEvent,    //用户B对用户A请求添加好友的回复 账户B+账户B昵称+账户A+回复
        AnswerApplyToAddGroupEvent,     //请求添加群聊的回复 账户B+账户B昵称+账户A+回复
        AddFriendMessageListToClient,   //服务器通知客户端新好友消息到达,至少包含例如好友账户+好友图像+群号/好友账户+消息
        AddGroupMessageListToClient,    //服务器通知客户端新群聊消息到达,至少包含例如好友账户+好友图像+群号/好友账户+消息
        SendOnlineStatusToClient,       //向客户端发送在线/离线信息
        AddFriendsListToClient,         //服务器通知客户端添加好友，可能是回复好友列表请求，也可能是新的添加，账户+昵称+图像+在线信息
        AddGroupsListToClient,          //服务器通知客户端添加好友，可能是回复好友列表请求，也可能是新的添加
    }

    /// <summary>
    /// 一个区间的类型枚举
    /// </summary>
    public enum BlockKind
    {
        none=0,
        Start = 1,      //一个block的开头
        Txt =2,
        Image=3,
        File=4,
        End=5,          //一个block的结尾
        Error =6
    }
}

//采取火车协议

///// <summary>
///// 用于开始标记等
///// </summary>
///// <param name="messageKind">messageKind.Start</param>
///// <param name="sendAccount">消息发送者，通常为本用户账户</param>
///// <param name="environmentAccount">群号/好友账户</param>
///// <returns>形成具有一定含义，可以供发出的字节数组</returns>
//public static Byte[] MessageToBytes(MessageKind messageKind,Byte[] sendAccount, Byte[] environmentAccount)
//{
//    if(messageKind!=MessageKind.Start)
//    {
//        return null;
//    }

//    Int32 headNumber = (Int32)messageKind + sendAccount.Length * 10 + environmentAccount.Length * 100000; //定义此消息头部数值大小
//    return AddBytes(BitConverter.GetBytes(headNumber), sendAccount, environmentAccount);
//}

///// <summary>
///// 用于消息、图片、文件等
///// </summary>
///// <param name="messageKind">messageKind.Txt | messageKind.image | messageKind.File</param>
///// <param name="contain">数据正文</param>
///// <returns>形成具有一定含义，可以供发出的字节数组</returns>
//public static Byte[] MessageToBytes(MessageKind messageKind, Byte[] contain)
//{
//    if (messageKind != MessageKind.Txt && messageKind != MessageKind.Image && messageKind != MessageKind.File)
//    {
//        return null;
//    }

//    Int32 headNumber = (Int32)messageKind + contain.Length*10; //定义此消息头部数值大小
//    return AddBytes(BitConverter.GetBytes(headNumber),contain);
//}

///// <summary>
///// 用户具有指定功能的字节数组，而不是为了传输数据
///// </summary>
///// <param name="messageKind">messageKind.Signal</param>
///// <param name="signalKind">枚举,对应不同的特定含义</param>
///// <param name="sendAccount">消息发送账户</param>
///// <param name="Additional">可以是密码，账户，或者其它信息，不大于0.97KB</param>
///// <returns>形成具有一定含义，可以供发出的字节数组</returns>
//public static Byte[] MessageToBytes(MessageKind messageKind, SignalKind signalKind,Byte[] sendAccount,Byte[] Additional=null)
//{
//    if (messageKind != MessageKind.Signal)
//    {
//        return null;
//    }
//    if(Additional==null)
//    {
//        Int32 headNumber = (Int32)messageKind + sendAccount.Length * 10; //定义此消息头部数值大小
//        return AddBytes(BitConverter.GetBytes(headNumber), BitConverter.GetBytes((Byte)signalKind), sendAccount);
//    }
//    else
//    {
//        Int32 headNumber = (Int32)messageKind + sendAccount.Length * 10 + Additional.Length * 100000; //定义此消息头部数值大小
//        return AddBytes(BitConverter.GetBytes(headNumber), BitConverter.GetBytes((Byte)signalKind), sendAccount, Additional);
//    }
//}

///// <summary>
///// 接收此消息表示一个消息块传送完毕，一个消息块总是紧随一个MessageKind.End
///// 主通信中应该与essageKind.Start配套使用，临时通信中可省略
///// </summary>
///// <param name="messageKind"></param>
///// <returns></returns>
//public static Byte[] MessageToBytes(MessageKind messageKind)
//{
//    if (messageKind != MessageKind.End)
//    {
//        return null;
//    }
//    Int32 headNumber = (Int32)messageKind; //定义此消息头部数值大小
//    return BitConverter.GetBytes(headNumber);
//}

///// <summary>
///// 从数据头部分离出第二个变量的字节数(头部最左边一段有效数据）
///// </summary>
///// <param name="number"></param>
///// <returns></returns>
//public static int GetSecondPartByteNumber(Int32 number)
//{
//    return number / 100000 % 10000;
//}


///// <summary>
///// 从数据头部分离出第一个变量的字节数(头部最左边一段有效数据）
///// </summary>
///// <param name="number"></param>
///// <returns></returns>
//public static int GetFirstPartByteNumber(Int32 number)
//{
//    return number / 10 % 10000;
//}

///// <summary>
///// 计算图片、消息、文件等所占字节数
///// </summary>
///// <param name="number"></param>
///// <returns></returns>
//public static int GetFileBytesNumber(Int32 number)
//{
//    return number / 10 % 100000000;
//}

///// <summary>
///// 从数据头部分离出信号部分
///// </summary>
///// <param name="number"></param>
///// <returns></returns>
//public static int GetOneByteSignalNumber(Int32 number)
//{
//    return number % 10;
//}

///// <summary>
///// 从数组指定索引开始获取标识信息
///// </summary>
///// <param name="array"></param>
///// <param name="startIndex">起始索引</param>
///// <returns></returns>
//public static ValueInformation GetBlockInformation(Byte[] array, int startIndex = 0)
//{
//    int number = BitConverter.ToInt32(array, startIndex);
//    ValueInformation valueInformation = new ValueInformation();
//    valueInformation.Kind = number % 10;
//    switch (valueInformation.messageKind)
//    {
//        case MessageKind.Start:
//            valueInformation.length1 = number / 10 % 10000;
//            valueInformation.length2 = number / 100000 % 10000;
//            valueInformation.lengthOfValue = valueInformation.length1 + valueInformation.length2;
//            valueInformation.lengthOfAll = 4 + valueInformation.lengthOfValue;
//            break;
//        case MessageKind.Txt:
//            valueInformation.length1 = number / 10 % 100000000;
//            valueInformation.lengthOfValue = valueInformation.length1;
//            valueInformation.length2 = 0;
//            valueInformation.lengthOfAll = 4 + valueInformation.lengthOfValue;
//            break;
//        case MessageKind.Image:
//            valueInformation.length1 = number / 10 % 100000000;
//            valueInformation.lengthOfValue = valueInformation.length1;
//            valueInformation.length2 = 0;
//            valueInformation.lengthOfAll = 4 + valueInformation.lengthOfValue;
//            break;
//        case MessageKind.File:
//            valueInformation.length1 = number / 10 % 100000000;
//            valueInformation.lengthOfValue = valueInformation.length1;
//            valueInformation.length2 = 0;
//            valueInformation.lengthOfAll = 4 + valueInformation.lengthOfValue;
//            break;
//        case MessageKind.Signal:
//            valueInformation.length1 = number / 10 % 10000;
//            valueInformation.length2 = number / 100000 % 10000;
//            valueInformation.Signal = BitConverter.ToInt16(array, startIndex + 4);
//            valueInformation.lengthOfValue = valueInformation.length1 + valueInformation.length2;
//            valueInformation.lengthOfAll = 6 + valueInformation.lengthOfValue;
//            break;
//        case MessageKind.End:
//            valueInformation.length1 = 0;
//            valueInformation.length2 = 0;
//            valueInformation.lengthOfValue = 0;
//            valueInformation.lengthOfAll = 4;
//            break;
//        default:
//            break;
//    }
//    return valueInformation;
//}