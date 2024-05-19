using CSRedis;
using Game.Common;
using Game.Model;
using Newtonsoft.Json;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram_Bot.Bussion;
using Telegram_Bot.Model;

namespace Telegram_Bot.lang
{
    public static class CallLang
    {
        private static object locks=new object();
        private static Send.SendMessage send;
        private static string TGUrl = "https://t.me/";
        static CallLang()
        {
            if (send == null)
            {
                lock (locks)
                {
                    if(send == null)
                        send = new Send.SendMessage();
                }
            }
        }
        public static async void BotLang(SqlSugarScope db, CSRedisClient csredis, long ManageUserPassportId, string lang, long chatId, string messageText, string moneyAddress, string receiveMessage, ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            csredis.Del($"{ManageUserPassportId}Lang");
            List<ULangDetails> list = new List<ULangDetails>();
            if (!csredis.Exists($"{ManageUserPassportId}Lang"))
            {
                list = db.Queryable<ULangDetails>().Where(c => c.ManageUserPassportId == ManageUserPassportId).ToList();
                csredis.Set($"{ManageUserPassportId}Lang", list, 3600 * 24 * 30);
            }
            if (csredis.Get<List<ULangDetails>>($"{ManageUserPassportId}Lang")?.Count < 1)
            {
                list = db.Queryable<ULangDetails>().Where(c => c.ManageUserPassportId == ManageUserPassportId).ToList();
                csredis.Set($"{ManageUserPassportId}Lang", list, 3600 * 24 * 30);
            }
           
            list = csredis.Get<List<ULangDetails>>($"{ManageUserPassportId}Lang");
            ///语言区分
            int IntLang = 1;
            if (!string.IsNullOrWhiteSpace(lang))
            {
                int.TryParse(lang, out IntLang);
            }
            else
            {
                csredis.Del(update.CallbackQuery.Message.Chat.Id.ToString());
            }
            List<KeyboardButton[]> arraybuttons = new List<KeyboardButton[]>();
            List<KeyboardButton> buttons = new List<KeyboardButton>();
            list = list.Where(x => x.ULangId == IntLang).ToList();
            var d = list.Where(x => x.IsKeyboard == 1).ToList();
            if (d.Count > 6)
            {
                for (int i = 0; i < d.Count; i++)
                {
                    if (i == 9) break;
                    if (i % 3 == 0 && i != 0)
                    {
                        arraybuttons.Add(buttons.ToArray());
                        buttons.Clear();
                    }
                    buttons.Add(d[i].ULangValue);
                }
            }
            else
            {
                for (int i = 0; i < d.Count; i++)
                {
                    if (i % 2 == 0 && i != 0)
                    {
                        arraybuttons.Add(buttons.ToArray());
                        buttons.Clear();
                    }
                    buttons.Add(d[i].ULangValue);
                }
            }
            if (buttons.Count > 0)
            {
                arraybuttons.Add(buttons.ToArray());
            }
            ReplyKeyboardMarkup replyKeyboardMarkup = new(arraybuttons)
            {
                ResizeKeyboard = true
            };

            var u_langval = list.Where(x => x.IsKeyboard == 1 && x.ULangValue.Equals(messageText)).FirstOrDefault();

            string TJCode = string.Empty;
            if (messageText.Contains("/start"))
            {
                TJCode = messageText.Replace("/start", "").Trim();
                if (!csredis.Exists($"{chatId.ToString()}TJCode"))
                {
                    csredis.Set($"{chatId.ToString()}TJCode", TJCode);
                }

                UserInfo userInfo = db.Queryable<UserInfo>().First(c => c.UserName == chatId.ToString());
                if (userInfo == null) //数据库中不存在
                {
                    TJCode = list.Where(x => x.ULangKey == "BINDCONTENT").FirstOrDefault().ULangValue;
                }
               
                Console.WriteLine($"Received a 注册 message in chat {chatId} TJCode:{TJCode}");
            }
            else if (messageText.Length == 34)
            {
                moneyAddress = messageText;
                string url = $"{ConfigurationManager.AppSettings["address"].ToString()}{moneyAddress}";
                string result = HttpHelper.Helper.GetMoths(url);
                TrcResult trc = JsonConvert.DeserializeObject<TrcResult>(result);
                if (trc.success.Trim().ToUpper() == "TRUE")
                {
                    UserInfo userInfo = db.Queryable<UserInfo>().First(c => c.UserName == chatId.ToString());
                    if (userInfo == null) //数据库中不存在
                    {
                        TJCode = csredis.Get($"{chatId.ToString()}TJCode");
                        string register_url = ConfigurationManager.AppSettings["register"].ToString();
                        dynamic dc = "{\"UserName\":\"" + chatId.ToString() + "\",\"HashAddress\":\"" + messageText + "\",\"Pwd\":\"123456\",\"ParentTJCode\":\"" + TJCode + "\",\"ManageUserPassportId\":0,\"OtherMsg\":\""+update.Message.From.Username+"\"}";
                        Console.WriteLine(dc);
                        string register_result = HttpHelper.Helper.PostMoths(register_url, dc);
                        MsgInfo info = JsonConvert.DeserializeObject<MsgInfo>(register_result);
                        if (info.code == 200)
                        {
                            TJCode = list.Where(x => x.ULangKey == "STARTCONTENT").FirstOrDefault().ULangValue;
                            csredis.Del($"{chatId.ToString()}TJCode");
                        }
                    }
                }
                Console.WriteLine($"Received a 绑定{trc.success} message in chat {chatId} TJCode:{TJCode}");
            }
            else if (receiveMessage.Contains("/lang"))
            {
                List<ULang> uLangs = db.Queryable<ULang>().ToList();
                List<InlineKeyboardButton> listLang = new List<InlineKeyboardButton>();
                for (int i = 0; i < uLangs.Count; i++)
                {
                    listLang.Add(InlineKeyboardButton.WithCallbackData(uLangs[i].UserLangName, uLangs[i].UserLangCallBack));
                }
                Message message = await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: $"{list.Where(x => x.ULangKey == "XZYY" && x.ULangId == IntLang).FirstOrDefault().ULangValue}:",
                    parseMode: ParseMode.MarkdownV2,
                    disableNotification: true,
                    replyToMessageId: update.Message.MessageId,
                    replyMarkup: new InlineKeyboardMarkup(listLang),
                    cancellationToken: cancellationToken);
            }
            
            if (u_langval != null)
            {
                switch (u_langval.ULangKey)
                {
                    case "TGYJ":
                       await new Watr().GetMeWatr(db, replyKeyboardMarkup, botClient,update,cancellationToken);
                        break;
                    case "LXSX":
                        var SX=  db.Queryable<UserInfo>().Where(x => x.PassportId == SqlFunc.Subqueryable<UserInfo>()
                        .Where(d => d.UserName == update.Message.Chat.Id.ToString()).Select(s => s.ParentId)).Select(x=>x.OtherMsg).First();
                        if (!string.IsNullOrEmpty(SX))
                        {
                            TJCode = TGUrl + SX;
                        }
                        else
                            TJCode = "上级未设置用户名";
                        break;
                    case "DLFY":
                        new Watr().GetReta(db, replyKeyboardMarkup, botClient, update, cancellationToken);
                        break;
                    default:
                        var retnsurlt = list.Where(x => x.IsKeyboard == 0 && x.ULangKey.StartsWith(u_langval.ULangKey)).FirstOrDefault();
                        TJCode = (retnsurlt != null) ? retnsurlt.ULangValue : "Error";
                        break;
                }
              
                Console.WriteLine(messageText+" ddd"+chatId);
            }
            if(!string.IsNullOrEmpty(TJCode))
            await send.SendTextMessageAsync(TJCode.ReplaceMsg(), botClient, update, cancellationToken,replyKeyboardMarkup);

            //单双
            //string DS = (from c in list where c.ULangKey == "DS" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();
            //string DSCONTENT = (from c in list where c.ULangKey == "DSCONTENT" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();
            ////大小
            //string DX = (from c in list where c.ULangKey == "DX" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();
            //string DXCONTENT = (from c in list where c.ULangKey == "DXCONTENT" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();
            ////双尾
            //string SW = (from c in list where c.ULangKey == "SW" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();
            //string SWCONTENT = (from c in list where c.ULangKey == "SWCONTENT" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();
            ////百家乐
            //string BJL = (from c in list where c.ULangKey == "BJL" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();
            //string BJLCONTENT = (from c in list where c.ULangKey == "BJLCONTENT" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();
            ////个人中心
            //string GRZX = (from c in list where c.ULangKey == "GRZX" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();
            ////我的推广
            //string WDTG = (from c in list where c.ULangKey == "WDTG" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();
            //string WDTGCONTENT = (from c in list where c.ULangKey == "WDTGCONTENT" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();
            ////切换成功
            //string QHCG = (from c in list where c.ULangKey == "QHCG" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();
            ////START
            //string STARTCONTENT = (from c in list where c.ULangKey == "STARTCONTENT" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();
            ////BIND
            //string BINDCONTENT = (from c in list where c.ULangKey == "BINDCONTENT" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();
            ////XZYY
            //string XZYY = (from c in list where c.ULangKey == "XZYY" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();

            //string TJCode = "";
            ////Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");
            //if (messageText.Contains(DS))
            //{
            //    messageText = DSCONTENT.ReplaceMsg();
            //    Console.WriteLine($"Received a 单双 message in chat {chatId}.");
            //}

            //else if (messageText.Contains(SW))
            //{
            //    messageText = SWCONTENT.ReplaceMsg();
            //    Console.WriteLine($"Received a 尾数 message in chat {chatId}.");
            //}

            //else if (messageText.Contains(DX))
            //{
            //    messageText = DXCONTENT.ReplaceMsg();
            //    Console.WriteLine($"Received a 大小 message in chat {chatId}.");
            //}

            //else if (messageText.Contains(BJL))
            //{
            //    messageText = BJLCONTENT.ReplaceMsg();
            //    Console.WriteLine($"Received a 庄闲 message in chat {chatId}.");
            //}

            //else
            //if (messageText.Contains("/start"))
            //{
            //    TJCode = messageText.Replace("/start", "").Trim();
            //    if (!csredis.Exists($"{chatId.ToString()}TJCode"))
            //    {
            //        csredis.Set($"{chatId.ToString()}TJCode", TJCode);
            //    }

            //    UserInfo userInfo = db.Queryable<UserInfo>().First(c => c.UserName == chatId.ToString());
            //    if (userInfo == null) //数据库中不存在
            //    {
            //        messageText = STARTCONTENT.ReplaceMsg();
            //    }
            //    else
            //    {
            //       await send.SendTextMessageAsync("可选择快捷操作", botClient, update, cancellationToken);
            //    }
            //    Console.WriteLine($"Received a 注册 message in chat {chatId} TJCode:{TJCode}");
            //}
            //else if (messageText.Length == 34)
            //{
            //    moneyAddress = messageText;
            //    string url = $"{ConfigurationManager.AppSettings["address"].ToString()}{moneyAddress}";
            //    string result = HttpHelper.Helper.GetMoths(url);
            //    TrcResult trc = JsonConvert.DeserializeObject<TrcResult>(result);
            //    if (trc.success.Trim().ToUpper() == "TRUE")
            //    {
            //        UserInfo userInfo = db.Queryable<UserInfo>().First(c => c.UserName == chatId.ToString());
            //        if (userInfo == null) //数据库中不存在
            //        {
            //            TJCode = csredis.Get($"{chatId.ToString()}TJCode");
            //            string register_url = ConfigurationManager.AppSettings["register"].ToString();
            //            dynamic dc = "{\"UserName\":\"" + chatId.ToString() + "\",\"HashAddress\":\"" + messageText + "\",\"Pwd\":\"123456\",\"ParentTJCode\":\"" + TJCode + "\",\"ManageUserPassportId\":0}";
            //            Console.WriteLine(dc);
            //            string register_result = HttpHelper.Helper.PostMoths(register_url, dc);
            //            MsgInfo info = JsonConvert.DeserializeObject<MsgInfo>(register_result);
            //            if (info.code == 200)
            //            {
            //                messageText = BINDCONTENT.ReplaceMsg();
            //                csredis.Del($"{chatId.ToString()}TJCode");
            //            }
            //        }
            //    }
            //    Console.WriteLine($"Received a 绑定{trc.success} message in chat {chatId} TJCode:{TJCode}");
            //}
            //else if (messageText.Contains(WDTG))
            //{
            //    UserInfo userInfo = db.Queryable<UserInfo>().First(c => c.UserName == chatId.ToString());
            //    //            if (userInfo == null) //数据库中不存在
            //    //            {
            //    //                messageText =
            //    //@"
            //    //                        你没有推广，请先注册！
            //    //                        ";
            //    //            }
            //    //            else
            //    if (userInfo != null)
            //    {
            //        var boturl = WDTGCONTENT.ReplaceMsg().Replace("TUIGUANGURL", $"{ConfigurationManager.AppSettings["boturl"].ToString()}{userInfo.TJCode}");
            //        messageText = boturl;
            //    }
            //    Console.WriteLine($"Received a 推广 message in chat {chatId}.");
            //    var ds = db.Queryable<UserInfo>().ToList();
            //}




            //if (receiveMessage.Contains(DS) || receiveMessage.Contains(SW) ||
            //    receiveMessage.Contains(DX) || receiveMessage.Contains(BJL) ||
            //    (receiveMessage.Contains("/start") && messageText.Contains(STARTCONTENT)) ||
            //    (receiveMessage.Length == 34 && messageText.Contains(BINDCONTENT)) ||
            //    receiveMessage.Contains(WDTG)
            //    )
            //{

            //    Message sentMessage = await botClient.SendTextMessageAsync(
            //        chatId: chatId,
            //        text: messageText,
            //        parseMode: ParseMode.MarkdownV2,
            //        replyToMessageId: update.Message.MessageId,
            //        replyMarkup: replyKeyboardMarkup,
            //        cancellationToken: cancellationToken);
            //}
            // if (receiveMessage.Contains("/lang"))
            //{
            //    List<ULang> uLangs = db.Queryable<ULang>().ToList();
            //    List<InlineKeyboardButton> listLang = new List<InlineKeyboardButton>();
            //    for (int i = 0; i < uLangs.Count; i++)
            //    {
            //        listLang.Add(InlineKeyboardButton.WithCallbackData(uLangs[i].UserLangName, uLangs[i].UserLangCallBack));
            //    }
            //    Message message = await botClient.SendTextMessageAsync(
            //        chatId: chatId,
            //        text: $"{XZYY}:",
            //        parseMode: ParseMode.MarkdownV2,
            //        disableNotification: true,
            //        replyToMessageId: update.Message.MessageId,
            //        replyMarkup: new InlineKeyboardMarkup(
            //            listLang
            //            ),
            //        cancellationToken: cancellationToken);
            //}

        }

        public static string ReplaceMsg(this string msg)
        {
            return msg.Replace(".", "\\.").
                    Replace("-", "\\-").
                    Replace("+", "\\+").
                    Replace("(", "\\(").
                    Replace(")", "\\)").
                    Replace("*", "\\*");
        }
    }
}
