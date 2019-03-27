using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;
using System.Windows.Forms;

namespace MessageBird
{
    /// <summary>
    /// 定义右键发送功能的类
    /// </summary>
    class Email
    {
        /// <summary>
        /// 发送邮件
        /// subject邮件主题
        /// body邮件正文
        /// userName = "yt13087554668@126.com";  发送端账号   
        /// password = "china569874123";  发送端密码
        /// host = "smtp.126.com";  邮件服务器smtp.163.com表示网易邮箱服务器  ;要开启25端口
        /// 返回true表示发送成功
        /// </summary>
        public static bool SendEmail(string subject, string body, string sendto, string userName = "yt13087554668@126.com", string password = "china569874123", string sendername = "信鸽应用", string host = "smtp.126.com")
        {
            //管理员权限执行DOS命令，开启25端口
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = System.Environment.CurrentDirectory + "\\一键开启网易邮箱端口.bat";
            startInfo.Verb = "runas";
            try
            {
                System.Diagnostics.Process.Start(startInfo);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式    
            client.Host = host;//邮件服务器
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential(userName, password);//用户名、密码
            try
            {
                //string strfrom = userName;
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(userName, sendername);
                msg.To.Add(sendto);//发送给XXX
                msg.Subject = subject;//邮件标题   
                msg.Body = body;//邮件内容   
                msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码   
                msg.IsBodyHtml = true;//是否是HTML邮件   
                msg.Priority = MailPriority.Low; //邮件优先级
                client.Send(msg);
                //MessageBox.Show("发送成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误参数: " + ex.Message + "\n请稍后再试", "发生错误");
                return false;
            }
            finally
            {
                startInfo.FileName = System.Environment.CurrentDirectory + "\\一键关闭网易邮箱端口.bat";
                try
                {
                    System.Diagnostics.Process.Start(startInfo);
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return true;
        }
    }
}

