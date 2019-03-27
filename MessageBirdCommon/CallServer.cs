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
    public static class CallServer
    {
        /// <summary>
        /// 默认构造函数，连接服务器
        /// 返回值为是否成功
        /// </summary>
        public static bool InitCallServer()
        {
            //连接服务器
            IPAddress iPAddress = IPAddress.Parse(serverIp);
            CallServer.clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            RestartConnection:
            try
            {
                CallServer.clientSocket.Connect(new IPEndPoint(iPAddress, serverPort));//连接服务器
            }
            catch (Exception ex)
            {
                DialogResult result= MessageBox.Show("远程服务器异常:"+ ex.Message+"\n10s后程序将再次尝试连接，点击取消按钮可结束程序\n" ,"错误",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                if(result==DialogResult.Cancel)
                {
                    //CommonEvent.EmitCloseProgramEvent();
                    return false;
                }
                Thread.Sleep(10000);//休眠10s
                goto RestartConnection;
            }

            //打开发送和接收线程
            Thread sendThread = new Thread(CallServer.SendNewsToServer);
            Thread receiveThread = new Thread(CallServer.ReceiveNewsFormServer);
            Thread runFuncionwordsThread = new Thread(RunReceivedFunctionWords);
            sendThread.Start();
            receiveThread.Start();
            runFuncionwordsThread.Start();
            return true;
        }

        /// <summary>
        /// 执行功能块语句
        /// </summary>
        /// <param name="functionWords"></param>
        private static void RunFunctionWords(FunctionWords functionWords)
        {
            switch (functionWords.functionKind)
            {
                case FunctionKind.AnswerApplyToAddFriendEvent:
                    int circulationTimes1=0;
                    if (functionWords.stringList.Count>0 && functionWords.stringList.Count%3==0)
                    {
                        circulationTimes1 = functionWords.stringList.Count / 3;
                    }
                    else
                    {
                        MessageBox.Show("来自服务器的消息格式错误1");
                        return;
                    }

                    for(int i=0;i<circulationTimes1;i++)
                    {
                        string account = functionWords.stringList[3 * i];
                        string userName = functionWords.stringList[3 * i + 1];
                        bool yesOrno = false;
                        if (functionWords.stringList[3 * i + 2]=="true")
                        {
                            yesOrno = true;
                        }
                        CommonEvent.EmitAnswerApplyToAddFriendEvent(account, userName, yesOrno);
                    }
                    break;

                case FunctionKind.AnswerApplyToAddGroupEvent:
                    int circulationTimes2 = 0;
                    if (functionWords.stringList.Count > 0 && functionWords.stringList.Count % 3 == 0 )
                    {
                        circulationTimes2 = functionWords.stringList.Count / 3;
                    }
                    else
                    {
                        MessageBox.Show("来自服务器的消息格式错误2");
                        return;
                    }

                    for (int i = 0; i < circulationTimes2; i++)
                    {
                        string groupAccount = functionWords.stringList[3 * i];
                        string groupName = functionWords.stringList[3 * i + 1];
                        bool yesOrno = false;
                        if (functionWords.stringList[3 * i + 2] == "true")
                        {
                            yesOrno = true;
                        }
                        CommonEvent.EmitAnswerApplyToAddGroupEvent(groupAccount, groupName, yesOrno);
                    }
                    break;

                case FunctionKind.AddFriendMessageListToClient:
                    int circulationTimes3 = 0;
                    if (functionWords.stringList.Count > 0 && functionWords.stringList.Count % 3 == 0)
                    {
                        circulationTimes3 = functionWords.stringList.Count / 3;
                    }
                    else
                    {
                        MessageBox.Show("来自服务器的消息格式错误3");
                        return;
                    }

                    for (int i = 0; i < circulationTimes3; i++)
                    {
                        string account = functionWords.stringList[3 * i];
                        string message = functionWords.stringList[3 * i + 1];
                        string time= functionWords.stringList[3 * i + 2];

                        CommonEvent.EmitAddNewFriendMessageEvent(account, message, time);
                    }
                    break;

                case FunctionKind.AddGroupMessageListToClient:
                    int circulationTimes4 = 0;
                    if (functionWords.stringList.Count > 0 && functionWords.stringList.Count % 5 == 0 && ((functionWords.stringList.Count / 5) == functionWords.bitmapList.Count))
                    {
                        circulationTimes4 = functionWords.bitmapList.Count;
                    }
                    else
                    {
                        MessageBox.Show("来自服务器的消息格式错误4");
                        return;
                    }

                    for (int i = 0; i < circulationTimes4; i++)
                    {
                        string userName = functionWords.stringList[5 * i];
                        string userAccount = functionWords.stringList[5 * i + 1];
                        string message = functionWords.stringList[5 * i + 2];
                        string time = functionWords.stringList[5 * i + 3];
                        string groupAccount = functionWords.stringList[5 * i + 4];

                        CommonEvent.EmitAddNewGroupMessageEvent(userName, userAccount, message, time, functionWords.bitmapList[i], groupAccount);
                    }
                    break;

                case FunctionKind.AddFriendsListToClient:
                    int circulationTimes5 = 0;
                    if (functionWords.stringList.Count > 0 && functionWords.stringList.Count % 3 == 0 && ((functionWords.stringList.Count / 3) == functionWords.bitmapList.Count))
                    {
                        circulationTimes5 = functionWords.bitmapList.Count;
                    }
                    else
                    {
                        MessageBox.Show("来自服务器的消息格式错误5");
                        return;
                    }

                    for (int i = 0; i < circulationTimes5; i++)
                    {
                        string userName = functionWords.stringList[3 * i];
                        string account = functionWords.stringList[3 * i + 1];
                        bool isOnline = false;
                        if (functionWords.stringList[3 * i + 2] == "true")
                        {
                            isOnline = true;
                        }

                        CommonEvent.EmitAddNewFriendEvent(userName, account,functionWords.bitmapList[i],isOnline);
                    }
                    ReceivedListCount++;
                    break;

                case FunctionKind.AddGroupsListToClient:
                    int circulationTimes6 = 0;
                    if (functionWords.stringList.Count > 0 && functionWords.stringList.Count % 2 == 0 && ((functionWords.stringList.Count / 2) == functionWords.bitmapList.Count))
                    {
                        circulationTimes6 = functionWords.bitmapList.Count;
                    }
                    else
                    {
                        MessageBox.Show("来自服务器的消息格式错误5");
                        return;
                    }

                    for (int i = 0; i < circulationTimes6; i++)
                    {
                        string groupName = functionWords.stringList[2 * i];
                        string account = functionWords.stringList[2 * i + 1];
                        CommonEvent.EmitAddNewGroupEvent(groupName, account, functionWords.bitmapList[i]);
                    }
                    ReceivedListCount++;
                    break;

                case FunctionKind.SendOnlineStatusToClient:
                    int circulationTimes7 = 0;
                    if (functionWords.stringList.Count > 0 && functionWords.stringList.Count % 2 == 0)
                    {
                        circulationTimes7 = functionWords.stringList.Count % 2;
                    }
                    else
                    {
                        MessageBox.Show("来自服务器的消息格式错误5");
                        return;
                    }

                    for (int i = 0; i < circulationTimes7; i++)
                    {
                        string account = functionWords.stringList[2 * i];
                        bool isOnline = false;
                        if (functionWords.stringList[2 * i + 2] == "true")
                        {
                            isOnline = true;
                        }
                        CommonEvent.EmitOnlineChangeEvent(account, isOnline);
                    }
                    break;
            }
        }

        /// <summary>
        /// 添加一个字节数组到待发送消息队列
        /// </summary>
        /// <param name="news"></param>
        public static void AddSendNews(Byte[] news)
        {
            waitToSendBytes.Enqueue(news);
        }

        // <summary>
        /// 添加一个字节数组到待发送消息队列
        /// </summary>
        /// <param name="news"></param>
        public static void AddSendNews(Byte[] news1, Byte[] news2)
        {
            waitToSendBytes.Enqueue(MessageProtocol.AddBytes(news1,news2));
        }

        // <summary>
        /// 添加一个字节数组到待发送消息队列
        /// </summary>
        /// <param name="news"></param>
        public static void AddSendNews(Byte[] news1, Byte[] news2, Byte[] news3)
        {
            waitToSendBytes.Enqueue(MessageProtocol.AddBytes(news1, news2,news3));
        }

        // <summary>
        /// 添加一个字节数组到待发送消息队列
        /// </summary>
        /// <param name="news"></param>
        public static void AddSendNews(Byte[] news1, Byte[] news2, Byte[] news3, Byte[] news4)
        {
            waitToSendBytes.Enqueue(MessageProtocol.AddBytes(news1, news2, news3,news4));
        }

        // <summary>
        /// 添加一个字节数组到待发送消息队列
        /// </summary>
        /// <param name="news"></param>
        public static void AddSendNews(Byte[] news1, Byte[] news2, Byte[] news3, Byte[] news4, Byte[] news5)
        {
            waitToSendBytes.Enqueue(MessageProtocol.AddBytes(news1, news2, news3, news4,news5));
        }

        // <summary>
        /// 添加一个字节数组到待发送消息队列
        /// </summary>
        /// <param name="news"></param>
        public static void AddSendNews(Byte[] news1, Byte[] news2, Byte[] news3, Byte[] news4, Byte[] news5, Byte[] news6)
        {
            waitToSendBytes.Enqueue(MessageProtocol.AddBytes(MessageProtocol.AddBytes(news1, news2, news3), MessageProtocol.AddBytes(news4, news5, news6)));
        }

        /// <summary>
        /// 执行 “待执行的功能块队列” 中的功能
        /// 并发执行
        /// </summary>
        private static void RunReceivedFunctionWords()
        {
            while (true)
            {
                while (receivedFunctionWords.Count < 1)
                {
                    Thread.Sleep(100);
                }
                RunFunctionWords(receivedFunctionWords.Dequeue());
            }
        }

        /// <summary>
        /// 将消息从 “待发送字节队列” 发送到远程服务器
        /// 并发执行
        /// </summary>
        private static void SendNewsToServer()
        {
            while (true)
            {
                while (waitToSendBytes.Count < 1)
                {
                    Thread.Sleep(100);
                }
                clientSocket.Send(waitToSendBytes.Dequeue());
            }
        }


        /// <summary>
        /// 接收消息、解码并存储在 “待执行的功能块队列” 中
        /// 并发执行
        /// </summary>
        private static void ReceiveNewsFormServer()
        {
            //开始接收返回值
            Byte[] realDataReceived = new Byte[0];
            FunctionWords functionWords = new FunctionWords();

            try
            {
                //开始读取，遇到结束标识跳出
                while (true)
                {
                    //确保头部四字节数据完整
                    while (realDataReceived.Length < 4)
                    {
                        Byte[] RecvArray = new Byte[bufferSize];  //用于存放接收信息
                        int dataLengthInFact = clientSocket.Receive(RecvArray);   //接收信息
                        if(dataLengthInFact<=0) //服务器主动断开连接
                        {
                            errorTimes++;
                            if(errorTimes>3)
                            {
                                MessageBox.Show("远程服务器主动退出,立即中断操作。错误:7");
                                return;
                            }
                        }
                        else
                        {
                            errorTimes = 0;
                        }
                        realDataReceived = MessageProtocol.AddBytes(realDataReceived, RecvArray.Take(dataLengthInFact).ToArray());
                    }
                    BlockInformation blockInformation = realDataReceived.ReadBlockInformation(0);

                    //确保尾部数据完整
                    while (realDataReceived.Length < blockInformation.lengthOfAll)
                    {
                        Byte[] RecvArray = new Byte[bufferSize];  //用于存放接收信息
                        int dataLengthInFact = clientSocket.Receive(RecvArray);   //接收信息
                        realDataReceived = MessageProtocol.AddBytes(realDataReceived, RecvArray.Take(dataLengthInFact).ToArray());
                    }

                    switch (blockInformation.blockKind)
                    {
                        case BlockKind.Start:
                            functionWords.functionKind = blockInformation.functionKind;
                            break;
                        case BlockKind.Txt: //读取字符串
                            functionWords.stringList.Add(realDataReceived.ToTxt(4, blockInformation.LengthOfValue));
                            break;
                        case BlockKind.Image:
                            functionWords.bitmapList.Add(realDataReceived.ToBitmap(4, blockInformation.LengthOfValue));
                            break;
                        case BlockKind.File: //预留接口
                            Console.WriteLine("文件传输功能尚未开放，错误:8");
                            break;
                        case BlockKind.End: //读取到块结尾，说明一个功能语句读取完毕
                            receivedFunctionWords.Enqueue(functionWords);
                            functionWords = new FunctionWords();
                            break;
                    }
                    realDataReceived = realDataReceived.Skip(blockInformation.lengthOfAll).ToArray();   //去除字节数组中已经读过的部分
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接错误，异常信息:9" + ex.Message);
                return;
            }
        }

        /// <summary>
        /// 待执行的功能块队列
        /// </summary>
        private static Queue<FunctionWords> receivedFunctionWords=new Queue<FunctionWords>();
        /// <summary>
        /// 待发送的字节队列
        /// </summary>
        private static Queue<Byte[]> waitToSendBytes=new Queue<Byte[]>();

        /// <summary>
        /// 此套接字连接后直到客户端关闭不断开
        /// </summary>
        private static Socket clientSocket = null;

        //远程服务器基础信息
        private static string serverIp = "127.0.0.1";
        private static int serverPort = 54321;
        private static int bufferSize = 1024;
        private static int receivedListCount = 0;
        private static int errorTimes = 0;
        public static int ReceivedListCount
        {
            get => receivedListCount;
            set
            {
                receivedListCount = value;
                if(receivedListCount==2)
                {
                    CallServer.AddSendNews(MessageProtocol.GetStartBytes(FunctionKind.ClientAllReadyToReceiveNews),"true".ToTxtBytes(), MessageProtocol.GetEndBytes());
                }
            }
        }
    }
}
