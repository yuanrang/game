using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Game.Common
{
    public sealed  class TGbotHelp
    {
        /// <summary>
        /// copy文件夹
        /// </summary>
        /// <param name="sourceDirectory"></param>
        /// <param name="targetDirectory"></param>
        internal static void directoryCopy(string sourceDirectory, string targetDirectory)
        {
            try
            {

                DirectoryInfo dir = new DirectoryInfo(sourceDirectory);

                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)
                    {
                        if (!Directory.Exists(targetDirectory + "\\" + i.Name))
                            Directory.CreateDirectory(targetDirectory + "\\" + i.Name);

                        directoryCopy(i.FullName, targetDirectory + "\\" + i.Name);
                    }
                    else
                        File.Copy(i.FullName, targetDirectory + "\\" + i.Name, true);

                }

            }
            catch { }
        }


        private static ConnectionFactory rabbitMqFactory = new ConnectionFactory()
        {
            UserName = "guest",//用户名
            Password = "guest",//密码
            HostName = "localhost"//rabbitmq ip
            //AutomaticRecoveryEnabled=true
        };

        public static void rabbitackconsu(string json)
        {
            var connection = rabbitMqFactory.CreateConnection();

            var channel = connection.CreateModel();
            channel.QueueDeclare("999999999", false, false, false, null);
            channel.BasicPublish("", "999999999", null,System.Text.Encoding.UTF8.GetBytes(json));
            channel.Close();
            connection.Close();
            
        }


  
        /// <summary>
        /// 启动bot
        /// </summary>
        /// <param name="name"></param>
        /// <param name="token"></param>
        internal static void StartBot(string name, string token)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\" + name + @"\Telegram_Bot\bin\Debug\net5.0\Telegram_Bot.dll.config");
            XmlNode node = doc.SelectSingleNode(@"//add[@key='token']");
            //node.Attributes[0] = "5238108689:AAE0XNZLa07sXPkj80l6d_IjmGDp5tmhLvo";
            XmlElement ele = (XmlElement)node;
            ele.SetAttribute("value", token);
            doc.Save(@"D:\" + name + @"\Telegram_Bot\bin\Debug\net5.0\Telegram_Bot.dll.config");
            try
            {
                string tgbot = @"D:\" + name + @"\Telegram_Bot\bin\Debug\net5.0\Telegram_Bot.exe";
                Process[] arrPro = Process.GetProcessesByName("Telegram_Bot");
                var tgbotfile = arrPro.FirstOrDefault(d => d.MainModule.FileName == tgbot);
                if (tgbotfile != null)
                    tgbotfile.Kill();
                System.Diagnostics.Process.Start(@"D:\" + name + @"\Telegram_Bot\bin\Debug\net5.0\Telegram_Bot.exe");

            }
            catch (Exception)
            {
                RabbitMqModel rabbit = new RabbitMqModel() { Name = name, Token = token };
                rabbitackconsu(JsonConvert.SerializeObject(rabbit));
            }
        }


        internal static bool ExisStart(string maanapossportid)
        {
            string name = @"d:\" + maanapossportid + @"\Telegram_Bot\bin\Debug\net5.0\Telegram_Bot.exe";
            Process[] arrPro = Process.GetProcessesByName("Telegram_Bot");
            return arrPro.FirstOrDefault(d => d.MainModule.FileName == name)==null?false:true;
        }

        /// <summary>
        /// 重启机器人
        /// </summary>
        /// <param name="maanapossportid"></param>
        /// <returns></returns>
        internal static bool RestartStart(string maanapossportid,int tyep)
        {
            string name = @"D:\" + maanapossportid + @"\Telegram_Bot\bin\Debug\net5.0\Telegram_Bot.exe";
            Process[] arrPro = Process.GetProcessesByName("Telegram_Bot");            try
            {
                var tgbot = arrPro.FirstOrDefault(d => d.MainModule.FileName == name);
                if (tgbot != null)
                     tgbot.Kill();
                
                 System.Diagnostics.Process.Start(name);
               
            }
            catch (Exception ex)
            {
                RabbitMqModel rabbit = new RabbitMqModel() { Name = maanapossportid };
                rabbitackconsu(JsonConvert.SerializeObject(rabbit));


            }
            return true;

        }
        /// <summary>
        /// 图片转base64
        /// </summary>
        /// <param name="imgname"></param>
        /// <returns></returns>
        internal static string ImgToBase64(string imgname)
        {
            Bitmap bmp = new Bitmap(imgname);
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] arr = new byte[ms.Length]; ms.Position = 0;
            ms.Read(arr, 0, (int)ms.Length); ms.Close();
            return Convert.ToBase64String(arr);

        }
        /// <summary>
        /// 将选择的图片发送给前端
        /// </summary>
        /// <param name="key"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        internal static  string fileimg(string key,string filename,string base64="")
        {
          
            string name = @"d:\"+filename+@"\Telegram_Bot\bin\Debug\net5.0\TGBOTIMG";
            switch (key)
            {
                case "DSYX":
                    name += "\\单双0-0.jpg";
                    break;
                case "DXYX":
                    name += "\\大小0-0.jpg";
                    break;
                case "BJLYX":
                    name += "\\庄闲0-0.jpg";
                    break;
                case "SWYX":
                    name += "\\尾数0-0.jpg";
                    break;
            }
         
                return name;
        
        }

        /// <summary>
        /// base64转图片
        /// </summary>
        /// <param name="base64"></param>
        /// <param name="filename"></param>
        internal static void Base64Toimg(string base64, string filename)
        {
            base64 = base64.Replace("data:image/png;base64,", "").Replace("data:image/jgp;base64,", "").Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", "");//将base64头部信息替换
          
            System.Drawing.Bitmap bitmap = null;

            try//会有异常抛出，try，catch一下
            {

                byte[] arr = Convert.FromBase64String(base64);

                System.IO.MemoryStream ms = new System.IO.MemoryStream(arr);
                bitmap = new System.Drawing.Bitmap(ms);

                bitmap.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);//保存
                ms.Close();
                bitmap.Dispose();
            }
            catch (Exception e)
            {
                string massage = e.Message;
            }
          
        }
        internal static void StartTaskscheduling()
        {
            //D:\GameQuartz\GameQuartz
            System.Diagnostics.Process.Start(@"D:\GameQuartz\GameQuartz\bin\Debug\net5.0\GameQuartz.exe");

        }
        public static void senmq(string passportid)
        {
            using (var connection = rabbitMqFactory.CreateConnection())
            {
                using (var channl = connection.CreateModel())
                {

                    //指定队列的x-dead-letter-exchange和x-dead-letter-routing-key
                   Dictionary<string, object> queueArgs = new Dictionary<string, object>()
                   {
                     { "x-dead-letter-exchange","exchange.test" },
                     {"x-dead-letter-routing-key","businessRoutingkey" }
                   };

                    channl.ExchangeDeclare("Game.dlx", "direct", true, false, null);
                    channl.QueueDeclare("Game.dlx", true, false, false, queueArgs);
                    channl.QueueBind("Game.dlx", "Game.dlx", "");

                    channl.ExchangeDeclare("exchange.test", "direct", true, false, null);
                    channl.QueueDeclare("Game.test", true, false, false, null);
                    channl.QueueBind("Game.test", "exchange.test", "businessRoutingkey", null);

                    var body = Encoding.UTF8.GetBytes(passportid);
                    var properties = channl.CreateBasicProperties();
                    properties.Persistent = true;
                    properties.Expiration = DateTime.Now.AddMinutes(1).Subtract(DateTime.Now).Seconds + "000";
                    channl.BasicPublish("Game.dlx", "", properties, body);
                
                }
            }

        }

    }
    internal class RabbitMqModel
    {
        public string Name { get; set; }
        public string Token { get; set; }
    }
}
