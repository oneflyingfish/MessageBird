using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace ObjectExpandClass
{
    public static class ExpandForSocket
    {
        /// <summary>
        /// 发送一个信息请求，一次性返回服务器回复内容
        /// 内容均为UTF-8编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="functionKind">请求种类</param>
        /// <param name="addition1">字符串1，不需要写入空串</param>
        /// <param name="addition2">字符串2，不需要写入空串</param>
        /// <param name="bitmap"></param>
        /// <returns>服务器返回的结果</returns>
        public static FunctionWords SendNewsAndReceiveAnswer(this object sender, FunctionKind functionKind=FunctionKind.none, string addition1="", string addition2="",Bitmap bitmap=null)
        {
            //连接服务器
            IPAddress iPAddress = IPAddress.Parse(serverIp);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(new IPEndPoint(iPAddress, serverPort));//连接服务器
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("临时请求发送失败,异常信息:\n" + ex.Message);
                clientSocket.Close();
                return null;
            }

            //确认发送消息内容
            byte[] requestMessage = null;
            switch(functionKind)
            {
                case FunctionKind.SeekForImage:                 //开始+账号+结尾
                    if(!addition1.EndsWith(".com"))
                    {
                        Console.WriteLine("发送信息格式错误:1");
                        clientSocket.Close();
                        return null;
                    }
                    requestMessage = MessageProtocol.AddBytes(MessageProtocol.GetStartBytes(functionKind), MessageProtocol.GetTxtBytes(addition1),MessageProtocol.GetEndBytes());
                    break;
                case FunctionKind.VerifyAccount:                //开始+账户+密码+结尾
                    if (!addition1.EndsWith(".com") || addition2=="")
                    {
                        Console.WriteLine("发送信息格式错误:2");
                        clientSocket.Close();
                        return null;
                    }
                    requestMessage = MessageProtocol.AddBytes(MessageProtocol.GetStartBytes(functionKind), MessageProtocol.GetTxtBytes(addition1), MessageProtocol.GetTxtBytes(addition2), MessageProtocol.GetEndBytes());
                    break;
                case FunctionKind.SeekForUserName:              //开始+账号+结尾
                    requestMessage = MessageProtocol.AddBytes(MessageProtocol.GetStartBytes(functionKind), MessageProtocol.GetTxtBytes(addition1), MessageProtocol.GetEndBytes());
                    break;
                case FunctionKind.SeekForNewGroupAccount:       //开始+结尾
                    requestMessage = MessageProtocol.AddBytes(MessageProtocol.GetStartBytes(functionKind), MessageProtocol.GetEndBytes());
                    break;
                case FunctionKind.QueryMemberOfGroup:           //开始+群号+结尾
                    if (addition1.EndsWith(".com"))
                    {
                        Console.WriteLine("发送信息格式错误:4");
                        clientSocket.Close();
                        return null;
                    }
                    requestMessage = MessageProtocol.AddBytes(MessageProtocol.GetStartBytes(functionKind), MessageProtocol.GetTxtBytes(addition1), MessageProtocol.GetEndBytes());
                    break;
                default:
                    Console.WriteLine("发送信息格式错误:5");
                    clientSocket.Close();
                    return null;
            }

            //确定发送消息不为空
            if (requestMessage == null)
            {
                Console.WriteLine("发送信息格式错误:6");
                clientSocket.Close();
                return null;
            }
            //发送请求
            clientSocket.Send(requestMessage, requestMessage.Length, SocketFlags.None);

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
                        if (dataLengthInFact <= 0) //服务器主动断开连接
                        {
                            errorTimes++;
                            if (errorTimes > 3)
                            {
                                MessageBox.Show("远程服务器主动退出,立即中断操作。错误:7");
                                return null;
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
                            Console.WriteLine("功能尚未开放，错误:7");
                            clientSocket.Close();
                            return null;
                        case BlockKind.End: //读取到块结尾，说明一个功能语句读取完毕
                            goto EndBlock;
                    }
                    realDataReceived = realDataReceived.Skip(blockInformation.lengthOfAll).ToArray();   //去除字节数组中已经读过的部分
                }
                EndBlock:;
            }
            catch(Exception ex)
            {
                Console.WriteLine("连接错误，异常信息:8" + ex.Message);
                return null;
            }

            if(functionKind!=functionWords.functionKind)
            {
                Console.WriteLine("服务器返回了错误的答复:9");
                clientSocket.Close();
                return null;
            }

            return functionWords;
        }

        private static string serverIp = "127.0.0.1";
        private static int serverPort = 12345;
        private static int bufferSize = 1024;
        private static int errorTimes = 0;
    }
}

